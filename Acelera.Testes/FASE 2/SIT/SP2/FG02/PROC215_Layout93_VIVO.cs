using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC215_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3711_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3711", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200201.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_3712_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3712", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), -10.00M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_3713_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3713", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF SUPERIOR em 0.01 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 0.01M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_3714_VL_PREMIO_TOTAL_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3714", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF inferior em 10.00 ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarValores(SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF"), 10.00M));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_3715_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3715", "FG02 - PROC215 - Informar VL_PREMIO_LIQUIDO + VL_IOF igual ao VL_PREMIO_TOTAL");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_TOTAL", SomarDoisCamposDoArquivo(0, "VL_PREMIO_LIQUIDO", "VL_IOF").ValorFormatado());
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "215");
            ValidarTeste();

        }


    }
}
