using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC15_Layout94_TIM : TesteBase
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informado o código 1234567 respeitando a tamanho do campos: ID_TRANSACAO_CANC Premissa: CD_TIPO_EMISSAO do registro ser 9 ou 10 ou 11 ou 12 ou 13 ou 21
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2347_PARC_EMISSAO_ID_TRANSACAO_CANC_Dif()
        {
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2546_PARC_EMISSAO_ID_TRANSACAO_CANC()
        {
        }

    }
}
