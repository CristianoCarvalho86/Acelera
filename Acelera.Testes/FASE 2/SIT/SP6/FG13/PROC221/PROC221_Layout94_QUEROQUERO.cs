using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC221
{
    [TestClass]
    public class PROC221_Layout94_QUEROQUERO: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9735()
        {
            IniciarTeste("9735", "", OperadoraEnum.QUEROQUERO);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao.ObterLinha(1), triplice.ArquivoComissao.ObterLinha(1));

            SalvaExecutaEValidaTrinca(false);

            CriarCancelamento(false, false, OperadoraEnum.QUEROQUERO, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            arquivoParcCancelamento.AdicionarLinha(CriarLinhaCancelamento(triplice.ArquivoParcEmissao.ObterLinha(1), "10"));

            arquivoComissaoCancelamento.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(arquivoParcCancelamento.ObterLinha(1), arquivoComissaoCancelamento.ObterLinha(1));

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);

            ValidarFGsAnterioresEErros(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros(arquivoComissaoCancelamento);

            //EnviarParaOds(arquivoParcCancelamento, false, false, CodigoStage.AprovadoNaFG09);
            //EnviarParaOds(arquivoComissaoCancelamento, false, false, CodigoStage.AprovadoNaFG09);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.QUEROQUERO);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao.ObterLinha(1), arquivo.ObterLinha(0));
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", triplice.ArquivoParcEmissao[0]["VL_PREMIO_TOTAL"]);

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
