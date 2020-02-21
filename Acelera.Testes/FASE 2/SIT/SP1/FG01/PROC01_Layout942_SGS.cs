using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC01_Layout942_SGS : TesteBase
    {

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2282_SINISTRO_SemCD_TPA()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 00
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2283_SINISTRO_CD_TPA_00()
        {
        }


        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2474_SINISTRO()
        {
        }

    }
}
