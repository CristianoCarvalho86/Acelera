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
    public class PROC208_LAYOUT94_LASA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.LASA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5710()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5710", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));

            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", 5));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5711()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5711", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10"));
            //AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", -5));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5712()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5712", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10")); 

            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"), arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE")));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5713()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5713", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10"));

            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5714()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5714", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, false);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));

            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
