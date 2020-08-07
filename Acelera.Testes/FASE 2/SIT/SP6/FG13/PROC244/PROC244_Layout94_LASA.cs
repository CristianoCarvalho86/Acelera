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

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC224
{
    [TestClass]
    public class PROC244_Layout94_LASA: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9750()
        {
            IniciarTeste("9750", "SAP-9750:FG13 - PROC 244 - COBRANCA - Enviar cobrança de parcela não baixada - 1a parcela", OperadoraEnum.LASA);

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "31");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"),"0"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

        /// <summary>
        /// 	Enviar trinca de arquivos - 1ª parcela para ODS. Enviar arquivo de baixa da 1ª parcela Enviar trinca de arquivos - 2ª parcela para ODS.
        /// 	Enviar arquivo de baixa da 2ª parcela com CD_OCORRENCIA = 31 - Estorno
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9751()
        {
            IniciarTeste("9751", "SAP-9751:FG13 - PROC 244 - COBRANCA - Enviar cobrança de parcela não baixada - 2a parcela", OperadoraEnum.LASA);

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "31");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"), "0"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNaFG13);

            CriarNovaLinhaParaEmissao(triplice.ArquivoParcEmissao, 0);
            triplice.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(triplice.ArquivoParcEmissao.ObterLinha(1), triplice.ArquivoComissao.ObterLinha(1));
            triplice.ArquivoParcEmissao.RemoverLinhaComAjuste(0);
            triplice.ArquivoComissao.RemoverLinhaComAjuste(0);

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "31");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"), "0"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.ReprovadoNaFG13);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9752()
        {
            IniciarTeste("9752", "SAP-9752:FG13 - PROC 244 - COBRANCA - Enviar cobrança de parcela baixada", OperadoraEnum.LASA);

            SalvaExecutaEValidaTrinca(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_PARCELA"]) + 1).ToString());
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", (int.Parse(triplice.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString());
            AlterarLinha(0, "CD_OCORRENCIA", "31");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(triplice.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", SomarValores(triplice.ArquivoParcEmissao.ObterValorFormatado(0, "VL_PREMIO_TOTAL"), "0"));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNaFG13);

        }

    }
}
