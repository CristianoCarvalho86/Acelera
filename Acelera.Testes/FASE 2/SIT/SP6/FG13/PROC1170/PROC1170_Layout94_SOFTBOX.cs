﻿using Acelera.Domain.Enums;
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
    public class PROC1170_Layout94_SOFTBOX: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9778()
        {
            IniciarTeste("9778", "", OperadoraEnum.SOFTBOX);

            AdicionarNovaCoberturaNaEmissao(triplice.ArquivoParcEmissao, dados, 0);

            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao.ObterLinha(1), triplice.ArquivoComissao.ObterLinha(1));

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_IOF_PAGO", SomarValores(triplice.ArquivoParcEmissao.SomarLinhasDoArquivo("VL_IOF"), 1));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
