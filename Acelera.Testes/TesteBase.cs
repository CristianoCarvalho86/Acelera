using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
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
        public abstract LinhaTabela LinhaDeValidacao {get;}
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

        protected LinhaTabela ChamarExecucao(MyLogger logger)
        {
            logger.InicioOperacao(OperacaoEnum.Processar);
            IntegracaoCMD integracao = new IntegracaoCMD();
            var retorno = string.Empty;
            var textoCompletoCMD = string.Empty;
            LinhaTabela linhaDeValidacao = null;
            try
            {
                integracao.AbrirCMD();
                integracao.ChamarExecucao();
                logger.SucessoDaOperacao(OperacaoEnum.Processar);
                integracao.FecharCMD();
                textoCompletoCMD = integracao.ObterTextoCMD();
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw;
            }

            logger.LogRetornoCMD(textoCompletoCMD);

            var retornoQuery = ObterRetornoQuery(textoCompletoCMD, linhaDeValidacao);

            logger.ResultadoDaConsulta(retornoQuery);

            return linhaDeValidacao;
        }

        public LinhaTabela ChamarValidacaoLogProcessamento(Arquivo arquivo, MyLogger logger)
        {
            logger.InicioOperacao(OperacaoEnum.ConsultaBanco);
            var integracao = new IntegracaoCMD();
            integracao.AbrirCMD();
            var linhaValidacao = new LogProcessamento().ObterQuery();
            integracao.ExecutarQuery(linhaValidacao.ObterQuery());
            logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco);
            return linhaValidacao;
        }


        private string ObterRetornoQuery(string resultadoCMD, LinhaTabela linhaTabela)
        {
            var linhas = resultadoCMD.Split(new string[]{ Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
            var linhaResultado = linhas.Where(x => x.Contains(linhaTabela.Campos[0].Coluna) && !x.Contains("CONCAT")).FirstOrDefault();
            linhaTabela.CarregarLinha(linhaResultado);
            return linhaResultado;
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
