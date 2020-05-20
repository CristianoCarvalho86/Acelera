using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC35_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        ///  Informar campo negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2802_PARC_EMISSAO_AUTO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2802", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            AlterarLinha(2, "VL_JUROS", "-20");
            AlterarLinha(2, "VL_DESCONTO", "-20");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "-20");
            AlterarLinha(2, "VL_IOF", "-20");
            AlterarLinha(2, "VL_ADIC_FRACIONADO", "-20");
            AlterarLinha(2, "VL_CUSTO_APOLICE", "-20");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "-20");
            AlterarLinha(2, "VL_TAXA_MOEDA", "-20");
            AlterarLinha(2, "VL_LMI", "-20");
            AlterarLinha(2, "VL_IS", "-20");
            AlterarLinha(2, "VL_PERCENTUAL_COSSEGURO", "-20");
            AlterarLinha(2, "VL_PREMIO_CEDIDO", "-20");
            AlterarLinha(2, "VL_COMISSAO_CEDIDO", "-20");
            AlterarLinha(2, "VL_FRANQUIA", "-20");
            AlterarLinha(2, "VL_PERC_FATOR", "-20");
            AlterarLinha(2, "VL_PERC_BONUS", "-20");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC35");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(15 ,"35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_OCORRENCIA, NR_PARCELA, VL_DESCONTO negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2805_COBRANCA_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2805", "FG02 - PROC35 - Informar campo NR_PARCELA, CD_OCORRENCIA, VL_DESCONTO negativo");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_DESCONTO", "-200.10");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2806_PARC_EMISSAO_AUTO_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2806", "FG02 - PROC35 - Informar campo negativo");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "VL_JUROS", "20");
            AlterarLinha(2, "VL_DESCONTO", "20");
            AlterarLinha(2, "VL_PREMIO_LIQUIDO", "20");
            AlterarLinha(2, "VL_IOF", "20");
            AlterarLinha(2, "VL_ADIC_FRACIONADO", "20");
            AlterarLinha(2, "VL_CUSTO_APOLICE", "20");
            AlterarLinha(2, "VL_PREMIO_TOTAL", "20");
            AlterarLinha(2, "VL_TAXA_MOEDA", "20");
            AlterarLinha(2, "VL_LMI", "20");
            AlterarLinha(2, "VL_IS", "20");
            AlterarLinha(2, "VL_PERCENTUAL_COSSEGURO", "20");
            AlterarLinha(2, "VL_PREMIO_CEDIDO", "20");
            AlterarLinha(2, "VL_COMISSAO_CEDIDO", "20");
            AlterarLinha(2, "VL_FRANQUIA", "20");
            AlterarLinha(2, "VL_PERC_FATOR", "20");
            AlterarLinha(2, "VL_PERC_BONUS", "20");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo CD_CLIENTE positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2807_CLIENTE_CDCLIENTE_POSITIVO()
        {
            IniciarTeste(TipoArquivo.Cliente, "2807", "FG02 - PROC35 - Informar campo CD_CLIENTE positivo");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_CLIENTE", "2005");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "35");
            ValidarTeste();
        }

        /// <summary>
        ///  Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2808_COMISSAO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Comissao, "2808", "FG02 - PROC35 - Informar campo NR_SEQUENCIAL_EMISSAO, NR_PARCELA positivo");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "2");
            AlterarLinha(2, "NR_PARCELA", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.txt");

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
        ///  Informar campo CD_OCORRENCIA, NR_PARCELA, VL_DESCONTO positivo
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2809_COBRANCA_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2809", "FG02 - PROC35 - Informar campo NR_PARCELA, CD_OCORRENCIA, VL_DESCONTO positivo");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_OCORRENCIA", "20");
            AlterarLinha(2, "NR_PARCELA", "2");
            AlterarLinha(2, "VL_DESCONTO", "200.10");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
