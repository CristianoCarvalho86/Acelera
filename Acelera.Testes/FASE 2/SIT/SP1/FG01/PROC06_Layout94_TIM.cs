using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout94_TIM : TesteBase
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2330_CLIENTE_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2331_PARC_EMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2332_EMS_COMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2333_OCR_COBRANCA_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2334_LANCTO_COMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2335_SINISTRO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2325_CLIENTE_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2326_PARC_EMISSAO_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2327_OCR_COBRANCA_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_PAGAMENTO DT_BAIXA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2328_LANCTO_COMISSAO_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2329_SINISTRO_DataInv_Body()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2500_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2501_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2502_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2503_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2504_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2505_SINISTRO()
        {
        }

    }
}
