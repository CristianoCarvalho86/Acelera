﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC232
{
    [TestClass]
    public class PROC232_Layout94_LASA : TestesFG05
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9308()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "9319", "SAP-9308:FG05 - PROC 232 - C/C - PARCELA - ID_TRANSACAO já processado");
            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            contratoRegras.CriarNovoContrato(0,arquivo);

            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            EnviarParaOdsAlterandoCliente(arquivo);
            var arquivoods1 = arquivo.Clone();
            

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            ArquivoUtils.IgualarCamposQueExistirem(arquivoods1, arquivo);
            AlterarLinha(0, "CD_ITEM","12345");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "232", 1);
        }

    }
}
