using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1227_SINISTRO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1226_LANCTO_COMISSAO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_12225_OCR_COBRANCA_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1224_EMS_COMISSAO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1223_PARC_EMISSAO_AUTO_QT_LIN_CarEsp()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1222_CLIENTE_QT_LIN_CarEsp()
        {
        }


        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1311_SINISTRO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1310_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1306_CLIENTE_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1309_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1308_EMS_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1307_PARC_EMISSAO_AUTO_QT_LIN()
        {
        }

    }
}
