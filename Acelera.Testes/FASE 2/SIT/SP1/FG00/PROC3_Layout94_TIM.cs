using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC3_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1216_CLIENTE_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1217_PARC_EMISSAO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1218_EMS_COMISSAO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1219_OCR_COBRANCA_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1220_LANCTO_COMISSAO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1221_SINISTRO_QT_LIN_Diferente()
        {
        }


        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1300_CLIENTE_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1301_PARC_EMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1302_EMS_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1303_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1304_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1305_SINISTRO_QT_LIN()
        {
        }

    }
}
