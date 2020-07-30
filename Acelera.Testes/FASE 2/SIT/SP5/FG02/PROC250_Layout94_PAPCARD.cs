using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC250_Layout94_PAPCARD : TestesFG02
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8942_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8942", "PAPCARD - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "200");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "100");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8943_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8943", "SAP-8943:FG02 - 250 - C/C - PAPCARD - PARCELA - CD_TIPO_EMISSAO = 10 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "200");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "100");
            AlterarHeader("VERSAO", "9.6");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            //ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8944_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8944", "PAPCARD - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "200");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "100");
            AlterarLinha(0, "VL_IOF", "100");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8945_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "COOP - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "0");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "0");
            AlterarLinha(0, "VL_IOF", "0");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8946_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8952", "COOP - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "0");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "0");
            AlterarLinha(0, "VL_IOF", "0");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8947_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8953", "COOP - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            AlterarLayout<Arquivo_Layout_9_6_ParcEmissao>(arquivo);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "0");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "0");
            AlterarLinha(0, "VL_IOF", "0");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

    }
}
