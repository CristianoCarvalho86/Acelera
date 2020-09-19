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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC190
{
    [TestClass]
    public class PROC190_LAYOUT94_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5473()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5473", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.ObterValorDecimal(0,"VL_PREMIO_LIQUIDO"), 1000M));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5474()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5474", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5475()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5475", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, false, 3);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5476()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5476", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(1), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO").ValorFormatado());
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "190");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5477()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5477", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", (arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO") - 1).ValorFormatado());
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));
            AlterarCobertura(false);

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "190");

        }
    }
}
