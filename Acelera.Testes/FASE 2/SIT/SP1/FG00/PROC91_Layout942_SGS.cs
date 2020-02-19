using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout942_SGS : TesteBase
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1186_SINISTRO_SemVERSAO()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO informar código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1202_SINISTRO_VERSAO_9_4()
        {
        }


    }
}
