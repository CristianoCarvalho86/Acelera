using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout94_Pompeia : TesteBase
    {

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2393_CLIENTE_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos: DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA NR_APOLICE NR_ENDOSSO NR_DOCUMENTO DT_VENCIMENTO VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA CD_PRODUTO ID_TRANSACAO CD_UF_RISCO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2394_PARC_EMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: CD_TIPO_COMISSAO CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2395_EMS_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2396_OCR_COBRANCA_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_EXTRATO_COMISSAO NR_MES_REFERENCIA CD_LANCAMENTO VL_COMISSAO_PAGO DT_PAGAMENTO DT_BAIXA CD_SISTEMA CD_TIPO_LANCAMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2397_LANCTO_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: NM_BENEFICIARIO EN_BENEFICIARIO EN_BAIRRO_BENEFICIARIO EN_CIDADE_BENEFICIARIO EN_UF_BENEFICIARIO EN_CEP_BENEFICIARIO EN_PAIS_BENEFICIARIO DT_NASC_BENEFICIARIO CD_COBERTURA CD_MOEDA CD_SISTEMA VL_CEDIDO CD_TIPO_BENEFICIARIO NR_DOCTO_BENEFICIARIO CD_PRODUTO TP_RAMO_SINISTRO NR_ENDOSSO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2398_SINISTRO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2392_SINISTRO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2391_EMS_COMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2390_OCR_COBRANCA_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2389_EMS_COMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo PARC_EMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2388_PARC_EMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2387_CLIENTE_SemCampObrig_Header_Trailler()
        {
        }


        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2487_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2488_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2489_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2490_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2491_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2492_SINISTRO()
        {
        }

    }
}
