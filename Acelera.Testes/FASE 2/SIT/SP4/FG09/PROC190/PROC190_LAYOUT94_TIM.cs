using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC190
{
    [TestClass]
    public class PROC190_LAYOUT94_TIM : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5478()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5478", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.ObterValorDecimal(0,"VL_PREMIO_LIQUIDO"), 1000M));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5479()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5479", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(1), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5480()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5480", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM, false, 3);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(2), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5481()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5481", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(1), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO").ValorFormatado());
            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "190");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5482()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5482", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.TIM);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", (arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO")).ValorFormatado());
            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "190");

        }
    }
}
