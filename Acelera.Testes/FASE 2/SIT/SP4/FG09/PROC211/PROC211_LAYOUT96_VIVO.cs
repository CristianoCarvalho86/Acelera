﻿using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Domain.Utils;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC211
{
    [TestClass]
    public class PROC211_LAYOUT94_VIVO : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5724()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5724", "FG09 - PROC211 - ");

            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AlterarHeader("VERSAO", "9.6");
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarLinha(0, "ID_TRANSACAO_CANC", StringUtils.AlterarUltimasPosicoes(ObterValorFormatado(0, "ID_TRANSACAO_CANC"), "5"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "211", 1);

        }

        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_5725()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5725", "FG09 - PROC211 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, 2);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "11"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09, "211", 1);

        }

    }
}
