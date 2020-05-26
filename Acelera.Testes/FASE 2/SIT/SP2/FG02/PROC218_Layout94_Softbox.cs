using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC218_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3743_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3743", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-2752-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P",false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"218");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=C e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3744_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3744", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3163-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "218");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar CD_TIPO_COMISSAO=R e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3745_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3745", "FG02 - PROC218 -  Informar CD_TIPO_COMISSAO=R e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3180-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "218");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=P e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3746_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3746", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3197-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "218");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=C e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3747_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3747", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3213-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "218");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=R e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3748_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3748", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=R e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.EMSCMS-EV-3229-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "218");
            ValidarTeste();

        }


    }
}
