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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC207
{
    [TestClass]
    public class PROC207_LAYOUT94_VIVO : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5680()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5680", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", SomarValor(0, "VL_IOF", 5));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5681()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5681", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", SomarValor(0, "VL_IOF", -5));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5682()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5682", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_IOF"), arquivoods1.ObterValorFormatado(1, "VL_IOF")));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5683()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5683", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "206");

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5684()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5684", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10", "03"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidarDesconsiderandoErro(CodigoStage.AprovadoNaFG09, "206");

        }
    }
}
