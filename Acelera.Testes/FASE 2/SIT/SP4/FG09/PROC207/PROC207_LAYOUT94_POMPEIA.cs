﻿using Acelera.Data;
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
    public class PROC207_LAYOUT94_POMPEIA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.POMPEIA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5695()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5695", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", arquivoods1.ObterValorFormatado(0, "VL_IOF"));
            AlterarLinha(0, "VL_IOF", SomarValor(0, "VL_IOF", 5));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5696()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5696", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", arquivoods1.ObterValorFormatado(1, "VL_IOF"));
            AlterarLinha(0, "VL_IOF", SomarValor(0, "VL_IOF", -5));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());


            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5697()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5697", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_IOF"), arquivoods1.ObterValorFormatado(1, "VL_IOF")));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "207", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5698()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5698", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true, 2);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF",arquivoods1.ObterValorFormatado(1, "VL_IOF"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5699()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5699", "FG09 - PROC207 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //ParcEmissao referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_IOF", arquivoods1.ObterValorFormatado(0, "VL_IOF"));
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
