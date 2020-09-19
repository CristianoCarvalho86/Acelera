using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC47
{
    [TestClass]
    public class PROC47_Layout94_TIM: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9582()
        {
            IniciarTesteFG07("9582", "", OperadoraEnum.TIM);

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao, 0);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(1), trinca.ArquivoComissao.ObterLinha(0));

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            ArquivoUtils.IgualarCamposQueExistirem(trinca.ArquivoParcEmissao.ObterLinha(1), arquivo.ObterLinha(0), logger);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(trinca.ArquivoParcEmissao[1]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(trinca.ArquivoParcEmissao[1]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(trinca.ArquivoParcEmissao[1]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", trinca.ArquivoParcEmissao[0]["VL_PREMIO_TOTAL"]);

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
