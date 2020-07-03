﻿using Acelera.Data;
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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC45
{
    [TestClass]
    public class PROC45_LAYOUT94_POMPEIA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5311()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5307", "FG09 - PROC45 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "CD_RAMO", dados.ObterRamoRelacionadoACoberturaDiferenteDe(ObterValor(0, "CD_COBERTURA"), ObterValor(0, "CD_RAMO"), out string produto));
            AlterarLinha(0, "CD_PRODUTO", produto);
            AlterarHeader("VERSAO", "9.6");
            AlterarCobertura(false);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "45", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5314()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5310", "FG09 - PROC45 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.POMPEIA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.POMPEIA);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

    }

}