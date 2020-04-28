using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC120_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=8
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3054_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3000", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=8");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "8");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200211.txt");

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
        /// Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3056_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3056", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=1");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

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
        /// Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3057_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3057", "FG02 - PROC120 -Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=2");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

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
        /// Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3058_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3058", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=3");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

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
        /// Informar CD_TIPO_EMISSAO =146 e Informar CD_FORMA_PAGTO inválido=F
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3060_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3060", "FG02 - PROC120 - Informar CD_TIPO_EMISSAO =146 e Informar CD_FORMA_PAGTO inválido=F");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "F");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200316.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3055_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3055", "FG02 - PROC120 - Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=9");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200320.txt");

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
        /// Informar CD_TIPOMOVIMENTO =7 e Informar CD_FORMA_PAGTO=Z
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3059_CD_FORMA_PAGTO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3059", "FG02 - PROC88 - Informar CD_TIPOMOVIMENTO =7 e Informar CD_FORMA_PAGTO=Z");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3248-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "Z");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200321.txt");

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
        public void SAP_3061_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3061", "FG02 - PROC88 - Informar CD_TIPO_EMISSAO =5 e Informar CD_FORMA_PAGTO=3");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(0, "CD_FORMA_PAGTO", "3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

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
        /// Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=5
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3063_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3063", "FG02 - PROC88 - Informar CD_TIPO_EMISSAO =8 e Informar CD_FORMA_PAGTO=5");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "5");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.txt");

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
        /// Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=6
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3064_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3064", "FG02 - PROC88 - Informar CD_TIPO_EMISSAO =17 e Informar CD_FORMA_PAGTO=6");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "17");
            AlterarLinha(0, "CD_FORMA_PAGTO", "6");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.txt");

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
        ///Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3065_PARCEMS_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3065", "FG02 - PROC88 - Informar CD_TIPO_EMISSAO =20 e Informar CD_FORMA_PAGTO=7");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(0, "CD_FORMA_PAGTO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=c
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3062_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3062", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =8 e Informar CD_FORMA_PAGTO=c");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3297-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "8");
            AlterarLinha(0, "CD_FORMA_PAGTO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3066_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3066", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =7, e informar CD_FORMA_PAGTO=R");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "CD_FORMA_PAGTO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

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
        /// Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=M
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3067_SINISTRO_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3067", "FG02 - PROC88 - Informar CD_TIPO_MOVIMENTO =146, e informar CD_FORMA_PAGTO=M");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3300-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "146");
            AlterarLinha(0, "CD_FORMA_PAGTO", "M");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.SINISTRO-EV-/*R*/-20200324.txt");

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
