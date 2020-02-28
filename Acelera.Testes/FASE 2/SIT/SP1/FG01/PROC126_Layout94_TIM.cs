using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout94_TIM : TesteBase
    {

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF informar valor o código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2360_CLIENTE_EN_UF_01()
        {
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2361_PARC_EMISSAO_EN_UF_RISCO_01()
        {
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2362_SINISTRO_EN_UF_BENEFICIARIO_01()
        {
        }
        
        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2585_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2586_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2587_PSINISTRO()
        {
        }
    }
}
