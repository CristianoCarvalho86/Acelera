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
    public class PROC45_LAYOUT96_VIVO : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5303()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5303", "FG09 - PROC45 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            //AlterarLinha(0, "CD_RAMO", dados.ObterRamoRelacionadoACoberturaDiferenteDe(ObterValorFormatado(0, "CD_COBERTURA"), ObterValorFormatado(0, "CD_RAMO"), out string produto));
            //AlterarLinha(0, "CD_PRODUTO", produto);
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "45", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5306()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5306", "FG09 - PROC45 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            cancelamentoRegras.CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

    }

}
