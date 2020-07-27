using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Testes.Validadores.FG02;
using Acelera.Utils;
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
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", arquivo.NomeArquivo);
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

        public abstract void ValidarTabelaDeRetorno(Arquivo arquivo,bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);

        public virtual IList<ILinhaTabela> ValidarStages(Arquivo _arquivo ,bool deveHaverRegistro, int codigoEsperado = 0, bool aoMenosUmCodigoEsperado = false)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return null;

            var linhasEncontradas = new List<ILinhaTabela>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                var validador = new ValidadorStages(_arquivo.tipoArquivo.ObterTabelaStageEnum(), _arquivo.NomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);


                if (validador.ValidarTabela(deveHaverRegistro, out linhasEncontradas, codigoEsperado, aoMenosUmCodigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception ex)
            {
                TratarErro($" Validação da Stage : {arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()} - {ex.Message}");
            }

            if (sucessoDoTeste == false)
                ExplodeFalha();

            return linhasEncontradas;
        }

        public void ExecutarEValidarFG01_2(Arquivo arquivo)
        {
            logger.EscreverBloco("Inicio da Validação da FG01_2.");
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ValidarStages(CodigoStage.AprovadoNaFG01_2,false, arquivo);
            ValidarTabelaDeRetorno(arquivo,false);
            logger.EscreverBloco("Fim da Validação da FG01_2. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
        }

        public void EnviarParaOds(Arquivo arquivo, bool alterarCdCliente = true, string nomeProc = "")
        {
            if (alterarCdCliente && operadora != OperadoraEnum.SGS)
            {
                //TODO LEMBRAR DE ALTERAR CD_CLIENTE POR UM DA LISTA
                int i = 0;
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(operadora));
            }

            SalvarArquivo();

            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());

            var linhas = ValidarStages(CodigoStage.AprovadoNaFG01);

            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11", "9", "12", "13", "21" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcAutoCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);

                    }
                    else
                    {
                        ODSInsertParcAuto.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertParcCobertura.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, TabelasEnum.ParcEmissaoAuto, logger);
                    }
                }
            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
                foreach (var linha in linhas)
                {
                    if (new string[] { "10", "11" }.Contains(linha.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                    {
                        ODSInsertParcCancelamento.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSUpdateParcCancelamento.Update(logger);

                    }
                    else
                    {
                        ODSInsertParcData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
                        ODSInsertParcCobertura.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, TabelasEnum.ParcEmissao, logger);
                    } // se não for cancelamento
                }
            else if (arquivo.tipoArquivo == TipoArquivo.Cliente)
                foreach (var linha in linhas)
                    ODSInsertClienteData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);

            else if (arquivo.tipoArquivo == TipoArquivo.Comissao)
                foreach (var linha in linhas)
                    ODSInsertComissaoData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
        }


        public IList<ILinhaTabela> ValidarStages(CodigoStage codigo, bool aoMenosUmComCodigoEsperado = false, Arquivo arquivo = null)
        {
            arquivo = arquivo == null ? this.arquivo : arquivo;
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            var linhas = ValidarStages(arquivo,true, (int)codigo);
            AoMenosUmComCodigoEsperado = false;
            return linhas;
        }


        protected void AjustarEntradaErros(ref string[] erros)
        {
            if (erros == null || (erros.Length == 1 && erros.Contains(string.Empty)))
                erros = new string[] { };

        }

        protected void ExplodeFalha(string descricao = null)
        {
            if(!string.IsNullOrEmpty(descricao))
                logger.Erro(descricao);
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
                nomeArquivoDeLog = arquivo.NomeArquivo.ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{NomeFG}-{sucesso}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");


            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                File.Copy(Parametros.pastaDestino + arquivo.NomeArquivo, Parametros.pastaLogArquivo + nomeArquivoDeLog);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && !string.IsNullOrEmpty(Parametros.pastaLogArquivoCopia))
                File.Copy(pathOrigem, Parametros.pastaLogArquivoCopia + nomeArquivoDeLog);

            //if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo && File.Exists(Parametros.pastaLogArquivo + nomeArquivoDeLog))
            //    File.Delete(Parametros.pastaDestino + arquivo.NomeArquivo);

            else if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Erro ao copiar arquivo para pasta de log.");

            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                logger.EscreverBloco("Nome do arquivo de log criado : " + Parametros.pastaLogArquivo + nomeArquivoDeLog);


            operacao = arquivo.NomeArquivo.Split('.').Take(2).Reverse().First().Replace(".", "");
            if (operacao.Length > 5)
                operacao = operacao.Substring(0, 5);


            logger.FimDoArquivo(numeroDoLote, operacao, Parametros.pastaLogCopia, Parametros.ModoExecucao);
        }
    }
}
