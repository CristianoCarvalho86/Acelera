using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1056_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3859_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3859", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TIPO_EMISSAO", dados.ObterCdTipoEmissao(TipoArquivo.ParcEmissao, false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1056");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3860_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3860", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TIPO_EMISSAO", "18");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1056");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3861_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3861", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TIPO_EMISSAO", dados.ObterCdTipoEmissao(TipoArquivo.ParcEmissao, true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.txt");

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
