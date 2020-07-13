using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC07_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_CLIENTE  
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2251_CLIENTE_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.Cliente, "2251", "FG01 - PROC7 - No Body do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_CLIENTE");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "A");
            AlterarLinha(0, "NR_CNPJ_CPF", "17077754782");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos 
        /// NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO 
        /// VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS TEMPO_HAB CEP_UTILIZACAO CEP_PERNOITE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2252_PARC_EMISSAO_AUTO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2252", "FG01 - PROC7 - No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS TEMPO_HAB CEP_UTILIZACAO CEP_PERNOITE");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_CLIENTE", ",,");
            AlterarLinha(0, "VL_JUROS", ",,");
            AlterarLinha(0, "VL_DESCONTO", "!!");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "A");
            AlterarLinha(0, "VL_IOF", "A");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "A");
            AlterarLinha(0, "VL_CUSTO_APOLICE", "A");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "A");
            AlterarLinha(0, "VL_TAXA_MOEDA", ",");
            AlterarLinha(0, "VL_LMI", "A");
            AlterarLinha(0, "VL_IS", "A");
            AlterarLinha(0, "VL_PERCENTUAL_COSSEGURO", ",");
            AlterarLinha(0, "VL_PREMIO_CEDIDO", ",");
            AlterarLinha(0, "VL_COMISSAO_CEDIDO", ",");
            AlterarLinha(0, "VL_FRANQUIA", "A!");
            AlterarLinha(0, "ANO_MODELO", "A!");
            AlterarLinha(0, "VL_PERC_FATOR", ",");
            AlterarLinha(0, "VL_PERC_BONUS", ",");
            AlterarLinha(0, "TEMPO_HAB", ",");
            AlterarLinha(0, "CEP_UTILIZACAO", "!!");
            AlterarLinha(0, "CEP_PERNOITE", "A!");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos 
        /// NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO 
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2253_EMS_COMISSAO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.Comissao, "2253", "FG01 - PROC7 - No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO ");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200109.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "A");
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_ITEM", "A");
            AlterarLinha(0, "VL_COMISSAO", "A");
            AlterarLinha(0, "VL_BASE_CALCULO", "A");
            AlterarLinha(0, "PC_COMISSAO", "A");
            AlterarLinha(0, "PC_PARTICIPACAO", "A");
            RemoverLinhasExcetoAsPrimeiras(100);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200109.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos 
        /// CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV VL_CEDIDO 
        /// CD_BANCO NR_AGENCIA NR_CONTA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2254_OCR_COBRANCA_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2254", "FG01 - PROC7 - No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_OCORRENCIA", "A");
            AlterarLinha(0, "VL_DESCONTO", "A");
            AlterarLinha(0, "VL_PREMIO_PAGO", "A");
            AlterarLinha(0, "VL_MULTA", "$1");
            AlterarLinha(0, "VL_IOF_RETIDO", "*");
            AlterarLinha(0, "VL_ADC_FRC", "@!");
            AlterarLinha(0, "VL_ADC_FRC_DVI", "!");
            AlterarLinha(0, "VL_MULTA_DEVIDO", ",");
            AlterarLinha(0, "VL_JUROS_COBRADO", ",");
            AlterarLinha(0, "VL_JUROS_DEVIDO", "A");
            AlterarLinha(0, "VL_DIF_PREMIO", "A");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2513_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2514_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2515_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2516_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2517_LANCTO_COMISSAO()
        {
        }

    }
}
