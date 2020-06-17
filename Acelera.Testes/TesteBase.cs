using Acelera.Data;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Logger;
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
        protected ControleNomeArquivo controleNomeArquivo = ControleNomeArquivo.Instancia;
        protected string numeroDoTeste;
        protected bool sucessoDoTeste;
        protected string numeroDoLote;
        protected string operacao;
        protected string nomeDoTeste;
        protected string localDoErro = string.Empty;
        protected string pathOrigem;
        protected string nomeArquivo = string.Empty;
        protected TipoArquivo tipoArquivoTeste { get; set; }
        protected OperadoraEnum operadora => EnumUtils.ObterOperadoraDoArquivo(arquivo.NomeArquivo);

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
            //if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
            //    logger = new Mock<IMyLogger>().Object;
            //else
            logger = new MyLogger($"{Parametros.pastaLog}", nomeArquivo);
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {nomeDoTeste}");

        }

        protected virtual void SalvarArquivo()
        {
            var array = arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            nomeArquivo = array.ToList().ObterListaConcatenada("-");
            SalvarArquivo(nomeArquivo, true);
        }

        protected virtual void SalvarArquivo(Arquivo arquivo)
        {
            var array = arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            SalvarArquivo(array.ToList().ObterListaConcatenada("-"), true);
        }


        protected void SalvarArquivo(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            var nomeOriginalArquivo = arquivo.NomeArquivo;
            if (!_nomeArquivo.Contains("/*R*/"))
            {
                //nomeArquivo = _nomeArquivo.Replace("-","_") + "_" + nomeArquivo;// inclusao do nome da proc
                SalvarArquivo();
                return;
            }

            FinalizarAlteracaoArquivo();
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                arquivo.Salvar(ObterArquivoDestino(_nomeArquivo, AlterarNomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                arquivo.Salvar(ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasValidacao)
                ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo);

            valoresAlteradosBody.FinalizarAlteracaoArquivo(nomeOriginalArquivo, this.nomeArquivo);
        }

        public virtual void EnviarParaOds(Arquivo arquivo, bool alterarCdCliente = true, string nomeProc = "")
        {
            //if(arquivo.tipoArquivo == TipoArquivo.Cliente)
            //{
            //    SalvarArquivo();
            //    ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());
            //    ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());
            //    ODSInsertClienteData.Insert(arquivo.NomeArquivo, logger);
            //}
            //else if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
            //{
            //    SalvarArquivo();
            //    ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            //    ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            //    ODSInsertParcData.Insert(arquivo.NomeArquivo, logger);
            //}
            //else if (arquivo.tipoArquivo == TipoArquivo.Sinistro)
            //{
            //    SalvarArquivo();
            //    ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            //    ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());
            //    ODSInsertSinistroData.Insert(arquivo.NomeArquivo, logger);
            //}
        }

        protected virtual void SalvarArquivo(bool alterarCdCliente, string nomeProc = "")
        {
            throw new NotImplementedException();
        }

        public virtual void ValidarODS()
        {
            throw new NotImplementedException();
            //foreach (var arquivo in arquivosOds)
            //    validadorODS = new ValidadorODSFG05(logger, arquivo);
        }

        protected string ObterArquivoDestino(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(arquivo.tipoArquivo);
            numeroDoLote = numeroArquivoNovo;
            if (AlterarNomeArquivo)
            {
                this.nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if (arquivo.Header.Count > 0)
                    arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);
            }
            else
                this.nomeArquivo = _nomeArquivo;

            var path = Parametros.pastaDestino + nomeArquivo;

            arquivo.AtualizarNomeArquivoFinal(this.nomeArquivo);

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected string ObterArquivoDestinoApenasCriacaoOuValidacao(string _nomeArquivo)
        {
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

            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(arquivo.tipoArquivo);
            numeroDoLote = numeroArquivoNovo;

            nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
            if (arquivo.Header.Count > 0)
                arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);

            var path = Parametros.pastaDestino + nomeArquivo;

            arquivo.AtualizarNomeArquivoFinal(this.nomeArquivo);

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
            logger.InicioOperacao(OperacaoEnum.Processar, "");
            IntegracaoCMD integracao = new IntegracaoCMD();
            var retorno = string.Empty;
            var textoCompletoCMD = string.Empty;
            LinhaTabela linhaDeValidacao = null;
            try
            {
                integracao.AbrirCMD();
                integracao.ChamarExecucao();
                logger.SucessoDaOperacao(OperacaoEnum.Processar, "");
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

        protected virtual void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
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

        protected string AlterarUltimasPosicoes(string texto, string textoASerTrocadoNoFinal)
        {
            return string.IsNullOrEmpty(texto) ? null : texto.Remove(texto.Length - textoASerTrocadoNoFinal.Length) + textoASerTrocadoNoFinal;
        }

        public void IgualarCampos(Arquivo arquivoOrigem, Arquivo arquivoDestino, string[] campos, bool linhaUnicaNaOrigem = false)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DOS ARQUIVOS:");
            var nomeCampo = string.Empty;
            foreach (var linha in arquivoDestino.Linhas)
                foreach (var campo in campos)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    var index = linhaUnicaNaOrigem ? 0 : linha.Index;
                    AlterarLinha(arquivoDestino, linha.Index, nomeCampo, arquivoOrigem.ObterLinha(index).ObterCampoDoArquivo(nomeCampo).ValorFormatado, true);
                }
        }

        public void IgualarCamposQueExistirem(Arquivo arquivoOrigem, Arquivo arquivoDestino)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DOS ARQUIVOS:");

            if (arquivoOrigem.Linhas.Count != arquivoDestino.Linhas.Count)
                throw new Exception("ARQUIVOS COM QUANTIDADE DE LINHAS DIFERENTES.");
            
            var nomeCampo = string.Empty;
            foreach (var linha in arquivoDestino.Linhas)
                foreach (var campo in arquivoDestino.CamposDoBody)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    AlterarLinha(arquivoDestino, linha.Index, nomeCampo, arquivoOrigem.ObterLinha(linha.Index).ObterCampoDoArquivo(nomeCampo).ValorFormatado, true);
                }
        }

    }
}
