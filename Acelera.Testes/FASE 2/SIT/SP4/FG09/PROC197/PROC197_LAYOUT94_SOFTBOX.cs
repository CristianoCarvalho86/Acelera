using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC197
{
    [TestClass]
    public class PROC197_LAYOUT94_TIM : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_6066()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6066", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            //AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 10));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "197", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6067()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6067", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), -1));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), -1));
            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "197");
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_6068()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "6068", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 0));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 0));
            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "197");
        }
    }
}
