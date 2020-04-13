using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC120_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3040_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "23040", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =6 e Informar CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3041_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3041", "FG02 - PROC120 -Informar CD_TIPO_MOVIMENTO =6 e Informar CD_FORMA_PAGTO=N");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "6");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3042_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3042", "FG02 - PROC120 -Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=C");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3043_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3043", "FG02 - PROC120 -Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=M");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3044_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3044", "FG02 - PROC120 -Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=R");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =7 e Informar CD_FORMA_PAGTO=X
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3045_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3045", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =7 e Informar CD_FORMA_PAGTO=X");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3314-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "X");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =146 e Informar CD_FORMA_PAGTO=Y
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3046_CD_FORMA_PAGTO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3046", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =146 e Informar CD_FORMA_PAGTO=Y");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "Y");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3047_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3047", "Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=3");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=5
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3049_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3049", "Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=5");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "5");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=6
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3050_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3050", "Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=6");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "6");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3051_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3051", "Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=7");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        ///Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3048_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3048", "Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=R");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=C
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3052_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3052", "Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=C");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=D
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3053_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3053", "Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=D");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

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
