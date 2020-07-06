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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC208
{
    [TestClass]
    public class PROC208_LAYOUT96_VIVO: TestesFG09
    {
        private OperadoraEnum operacaoDoTeste => OperadoraEnum.VIVO;

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5715()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5715", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", 5));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5716()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5716", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, "20", 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(1), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValor(0, "VL_CUSTO_APOLICE", -4));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5717()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5717", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, "20", 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", SomarValores(arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"), arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE")));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "208", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5718()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5718", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true, "20", 2);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE",arquivoods1.ObterValorFormatado(1, "VL_CUSTO_APOLICE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5719()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "5719", "FG09 - PROC208 - ");

            //Envia parc normal
            var arquivoods1 = CriarEmissaoODS<Arquivo_Layout_9_6_ParcEmissaoAuto>(operacaoDoTeste, true);

            //ParcEmissaoAuto referente a cancelamento
            arquivo = new Arquivo_Layout_9_6_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operacaoDoTeste);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods1.ObterLinha(0), "10"));
            AlterarHeader("VERSAO", "9.6");
            AlterarLinha(0, "VL_CUSTO_APOLICE", arquivoods1.ObterValorFormatado(0, "VL_CUSTO_APOLICE"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
