using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC24_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4010_PARC_EMISSAO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4010", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200210.txt");

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
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4011_COMISSAO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "4011", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.EMSCMS-EV-1920-20200208.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

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
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4012_SINISTRO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4012", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", dados.ObterCDCobertura(false));

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
        /// Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4013_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4013", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "24");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4014_COMISSAO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Comissao, "4014", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.EMSCMS-EV-1935-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4015_SINISTRO_Sem_Critica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4015", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_COBERTURA", dados.ObterCDCobertura(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "24");
            ValidarTeste();

        }

    }
}
