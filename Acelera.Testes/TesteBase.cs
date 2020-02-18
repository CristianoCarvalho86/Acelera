using Acelera.Domain.Enums;
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
            try
            {
                integracao.AbrirCMD();
                integracao.ChamarExecucao();
                logger.SucessoDaOperacao(OperacaoEnum.Processar);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado);
                logger.LogRetornoCMD(integracao.ObterTextoCMD());
                //integracao.ChamarValidacao(queryValidacao);
                retorno = integracao.ObterTextoCMD();
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw;
            }
            finally
            {
                integracao.FecharCMD();
            }
            integracao.FecharCMD();
            return retorno;
        }

        protected MyLogger ObterLogger(string numeroDoTeste)
        {
            return new MyLogger($"{pastaLog}SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM-yyyy-mmssffff")}.txt");
        }

        protected void Validar(string esperado, string obtido)
        {
            throw new NotImplementedException();
            Assert.IsTrue(esperado == obtido);
        }
    }
}
