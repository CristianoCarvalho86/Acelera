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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC201
{
    [TestClass]
    public class PROC201_LAYOUT94_TIM : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.TIM;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5650()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5650", "FG09 - PROC201 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", arquivoods1.ObterValorFormatado(0, "VL_ADIC_FRACIONADO"));
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValor(0, "VL_ADIC_FRACIONADO", 1));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "201", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5651()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5651", "FG09 - PROC201 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", arquivoods1.ObterValorFormatado(1, "VL_ADIC_FRACIONADO"));
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValor(0, "VL_ADIC_FRACIONADO", -1));


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "201", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5652()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5652", "FG09 - PROC201 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_ADIC_FRACIONADO"), arquivoods1.ObterValorFormatado(1, "VL_ADIC_FRACIONADO")));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "201", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5653()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5653", "FG09 - PROC201 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", arquivoods1.ObterValorFormatado(1, "VL_ADIC_FRACIONADO"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5654()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5654", "FG09 - PROC201 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", arquivoods1.ObterValorFormatado(0, "VL_ADIC_FRACIONADO"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
