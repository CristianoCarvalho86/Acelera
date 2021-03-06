﻿using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC236
{
    [TestClass]
    public class PROC236_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9386()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9386:FG05 - PROC 236 - PAPCARD - PARCELA - Registros do mesmo contrato c/ vig. Dif. - Arquivos diferentes");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);

            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            SalvarArquivo();
            //ValidarFGsAnteriores();

            emissaoRegras.AdicionarNovaCoberturaNaEmissao(arquivo, dados);

            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivo[0]["DT_INICIO_VIGENCIA"], 30));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivo[0]["DT_FIM_VIGENCIA"], 30));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", arquivo[1].ObterCampoSeExistir("NR_SEQUENCIAL_EMISSAO_EST").ValorFormatado);
            RemoverLinhaComAjusteDeFooter(0);


            AlterarCobertura(false);
            SalvarArquivo();

            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "236", 1);
        }
    }
}
