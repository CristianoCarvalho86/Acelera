using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC218_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3731_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3731", "FG02 - PROC218 - Informar CD_TIPO_COMISSAO=P e corretor que não está parametizado para esse CD_TIPO_REMUNERACAO na tabela TAB_PRM_REMUNERACAO_7013");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "P");
            AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao("P",false));

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
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3712_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3712", "FG02 - PROC218 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1820-20200201.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -10.00M));

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
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3713_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3713", "FG02 - PROC218 - Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1820-20200201.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 0.01M));

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
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3714_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3714", "FG02 - PROC218 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1820-20200201.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 10.00M));

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
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3715_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.Comissao, "3715", "FG02 - PROC218 - Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1820-20200201.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

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
