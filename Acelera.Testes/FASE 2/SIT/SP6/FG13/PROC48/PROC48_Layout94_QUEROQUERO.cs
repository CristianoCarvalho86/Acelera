using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC48
{
    [TestClass]
    public class PROC48_Layout94_QUEROQUERO: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9679()
        {
            IniciarTesteFG07("9679", "", OperadoraEnum.QUEROQUERO);

            AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados, 0);

            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(1), trinca.ArquivoComissao.ObterLinha(1));


            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.QUEROQUERO);

            IgualarCamposQueExistirem(trinca.ArquivoParcEmissao.ObterLinha(0), arquivo.ObterLinha(0));
            AlterarLinha(0, "NR_PARCELA", (int.Parse(trinca.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(trinca.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(trinca.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(trinca.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"),"1"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
