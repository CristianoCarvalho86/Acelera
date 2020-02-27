using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC62_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo SINISTRO no campo CD_SINISTRO não informar o número do sinistro (Será criiticado também plea PROC 5)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2266_SINISTRO_SemCD_SINISTRO()
        {
        }


        /// <summary>
        ///  Importar arquivo com NR_SINISTRO valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2548_SINISTRO()
        {
        }

    }
}
