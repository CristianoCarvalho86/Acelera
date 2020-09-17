using Acelera.Contratos;
using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
using Acelera.Testes.FASE_2;
using Acelera.Testes.Repositorio;
using Acelera.Testes.Validadores.FG05;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG05 : TestesFG02
    {
        private bool alterarCobertura;

        protected TabelaParametrosDataSP3 dados { get; set; }

        protected IList<DataRow> linhasInseridasODS { get; set; }

        protected ValidadorODSFG05 validadorODS { get; set; }

        protected IList<Arquivo> arquivosOds { get; set; }

        protected override string NomeFG => "FG05";
        public TestesFG05()
        {
            arquivosOds = new List<Arquivo>();
            alterarCobertura = true;
        }

        protected override void SalvarArquivo(bool alterarCdCliente, string nomeProc = "")
        {
            if (alterarCdCliente)
            {
                var i = 0;
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", ParametrosBanco.ObterCDClienteCadastrado(arquivo.Operadora));
            }


            base.SalvarArquivo(nomeProc);
        }

        public override void FinalizarAlteracaoArquivo(IArquivo _arquivo)
        {
            Parametrizacoes(_arquivo);
            base.FinalizarAlteracaoArquivo(_arquivo);
        }

        protected void AlterarCobertura(bool alterar)
        {
            alterarCobertura = alterar;
        }

        private void Parametrizacoes(IArquivo _arquivo)
        {
            if (alterarCobertura)
                for (int i = 0; i < _arquivo.Linhas.Count; i++)
                {
                    var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
                    _arquivo.AlterarLinhaSeExistirCampo(i, "CD_COBERTURA", cobertura.CdCobertura);
                    _arquivo.AlterarLinhaSeExistirCampo(i, "CD_RAMO", cobertura.CdRamo);
                    _arquivo.AlterarLinhaSeExistirCampo(i, "CD_PRODUTO", cobertura.CdProduto);
                    var cdContrato = _arquivo[i]["CD_CONTRATO"];
                    cdContrato = cdContrato.Substring(0, 2) + cobertura.CdRamo + cdContrato.Substring(4);
                    AlterarContrato(_arquivo, i, cdContrato);
                }
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            dados = new TabelaParametrosDataSP3(logger);
        }

        protected virtual void ExecutarEValidar(CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno = "", int qtdErrosNaTabelaDeRetorno = 0)
        {
            ValidarFGsAnteriores();

            //Executar FG05
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG05Enum().ObterTexto());

            //VALIDAR NA FG05
            Validar(codigoEsperadoStage, erroEsperadoNaTabelaDeRetorno, qtdErrosNaTabelaDeRetorno);
        }

        protected void ExecutarEValidarAteFg05(IArquivo arquivo, string mensagemErroNaTabelaDeRetorno = "")
        {
            this.arquivo = arquivo;
            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia, mensagemErroNaTabelaDeRetorno);
        }

        protected void Validar(CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno, int qtdErrosNaTabelaDeRetorno)
        {
            ValidarLogProcessamento(true);
            ValidarStages(codigoEsperadoStage);
            if (qtdErrosNaTabelaDeRetorno > 0)
                ValidarTabelaDeRetorno(qtdErrosNaTabelaDeRetorno, erroEsperadoNaTabelaDeRetorno);
            if (erroEsperadoNaTabelaDeRetorno == string.Empty)
                ValidarTabelaDeRetorno();

            ValidarTeste();
        }

        protected virtual void ExecutarEValidarDesconsiderandoErro(CodigoStage codigoEsperadoStage, string erroNaoEsperadoNaTabelaDeRetorno, IArquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            ValidarFGsAnteriores(_arquivo);

            //Executar FG05
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG05Enum().ObterTexto());

            ValidarDesconsiderandoErro(_arquivo, codigoEsperadoStage, erroNaoEsperadoNaTabelaDeRetorno);
        }

        protected void ValidarDesconsiderandoErro(IArquivo _arquivo, CodigoStage codigoEsperadoStage, string erroNaoEsperadoNaTabelaDeRetorno)
        {
            SetarArquivoEmUso(ref _arquivo);
            //VALIDAR NA FG05
            ValidarLogProcessamento(true,1, _arquivo);
            ValidarStagesSemGerarErro(codigoEsperadoStage);
            ValidarTabelaDeRetorno(true, false, new string[] { erroNaoEsperadoNaTabelaDeRetorno });

            ValidarTeste();
        }


        public override void ValidarFGsAnteriores(IArquivo _arquivo = null)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            SetarArquivoEmUso(ref _arquivo);

            base.ValidarFGsAnteriores(_arquivo);

            logger.EscreverBloco("Inicio da Validação da FG02.");
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());
            ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG02, _arquivo.tipoArquivo));
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetornoFG01(_arquivo);
            logger.EscreverBloco("Fim da Validação da FG02. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();
            logger.EscreverBloco("Fim da FG02.");
        }

        protected override IList<string> ObterProceduresASeremExecutadas(IArquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG05, _arquivo.tipoArquivo);
        }

        public void AjustaValoresParaFG02(IArquivo _arquivo)
        {
            if (_arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
            {
                _arquivo.AlterarLinha(0, "DT_EMISSAO", "20200101");
                _arquivo.AlterarLinha(0, "DT_EMISSAO_APOLICE", "20190101");
            }

        }


    }
}
