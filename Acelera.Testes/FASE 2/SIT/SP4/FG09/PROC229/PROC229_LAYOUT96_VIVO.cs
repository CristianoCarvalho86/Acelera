using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC229
{
    [TestClass]
    public class PROC229_LAYOUT96_VIVO : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5747()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5747", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "01");
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5748()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5748", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "03"));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5749()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5749", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarHeader("VERSAO", "9.6");
            
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }
    }
}
