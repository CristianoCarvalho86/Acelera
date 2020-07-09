using Acelera.Data;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Acelera.Domain.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC211
{
    [TestClass]
    public class PROC211_LAYOUT94_LASA : TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.LASA;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5722()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5722", "FG09 - PROC211 - ");

            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissao>(operacaoDoTeste, true);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AlterarHeader("VERSAO", "9.6");
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            CriarNovoContrato(0);

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "211", 1);

        }

        [TestMethod]
        [TestCategory("Semm Critica")]
        public void SAP_5723()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5723", "FG09 - PROC211 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(operacaoDoTeste, true, 2, "5");

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);
            AlterarHeader("VERSAO", "9.6");
            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "11"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09, "211", 1);

        }

    }
}
