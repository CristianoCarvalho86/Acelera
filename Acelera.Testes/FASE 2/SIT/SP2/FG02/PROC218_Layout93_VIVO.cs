using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC218_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3731_CD_TIPO_COMISSAO_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3731", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("P",false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC218");

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
        public void SAP_3732_CD_TIPO_COMISSAO_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3732", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("C", false));

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
        public void SAP_3733_CD_TIPO_COMISSAO_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3733", "FG02 - PROC218 -  Informar CD_TIPO_COMISSAO=R e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("R", false));

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
        public void SAP_3734_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3734", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("R", true));

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
        /// Informar CD_TIPO_COMISSAO=C e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3735_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3735", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=C e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "C");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("C", true));

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
        /// Informar CD_TIPO_COMISSAO=R e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3736_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3736", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=R e corretor QUE ESTÁ Parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("R", true));

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


    }
}
