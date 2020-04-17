using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC25_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4046_PARC_EMISSAO_CD_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4046", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4047_COMISSAO_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "4047", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3309-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4048_SINISTRO_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4048", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4049_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2753", "FG02 - PROC25 - Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3325-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200326.txt");

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
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4050_COMISSAO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Comissao, "4050", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3309-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4051_SINISTRO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4051", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3231-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

    }
}
