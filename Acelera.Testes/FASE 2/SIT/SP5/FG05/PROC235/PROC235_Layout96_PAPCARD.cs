﻿using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC235
{
    [TestClass]
    public class PROC235_Layout96_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9372()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9372", "SAP-9368:FG05 - PROC 235 - C/C - PARCELA - Contrato com registro rejeitado - Mesmo arquivo");
            //Envia parc normal
            AlterarCobertura(false);

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            AdicionarNovaCoberturaNaEmissao(arquivo, dados);
            AlterarLinha(1, "CD_RAMO", dados.ObterRamoRelacionadoACoberturaDiferenteDe(arquivo[1]["CD_COBERTURA"], arquivo[0]["CD_RAMO"], out string produto));
            AlterarLinha(1, "CD_PRODUTO", produto);

            SalvarArquivo();
            var arquivoparc = arquivo.Clone();

            CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.PAPCARD, arquivoparc);
            AlterarLinha(0, "CD_RAMO", arquivoparc[1]["CD_RAMO"]);
            AlterarLinha(1, "CD_RAMO", arquivoparc[0]["CD_RAMO"]);

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "235", 1);
        }

    }
}
