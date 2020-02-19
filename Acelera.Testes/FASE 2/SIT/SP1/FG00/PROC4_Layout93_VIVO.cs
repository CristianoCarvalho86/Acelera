using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1082_SINISTRO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1081_LANCTO_COMISSAO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1080_OCR_COBRANCA_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1079_EMS_COMISSAO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1078_PARC_EMISSAO_AUTO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1077_CLIENTE_QT_LIN_CarEsp()
        {
        }


        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1136_SINISTRO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1135_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1131_CLIENTE_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1134_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1133_EMS_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1132_PARC_EMISSAO_AUTO_QT_LIN()
        {
        }

    }
}
