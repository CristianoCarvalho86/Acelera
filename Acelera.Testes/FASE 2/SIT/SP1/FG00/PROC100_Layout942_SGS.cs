using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC100_Layout942_SGS : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1190_SINISTRO_SemCD_TPA()
        {
        }


        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1206_SINISTRO_CD_TPA_01()
        {
        }

    }
}
