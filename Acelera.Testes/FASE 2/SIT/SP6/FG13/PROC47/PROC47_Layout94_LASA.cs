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
    public class PROC47_Layout94_LASA: TestesFG13
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9574()
        {
            IniciarTesteFG07("9574", "", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTrinca(trinca, "C", dados);
            trinca.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            trinca.AlterarCliente(0, "CD_CLIENTE", GerarNumeroAleatorio(7));
            trinca.AlterarCliente(0, "NR_CNPJ_CPF", GeneralUtils.GerarNumeroValidadorCpf(GerarNumeroAleatorio(9)));
            trinca.AlterarCliente(0, "NM_CLIENTE", GeneralUtils.GerarTextoAleatorio(40));

            SalvaExecutaEValidaTrincaFG02(false);

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(trinca.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "NR_PARCELA", "2");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(0, "CD_OCORRENCIA", "18");
            AlterarLinha(0, "DT_OCORRENCIA",SomarData(trinca.ArquivoParcEmissao[0]["DT_EMISSAO"], 10));
            AlterarLinha(0, "VL_PREMIO_PAGO", trinca.ArquivoParcEmissao[0]["VL_PREMIO_TOTAL"]);

            SalvarArquivo();

            ExecutarEValidarAteFG13(arquivo, CodigoStage.AprovadoNegocioSemDependencia);

        }

    }
}
