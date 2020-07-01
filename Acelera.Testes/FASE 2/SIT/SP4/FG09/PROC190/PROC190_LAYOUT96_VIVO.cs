using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC190
{
    [TestClass]
    public class PROC190_LAYOUT96_VIVO : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5468()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5468", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.ObterValorDecimal(0,"VL_PREMIO_LIQUIDO"), 1000M));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5469()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5469", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, "20", 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5470()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5470", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, "20", 3);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValores(arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO"), 1000M));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5471()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5471", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true, "20", 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO").ValorFormatado());
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5472()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5472", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", (arquivoods.ObterValorDecimal(0, "VL_PREMIO_LIQUIDO") - 1).ValorFormatado());
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }
    }
}
