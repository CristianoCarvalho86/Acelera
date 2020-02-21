using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout94_Pompeia : TesteBase
    {
        /// <summary>
        /// No arquivo CLIENTE repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Trailler
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1432_OCR_CLIENTE_2xHeader_2xTrailler()
        {
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 4x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1434_PARC_EMISSAO_4xTrailler()
        {
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1436_EMS_COMISSAO_3xTrailler()
        {
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1439_OCR_COBRANCA_2xTrailler()
        {
        }


        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1441_LANCTO_COMISSAO_3xTrailler_2xHeader()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1442_SINISTRO_1xHeader()
        {
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1504_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1506_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1508_SINISTRO()
        {
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1502_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1500_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// No arquivo CLIENTE apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1498_CLIENTE()
        {
        }
    }
}
