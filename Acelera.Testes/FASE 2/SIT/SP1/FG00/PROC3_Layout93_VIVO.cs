using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC3_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1035_CLIENTE_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1036_PARC_EMISSAO_AUTO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1037_EMS_COMISSAO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1038_OCR_COBRANCA_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1039_LANCTO_COMISSAO_QT_LIN_Diferente()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1040_SINISTRO_QT_LIN_Diferente()
        {
        }


        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1125_CLIENTE_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1126_PARC_EMISSAO_AUTO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1127_EMS_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1128_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1129_LANCTO_COMISSAO_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1130_SINISTRO_QT_LIN()
        {
        }

    }
}
