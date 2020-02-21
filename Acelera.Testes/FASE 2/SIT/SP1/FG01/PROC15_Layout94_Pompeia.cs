using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC15_Layout94_Pompeia : TesteBase
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO_CANC Premissa: CD_TIPO_EMISSAO do registro ser 9 ou 10 ou 11 ou 12 ou 13 ou 21
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2421_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2547_PARC_EMISSAO_ID_TRANSACAO_CANC()
        {
        }

    }
}
