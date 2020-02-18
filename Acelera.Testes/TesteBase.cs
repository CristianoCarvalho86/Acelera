using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Adapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public abstract class TesteBase : TesteItens
    {
        protected string ObterArquivoOrigem(string nomeArquivo, MyLogger logger)
        {
            var path = pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            return path;
        }

        protected string ObterArquivoDestino(string nomeArquivo, MyLogger logger)
        {
            var path = pastaDestino + nomeArquivo;
            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected string ChamarExecucao(MyLogger logger, string queryValidacao)
        {
            logger.InicioOperacao(OperacaoEnum.Processar);
            IntegracaoCMD integracao = new IntegracaoCMD();
            var retorno = string.Empty;
            var textoCompletoCMD = string.Empty;
            try
            {
                integracao.AbrirCMD();
                integracao.ChamarExecucao();
                logger.SucessoDaOperacao(OperacaoEnum.Processar);
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco);
                integracao.ChamarValidacao(queryValidacao);
                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco);
                integracao.FecharCMD();
                textoCompletoCMD = integracao.ObterTextoCMD();
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw;
            }
            finally
            {
                
            }
            logger.LogRetornoCMD(textoCompletoCMD);

            var retornoQuery = ObterRetornoQuery(textoCompletoCMD);

            logger.ResultadoDaConsulta(retornoQuery);

            return retornoQuery;
        }

        private string ObterRetornoQuery(string resultadoCMD)
        {
            var linhas = resultadoCMD.Split(new string[]{ Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var linhaResultado = linhas.Where(x => x.Contains("resultado:") && !x.Contains("CONCAT")).FirstOrDefault();
            int startIndex = linhaResultado.IndexOf("resultado:") + 10;
            return linhaResultado.Substring(startIndex, linhaResultado.IndexOf("\",\"fim") - startIndex);
        }

        protected MyLogger ObterLogger(string numeroDoTeste, string nomeDoTeste)
        {
            var logger = new MyLogger($"{pastaLog}SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM-yyyy-mmssffff")}.txt");
            logger.EscreverBloco($"Nome do Teste : {nomeDoTeste}");
            return logger;
        }

        protected void Validar(string esperado, string obtido , MyLogger logger)
        {
            logger.InicioOperacao(OperacaoEnum.ValidarResultado);
            logger.EscreveValidacao(obtido, esperado);

            if(esperado == obtido)
                logger.TesteSucesso();

            logger.TesteComFalha();
            Assert.Fail();
        }
    }
}
