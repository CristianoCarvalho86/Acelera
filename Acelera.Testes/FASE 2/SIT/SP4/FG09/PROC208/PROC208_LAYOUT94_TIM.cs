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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC208
{
    [TestClass]
    public class PROC208_LAYOUT94_TIM : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.TIM;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5705()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5705", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"));
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", 5));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5706()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5706", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE"));
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", -5));


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5707()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5707", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"), arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE")));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5708()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5708", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE",arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5709()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5709", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
