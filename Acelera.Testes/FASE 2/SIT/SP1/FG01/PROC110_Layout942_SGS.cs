using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC110_Layout942_SGS : TesteBase
    {

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2281_SINISTRO_3xBody()
        {
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2455_SINISTRO()
        {
        }

    }
}
