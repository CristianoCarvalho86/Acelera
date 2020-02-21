using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout94_TIM : TesteBase
    {

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_RAMO CD_CORRETOR CD_CONTRATO NR_SEQ_EMISSAO CD_TIPO_COMISSAO NR_PARCELA NR_APOLICE NR_ENDOSSO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2323_LANCTO_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo COMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2321_COMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2319_CLIENTE_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2320_PARC_EMISSAO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2324_SINISTRO_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2322_OCR_COBRANCA_SemCampObrig_Body()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo SINISTRO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2318_SINISTRO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2315_EMS_COMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2316_OCR_COBRANCA_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2317_LANCTO_COMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo PARC_EMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2314_PARC_EMISSAO_SemCampObrig_Header_Trailler()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// No Trailler do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2313_CLIENTE_SemCampObrig_Header_Trailler()
        {
        }


        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2481_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2482_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2483_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2484_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2485_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2486_SINISTRO()
        {
        }

    }
}
