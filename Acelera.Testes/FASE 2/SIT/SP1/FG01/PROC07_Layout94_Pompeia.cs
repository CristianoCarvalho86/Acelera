using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC07_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_CLIENTE  
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2410_CLIENTE_SemCampoNum_Header_Body_Trailler()
        {
             IniciarTeste(TipoArquivo.Cliente, "2410", "FG01 - PROC7 - No Body do arquivo CLIENTE não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_CLIENTE");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT");

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
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS TEMPO_HAB CEP_UTILIZACAO CEP_PERNOITE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2411_PARC_EMISSAO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2411", "FG01 - PROC7 - No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_CLIENTE VL_JUROS VL_DESCONTO VL_PREMIO_LIQUIDO VL_IOF VL_ADIC_FRACIONADO VL_CUSTO_APOLICE VL_PREMIO_TOTAL VL_TAXA_MOEDA VL_LMI VL_IS VL_PERCENTUAL_COSSEGURO VL_PREMIO_CEDIDO VL_COMISSAO_CEDIDO VL_FRANQUIA ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS TEMPO_HAB CEP_UTILIZACAO CEP_PERNOITE");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_CLIENTE", "!");
            AlterarLinha(0, "VL_JUROS", "A");
            AlterarLinha(0, "VL_DESCONTO", "A");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "!,");
            AlterarLinha(0, "VL_IOF", ",");
            AlterarLinha(0, "VL_ADIC_FRACIONADO", "!!");
            AlterarLinha(0, "VL_CUSTO_APOLICE", "A");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "A");
            AlterarLinha(0, "VL_TAXA_MOEDA", "A,");
            AlterarLinha(0, "VL_LMI", "A");
            AlterarLinha(0, "VL_IS", "A");
            AlterarLinha(0, "VL_PERCENTUAL_COSSEGURO", "A");
            AlterarLinha(0, "VL_PREMIO_CEDIDO", "A");
            AlterarLinha(0, "VL_COMISSAO_CEDIDO", "!!");
            AlterarLinha(0, "VL_FRANQUIA", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO 
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2412_EMS_COMISSAO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.Comissao, "2412", "FG01 - PROC7 - No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO ");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "A");
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_ITEM", "A");
            AlterarLinha(0, "VL_COMISSAO", "A");
            AlterarLinha(0, "VL_BASE_CALCULO", "A");
            AlterarLinha(0, "PC_COMISSAO", "A");
            AlterarLinha(0, "PC_PARTICIPACAO", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.EMSCMS-EV-/*R*/-20200211.TXT");

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
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2413_OCR_COBRANCA_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2413", "FG01 - PROC7 - No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos CD_TIPO_MOVIMENTO CD_AVISO CD_RAMO CD_CLIENTE CD_MOVIMENTO VL_MOVIMENTO VL_TAXA_PAGTO EN_CEP_BENEFICIARIO CD_BANCO_SEG NR_AGENCIA_SEG NR_CONTA_SEG NR_SEQ_MOV VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1694-20191128.txt"));

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
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

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
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_OCORRENCIA VL_DESCONTO VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO VL_ADC_FRC VL_ADC_FRC_DVI VL_MULTA_DEVIDO VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2414_LANCTO_COMISSAO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2414", "FG01 - PROC7 - No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_OCORRENCIA VL_DESCONTO VL_PREMIO_PAGO VL_MULTA VL_IOF_RETIDO VL_ADC_FRC VL_ADC_FRC_DVI VL_MULTA_DEVIDO VL_JUROS_COBRADO VL_JUROS_DEVIDO VL_DIF_PREMIO");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NR_PARCELA", "A");
            AlterarLinha(0, "CD_EXTRATO_COMISSAO", "A");
            AlterarLinha(0, "CD_LANCAMENTO", "A");
            AlterarLinha(0, "VL_COMISSAO_PAGO", "A");
            AlterarLinha(0, "CD_TIPO_LANCAMENTO", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("7");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2415_SINISTRO_SemCampoNum_Header_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2415", "FG01 - PROC7 - No Body do arquivo SINISTRO não informar valor nos seguintes campos, ou seja, campos em branco, respeitando a tamanho do campos NR_PARCELA CD_EXTRATO_COMISSAO CD_LANCAMENTO VL_COMISSAO_PAGO CD_TIPO_LANCAMENTO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "A");
            AlterarLinha(0, "CD_AVISO", "A");
            AlterarLinha(0, "CD_RAMO", "A");
            AlterarLinha(0, "CD_CLIENTE", "A");
            AlterarLinha(0, "CD_MOVIMENTO", "A");
            AlterarLinha(0, "VL_MOVIMENTO", "A");
            AlterarLinha(0, "VL_TAXA_PAGTO", "A");
            AlterarLinha(0, "EN_CEP_BENEFICIARIO", "A");
            AlterarLinha(0, "CD_BANCO_SEG", "A");
            AlterarLinha(0, "NR_AGENCIA_SEG", "A");
            AlterarLinha(0, "NR_SEQ_MOV", "A");
            AlterarLinha(0, "VL_CEDIDO", "A");
            AlterarLinha(0, "CD_BANCO", "A");
            AlterarLinha(0, "NR_AGENCIA", "A");
            AlterarLinha(0, "NR_CONTA", "A");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

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
        public void SAP_2525_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2526_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2527_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2528_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2529_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds campos numéricos válidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2530_SINISTRO()
        {
        }

    }
}
