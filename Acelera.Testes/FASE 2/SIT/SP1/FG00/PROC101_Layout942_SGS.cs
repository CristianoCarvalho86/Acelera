using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout942_SGS : TesteBase
    {
        /// <summary>
        /// No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1197_SINISTRO_2xTrailler_2xHeader()
        {
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Header
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1208_SINISTRO()
        {
        }

    }
}
