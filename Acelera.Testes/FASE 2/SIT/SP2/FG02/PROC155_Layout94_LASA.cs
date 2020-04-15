using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC155_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=18	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3327_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3327", "FG02 - PROC155 - ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=18	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "ID_TRANSACAO_CANC", "0123456789");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "18");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "155");
            ValidarTeste();

        }

        /// <summary>
        /// ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=20	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3328_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3328", "FG02 - PROC155 - ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=20");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "ID_TRANSACAO_CANC", "0123456789");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "20");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200317.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "155");
            ValidarTeste();

        }

        /// <summary>
        /// ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=7	
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3329_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3329", "FG02 - PROC155 - ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=7	");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "ID_TRANSACAO_CANC", "0123456789");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "7");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "155");
            ValidarTeste();

        }


        /// <summary>
        /// Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=18
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3330_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3330", "FG00 - PROC155 - Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=18");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(3, "ID_TRANSACAO_CANC", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200319.TXT");

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
        /// Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=20
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3331_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3331", "FG00 - PROC155 - Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=20");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(3, "ID_TRANSACAO_CANC", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200320.TXT");

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
        /// Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=7
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3332_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3332", "FG00 - PROC155 - Não informar ID_TRANSACAO_CANC para CD_TIPO_EMISSAO=7");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(3, "ID_TRANSACAO_CANC", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.TXT");

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
        /// ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=10
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3333_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3333", "FG00 - PROC155 - ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=10");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3256-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_TIPO_EMISSAO", "10");
            AlterarLinha(3, "ID_TRANSACAO_CANC", "0123456789");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200322.TXT");

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
        /// ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=11
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3334_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3334", "FG00 - PROC155 - ID_TRANSACAO_CANC=0123456789 para CD_TIPO_EMISSAO=11");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_TIPO_EMISSAO", "11");
            AlterarLinha(3, "ID_TRANSACAO_CANC", "0123456789");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.TXT");

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
    }
}
