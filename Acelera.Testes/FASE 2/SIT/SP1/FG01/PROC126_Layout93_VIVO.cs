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
        ///  No Body do arquivo CLIENTE no campo EN_UF informar código CC
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2275_CLIENTE_EN_UF_CC()
        {
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO_AUTO no campo CD_UF_RISCO informar código PP	
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2276_PARC_EMISSAO_AUTO_EN_UF_RISCO_PP()
        {
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código SS
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2277_SINISTRO_EN_UF_BENEFICIARIO_SS()
        {
        }

        /// <summary>
        ///  No Body do arquivo CLIENTE no campo EN_UF não informar valor, ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2278_CLIENTE_SemEN_UF()
        {
        }

        /// <summary>
        ///  No Body do arquivo PARC_EMISSAO_AUTO não informar valor, ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2279_PARC_EMISSAO_AUTO_SemEN_UF()
        {
        }

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO não informar valor, ou seja, campos em branco, respeitando a tamanho do campos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2280_SINISTRO_SemEN_UF_BENEFICIARIO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2582_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2583_PARC_EMISSAO_AUTO()
        {
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2584_PSINISTRO()
        {
        }
    }
}
