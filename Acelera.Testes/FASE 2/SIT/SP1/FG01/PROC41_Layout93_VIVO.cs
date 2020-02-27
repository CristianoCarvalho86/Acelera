using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC41_Layout93_VIVO : TesteBase
    {

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com dígito verificador inválido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2263_CLIENTE_NR_CNPJ_CPF_DigInv()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com dígito verificador inválido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2264_CLIENTE_NR_CNPJ_CPF_DigInv()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: NR_CNPJ_CPF (Será criiticado também plea PROC 5)
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2265_PARC_EMISSAO_AUTO_SemNR_CNPJ_CPF()
        {
        }


        /// <summary>
        ///  Importar arquivo com CPF valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2548_CLIENTE()
        {
        }

    }
}
