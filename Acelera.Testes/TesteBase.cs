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
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        protected string numeroDoLote;
        protected string operacao;
        protected string nomeDoTeste;
        protected string localDoErro = string.Empty;
        protected string pathOrigem;
        protected string nomeArquivo = string.Empty;


        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            this.nomeArquivo = nomeArquivo;
            var path = Parametros.pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            pathOrigem = path;
            return path;
        }

        private void CriarLog()
        {
            var nomeArquivo = $"SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM")}-{operacao ?? "OPERACAO"}-{tipoArquivoTeste.ObterTexto()}-{numeroDoLote ?? "NLOTE"}.txt";
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                logger = new Mock<IMyLogger>().Object;
            else
                logger = new MyLogger($"{Parametros.pastaLog}", nomeArquivo);
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {nomeDoTeste}");
        }

        protected void SalvarArquivo(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                arquivo.Salvar(ObterArquivoDestino(_nomeArquivo, AlterarNomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                arquivo.Salvar(ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasValidacao)
                ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo);
        }

        protected string ObterArquivoDestino(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(tipoArquivoTeste);
            numeroDoLote = numeroArquivoNovo;
            if (AlterarNomeArquivo)
            {
                this.nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if(arquivo.Header.Count > 0)
                    arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);
            }
            else
                this.nomeArquivo = _nomeArquivo;

            var path = Parametros.pastaDestino + nomeArquivo;

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected string ObterArquivoDestinoApenasCriacaoOuValidacao(string _nomeArquivo)
        {
           this.nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroDoTeste).Replace(".txt", ".TXT");

           if (!string.IsNullOrEmpty(_nomeArquivo))
           {
               var dataArquivo = nomeArquivo.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
                nomeArquivo = nomeArquivo.Replace(dataArquivo[3],(Parametros.dataArquivoParametro + ".TXT"));
           }

           if (arquivo.Header.Count > 0)
               arquivo.AlterarHeader("NR_ARQ", numeroDoTeste);

            numeroDoLote = numeroDoTeste;

            var path = Parametros.pastaDestino + nomeArquivo;


            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected void ChamarExecucao(string taskName)
        {
            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
                return;
            try
            {
                Thread.Sleep(15000);
                var comando = $"START TASK {Parametros.instanciaDB}.{taskName}";
                logger.EscreverBloco($"EXECUTANDO TAREFA : '{taskName}'");
                var retorno = helper.Execute(comando);
                logger.EscreverBloco($"RESULTADO DA TAREFA : '{retorno}'");
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
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
            this.nomeDoTeste = nomeDoTeste;
            tipoArquivoTeste = tipo;
            CriarLog();
        }

        protected string[] ErrosEsperados(params string[] erros)
        {
            return erros;
        }

    }
}
