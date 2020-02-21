using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC01_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2213_OCR_COBRANCA_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2210_CLIENTE_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2211_PARC_EMISSAO_AUTO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2212_EMS_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2214_LANCTO_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2215_SINISTRO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2216_CLIENTE_CD_TPA_9_33()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2217_PARC_EMISSAO_AUTO_CD_TPA_9_33()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2218_EMS_COMISSAO_CD_TPA_9_33()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2219_OCR_COBRANCA_CD_TPA_9_33()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2220_LANCTO_COMISSAO_CD_TPA_9_33()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 9.33
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2221_SINISTRO_CD_TPA_9_33()
        {
        }


        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2456_CLIENTE()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2457_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2458_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2459_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2460_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2461_SINISTRO()
        {
        }

    }
}
