using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.RegrasNegocio;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Acelera.Specflow.Steps
{
    public abstract class BaseSteps
    {
        protected ExecucaoFgsRegras execucaoRegras;
        protected ArquivoRegras arquivoRegras;
        protected ContratoRegras contratoRegras;
        protected EmissaoRegras emissaoRegras;
        protected readonly ScenarioContext _scenarioContext;

        public abstract string nomeFg { get; }
        public string numeroDoTeste
        {
            get
            {
                _scenarioContext.TryGetValue<string>("numeroDoTeste", out string _msgTabelaDeRetorno);
                return _msgTabelaDeRetorno;
            }
            set
            {
                _scenarioContext["numeroDoTeste"] = value;
            }
        }

        protected IList<string> arquivosSalvos
        {
            get
            {
                IList<string> lista;
                _scenarioContext.TryGetValue<IList<string>>("arquivosSalvos", out lista);
                return lista;
            }
            set
            {
                if (_scenarioContext.ContainsKey("arquivosSalvos"))
                    _scenarioContext.Remove("arquivosSalvos");
                _scenarioContext.Add("arquivosSalvos", value);
            }
        }

        private IMyLogger _logger;
        protected IMyLogger logger
        {
            get
            {
                _scenarioContext.TryGetValue<IMyLogger>("logger", out _logger);
                return _logger;
            }
            set
            {
                if (_scenarioContext.ContainsKey("logger"))
                    _scenarioContext.Remove("logger");
                _scenarioContext.Add("logger", value);
            }
        }

        private bool _sucessoDoTeste;
        protected bool sucessoDoTeste
        {
            get
            {
                _scenarioContext.TryGetValue<bool>("sucessoDoTeste", out _sucessoDoTeste);
                return _sucessoDoTeste;
            }
            set
            {
                if (!value)
                {
                    _scenarioContext.Remove("sucessoDoTeste");
                    _scenarioContext.Add("sucessoDoTeste", false);
                }
            }
        }

        protected FGs executarAteFg
        {
            get
            {
                _scenarioContext.TryGetValue<FGs>("executarAteFg", out FGs _executarAteFg);
                return _executarAteFg;
            }
            set
            {
                    _scenarioContext["executarAteFg"] = value;
            }
        }

        protected CodigoStage codigoStageEsperado
        {
            get
            {
                _scenarioContext.TryGetValue<CodigoStage>("codigoStageEsperado", out CodigoStage _codigoStageEsperado);
                return _codigoStageEsperado;
            }
            set
            {
                _scenarioContext["codigoStageEsperado"] = value;
            }
        }

        protected string msgTabelaDeRetornoEsperada
        {
            get
            {
                _scenarioContext.TryGetValue<string>("msgTabelaDeRetornoEsperada", out string _msgTabelaDeRetorno);
                return _msgTabelaDeRetorno;
            }
            set
            {
                _scenarioContext["msgTabelaDeRetornoEsperada"] = value;
            }
        }

        public BaseSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            _scenarioContext.Add("sucessoDoTeste", true);
            arquivosSalvos = new List<string>();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);
            logger.DefinirSucesso(sucessoDoTeste);
            
            CopiaArquivos();

            logger.FimDoArquivo(ArquivoUtils.ObterNumeroDoLote(arquivo.NomeArquivo), arquivo.Operadora.ObterTexto(), null, Parametros.ModoExecucao);

            if (!sucessoDoTeste)
                throw new Exception();
        }

        protected void CriarLog(string operacao)
        {
            numeroDoTeste = _scenarioContext.ScenarioInfo.Title.Trim().Remove(0, 4).Remove(4);
            var nomeArquivo = $"SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM")}-{operacao ?? "OPERACAO"}-{"NLOTE"}.txt";
            //if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
            //    logger = new Mock<IMyLogger>().Object;
            //else
            logger = new MyLogger($"{Parametros.pastaLog}", nomeArquivo, Parametros.logStackTrace, Parametros.logDataBaseResults);
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {_scenarioContext.ScenarioInfo.Title.Trim()}");
        }

        protected void CarregaRegras()
        {
            execucaoRegras = new ExecucaoFgsRegras(logger);
            arquivoRegras = new ArquivoRegras(logger);
            contratoRegras = new ContratoRegras(logger);
            emissaoRegras = new EmissaoRegras(logger);
        }

        protected virtual void SalvarArquivo(IArquivo _arquivo)
        {
            var array = _arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            SalvarArquivo(array.ToList().ObterListaConcatenada("-"),  _arquivo);
        }


        protected void SalvarArquivo(string _nomeArquivo, IArquivo _arquivo)
        {
            if (!_nomeArquivo.Contains("/*R*/"))
            {
                //nomeArquivo = _nomeArquivo.Replace("-","_") + "_" + nomeArquivo;// inclusao do nome da proc
                SalvarArquivo(_arquivo);
                return;
            }

            string numeroDoLote = "";
            var nomeOriginalArquivo = _arquivo.NomeArquivo;

            //_nomeArquivo = nomeDoTeste.Replace("-", "_") + _nomeArquivo;
            FinalizarAlteracaoArquivo(_arquivo);
            var enderecoArquivoSalvo = string.Empty;
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
            {
                enderecoArquivoSalvo = arquivoRegras.ObterArquivoDestino(_arquivo, _nomeArquivo, true, out numeroDoLote);
                _arquivo.Salvar(enderecoArquivoSalvo);
            }

            _arquivo.valoresAlteradosBody.FinalizarAlteracaoArquivo(nomeOriginalArquivo, _arquivo.NomeArquivo);
            arquivosSalvos.Add(enderecoArquivoSalvo);
        }

        protected virtual void FinalizarAlteracaoArquivo(IArquivo arquivo)
        {
            if(executarAteFg >= FGs.FG02)
                arquivoRegras.AjusteIdTransacao(arquivo);
        }

        private void CopiaArquivos()
        {
            if (arquivosSalvos != null && arquivosSalvos.Count > 0)
                foreach (var arqSalvo in arquivosSalvos)
                {
                    if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                    {
                        var nomeArquivoDeLog = arqSalvo.Split('\\').Last().ToUpper().Replace(".TXT", $"-Teste-{numeroDoTeste}-{nomeFg}-{sucessoDoTeste}-Data-{DateTime.Now.ToString("ddMMyy_hhmm")}.TXT");
                        var prefixo = "";


                        File.Copy(arqSalvo, Parametros.pastaLogArquivo + prefixo + nomeArquivoDeLog);
                        logger.EscreverBloco("Nome do arquivo de log criado : " + Parametros.pastaLogArquivo + nomeArquivoDeLog);
                        if (File.Exists(Parametros.pastaLogArquivo + nomeArquivoDeLog))
                        {
                            File.Delete(arqSalvo);
                            logger.EscreverBloco("Arquivo deletado : " + arqSalvo);
                        }
                    }
                }
        }
    }
}
