﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG05.PROC219
{
    [TestClass]
    public class PROC219_Layout94_TIM : TestesFG05
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9224()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG05 - PROC219 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            contratoRegras.CriarNovoContrato(0,arquivo);

            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO","20");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, arquivo.Header[0]["CD_TPA"], new string[] { arquivo[0]["CD_CLIENTE"] }));
            AlterarLinha(1, "NR_ENDOSSO", arquivo[0]["NR_ENDOSSO"].ObterProximoValorLong());
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", arquivo[0]["NR_SEQUENCIAL_EMISSAO"].ObterProximoValorInteiro());

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNegocioComDependencia);
        }
    }
}
