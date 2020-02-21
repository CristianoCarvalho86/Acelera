using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC93_Layout942_SGS : TesteBase
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1193_SINISTRO_TipoRegistro13()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1187_SINISTRO_SemTipoRegistro()
        {
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1203_SINISTRO_TipoRegistro09()
        {
        }

    }
}
