using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC35_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        ///  Informar campo negativo NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2810_PARC_EMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2810", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_JUROS", "-100.10");
            AlterarLinha(2, "VL_DESCONTO", "-100.10");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "-100.10");
            AlterarLinha(2, "VL_IOF", "-100.10");
            AlterarLinha(2, "VL_ADIC_FRACIONADO", "-100.10");
            AlterarLinha(2, "VL_CUSTO_APOLICE", "-100.10");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "-100.10");
            AlterarLinha(2, "VL_TAXA_MOEDA", "-100.10");
                   
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(8,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2812_COMISSAO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2812", "FG02 - PROC35 - Informar campo CD_ITEM, VL_COMISSAO negativo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_COMISSAO", "-25.50");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.EMSCMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2813_COBRANCA_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2813", "FG02 - PROC35 - Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO negativo");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_PAGO", "-208.54");
            AlterarLinha(0, "VL_MULTA", "-105");
            AlterarLinha(0, "VL_IOF_RETIDO", "-200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.COBRANCA-EV-/*R*/-20191128.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(3, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo negativo NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2815_PARC_EMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2815", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_JUROS", "100.10");
            AlterarLinha(2, "VL_DESCONTO", "100.10");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "100.10");
            AlterarLinha(2, "VL_IOF", "100.10");
            AlterarLinha(2, "VL_ADIC_FRACIONADO", "100.10");
            AlterarLinha(2, "VL_CUSTO_APOLICE", "100.10");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "100.10");
            AlterarLinha(2, "VL_TAXA_MOEDA", "100.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2817_COMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2817", "FG02 - PROC35 - Informar campo CD_ITEM, VL_COMISSAO positivo");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_COMISSAO", "25.50");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.EMSCMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO positivos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2818_COBRANCA_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2818", "FG02 - PROC35 - Informar campo VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO positivo");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "VL_PREMIO_PAGO", "208.54");
            AlterarLinha(0, "VL_MULTA", "105");
            AlterarLinha(0, "VL_IOF_RETIDO", "200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.COBRANCA-EV-/*R*/-20191128.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true,"35");
            ValidarTeste();
        }

    }
}
