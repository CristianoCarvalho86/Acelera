using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC74_Layout94_VIVO : TesteBase
    {

        /// <summary>
        /// CLIENTE - Não informar CD_CLIENTE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2268_CLIENTE_SemCD_CLIENTE()
        {
        }

        /// <summary>
        ///  SINISTRO - Importar arquivo com Beneficiário ok
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2559_SINISTRO()
        {
        }

    }
}
