using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC66_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo SINISTRO no campo CD_AVISOnão informar o número do aviso (Será criiticado também plea PROC 5)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2267_SINISTRO_SemCD_AVISO()
        {
        }

        /// <summary>
        ///  Importar arquivo com CD_AVISO valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2555_SINISTRO()
        {
        }

    }
}
