using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC14_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO (Será criiticado também pela PROC 5)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2260_PARC_EMISSAO_AUTO_ID_TRANSACAO_Dif()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo ID_TRANSACAO informar o número na sequência: CD_RAMO, NR_PARCELA, NR_ENDOSSO, NR_APOLICE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2261_PARC_EMISSAO_AUTO_ID_TRANSACAO_Dif()
        {
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2542_PARC_EMISSAO_AUTO_ID_TRANSACAO()
        {
        }

    }
}
