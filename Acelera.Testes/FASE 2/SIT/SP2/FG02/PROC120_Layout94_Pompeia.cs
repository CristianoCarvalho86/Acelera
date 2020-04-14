using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC120_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=30
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3026_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3026", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=30");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "30");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =6 e Informar CD_FORMA_PAGTO=99
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3027_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3027", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =6 e Informar CD_FORMA_PAGTO=99");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "6");
            AlterarLinha(0, "CD_FORMA_PAGTO", "99");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=55
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3028_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3028", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=55");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "55");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=62
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3029_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3029", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=62");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "62");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=88
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3030_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3030", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=88");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "88");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =7 e Informar CD_FORMA_PAGTO=A
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3031_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3031", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =7 e Informar CD_FORMA_PAGTO=A");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200211.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =146 e Informar CD_FORMA_PAGTO=E
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3032_CD_FORMA_PAGTO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3032", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =146 e Informar CD_FORMA_PAGTO=E");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "E");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.txt");

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
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=8
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3033_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3033", "Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=8");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "8");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200212.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3035_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3035", "Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=1");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3036_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3036", "Informar CD_TIPO_MOVIMENTO =17 e Informar CD_FORMA_PAGTO=2");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3037_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3037", "Informar CD_TIPO_MOVIMENTO =20 e Informar CD_FORMA_PAGTO=3");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3034_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3034", "Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=B");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=B
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3038_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3038", "Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=B");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "B");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3039_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3039", "Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=N");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "156");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.txt");

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
