using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout94_Pompeia : TesteBase
    {

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF informar valor o código CC
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2434_CLIENTE_EN_UF_CC()
        {
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO no campo CD_UF_RISCO informar valor o código PP
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2435_PARC_EMISSAO_EN_UF_RISCO_PP()
        {
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código SS
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2436_SINISTRO_EN_UF_BENEFICIARIO_SS()
        {
        }
        
        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2588_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2589_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2590_PSINISTRO()
        {
        }
    }
}
