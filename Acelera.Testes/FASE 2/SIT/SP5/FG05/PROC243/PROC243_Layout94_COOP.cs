﻿using Acelera.Domain.Enums;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC243
{
    [TestClass]
    public class PROC243_Layout96_COOP : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9463()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9463", "SAP-9318:FG05 - PROC 243 - C/C - PARCELA - ID_TRANSACAO já processado - Capa");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);
            CriarNovaLinhaParaEmissao(arquivo);

            var parc1 = arquivo.Clone();
            EnviarParaOdsAlterandoCliente(arquivo);


            arquivo = parc1;
            CriarNovaLinhaParaEmissao(arquivo,1);
            AlterarLinha(2, "NR_ENDOSSO", arquivo[1]["NR_ENDOSSO"]);
            RemoverLinha(0);
            RemoverLinha(0);
            AjustarQtdLinFooter();

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
