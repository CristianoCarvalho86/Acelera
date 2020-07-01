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
    public class PROC206_LAYOUT94_TIM : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.TIM;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5665()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5665", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", arquivoods1.ObterValorFormatado(0, "VL_PREMIO_TOTAL"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValor(0, "VL_PREMIO_TOTAL", 5));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5666()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5666", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, "20", 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", arquivoods1.ObterValorFormatado(1, "VL_PREMIO_TOTAL"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValor(0, "VL_PREMIO_TOTAL", -5));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5667()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5667", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, "20", 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_PREMIO_TOTAL"), arquivoods1.ObterValorFormatado(1, "VL_PREMIO_TOTAL")));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_TOTAL", -4));
            AlterarLinha(0, "VL_IOF", "4");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "206", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5668()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5668", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, "20", 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
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
        public void SAP_5669()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5669", "FG09 - PROC206 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
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
