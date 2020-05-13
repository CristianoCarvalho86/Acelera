using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC25_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4040_PARC_EMISSAO_CD_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4040", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "25");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4041_COMISSAO_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "4041", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3258-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_RAMO", dados.ObterRamo(false));
            RemoverLinhasExcetoAsPrimeiras(1);


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC25");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "25");
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4042_SINISTRO_RAMO_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4042", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

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
            ValidarTabelaDeRetorno(1, "25");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4043_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4043", "FG02 - PROC25 - Informar no campo CD_RAMO valor parametrizado na tabela TAB_PRM_RAMO_7002");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(5, "CD_RAMO", dados.ObterRamo(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "25");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4044_COMISSAO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Comissao, "4044", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3258-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_RAMO", dados.ObterRamo(true));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "25");
            ValidarTeste();
        }

        /// <summary>
        /// Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4045_SINISTRO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4045", "FG02 - PROC25 - Informar no campo CD_RAMO valor diferente do parametrizado na tabela TAB_PRM_RAMO_7002");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

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
            ValidarTabelaDeRetorno(true, "25");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

    }
}
