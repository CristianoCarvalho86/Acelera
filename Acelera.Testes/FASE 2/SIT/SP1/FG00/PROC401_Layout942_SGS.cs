using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC401_Layout942_SGS : TesteBase
    {
        /// <summary>
        /// Importar arquivo com campo Tipo Nome do Arquivo (segundo campo da nomenclatura) diferente do parametrizado na tabela TAB_PRM_LAYOUT_7016. Ex.: C01.POMPEIA.ARQUIVO-EV-1927-20200211.TXT
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2623_SINISTRO_TipoNomeArq_Dif()
        {
        }


        /// <summary>
        ///  Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2654_SINISTRO_()
        {
        }

    }
}
