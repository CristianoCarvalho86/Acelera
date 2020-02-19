using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout94_Pompeia : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1383_SINISTRO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1382_LANCTO_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1381_OCR_COBRANCA_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1380_EMS_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1379_PARC_EMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1378_CLIENTE_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1468_CLIENTE_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1469_PARC_EMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1473_SINISTRO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1472_LANCTO_COMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1471_OCR_COBRANCA_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1470_EMS_COMISSAO_VERSAO_9_4()
        {
        }


    }
}
