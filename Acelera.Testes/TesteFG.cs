using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Validadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            if (ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaLogProcessamento>(consulta, logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

                var falha = false;
                if (!Validar(lista.Count, proceduresASeremExecutadas.Count * vezesExecutado, "Quantidade de Procedures executadas"))
                    falha = true;
                if (!falha && !Validar((lista.All(x => x.ObterPorColuna("CD_STATUS").Valor == "S")), true, "Todos os CD_STATUS sao igual a 'S'"))
                    falha = true;

                var proceduresEsperadas = proceduresASeremExecutadas;
                var procedureNaoEncontrada = proceduresEsperadas.Where(x => !lista.Any(z => z.ObterPorColuna("CD_PROCEDURE").Valor.Contains(x))); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Validar(procedureNaoEncontrada.Count() > 0, false, $"Existem PROCEDURES NAO ENCONTRADAS : {procedureNaoEncontrada.ToList().ObterListaConcatenada(" ,")}"))
                    falha = true;

                if (Sucesso && falha || !Sucesso && !falha)
                {
                    ExplodeFalha();
                }
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
            }
            catch(Exception ex)
            {
                TratarErro("Validação da LogProcessamento");
            }
        }

        public abstract void ValidarTabelaDeRetorno(bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados);
        public virtual void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetorno(false, codigosDeErroEsperados);
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
        public void FimDoTeste()
        {
            logger.DefinirSucesso(sucessoDoTeste);
            var sucesso = sucessoDoTeste ? "SUCESSO" : "FALHA";
            logger.EscreverBloco($"RESULTADO DO TESTE {NomeFG} : {sucesso}");
            var nomeArquivoDeLog = nomeArquivo.ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{NomeFG}-{sucesso}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");
            File.Copy(pastaDestino + nomeArquivo, pastaLogArquivo + nomeArquivoDeLog);

            if(!string.IsNullOrEmpty(pastaLogArquivoCopia))
                File.Copy(pathOrigem, pastaLogArquivoCopia + nomeArquivoDeLog);

            if (File.Exists(pastaLogArquivo + nomeArquivoDeLog))
                File.Delete(pastaDestino + nomeArquivo);
            else
                logger.EscreverBloco("Erro ao copiar arquivo para pasta de log.");

            logger.EscreverBloco("Nome do arquivo de log criado : " + pastaLogArquivo + nomeArquivoDeLog);

            operacao = nomeArquivo.Split('.').Take(2).Reverse().First().Replace(".", "");
            if (operacao.Length > 5)
                operacao = operacao.Substring(0, 5);

            logger.FimDoArquivo(numeroDoLote, operacao, pastaLogCopia);
        }
    }
}
