﻿using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Validadores.FG02;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Acelera.Testes
{
    public abstract class TesteFG : TesteBase
    {
        protected abstract string NomeFG { get; }

        protected abstract IList<string> ObterProceduresASeremExecutadas();

        public void ValidarLogProcessamento(bool Sucesso, int vezesExecutado = 1)
        {
            ValidarLogProcessamento(Sucesso, vezesExecutado, ObterProceduresASeremExecutadas());
        }

        protected void ValidarLogProcessamento(bool Sucesso, int vezesExecutado, IList<string> proceduresASeremExecutadas)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            var proceduresEsperadas = proceduresASeremExecutadas;

            if (operadora != OperadoraEnum.LASA && operadora != OperadoraEnum.SOFTBOX)
            {
                proceduresEsperadas = proceduresEsperadas.Where(x => x.ObterValorInteiro() < 1000 || x.ObterValorInteiro() == 200000).ToList();
            }

            try
            {
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
                var consultas = new ConjuntoConsultas();
                consultas.AdicionarConsulta(consulta);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaLogProcessamento>(consultas, logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

                var falha = false;
                if (!Validar(lista.Count(), proceduresEsperadas.Count * vezesExecutado, "Quantidade de Procedures executadas"))
                    falha = true;
                if (!falha && !Validar((lista.All(x => x.ObterPorColuna("CD_STATUS").Valor == "S")), true, "Todos os CD_STATUS sao igual a 'S'"))
                    falha = true;



                var procedureNaoEncontrada = proceduresEsperadas.Where(x => !lista.Any(z => z.ObterPorColuna("CD_PROCEDURE").Valor.Contains(x))); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Validar(procedureNaoEncontrada.Count() > 0, false, $"Existem PROCEDURES NAO ENCONTRADAS : {procedureNaoEncontrada.ToList().ObterListaConcatenada(" ,")}"))
                    falha = true;

                var proceduresAMais = lista.Where(x => !proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z))).ToList(); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Validar(proceduresAMais.Count() > 0, false, $"Existem PROCEDURES EXECUTADAS A MAIS : {proceduresAMais.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ObterListaConcatenada(" ,")}"))
                    falha = true;

                if (Sucesso && falha || !Sucesso && !falha)
                {
                    ExplodeFalha();
                }
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
            }
            catch (Exception ex)
            {
                TratarErro("Validação da LogProcessamento");
            }
        }

        public abstract void ValidarTabelaDeRetorno(bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);
        public virtual void ValidarTabelaDeRetorno(bool naoDeveEncontrar = false , params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetorno(naoDeveEncontrar, false, codigosDeErroEsperados);
        }

        public virtual void ValidarStages(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{tabela.ObterTexto()}");
                var validador = new ValidadorStages(tipoArquivoTeste.ObterTabelaStageEnum(), nomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

                var linhasEncontradas = new List<ILinhaTabela>();
                if (validador.ValidarTabela(deveHaverRegistro, out linhasEncontradas, codigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{tabela.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($" Validação da Stage : {tabela.ObterTexto()}");
            }

            if (sucessoDoTeste == false)
                ExplodeFalha();
        }


        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros.Length == 1 && erros.Contains(string.Empty))
                erros = new string[] { };

        }

        protected void ExplodeFalha()
        {
            sucessoDoTeste = false;
            logger.TesteComFalha();
            Assert.Fail();
        }

        protected bool Validar(bool obtido, bool esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        protected bool Validar(int obtido, int esperado, string tituloValidacao)
        {
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString(), tituloValidacao);

            if (esperado == obtido)
                return true;
            return false;
        }

        protected void ValidarTeste()
        {
            if (!sucessoDoTeste)
                throw new Exception("Exceção encontrada no fim do teste : " + localDoErro);
        }

        protected void TratarErro(string erro)
        {
            logger.EscreverBloco("Houve um erro no teste -> " + erro);
            sucessoDoTeste = false;
            localDoErro += erro + ";";
        }

        [TestCleanup]
        public virtual void FimDoTeste()
        {
            logger.DefinirSucesso(sucessoDoTeste);
            var sucesso = sucessoDoTeste ? "SUCESSO" : "FALHA";
            logger.EscreverBloco($"RESULTADO DO TESTE {NomeFG} : {sucesso}");
            var nomeArquivoDeLog = string.Empty;
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                nomeArquivoDeLog = nomeArquivo.ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{NomeFG}-{sucesso}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                File.Copy(Parametros.pastaDestino + nomeArquivo, Parametros.pastaLogArquivo + nomeArquivoDeLog);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && !string.IsNullOrEmpty(Parametros.pastaLogArquivoCopia))
                File.Copy(pathOrigem, Parametros.pastaLogArquivoCopia + nomeArquivoDeLog);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && File.Exists(Parametros.pastaLogArquivo + nomeArquivoDeLog))
                File.Delete(Parametros.pastaDestino + nomeArquivo);
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Erro ao copiar arquivo para pasta de log.");

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Nome do arquivo de log criado : " + Parametros.pastaLogArquivo + nomeArquivoDeLog);


            operacao = nomeArquivo.Split('.').Take(2).Reverse().First().Replace(".", "");
            if (operacao.Length > 5)
                operacao = operacao.Substring(0, 5);


            logger.FimDoArquivo(numeroDoLote, operacao, Parametros.pastaLogCopia, Parametros.ModoExecucao);
        }
    }
}
