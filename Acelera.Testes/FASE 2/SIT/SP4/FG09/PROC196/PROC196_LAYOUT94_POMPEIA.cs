using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC196
{
    [TestClass]
    public class PROC196_LAYOUT94_POMPEIA : TestesFG09
    {

        [TestMethod]
        public void SAP_1111()
        {
            //C01.LASA.PARCEMS-EV-3780-20200423.TXT
            //C01.LASA.PARCEMS-EV-3798-20200424.TXT
            //C01.LASA.CLIENTE-EV-3781-20200423.TXT
            //C01.LASA.EMSCMS-EV-3782-20200423.TXT
            //C01.LASA.EMSCMS-EV-3800-20200424.TXT
            
            /*C01.LASA.PARCEMS-EV-4627-20200612.TXT
            C01.LASA.PARCEMS-EV-4747-20200620.TXT
            C01.LASA.CLIENTE-EV-4628-20200612.TXT
            C01.LASA.EMSCMS-EV-4628-20200612.TXT
            C01.LASA.EMSCMS-EV-4749-20200620.TXT*/
            IniciarTeste(TipoArquivo.ParcEmissao, "", "Geracao de massa");

            AlterarCobertura(false);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(@"C:\Cristiano\Origem2\C01.LASA.PARCEMS-EV-4627-20200612.TXT");
            var contrato =StringUtils.AlterarUltimasPosicoes(arquivo.ObterValorFormatado(0, "CD_CONTRATO"), GerarNumeroAleatorio(8));
            var cdCliente = GerarNumeroAleatorio(8);

            foreach (var linha in arquivo.Linhas)
                contratoRegras.CriarNovoContrato(linha.Index, arquivo, contrato);
            arquivo.AlterarTodasAsLinhas("CD_CLIENTE", cdCliente);
            SalvarArquivo();
            //ExecutarEValidarAteFg05(arquivo);
            LimparValidacao();

            arquivo.Carregar(@"C:\Cristiano\Origem2\C01.LASA.PARCEMS-EV-4747-20200620.TXT");
            foreach (var linha in arquivo.Linhas)
                contratoRegras.CriarNovoContrato(linha.Index, arquivo, contrato);
            arquivo.AlterarTodasAsLinhas("CD_CLIENTE", cdCliente);
            SalvarArquivo();
            //ExecutarEValidarAteFg05(arquivo);
            LimparValidacao();

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(@"C:\Cristiano\Origem2\C01.LASA.CLIENTE-EV-4628-20200612.TXT");
            arquivo.AlterarTodasAsLinhas("CD_CLIENTE", cdCliente);
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();
            //ExecutarEValidarAteFg05(arquivo);
            LimparValidacao();

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(@"C:\Cristiano\Origem2\C01.LASA.EMSCMS-EV-4628-20200612.TXT");
            arquivo.AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            SelecionarLinhaParaValidacao(0);
            SalvarArquivo();
            //ExecutarEValidarAteFg05(arquivo);
            LimparValidacao();

            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(@"C:\Cristiano\Origem2\C01.LASA.EMSCMS-EV-4749-20200620.TXT");
            arquivo.AlterarTodasAsLinhas("CD_CONTRATO", contrato);
            SalvarArquivo();
            //ExecutarEValidarAteFg05(arquivo);
            LimparValidacao();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5523()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5523", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), -10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), -10));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5524()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5524", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 365));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5525()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5525", "FG09 - PROC196 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            contratoRegras.CriarNovoContrato(0,arquivo);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
            AdicionarLinha(1, ObterLinha(0));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 30));
            AlterarLinha(1, "NR_ENDOSSO", "0");
            AlterarLinha(1, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_SEGURADORA", "5908");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 40));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5527()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5526", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 1));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 0));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5526()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5526", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 0));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 0));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
