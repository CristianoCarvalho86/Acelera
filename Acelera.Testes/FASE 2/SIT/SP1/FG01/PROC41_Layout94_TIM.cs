using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC41_Layout94_TIM : TesteBase
    {

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CPF com 8 dígitos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2348_CLIENTE_NR_CNPJ_CPF_8Dig()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo NR_CNPJ_CPF informar CNPJ com dígito verificador inválido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2349_CLIENTE_NR_CNPJ_CPF_DigInv()
        {
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: NR_CNPJ_CPF (Será criiticado também plea PROC 5)
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2350_PARC_EMISSAO_SemNR_CNPJ_CPF()
        {
        }


        /// <summary>
        ///  Importar arquivo com CPF valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2549_CLIENTE()
        {
        }

    }
}
