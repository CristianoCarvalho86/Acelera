using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC128_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3094_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3094", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

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
        public void SAP_3096_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3096", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=7. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200211.TXT");

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
        public void SAP_3097_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3097", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=9. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

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
        public void SAP_3098_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3098", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=30. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.TXT");

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
        public void SAP_3099_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3099", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=11. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.TXT");

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
        public void SAP_3100_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3100", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=146. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.TXT");

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
        public void SAP_3095_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3095", "FG02 - PROC128 -Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=2. Importar os arquivos separadamente.");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

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
        public void SAP_3101_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3101", "FG02 - PROC128 - No mesmo arquivo, informar dois registros (linhas) com o mesmo CD_SINISTRO (numero aleatorio) e CD_TIPO_MOVIMENTO=1.");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191223.TXT");

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
        public void SAP_3102_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3102", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=2 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

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
        public void SAP_3103_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3103", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=7 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.TXT");

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
        public void SAP_3104_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3104", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=9 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200127.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200211.TXT");

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
        public void SAP_3105_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3105", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=30 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200211.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

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
        public void SAP_3106_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3106", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=11 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

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
        public void SAP_3107_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3107", "FG02 - PROC128 - Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO. No primeiro arquivo, informar CD_TIPO_MOVIMENTO=1. No segundo, informar CD_TIPO_MOVIMENTO=146 Importar os arquivos separadamente");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sinistro = dados.ObterSucursal(true) + ObterValorFormatado(1, "CD_RAMO") + "20" + ObterValorHeader("CD_TPA") + GerarNumeroAleatorio(6);
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20200117.TXT");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0002-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SINISTRO", sinistro);
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "146");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191220.TXT");

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
