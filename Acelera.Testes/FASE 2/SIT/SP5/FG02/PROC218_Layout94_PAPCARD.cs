using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC218_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3749_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3749", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1920-20200208.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P",false));
            RemoverLinhasExcetoAsPrimeiras(1);

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
        public void SAP_3750_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3750", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1935-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", false));
            RemoverLinhasExcetoAsPrimeiras(1);
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
        public void SAP_3751_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3751", "FG02 - PROC218 -  Informar CD_TIPO_COMISSAO=R e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", false));
            RemoverLinhasExcetoAsPrimeiras(1);
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
        public void SAP_3752_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3752", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1926-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "R", true));
            RemoverLinhasExcetoAsPrimeiras(1);
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
        public void SAP_3753_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3753", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1920-20200208.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "C", true));
            RemoverLinhasExcetoAsPrimeiras(1);
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
        public void SAP_3754_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3754", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=R e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1917-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA") ,"R", true));
            RemoverLinhasExcetoAsPrimeiras(1);
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
