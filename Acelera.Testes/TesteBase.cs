using Acelera.Data;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
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
        protected ControleNomeArquivo controleNomeArquivo = ControleNomeArquivo.Instancia;
        public TabelaParametrosData dados { get; private set; }
        protected string numeroDoTeste;
        protected bool sucessoDoTeste;
        protected string numeroDoLote;
        protected string operacao;
        protected string nomeDoTeste;
        protected string localDoErro = string.Empty;
        protected string pathOrigem;
        protected bool AoMenosUmComCodigoEsperado = false;
        protected TipoArquivo tipoArquivoTeste { get; set; }

        protected OperadoraEnum operacaoDoTeste { get; set; }

        public TesteBase()
        {

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
            var nomeArquivo = $"SAP-SP1-{numeroDoTeste}-{DateTime.Now.ToString("dd-MM")}-{operacao ?? "OPERACAO"}-{tipoArquivoTeste.ObterTexto()}-{numeroDoLote ?? "NLOTE"}.txt";
            //if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
            //    logger = new Mock<IMyLogger>().Object;
            //else
            logger = new MyLogger($"{Parametros.pastaLog}", nomeArquivo,Parametros.logStackTrace,Parametros.logDataBaseResults);
            logger.EscreverBloco($"Nome do Teste : {numeroDoTeste} {nomeDoTeste}");
            dados = new TabelaParametrosData(logger);
        }

        protected virtual void SalvarArquivo()
        {
            var array = arquivo.NomeArquivo.Split('-');
            array[2] = "/*R*/";
            var nomeArquivo = array.ToList().ObterListaConcatenada("-");
            SalvarArquivo(nomeArquivo, true);
        }

        protected virtual void SalvarArquivo(Arquivo arquivo)
        {
            this.arquivo = arquivo;
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

            //_nomeArquivo = nomeDoTeste.Replace("-", "_") + _nomeArquivo;
            FinalizarAlteracaoArquivo();
            if (Parametros.ModoExecucao == ModoExecucaoEnum.Completo)
                arquivo.Salvar(ObterArquivoDestino(_nomeArquivo, AlterarNomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                arquivo.Salvar(ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo));
            else if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasValidacao)
                ObterArquivoDestinoApenasCriacaoOuValidacao(_nomeArquivo);

            valoresAlteradosBody.FinalizarAlteracaoArquivo(nomeOriginalArquivo, arquivo.NomeArquivo);
        }

        protected void LimparValidacao()
        {
            valoresAlteradosBody = new AlteracoesArquivo();
            valoresAlteradosHeader = new AlteracoesArquivo();
            valoresAlteradosFooter = new AlteracoesArquivo();
        }

        protected void CarregarArquivo(Arquivo arquivo, int qtdLinhas, OperadoraEnum operadora)
        {
            logger.AbrirBloco($"INICIANDO CARREGAMENTO DE ARQUIVO DO TIPO: {arquivo.tipoArquivo.ObterTexto()} - OPERACAO: {operadora.ObterTexto()}");
            var arquivoGerado = ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem);
            arquivo.Carregar(arquivoGerado, 1, 1, qtdLinhas);
            logger.Escrever("ARQUIVO GERADO " + arquivo.NomeArquivo);
            operacaoDoTeste = operadora;
            logger.FecharBloco();
        }

        protected virtual void SalvarArquivo(bool alterarCdCliente, string nomeProc = "")
        {
            throw new NotImplementedException();
        }

        protected string ObterArquivoDestino(string _nomeArquivo, bool AlterarNomeArquivo = true)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(arquivo.tipoArquivo);
            numeroDoLote = numeroArquivoNovo;
            if (AlterarNomeArquivo)
            {
                _nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if (arquivo.Header.Count > 0)
                    arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);
            }

            var path = Parametros.pastaDestino + _nomeArquivo;

            arquivo.AtualizarNomeArquivoFinal(_nomeArquivo);

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

            _nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
            if (arquivo.Header.Count > 0)
                arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);

            var path = Parametros.pastaDestino + _nomeArquivo;

            arquivo.AtualizarNomeArquivoFinal(_nomeArquivo);

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        protected void ChamarExecucaoSemErro(string taskName)
        {
            try
            {
                ChamarExecucao(taskName);
            }
            catch
            {
                localDoErro += taskName + ";";
            }
        }

        protected void ChamarExecucao(string taskName)
        {
            if (Parametros.ModoExecucao != ModoExecucaoEnum.Completo)
                return;
            try
            {
                var comando = "";
                if (taskName.Contains("FGR_01_"))//Temporario enquanto resolvem o problema da FG01 (Codigo vindo 150 onde nao devia)
                    comando = $"CALL {Parametros.instanciaDB}.{taskName}_SP()";
                else
                    comando = $"START TASK {Parametros.instanciaDB}.{taskName}";

                logger.AbrirBloco($"EXECUTANDO TAREFA : '{taskName}'");
                logger.Escrever($"EXECUTANDO COMANDO : {comando}");
                var retorno = helper.Execute(comando, out string erroEncontrado);

                logger.EscreverBloco($"RESULTADO DA TAREFA : '{retorno}'");

                if (retorno == 999)
                    logger.Escrever("HOUVE UM ERRO DESCARTADO NA EXECUÇÃO : " + erroEncontrado);
                logger.FecharBloco();
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
                throw ex;
            }

            logger.LogRetornoCMD(textoCompletoCMD);

            return linhaDeValidacao;
        }

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
        }


        protected string[] ErrosEsperados(params string[] erros)
        {
            return erros;
        }

        protected string AlterarUltimasPosicoes(string texto, string textoASerTrocadoNoFinal)
        {
            return string.IsNullOrEmpty(texto) ? null : texto.Remove(texto.Length - textoASerTrocadoNoFinal.Length) + textoASerTrocadoNoFinal;
        }

        public void IgualarCampos(Arquivo arquivoOrigem, Arquivo arquivoDestino, string[] campos, bool linhaUnicaNaOrigem = false, bool adicionaValidacao = true)
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
                    AlterarLinha(arquivoDestino, linha.Index, nomeCampo, arquivoOrigem.ObterLinha(index).ObterCampoDoArquivo(nomeCampo).ValorFormatado, adicionaValidacao);
                }
            logger.FecharBloco();
        }

        public void IgualarCampos(LinhaArquivo linhaOrigem, LinhaArquivo linhaDestino, string[] campos)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DAS LINHAS:");
            var nomeCampo = string.Empty;
            foreach (var campo in campos)
            {
                linhaDestino.ObterCampoDoArquivo(campo).AlterarValor(linhaOrigem.ObterCampoDoArquivo(campo).ValorFormatado);
            }
            logger.FecharBloco();
        }

        public void IgualarCamposQueExistirem(LinhaArquivo linhaOrigem, LinhaArquivo linhaDestino)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DAS LINHAS:");
            var nomeCampo = string.Empty;
            foreach (var campo in linhaOrigem.Campos)
            {
                linhaDestino.ObterCampoSeExistir(campo.ColunaArquivo)?.AlterarValor(linhaOrigem[campo.ColunaArquivo]);
            }
            logger.FecharBloco();
        }

        public void IgualarCamposQueExistirem(Arquivo arquivoOrigem, Arquivo arquivoDestino)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DOS ARQUIVOS:");

            if (arquivoOrigem.Linhas.Count != arquivoDestino.Linhas.Count)
                throw new Exception("ARQUIVOS COM QUANTIDADE DE LINHAS DIFERENTES.");

            var nomeCampo = string.Empty;
            foreach (var linha in arquivoOrigem.Linhas)
                foreach (var campo in arquivoOrigem.CamposDoBody)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    if (!arquivoDestino.CamposDoBody.Contains(nomeCampo))
                        continue;

                    AlterarLinha(arquivoDestino, linha.Index, nomeCampo, arquivoOrigem.ObterLinha(linha.Index).ObterCampoDoArquivo(nomeCampo).ValorFormatado, true);
                }
        }

        public void AlterarLayout<T>(ref Arquivo _arquivo) where T : Arquivo, new()
        {
            logger.AbrirBloco($"ALTERANDO LAYOUT DE {_arquivo.GetType().Name} para {typeof(T)}");
            var novoArquivo = new T();
            novoArquivo.Linhas = new List<LinhaArquivo>();
            novoArquivo.Header = new List<LinhaArquivo>();
            novoArquivo.Footer = new List<LinhaArquivo>();
            novoArquivo.AtualizarNomeArquivoFinal(_arquivo.NomeArquivo);

            novoArquivo.Header.Add(_arquivo.Header[0].Clone());
            novoArquivo.Footer.Add(_arquivo.Footer[0].Clone());
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
                novoArquivo.AdicionarLinha(novoArquivo.CriarLinhaVazia(i));

            novoArquivo.AjustarQtdLinhasNoFooter();
            IgualarCamposQueExistirem(_arquivo, novoArquivo);

            novoArquivo.AlterarHeader("VERSAO", novoArquivo.TextoVersaoHeader);

            logger.FecharBloco();
            _arquivo = novoArquivo;
        }

        public void CriarArquivoCancelamento(Arquivo ArquivoEmissao, Arquivo ArquivoCancelamento, string cdTipoEmissao, string cdMovtoCobranca = "02",
        string nrSequencialEmissao = "")
        {
            foreach (var linha in ArquivoEmissao.Linhas)
            {
                ArquivoCancelamento.AdicionarLinha(CriarLinhaCancelamento(linha, cdTipoEmissao, cdMovtoCobranca, nrSequencialEmissao));
            }
        }

        public LinhaArquivo CriarLinhaCancelamento(LinhaArquivo linhaArquivoEmissao, string cdTipoEmissao, string cdMovtoCobranca = "02",
        string nrSequencialEmissao = "")
        {
            logger.AbrirBloco("CRIANDO LINHA DE CANCELAMENTO.");
            logger.Escrever($"Utilizando a linha de emissao : {linhaArquivoEmissao.ObterTexto()}");

            var linhaCancelamento = linhaArquivoEmissao.Clone();
            var idTransacaoDaLinhaOriginal = linhaArquivoEmissao.ObterCampoSeExistir("ID_TRANSACAO").ValorFormatado;

            linhaCancelamento.ObterCampoDoArquivo("ID_TRANSACAO_CANC").AlterarValor(idTransacaoDaLinhaOriginal);
            linhaCancelamento.ObterCampoDoArquivo("CD_TIPO_EMISSAO").AlterarValor(cdTipoEmissao);
            linhaCancelamento.ObterCampoDoArquivo("NR_PARCELA").AlterarValor((linhaCancelamento.ObterValorInteiro("NR_PARCELA")).ToString());
            linhaCancelamento.ObterCampoDoArquivo("NR_ENDOSSO").AlterarValor(ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(linhaCancelamento));
            nrSequencialEmissao = string.IsNullOrEmpty(nrSequencialEmissao) ? ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(linhaArquivoEmissao, linhaArquivoEmissao.OperadoraDoArquivo).ToString() : nrSequencialEmissao;
            linhaCancelamento.ObterCampoDoArquivo("NR_SEQUENCIAL_EMISSAO").AlterarValor(nrSequencialEmissao);
            linhaCancelamento.ObterCampoDoArquivo("CD_MOVTO_COBRANCA").AlterarValor(cdMovtoCobranca);

            logger.FecharBloco();
            return linhaCancelamento;
        }

        public void CriarNovoContrato(int posicaoLinha, Arquivo arquivo = null, string novoContrato = "")
        {
            arquivo = arquivo == null ? this.arquivo : arquivo;
            var contrato = "";
            if (!string.IsNullOrEmpty(novoContrato))
                contrato = novoContrato;
            else if (arquivo.Operadora == OperadoraEnum.PAPCARD)
                contrato = "759303900006209";
            else
            {
                while (true)
                {
                    contrato = AlterarUltimasPosicoes(arquivo.ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
                    if (!DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.ParcEmissao.ObterTexto()} WHERE CD_CONTRATO = '{contrato}'", logger) &&
                       !DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.ParcEmissaoAuto.ObterTexto()} WHERE CD_CONTRATO = '{contrato}'", logger) &&
                       !DataAccessOIM.ExisteRegistro($"SELECT '1' FROM oim_apl01 where nr_doc_apolice = '{contrato}'", logger))
                        break;
                }
            }
            arquivo.AlterarLinha(posicaoLinha, "CD_CONTRATO", contrato);
            arquivo.AlterarLinha(posicaoLinha, "NR_APOLICE", contrato);
            arquivo.AlterarLinha(posicaoLinha, "NR_PROPOSTA", contrato);
        }

        protected Arquivo CriarComissao<T>(OperadoraEnum operadora, Arquivo arquivoParcela, bool alterarVersaoHeader = false) where T : Arquivo, new()
        {
            if (alterarVersaoHeader)
                return CriarComissao<T>(operadora, arquivoParcela, "9.6");
            return CriarComissao<T>(operadora, arquivoParcela, "");

        }

        protected Arquivo CriarComissao<T>(OperadoraEnum operadora, Arquivo arquivoParcela, string alterarVersaoHeader) where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, arquivoParcela.Linhas.Count, operadora);
            IgualarCamposQueExistirem(arquivoParcela, arquivo);

            foreach (var linha in arquivo.Linhas)
                AlterarLinha(linha.Index, "CD_TIPO_COMISSAO", dados.ObterTipoRemuneracaoDoCorretor(arquivo[linha.Index]["CD_CORRETOR"], arquivo[linha.Index]["CD_COBERTURA"], arquivoParcela[linha.Index]["CD_PRODUTO"]));

            if (!string.IsNullOrEmpty(alterarVersaoHeader))
                arquivo.AlterarHeader("VERSAO", alterarVersaoHeader);

            return arquivo;
        }

    }
}
