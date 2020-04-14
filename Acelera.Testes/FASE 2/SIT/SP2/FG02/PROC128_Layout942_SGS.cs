using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC128_Layout942_SGS : TestesFG02
    {

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3122_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3122", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000015");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000015");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=7. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3123_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3123", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=7. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000002");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000002");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=9. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3124_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3124", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=9. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000003");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000003");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=30. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3125_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3125", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=30. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000004");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000004");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=11 Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3126_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3126", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=11. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000005");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000005");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=146. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3127_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3127", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=146. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000006");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000006");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=2. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3128_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3128", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=2. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000007");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000007");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "128");
            ValidarTeste();
        }

        /// <summary>
        ///No mesmo arquivo, informar dois registros (linhas) com o mesmo CD_SINISTRO (numero aleatorio) e CD_TIPO_MOVIMENTO=1.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3129_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3129", "FG02 - PROC128 - No mesmo arquivo, informar dois registros (linhas) com o mesmo CD_SINISTRO (numero aleatorio) e CD_TIPO_MOVIMENTO=1.");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO", "123123456000008");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(1, "CD_SINISTRO", "123123456000008");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=2 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3130_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3130", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=2 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000009");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000009");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=7 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3131_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3131", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=7 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000010");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000010");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=9 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3132_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3132", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=9 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000011");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000011");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=30 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3133_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3133", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=30 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000012");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000012");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=11 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3134_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3134", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=11 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000013");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000013");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

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

        /// <summary>
        ///Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=146 Importar os arquivos separadamente
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3135_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3135", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=146 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000014");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.TXT");

            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000014");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200213.TXT");

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
