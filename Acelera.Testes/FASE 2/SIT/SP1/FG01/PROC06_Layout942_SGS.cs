using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout942_SGS : TesteBase
    {

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2287_SINISTRO_DataInv_Body()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2288_SINISTRO_DataInv_Header()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2512_SINISTRO()
        {
        }

    }
}
