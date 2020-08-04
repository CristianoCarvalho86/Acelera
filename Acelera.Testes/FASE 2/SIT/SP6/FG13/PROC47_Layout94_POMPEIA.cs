using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC47
{
    [TestClass]
    public class PROC47_Layout94_POMPEI: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9574()
        {
            IniciarTeste("9574", "", OperadoraEnum.POMPEIA);

            SalvaExecutaEValida(true);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", "2");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");

            SalvarArquivo();



        }

    }
}
