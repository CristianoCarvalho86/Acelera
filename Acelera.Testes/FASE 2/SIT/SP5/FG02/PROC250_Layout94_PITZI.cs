using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC250_Layout94_PITZI : TestesFG02
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8980_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "PITZI - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8981_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8943", "PITZI - PARCELA - CD_TIPO_EMISSAO = 10 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "10");
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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8982_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "PITZI - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8983_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "PITZI - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8984_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8943", "PITZI - PARCELA - CD_TIPO_EMISSAO = 10 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8985_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "PITZI - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio igual a zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

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
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("250");
            ValidarTeste();
        }


    }
}
