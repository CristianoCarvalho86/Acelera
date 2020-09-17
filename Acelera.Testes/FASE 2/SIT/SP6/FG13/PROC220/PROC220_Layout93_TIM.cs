using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC220
{
    [TestClass]
    public class PROC220_Layout94_TIM: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4607()
        {
            IniciarTesteFG07("4607", "", OperadoraEnum.TIM, true, true);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);
            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02();

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.TIM, out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento, "10");

            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AjustarArquivoDeBaixaParaParcela(arquivoParcCancelamento, arquivo, 0, "18");

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
