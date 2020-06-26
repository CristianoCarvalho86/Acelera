using Acelera.Data;
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
    public class PROC45_LAYOUT94_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5284()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5284", "FG09 - PROC45 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, 0);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "13");
            AlterarLinha(0,"CD_RAMO",dados.ObterRamoRelacionadoACoberturaDiferenteDe(ObterValor(0, "CD_COBERTURA"), ObterValor(0, "CD_RAMO"), out string produto));
            AlterarLinha(0, "CD_PRODUTO", produto);

           AlterarCobertura(false);
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "45", 1);

        }

    }
}
