using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC94_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1054_PARC_EMISSAO_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1053_CLIENTE_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1058_SINISTRO_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1057_LANCTO_COMISSAO_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1056_OCR_COBRANCA_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1055_COMISSAO_SemBody()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1090_PARC_EMISSAO_AUTO_TipoRegistro11()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO informar código 15
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1094_SINISTRO_TipoRegistro15()
        {
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 14
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1093_LANCTO_COMISSAO_TipoRegistro14()
        {
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1092_OCR_COBRANCA_TipoRegistro13()
        {
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 12
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1091_COMISSAO_TipoRegistro12()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO informar código 10
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1089_CLIENTE_TipoRegistro10()
        {
        }
        

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1154_SINISTRO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1153_LANCTO_COMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1152_OCR_COBRANCA_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1151_EMS_COMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1150_PARC_EMISSAO_AUTO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1149_CLIENTE_TipoRegistro03()
        {

        }

    }
}
