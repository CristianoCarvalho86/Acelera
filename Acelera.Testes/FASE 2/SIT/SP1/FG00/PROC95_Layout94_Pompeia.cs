using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC95_Layout94_Pompeia : TesteBase
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1408_CLIENTE_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1409_PARC_EMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1410_EMS_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1411_OCR_COBRANCA_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1412_LANCTO_COMISSAO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1413_SINISTRO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1414_CLIENTE_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1415_PARC_EMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1416_EMS_COMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1417_OCR_COBRANCA_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1418_LANCTO_COMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1419_SINISTRO_TipoRegistro100()
        {
        }
               
        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1486_CLIENTE_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1487_PARC_EMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1488_EMS_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1489_OCR_COBRANCA_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1490_LANCTO_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1491_SINISTRO_TipoRegistro01()
        {
        }

    }
}
