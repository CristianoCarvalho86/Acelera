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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC42
{
    [TestClass]
    public class PROC42_LAYOUT94_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5284()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5284", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, 0);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13"));
            

            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "13");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "42", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5285()
        {
            IniciarTeste(TipoArquivo.Sinistro, "5285", "FG09 - PROC42 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, 0);

            //Envia Parc com id cancelamento igual id transição do anterior
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "13"));


            EnviarParaOds(arquivo);
            var arquivoods2 = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods2.ObterLinha(0), "13");
            AlterarLinha(0, "NR_PARCELA", "9");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNegocioComDependencia, "42", 1);

        }

    }
}
