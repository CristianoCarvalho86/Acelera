using Acelera.Testes.TestesTipoArquivo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout94_TIM : TesteBase
    {
        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 4X o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1282_OCR_COBRANCA_2xHeader_4xTrailler()
        {
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir trailer
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1284_LANCTO_COMISSAO_1xHeader()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1287_SINISTRO_2xTrailler()
        {
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1280_EMS_COMISSAO_2xHeader()
        {
        }


        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 5x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 5X o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1279_PARC_EMISSAO_5xTrailler_5xHeader()
        {
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1277_CLIENTE_3xTrailler()
        {
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2595_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2596_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2597_SINISTRO()
        {
        }
        
        /// <summary>
        /// No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2594_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO_AUTO apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2593_PARC_EMISSAO_AUTO()
        {
        }

        /// <summary>
        /// No arquivo CLIENTE apresentar somente um registro do Trailler e Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2592_CLIENTE()
        {
        }
    }
}
