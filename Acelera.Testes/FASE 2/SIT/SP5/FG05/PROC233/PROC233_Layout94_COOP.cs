﻿using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC233
{
    [TestClass]
    public class PROC233_Layout94_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9328()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9328", "SAP-9360:FG05 - PROC 233 - C/C - PARCELA - Contrato com registro rejeitado - Mesmo arquivo");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            
            contratoRegras.CriarNovoContrato(0, null, "", true);
            AlterarCobertura(false);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            emissaoRegras.AdicionarNovaCoberturaNaEmissao(arquivo, dados, 0);
            AlterarLinha(1, "CD_RAMO", "00");

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }

    }
}
