using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1056_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3862_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3862", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3276-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TIPO_EMISSAO", dados.ObterCdTipoEmissao(TipoArquivo.ParcEmissao, false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200323.txt");

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
        /// Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3863_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3863", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3244-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200321.txt");

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
        public void SAP_3864_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3864", "FG02 - PROC1056 - Informar CD_TIPO_EMISSAO parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_TIPO_EMISSAO", dados.ObterCdTipoEmissao(TipoArquivo.ParcEmissao, true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200319.txt");

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
