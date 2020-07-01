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

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC196
{
    [TestClass]
    public class PROC196_LAYOUT96_VIVO : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5508()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5508", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO,true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            AdicionarLinha(0, CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), -10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), -10));
            AlterarHeader("VERSAO", "9.6");

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5509()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5509", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5510()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5510", "FG09 - PROC196 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, operadora);
            CriarNovoContrato(0);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AdicionarLinha(1, ObterLinha(0));
            AlterarLinha(1, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 30));
            AlterarLinha(1, "NR_ENDOSSO", "0");
            AlterarLinha(1, "ID_TRANSACAO_CANC", "");


            AlterarHeader("VERSAO", "9.6");
            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 40));
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5512()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5512", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 1));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5511()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5511", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_3_ParcEmissaoAuto>(OperadoraEnum.VIVO, true);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.VIVO);

            RemoverTodasAsLinhas();
            CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10");
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 0));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 0));
            AlterarHeader("VERSAO", "9.6");
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
