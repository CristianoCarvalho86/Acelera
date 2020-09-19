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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC222
{
    [TestClass]
    public class PROC222_LAYOUT94_POMPEIA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.POMPEIA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5740()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5740", "FG09 - PROC222 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 0, operacaoDoTeste);

            arquivo.SelecionarLinhas("CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO"));
            arquivo.RemoverValoresRepetidosNoCampo("CD_COBERTURA");

            AlterarCobertura(false);

            SalvarArquivo();
            //EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "222", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5741()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5741", "FG09 - PROC222 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 0, operacaoDoTeste);

            arquivo.SelecionarLinhas("CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO"));
            arquivo.RemoverValoresRepetidosNoCampo("CD_COBERTURA");

            AlterarCobertura(false);

            SalvarArquivo();
            //EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarArquivoCancelamento(arquivoods, arquivo, "10");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "11");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "222", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5742()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5742", "FG09 - PROC222 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 0, operacaoDoTeste);

            arquivo.SelecionarLinhas("CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO"));
            arquivo.RemoverValoresRepetidosNoCampo("CD_COBERTURA");

            AlterarCobertura(false);

            SalvarArquivo();
            //EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "222", 1);

            //Envia Parc com id cancelamento igual id transição do anterior

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(1), "10"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "222", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5743()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5743", "FG09 - PROC222 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 0, operacaoDoTeste);

            arquivo.SelecionarLinhas("CD_CONTRATO", ObterValorFormatado(0, "CD_CONTRATO"));
            arquivo.RemoverValoresRepetidosNoCampo("CD_COBERTURA");

            AlterarCobertura(false);

            SalvarArquivo();
            //EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Envia Parc com id cancelamento igual id transição do anterior

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarArquivoCancelamento(arquivoods, arquivo, "10");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

    }
}
