using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
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
    public abstract class TesteBase : TesteArquivoOperacoes
    {
        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
            var path = pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            return path;
        }

        protected string ObterArquivoDestino(string nomeArquivo)
        {
            var path = pastaDestino + nomeArquivo;
            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected LinhaTabela ChamarExecucao()
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
                textoCompletoCMD = integracao.ObterTextoCMD();
                integracao.FecharCMD();
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw;
            }

            logger.LogRetornoCMD(textoCompletoCMD);

            return linhaDeValidacao;
        }

        public IList<T> ChamarConsultaAoBanco<T>(Consulta consulta) where T : LinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco);
                var integracao = new IntegracaoCMD();
                integracao.AbrirCMD();

                integracao.ExecutarQuery(tabela.ObterQuery(consulta));
                var resultado = integracao.ObterTextoCMD();
                tabela.ObterRetornoQuery(resultado);

                logger.LogRetornoCMD(resultado);
                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco);

                integracao.FecharCMD();

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
            }
            return tabela.Linhas;
        }

        protected void IniciarTeste(string numeroDoTeste, string nomeDoTeste)
        {
            logger = new MyLogger($"{pastaLog}SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM-yyyy-mmssffff")}.txt");
            logger.EscreverBloco($"Nome do Teste : {nomeDoTeste}");
        }

        protected bool Validar(object esperado, object obtido ,string tituloValidacao)
        {
            logger.InicioOperacao(OperacaoEnum.ValidarResultado);
            logger.EscreveValidacao(obtido.ToString(), esperado.ToString());

            if(esperado == obtido)
                return true;
            return false;
        }
    }
}
