using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC196
{
    [TestClass]
    public class PROC196_LAYOUT94_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5513()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5513", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_EMISSAO", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), -10));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), -10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), -10));
            AlterarLinha(0, "VL_LMI", ObterValorFormatado(0, "VL_IS"));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5514()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5514", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5515()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5515", "FG09 - PROC196 - ");

            //Envia parc normal
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            CriarNovoContrato(0);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
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

            EnviarParaOds(arquivo);
            var arquivoods = arquivo.Clone();

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(0, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 10));
            AlterarLinha(0, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 40));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5517()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5516", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 1));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 1));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5516()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5517", "FG09 - PROC196 - ");

            //Envia parc normal
            var arquivoods = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA);

            //Sinistro referente a cancelamento
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            RemoverTodasAsLinhas();
            AdicionarLinha(0,CriarLinhaCancelamento(arquivoods.ObterLinha(0), "10"));
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_INICIO_VIGENCIA"), 0));
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(arquivoods.ObterValorFormatado(0, "DT_FIM_VIGENCIA"), 0));

            SalvarArquivo();

            ExecutarEValidar(CodigoStage.ReprovadoNaFG09, "196", 1);

        }
    }
}
