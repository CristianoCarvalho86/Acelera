﻿using Acelera.Domain.Enums;
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

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC48
{
    [TestClass]
    public class PROC48_Layout94_TIM: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9666()
        {
            IniciarTesteFG07("9666", "", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02();

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            ArquivoUtils.IgualarCamposQueExistirem(trinca.ArquivoParcEmissao.ObterLinha(1), arquivo.ObterLinha(0),logger);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(trinca.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(trinca.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(trinca.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(trinca.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"),"10"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
