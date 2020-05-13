using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC162_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3395_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3395", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "DT_EMISSAO", SomarData(ObterValor(0,"DT_EMISSAO"),-365));
            AlterarLinha(1, "NR_ENDOSSO", GerarNumeroAleatorio(20));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3396_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3396", "FG02 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO anterior a data do primeiro	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "DT_EMISSAO", SomarData(ObterValor(0, "DT_EMISSAO"), -30));
            AlterarLinha(1, "NR_ENDOSSO", GerarNumeroAleatorio(20));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "162");
            ValidarTeste();

        }


        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3397_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3397", "FG00 - PROC162 - Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=20 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO igual a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3179-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "DT_EMISSAO", ObterValor(0, "DT_EMISSAO"));
            AlterarLinha(1, "NR_ENDOSSO", GerarNumeroAleatorio(20));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200317.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "162");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        
        /// <summary>
        /// Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3398_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3398", "FG00 - PROC162 -Enviar dois registro no mesmo arquivo, um com CD_TIPO_EMISSÃO=7 e o segundo com CD_TIPO_EMISSAO=5. No segundo, informar DT_EMISSAO superior a data do primeiro");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(1, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(1, "DT_EMISSAO", ObterValor(0, "DT_EMISSAO"));
            AlterarLinha(1, "NR_ENDOSSO", GerarNumeroAleatorio(20));
            AlterarLinha(1, "NR_SEQUENCIAL_EMISSAO", SomarValor(0, "NR_SEQUENCIAL_EMISSAO", 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200318.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "162");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
