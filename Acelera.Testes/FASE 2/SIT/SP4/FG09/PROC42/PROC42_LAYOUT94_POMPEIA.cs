using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC42
{
    [TestClass]
    public class PROC42_LAYOUT94_POMPEIA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.POMPEIA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5294()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5294", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13"));
            

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods2 = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "13");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5295()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5295", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarLinha(0, "NR_PARCELA", "9");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5296()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5296", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11");

            AlterarDadosDeCobertura(0, dados.ObterCoberturaDiferenteDe(arquivoods1.ObterValorFormatado(0, "CD_COBERTURA")));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5297()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5297", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5298()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5298", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

    }
}
