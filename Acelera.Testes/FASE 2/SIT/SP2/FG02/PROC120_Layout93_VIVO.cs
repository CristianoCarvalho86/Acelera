using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC120_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=10
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3012_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3012", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=10");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC120");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =6 e Informar CD_FORMA_PAGTO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3013_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3013", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =6 e Informar CD_FORMA_PAGTO=11");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(0, "CD_FORMA_PAGTO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=12
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3014_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3014", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=12");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "12");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3015_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3015", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=13");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "13");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=14
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3016_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3016", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=14");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "14");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "120");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=5
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3023_PARCEMSAUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3023", "Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=5");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "5");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3019_PARCEMSAUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3019", "Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=1");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=4
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3022_PARCEMSAUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3019", "Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=4");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "4");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =6 e Informar CD_FORMA_PAGTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3020_PARCEMSAUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3020", "Informar CD_TIPO_EMISSAO =6 e Informar CD_FORMA_PAGTO=2");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "6");
            AlterarLinha(0, "CD_FORMA_PAGTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3021_PARCEMSAUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3021", "Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=3");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }

}

