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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC229
{
    [TestClass]
    public class PROC229_LAYOUT96_SOFTBOX : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5750()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5750", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "01");

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo, "223");

            ExecutarEValidarApenasFg09(arquivo, "229");

            //ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5751()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5751", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "03"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5752()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5752", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.SOFTBOX);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }
    }
}
