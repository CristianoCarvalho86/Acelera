using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC206
{
    [TestClass]
    public class PROC206_LAYOUT94_VIVO : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5660()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5660", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValor(0, "VL_PREMIO_TOTAL", 5));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5661()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5661", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValor(0, "VL_PREMIO_TOTAL", -5));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5662()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5662", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_PREMIO_TOTAL"), arquivoods1.ObterValorFormatado(1, "VL_PREMIO_TOTAL")));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5663()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5663", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL",arquivoods1.ObterValorFormatado(1, "VL_PREMIO_TOTAL"));
            AlterarLinha(0, "VL_IOF", arquivoods1.ObterValorFormatado(1, "VL_IOF"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods1.ObterValorFormatado(1, "VL_PREMIO_LIQUIDO"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5664()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5664", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", arquivoods1.ObterValorFormatado(0, "VL_PREMIO_TOTAL"));
            AlterarLinha(0, "VL_IOF", arquivoods1.ObterValorFormatado(1, "VL_IOF"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods1.ObterValorFormatado(1, "VL_PREMIO_LIQUIDO"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
