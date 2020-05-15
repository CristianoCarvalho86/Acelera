using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC182_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Informar TP_SINISTRO= 1 para CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3629_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3629", "FG02 - PROC182 - Informar TP_SINISTRO= 1 para CD_TIPO_MOVIMENTO=1");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO=05 para CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3630_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3630", "FG02 - PROC182 - Informar TP_SINISTRO= 05 para CD_TIPO_MOVIMENTO=2");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "05");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO=3 para CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3631_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3631", "FG02 - PROC182 - Informar TP_SINISTRO= 3 para CD_TIPO_MOVIMENTO=7");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "3");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO= 10 para CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3632_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3632", "FG02 - PROC182 - Informar TP_SINISTRO= 10 para CD_TIPO_MOVIMENTO=9");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(0, "TP_SINISTRO", "10");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO= 00 para CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3633_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3633", "FG02 - PROC182 - Informar TP_SINISTRO= 00 para CD_TIPO_MOVIMENTO=30");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "TP_SINISTRO", "00");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO=06 para CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3634_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3634", "FG02 - PROC182 - Informar TP_SINISTRO= 06 para CD_TIPO_MOVIMENTO=11");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(0, "TP_SINISTRO", "06");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        /// Informar TP_SINISTRO=2 para CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3635_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3635", "FG02 - PROC182 - Informar TP_SINISTRO= 2 para CD_TIPO_MOVIMENTO=146");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "TP_SINISTRO", "2");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "182");
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3636_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3636", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=1");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3637_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3637", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=2");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "02");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3638_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3638", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=7");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "03");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3639_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3639", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=9");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "9");
            AlterarLinha(0, "TP_SINISTRO", "04");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3640_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3640", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=30");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "TP_SINISTRO", "01");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3641_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3641", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=11");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "11");
            AlterarLinha(0, "TP_SINISTRO", "02");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }

        /// <summary>
        ///Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=146
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3642_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3642", "FG02 - PROC182 - Informar TP_SINISTRO valido para CD_TIPO_MOVIMENTO=146");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "TP_SINISTRO", "03");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"182");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }
    }
}
