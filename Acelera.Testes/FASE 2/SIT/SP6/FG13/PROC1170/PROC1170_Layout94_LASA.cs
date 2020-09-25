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

namespace Acelera.Testes.FASE_2.SIT.SP6.FG13.PROC48
{
    [TestClass]
    public class PROC1170_Layout94_LASA: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9764()
        {
            IniciarTesteFG07("9764", "", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);
            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            emissaoRegras.AdicionarNovaCoberturaNaEmissao(trinca.ArquivoParcEmissao, dados, 0);

            trinca.ArquivoComissao.ReplicarLinha(0, 1);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(1), trinca.ArquivoComissao.ObterLinha(1));

            SalvaExecutaEValidaTrincaFG02();

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCamposQueExistirem(trinca.ArquivoParcEmissao.ObterLinha(0), arquivo.ObterLinha(0),logger);
            AlterarLinha(0, "NR_PARCELA", trinca.ArquivoParcEmissao[0]["NR_PARCELA"]);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", trinca.ArquivoParcEmissao[0]["NR_SEQUENCIAL_EMISSAO"]);
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(trinca.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_IOF_RETIDO", SomarValores(trinca.ArquivoParcEmissao.SomarLinhasDoArquivo("VL_IOF"), -1));

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
