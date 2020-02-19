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
        /// No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1112_SINISTRO_2xTrailler_TIPOREGISTRO_9()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 3x o registro do Header, onde o TIPO REGISTRO é igual a 1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1111_SINISTRO_3xHeader_TIPOREGISTRO_1()
        {
        }


        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1208_SINISTRO_Trailler()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1207_SINISTRO_Header()
        {
        }

    }
}
