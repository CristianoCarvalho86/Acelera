using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo CLIENTE no campo EN_UF informar código CC
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2275_CLIENTE_EN_UF_CC()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo CD_UF_RISCO informar código PP
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2276_PARC_EMISSAO_AUTO_CD_UF_RISCO_PP()
        {
        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código SS
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2277_SINISTRO_EN_UF_BENEFICIARIO_SS()
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
