﻿using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC249
{
    [TestClass]
    public class PROC249_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9476()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-9476:FG05 - PROC 249 - PARCELA - NR_ENDOSSO já processado - Parcela 3 - Arquivos distintos");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);
            contratoRegras.CriarNovoContrato(0,arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoOds = arquivo.Clone();
            LimparValidacao();
            ConfereQtdLinhas(arquivo, 1);

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinhaComAjusteDeFooter(0);
            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoOds1 = arquivo.Clone();
            LimparValidacao();
            ConfereQtdLinhas(arquivo, 1);

            CriarNovaLinhaParaEmissao(arquivo, 0);
            AlterarLinha(1, "NR_ENDOSSO", arquivoOds1[0]["NR_ENDOSSO"]);
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", arquivoOds1[0]["NR_SEQUENCIAL_EMISSAO"]);
            AlterarLinha(1, "CD_ITEM", "12345");
            RemoverLinhaComAjusteDeFooter(0);
            ConfereQtdLinhas(arquivo, 1);
            SalvarArquivo();

            SelecionarLinhaParaValidacao(0);
            ValidarFGsAnteriores();
            //ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "249", 1);
        }
    }
}
