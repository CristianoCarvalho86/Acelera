using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP3.FG05.PROC108
{
    [TestClass]
    public class PROC108_Layout94_LASA : TestesFG05
    {

        /// <summary>
        /// Gerar arquivo cujo CD_CLIENTE não esteja cadastrado na tabela TAB_ODS_PARCEIRO_NEGOCIO_2000 com CD_TIPO_PARCEIRO_NEGOCIO=CL. Utilizar CD_EXTERNO para essa comparação
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4493()
        {
            IniciarTeste(TipoArquivo.Comissao, "4493", "FG05 - PROC108");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);
            AlterarLinha(0, "CD_TIPO_EMISSAO", dados.ObterCDTipoEmissao("EEN", true));
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");

            SalvarArquivo(true, "ODS-PROC108");
            var arquivoods = arquivo.Clone();

            //Carregar arquivo esteira
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            //Alterar arquivo
            var campos = new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO", "NR_PARCELA", "CD_COBERTURA", "CD_ITEM", "CD_RAMO"};
            IgualarCampos(arquivoods, arquivo, campos);

            AlterarLinha(0, "CD_RAMO", dados.ObterRamoNaoRelacionadoACobertura(cobertura.CdCobertura));
            SalvarArquivo(true, "PROC108");

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "108", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4494()
        {
            IniciarTeste(TipoArquivo.Comissao, "4494", "FG05 - PROC108");

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamo);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);

        }
    }
}
