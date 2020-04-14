using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC128_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3108_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3108", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2757-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000015");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000015");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.TXT");

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
        public void SAP_3109_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3109", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=7. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000002");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3287-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000002");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200323.TXT");

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
        public void SAP_3110_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3110", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=9. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3287-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000003");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200323.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3296-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000003");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

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
        public void SAP_3111_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3111", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=30. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3296-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000004");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3298-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000004");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

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
        public void SAP_3112_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3112", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=11. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3298-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000005");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000005");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

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
        public void SAP_3113_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3113", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=146. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3301-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000006");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000006");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

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
        public void SAP_3114_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3114", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=2. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000007");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000007");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

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
        public void SAP_3115_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3115", "FG02 - PROC128 - No mesmo arquivo, informar dois registros (linhas) com o mesmo CD_SINISTRO (numero aleatorio) e CD_TIPO_MOVIMENTO=1.");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO", "123123456000008");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(1, "CD_SINISTRO", "123123456000008");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

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
        public void SAP_3116_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3116", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=2 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3314-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000009");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000009");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

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
        public void SAP_3117_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3117", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=7 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3317-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000010");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3319-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000010");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

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
        public void SAP_3118_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3118", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=9 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3319-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000011");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000011");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

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
        public void SAP_3119_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3119", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=30 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000012");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000012");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

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
        public void SAP_3120_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3120", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=11 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3331-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000013");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3334-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000013");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

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
        public void SAP_3121_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3121", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=146 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3334-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000014");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3336-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", "123123456000014");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200326.TXT");

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
