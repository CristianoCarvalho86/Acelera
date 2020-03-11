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
        protected TipoArquivo tipoArquivoTeste;
        protected string numeroDoTeste;
        protected bool sucessoDoTeste;
        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
            var path = pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            return path;
        }

        protected string ObterArquivoDestino(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(tipoArquivoTeste);
            if (AlterarNomeArquivo)
            {
                this.nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if(arquivo.Header.Count > 0)
                    arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);
            }
            else
                this.nomeArquivo = _nomeArquivo;

            var path = pastaDestino + nomeArquivo;

            

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected void ChamarExecucao(string taskName)
        {
            try
            {
                helper.Execute($"START TASK HDIQAS_1.{taskName}");
            }
            catch (Exception ex)
            {
                sucessoDoTeste = false;
                throw ex;
            }
            
        }

        protected DataTable ChamarConsulta(string sql)
        {
            return helper.GetData(sql);
        }

        protected LinhaTabela ChamarExecucaoViaCMD()
        {
            logger.InicioOperacao(OperacaoEnum.Processar,"");
            IntegracaoCMD integracao = new IntegracaoCMD();
            var retorno = string.Empty;
            var textoCompletoCMD = string.Empty;
            LinhaTabela linhaDeValidacao = null;
            try
            {
                integracao.AbrirCMD();
                integracao.ChamarExecucao();
                logger.SucessoDaOperacao(OperacaoEnum.Processar,"");
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

        protected void IniciarTeste(TipoArquivo tipo ,string numeroDoTeste, string nomeDoTeste)
        {
            sucessoDoTeste = true;
            this.numeroDoTeste = numeroDoTeste;
            tipoArquivoTeste = tipo;
            logger = new MyLogger($"{pastaLog}SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM-yyyy-mmssffff")}.txt");
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {nomeDoTeste}");
        }

        protected string[] ErrosEsperados(params string[] erros)
        {
            return erros;
        }

    }
}
