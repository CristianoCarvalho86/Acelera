using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC215_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3721_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3721", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200201.txt");

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
        public void SAP_3722_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3722", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

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
        public void SAP_3723_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3723", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3179-20200317.txt"));

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
        public void SAP_3724_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3724", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

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
        public void SAP_3725_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3725", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ToString());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }


    }
}
