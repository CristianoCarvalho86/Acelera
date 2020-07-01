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
    public class PROC229_LAYOUT96_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5747()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5747", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "01");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5748()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5748", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10", "03");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5749()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5749", "FG09 - PROC197 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "229", 1);

        }
    }
}
