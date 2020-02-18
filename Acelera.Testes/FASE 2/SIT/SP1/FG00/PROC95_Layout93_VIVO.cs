using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC95_Layout93_VIVO_SGS : TesteBase
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1059_CLIENTE_SemHeader()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1064_SINISTRO_SemHeader()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1063_LANCTO_COMISSAO_SemHeader()
        {
        }


        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1061_EMS_COMISSAO_SemHeader()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1060_PARC_EMISSAO_AUTO_SemHeader()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 15
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1100_SINISTRO_AUTO_TipoRegistro15()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 14
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1099_LANCTO_COMISSAO_TipoRegistro14()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1098_OCR_COBRANCA_TipoRegistro13()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 12
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1097_EMS_COMISSAO_TipoRegistro12()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1096_PARC_EMISSAO_AUTO_TipoRegistro11()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 10
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1095_CLIENTE_TipoRegistro10()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1157_EMS_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1160_EMS_SINISTRO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1159_EMS_LANCTO_COMISSAO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1158_EMS_OCR_COBRANCA_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1156_PARC_EMISSAO_AUTO_TipoRegistro01()
        {
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1155_EMS_CLIENTE_TipoRegistro01()
        {
        }
    }
}
