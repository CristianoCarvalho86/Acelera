using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1233_SINISTRO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1232_LANCTO_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1231_OCR_COBRANCA_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1230_EMS_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1229_PARC_EMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1228_CLIENTE_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1312_CLIENTE_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1313_PARC_EMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1317_SINISTRO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1316_LANCTO_COMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1315_OCR_COBRANCA_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1314_EMS_COMISSAO_VERSAO_9_4()
        {
        }


    }
}
