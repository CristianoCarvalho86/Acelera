using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1146_SINISTRO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1145_LANCTO_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1144_OCR_COBRANCA_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1143_EMS_COMISSAO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1142_PARC_EMISSAO_AUTO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1141_CLIENTE_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1137_CLIENTE_VERSAO_9_3()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1138_PARC_EMISSAO_AUTO_VERSAO_9_3()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1142_SINISTRO_VERSAO_9_3()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1141_LANCTO_COMISSAO_VERSAO_9_3()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1140_OCR_COBRANCA_VERSAO_9_3()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1139_EMS_COMISSAO_VERSAO_9_3()
        {
        }


    }
}
