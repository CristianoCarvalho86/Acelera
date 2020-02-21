using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC07_Layout942_SGS : TesteBase
    {

        /// <summary>
        /// No Header do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_ARQ CD_TPA (Será criticada na C.I) 
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO 
        /// No Trailler do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos QT_LIN (Será criticada na C.I)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2289_SINISTRO_SemCampoNum_Header_Body_Trailler()
        {
        }
               
        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2531_SINISTRO()
        {
        }

    }
}
