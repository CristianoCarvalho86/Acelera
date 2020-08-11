﻿using Acelera.Domain.Enums;
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
    public class PROC220_Layout94_VIVO: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4607()
        {
            IniciarTeste("4607", "", OperadoraEnum.VIVO);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao.ObterLinha(1), triplice.ArquivoComissao.ObterLinha(1));

            SalvaExecutaEValidaTrinca(true);

            CriarCancelamentoDaTrincaFG13(OperadoraEnum.VIVO, out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento, "10", false);

            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            IgualarCamposQueExistirem(arquivoParcCancelamento.ObterLinha(1), arquivo.ObterLinha(0));
            AlterarLinha(0, "NR_PARCELA", (int.Parse(arquivoParcCancelamento[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(arquivoParcCancelamento[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(arquivoParcCancelamento[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", arquivoParcCancelamento[0]["VL_PREMIO_TOTAL"]);

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}