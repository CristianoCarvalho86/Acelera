using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2245_CLIENTE_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2246_PARC_EMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2247_EMS_COMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2248_OCR_COBRANCA_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2249_LANCTO_COMISSAO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2250_SINISTRO_DataInv_Header()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2399_CLIENTE_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_INICIO_VIGENCIA DT_FIM_VIGENCIA DT_VENCIMENTO DT_NASC_CONDUTOR
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2400_PARC_EMISSAO_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2401_OCR_COBRANCA_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_PAGAMENTO DT_BAIXA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2402_LANCTO_COMISSAO_DataInv_Body()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_REGISTRO DT_NASC_BENEFICIARIO DT_PAGAMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2403_SINISTRO_DataInv_Body()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2494_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2495_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2496_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2497_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2498_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2499_SINISTRO()
        {
        }

    }
}
