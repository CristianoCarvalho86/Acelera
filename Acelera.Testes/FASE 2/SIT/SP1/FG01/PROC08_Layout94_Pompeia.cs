using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC08_Layout94_Pompeia : TesteBase
    {

        /// <summary>
        ///No Body do arquivo CLIENTE nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2416_CLIENTE_CEPInv()
        {
        }

        /// <summary>
        ///No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: CEP_UTILIZACAO CEP_PERNOITE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2417_PARC_EMISSAO_CEPInv()
        {
        }

        /// <summary>
        ///No Body do arquivo SINISTRO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: EN_CEP_BENEFICIARIO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2418_SINISTRO_CEPInv()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2538_CLIENTE_CEP()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2539_PARC_EMISSAO_CEP()
        {
        }

        /// <summary>
        /// Importar arquivo com CEP em formato válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2540_SINISTRO_CEP()
        {
        }

    }
}
