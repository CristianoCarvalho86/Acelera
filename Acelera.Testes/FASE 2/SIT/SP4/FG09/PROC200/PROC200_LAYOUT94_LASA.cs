using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC200
{
    [TestClass]
    public class PROC200_LAYOUT96_LASA : TestesFG09
    {
            [TestMethod]
            [TestCategory("Com Critica")]
            public void SAP_5534()
            {
                IniciarTeste(TipoArquivo.ParcEmissao, "5534", "FG09 - PROC200 - ");

                //Envia parc normal
                var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

                //Sinistro referente a cancelamento
                arquivo = new Arquivo_Layout_9_4_ParcEmissao();
                CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

                RemoverTodasAsLinhas();
                AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
                //AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 10));
                AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 10));
                AlterarHeader("VERSAO", "9.6");
                SalvarArquivo();

                ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "200", 1);

            }
    }
}
