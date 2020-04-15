using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC164_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3343_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3343", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3344_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3344", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3345_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3345", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3346_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3346", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3347_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3347", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        /// Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3348_NR_DOCUMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3348", "FG02 - PROC164 - Não informar NR_DOCUMENTO para sinistro com: CD_TIPO_MOVIMENTO=146; TP_SINISTRO=02; CD_FORMA_PGTO=B");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_FORMA_PGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "164");
            ValidarTeste();
        }

        /// <summary>
        ///Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e NR_DOCUMENTO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e NR_DOCUMENTO = 01/04/2020
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3238_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3238", "FG02 - PROC164 - Em um único arquivo, duplicar linha. Em uma das linhas, informar CD_TIPO_MOVIMENTO = 1 e NR_DOCUMENTO = 01/04/2020 Na segunda linha, informar CD_TIPO_MOVIMENTO = 2 e NR_DOCUMENTO = 01/04/2020");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 1);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "NR_DOCUMENTO", "01/04/2020");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "01/04/2020");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
