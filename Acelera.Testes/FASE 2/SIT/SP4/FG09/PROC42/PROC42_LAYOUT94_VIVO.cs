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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC42
{
    [TestClass]
    public class PROC42_LAYOUT94_VIVO : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5275()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5275", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13"));
            

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods2 = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "13");
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5276()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5276", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "NR_PARCELA", "9");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5277()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5277", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "CD_MODELO", ObterValor(0,"CD_MODELO").AlterarUltimosCaracteres(GerarNumeroAleatorio(5)));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5278()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5278", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "11");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "CD_ITEM", ObterValor(0, "CD_ITEM").AlterarUltimosCaracteres(GerarNumeroAleatorio(10)));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5279()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5279", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "12");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "CD_CONTRATO", ObterValor(0, "CD_CONTRATO").AlterarUltimosCaracteres(GerarNumeroAleatorio(8)));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5280()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5280", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13");
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "NR_PARCELA", "9");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5281()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5281", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "21");
            AlterarHeader("VERSAO", "9.6");
            emissaoRegras.AlterarDadosDeCobertura(0, dados.ObterCoberturaDiferenteDe(arquivoods1.ObterValorFormatado(0, "CD_COBERTURA")), arquivo);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "42", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5282()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5282", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5283()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5282", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "9");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }




    }
}
