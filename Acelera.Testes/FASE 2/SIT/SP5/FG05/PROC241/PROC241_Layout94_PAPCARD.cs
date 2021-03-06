﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC241
{
    [TestClass]
    public class PROC241_Layout94_PAPCARD : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9419()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9419", "SAP-9419:FG05 - PROC 241 - PAPCARD - PARCELA - NR_SEQ_EMISSAO menor que o ultimo enviado - 2a parcela");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(ref arquivo);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoOds = arquivo.Clone();

            LimparValidacao();

            CriarNovaLinhaParaEmissao(arquivo);
            RemoverLinhaComAjusteDeFooter(0);

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "0");

            SalvarArquivo();

            ExecutarEValidarAteFg02(arquivo);
        }
    }
}
