using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC215_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3716_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3716", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3175-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"215");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3717_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3717", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -10.00M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "215");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3718_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3718", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3208-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "215");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3719_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3719", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3224-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 10.00M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "215");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3720_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3720", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "215");
            ValidarTeste();

        }


    }
}
