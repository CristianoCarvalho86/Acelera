using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC100_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1065_CLIENTE_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1070_SINISTRO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1069_LANCTO_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1068_OCR_COBRANCA_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1067_EMS_COMISSAO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1066_PARC_EMISSAO_SemCD_TPA()
        {
        }


        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1166_SINISTRO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1165_LANCTO_COMISSAO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1164_OCR_COBRANCA_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1163_EMS_COMISSAO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1162_PARC_EMISSAO_AUTO_CD_TPA_004()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1161_CLIENTE_CD_TPA_004()
        {
        }

    }
}
