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
    public class PROC190_LAYOUT94_POMPEIA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5483()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5483", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            //AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", SomarValor(0, "VL_PREMIO_LIQUIDO", 1));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5484()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5484", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(1), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "9999");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5485()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5485", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, false, 3);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(2), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "9999");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5486()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5486", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, false, 2);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO").ValorFormatado());

            AlterarCobertura(false);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5487()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5487", "FG09 - PROC190 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            var soma =  arquivoods.SomarLinhasDoArquivo("VL_PREMIO_LIQUIDO").ValorFormatado();
            AlterarLinha(0, "VL_PREMIO_LIQUIDO",soma +1);

            AlterarCobertura(false);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "190", 1);

        }
    }
}
