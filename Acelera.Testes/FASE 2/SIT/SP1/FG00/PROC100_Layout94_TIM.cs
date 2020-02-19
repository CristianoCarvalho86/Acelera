using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC100_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1272_EMS_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1273_OCR_COBRANCA_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1274_LANCTO_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1275_SINISTRO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1271_PARC_EMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1270_CLIENTE_SemCD_TPA()
        {
        }


        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1336_CLIENTE_CD_TPA_002()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1337_PARC_EMISSAO_CD_TPA_002()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1338_EMS_COMISSAO_CD_TPA_002()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1339_OCR_COBRANCA_CD_TPA_002()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1340_LANCTO_COMISSAO_CD_TPA_002()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1341_SINISTRO_CD_TPA_002()
        {
        }

    }
}
