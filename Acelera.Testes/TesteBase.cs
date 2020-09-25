using Acelera.Contratos;
using Acelera.Data;
using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.RegrasNegocio;
using Acelera.Testes.Adapters;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Testes.Validadores.FG05;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
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
        private DBHelperHana helper = DBHelperHana.Instance;

        protected string numeroDoTeste;
        protected bool sucessoDoTeste;
        protected string numeroDoLote;
        protected string operacao;
        protected string nomeDoTeste;
        protected string localDoErro = string.Empty;
        protected string pathOrigem;
        protected bool AoMenosUmComCodigoEsperado = false;
        protected List<string> arquivosSalvos;
        protected List<string> arquivosSalvosODS;
        string idTeste = string.Empty;

        protected abstract IList<string> ObterProceduresASeremExecutadas(IArquivo _arquivo);
        protected TipoArquivo tipoArquivoTeste { get; set; }

        protected OperadoraEnum operacaoDoTeste { get; set; }

        public TesteBase()
        {
            arquivosSalvos = new List<string>();
            arquivosSalvosODS = new List<string>();
            idTeste = RandomNumber.GerarNumeroAleatorio(8);
        }

        protected string ObterArquivoOrigem(string nomeArquivo)
        {
            var path = Parametros.pastaOrigem + nomeArquivo;
            logger.EscreverBloco("Obtendo arquivo origem : " + path);
            pathOrigem = path;
            return path;
        }

        private void CriarLog()
        {
            var nomeArquivo = $"SAP-SP1-{numeroDoTeste}-{idTeste}-{DateTime.Now.ToString("dd-MM")}-{operacao ?? "OPERACAO"}-{numeroDoLote ?? "NLOTE"}.txt";
            //if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
            //    logger = new Mock<IMyLogger>().Object;
            //else
            logger = new MyLogger($"{Parametros.pastaLog}", nomeArquivo,Parametros.logStackTrace,Parametros.logDataBaseResults);
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {nomeDoTeste}");
        }

        protected virtual void SalvarArquivo()
        {
            var array = arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            var nomeArquivo = array.ToList().ObterListaConcatenada("-");
            SalvarArquivo(nomeArquivo, true);
        }

        protected virtual void SalvarArquivo(IArquivo _arquivo = null)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
            var array = _arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            SalvarArquivo(array.ToList().ObterListaConcatenada("-"), true, _arquivo);
        }


        protected void SalvarArquivo(string _nomeArquivo, bool AlterarNomeArquivo = true, IArquivo _arquivo = null)
        {
            if (!_nomeArquivo.Contains("/*R*/"))
            {
                //nomeArquivo = _nomeArquivo.Replace("-","_") + "_" + nomeArquivo;// inclusao do nome da proc
                if (_arquivo == null)
                    SalvarArquivo();
                else
                    SalvarArquivo(_arquivo);
                return;
            }

            _arquivo = _arquivo != null ? _arquivo : this.arquivo;
            var nomeOriginalArquivo = _arquivo.NomeArquivo;

            //_nomeArquivo = nomeDoTeste.Replace("-", "_") + _nomeArquivo;
            FinalizarAlteracaoArquivo(_arquivo);
            var enderecoArquivoSalvo = string.Empty;
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
            {
                enderecoArquivoSalvo = ObterArquivoDestino(_arquivo, _nomeArquivo, AlterarNomeArquivo);
                _arquivo.Salvar(enderecoArquivoSalvo);
            }
                
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
            {
                enderecoArquivoSalvo = ObterArquivoDestinoApenasCriacaoOuValidacao(_arquivo,_nomeArquivo);
                _arquivo.Salvar(enderecoArquivoSalvo);
            }
                
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasValidacao)
            {
                enderecoArquivoSalvo =ObterArquivoDestinoApenasCriacaoOuValidacao(_arquivo,_nomeArquivo);
            }
                

            _arquivo.valoresAlteradosBody.FinalizarAlteracaoArquivo(nomeOriginalArquivo, _arquivo.NomeArquivo);
            arquivosSalvos.Add(enderecoArquivoSalvo);
        }

        protected void LimparValidacao(IArquivo _arquivo = null)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
            _arquivo.valoresAlteradosBody = new AlteracoesArquivo();
            _arquivo.valoresAlteradosHeader = new AlteracoesArquivo();
            _arquivo.valoresAlteradosFooter = new AlteracoesArquivo();
        }

        protected void CarregarArquivo(IArquivo arquivo, int qtdLinhas, OperadoraEnum operadora)
        {
            ArquivoUtils.CarregarArquivo(arquivo, qtdLinhas, operadora, logger);
            operacaoDoTeste = operadora;
        }

        protected virtual void SalvarArquivo(bool alterarCdCliente, string nomeProc = "")
        {
            throw new NotImplementedException();
        }

        protected string ObterArquivoDestino(IArquivo _arquivo, string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            return arquivoRegras.ObterArquivoDestino(_arquivo,_nomeArquivo,AlterarNomeArquivo,out numeroDoLote);
        }

        protected string ObterArquivoDestinoApenasCriacaoOuValidacao(IArquivo _arquivo, string _nomeArquivo)
        {

            return arquivoRegras.ObterArquivoDestinoApenasCriacaoOuValidacao(_arquivo, _nomeArquivo, out numeroDoLote);
            //this.nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroDoTeste).Replace(".txt", ".TXT");

            //if (!string.IsNullOrEmpty(_nomeArquivo))
            //{
            //    var dataArquivo = nomeArquivo.Split(new string[] { "-" }, StringSplitOptions.RemoveEmptyEntries);
            //     nomeArquivo = nomeArquivo.Replace(dataArquivo[3],(Parametros.dataArquivoParametro + ".TXT"));
            //}

            //if (arquivo.Header.Count > 0)
            //    arquivo.AlterarHeader("NR_ARQ", numeroDoTeste);

            // numeroDoLote = numeroDoTeste;

            // var path = Parametros.pastaDestino + nomeArquivo;


            // logger.EscreverBloco("Salvando arquivo modificado : " + path);
            // return path;


        }

        protected void ChamarExecucaoSemErro(string taskName)
        {
            try
            {
                ChamarExecucao(taskName);
            }
            catch (Exception)
            {
                localDoErro += taskName + ";";
            }
        }

        protected void ChamarExecucao(string taskName)
        {
            if (!DataAccess.ChamarExecucaoHana(taskName, logger))
                sucessoDoTeste = false;
        }

        //protected LinhaTabela ChamarExecucaoViaCMD()
        //{
        //    logger.InicioOperacao(OperacaoEnum.Processar, "");
        //    IntegracaoCMD integracao = new IntegracaoCMD();
        //    var retorno = string.Empty;
        //    var textoCompletoCMD = string.Empty;
        //    LinhaTabela linhaDeValidacao = null;
        //    try
        //    {
        //        integracao.AbrirCMD();
        //        integracao.ChamarExecucao();
        //        logger.SucessoDaOperacao(OperacaoEnum.Processar, "");
        //        textoCompletoCMD = integracao.ObterTextoCMD();
        //        integracao.FecharCMD();
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.Erro(ex);
        //        throw ex;
        //    }

        //    logger.LogRetornoCMD(textoCompletoCMD);

        //    return linhaDeValidacao;
        //}

        protected virtual void IniciarTeste(TipoArquivo tipo, string numeroDoTeste = "", string nomeDoTeste = "")
        {
            StackTrace stackTrace = new StackTrace();
            sucessoDoTeste = true;
            for (int i = 1; i < 11; i++)
            {
                this.numeroDoTeste = stackTrace.GetFrame(i).GetMethod().Name.Remove(0, 4).Substring(0, 4);
                if (int.TryParse(this.numeroDoTeste, out int r))
                    break;
                if (i == 10)
                    throw new Exception("NUMERO DO TESTE NAO ESPECIFICADO NO TITULO DO TESTE.");
            }


            this.nomeDoTeste = nomeDoTeste;
            tipoArquivoTeste = tipo;
            CriarLog();
            dados = new DadosParametrosData(logger);
            comissaoRegras = new ComissaoRegras(logger);
            cancelamentoRegras = new CancelamentoRegras(logger);
            emissaoRegras = new EmissaoRegras(logger);
            arquivoRegras = new ArquivoRegras(logger);
            contratoRegras = new ContratoRegras(logger);
            execucaoRegras = new ExecucaoFgsRegras(logger);
        }


        protected string[] ErrosEsperados(params string[] erros)
        {
            return erros;
        }

    }
}
