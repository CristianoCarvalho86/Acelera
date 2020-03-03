using Acelera.Data;
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
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public abstract class TesteBase : TesteArquivoOperacoes
    {
        private DBHelper helper = DBHelper.Instance;
        protected ControleNomeArquivo controleNomeArquivo = ControleNomeArquivo.Instancia;
        private TipoArquivo Tipo;
        private string numeroDoTeste;
        protected bool sucessoDoTeste;
        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
            var path = pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            return path;
        }

        protected string ObterArquivoDestino(string _nomeArquivo)
        {
            this.nomeArquivo = _nomeArquivo.Replace("/*R*/", controleNomeArquivo.ObtemValor(Tipo)).Replace(".txt",".TXT");

            var path = pastaDestino + nomeArquivo;
            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected void ChamarExecucao(string taskName)
        {
            helper.Execute($"START TASK HDIQAS_1.{taskName}");
        }

        protected DataTable ChamarConsulta(string sql)
        {
            return helper.GetData(sql);
        }

        protected LinhaTabela ChamarExecucaoViaCMD()
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

                var resultado = helper.GetData(tabela.ObterQuery(consulta));

                logger.LogRetornoQuery(resultado);

                tabela.ObterRetornoQuery(resultado);

                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco);

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
            }
            return tabela.Linhas;
        }


        public IList<T> ChamarConsultaAoBancoViaCMD<T>(Consulta consulta) where T : LinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco);
                var integracao = new IntegracaoCMD();
                integracao.AbrirCMD();

                integracao.ExecutarQuery(tabela.ObterQueryParaCMD(consulta));
                var resultado = integracao.ObterTextoCMD();
                tabela.ObterRetornoQueryCMD(resultado);

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

        protected void IniciarTeste(TipoArquivo tipo ,string numeroDoTeste, string nomeDoTeste)
        {
            sucessoDoTeste = true;
            this.numeroDoTeste = numeroDoTeste;
            Tipo = tipo;
            logger = new MyLogger($"{pastaLog}SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM-yyyy-mmssffff")}.txt");
            logger.EscreverBloco($"Nome do Teste : {nomeDoTeste}");
        }

        protected string[] ErrosEsperados(params string[] erros)
        {
            return erros;
        }

        [TestCleanup]
        public void FimDoTeste()
        {
            var sucesso = sucessoDoTeste ? "SUCESSO" : "FALHA";
            var nomeArquivoDeLog = nomeArquivo.Replace(".TXT", $"-Teste-{numeroDoTeste}-{sucesso}-Data-{DateTime.Now.ToString("ddMMYY_hhmm")}.TXT");
            File.Copy(pastaDestino + nomeArquivo, pastaLogArquivo + nomeArquivoDeLog);
            if (File.Exists(pastaLogArquivo + nomeArquivoDeLog))
                File.Delete(pastaDestino + nomeArquivo);
            else
                logger.EscreverBloco("Erro ao copiar arquivo para pasta de log.");

            logger.EscreverBloco("Nome do arquivo de log criado : " + pastaLogArquivo + nomeArquivoDeLog);
            logger.FimDoArquivo();
        }

    }
}
