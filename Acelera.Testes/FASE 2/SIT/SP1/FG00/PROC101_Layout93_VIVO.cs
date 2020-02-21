using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout93_VIVO : TesteBase
    {
        /// <summary>
        /// No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 3X o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1112_SINISTRO_2xTrailler_3xHeader()
        {
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir trailer
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1109_LANCTO_COMISSAO_2xHeader()
        {
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1108_OCR_COBRANCA_1xTrailler()
        {
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1106_EMS_COMISSAO_2xTrailler_2xHeader()
        {
        }


        /// <summary>
        /// No arquivo PARC_EMISSAO_AUTO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1104_PARC_EMISSAO_AUTO_2xTrailler_1xHeader()
        {
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1102_CLIENTE_1xTrailler_1xHeader()
        {
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1174_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1176_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1208_SINISTRO()
        {
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1172_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO_AUTO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1170_PARC_EMISSAO_AUTO()
        {
        }

        /// <summary>
        /// No arquivo CLIENTE apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1168_CLIENTE()
        {
        }
    }
}
