using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos: EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2393_CLIENTE_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2393", "FG01 - PROC5 - No Body do arquivo CLIENTE não informar valor nos seguintes campos: EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_BAIRRO", "");
            AlterarLinha(0, "EN_CIDADE", "");
            AlterarLinha(0, "EN_UF", "");
            AlterarLinha(0, "EN_CEP", "");
            AlterarLinha(0, "EN_PAIS", "");
            AlterarLinha(0, "TIPO", "");
            AlterarLinha(0, "SEXO", "");
            AlterarLinha(0, "DT_NASCIMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos: 
        /// DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA NR_APOLICE NR_ENDOSSO NR_DOCUMENTO DT_VENCIMENTO
        /// VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA CD_PRODUTO ID_TRANSACAO CD_UF_RISCO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2394_PARC_EMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2394", "FG01 - PROC5 - No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos: DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA NR_APOLICE NR_ENDOSSO NR_DOCUMENTO DT_VENCIMENTO VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA CD_PRODUTO ID_TRANSACAO CD_UF_RISCO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_REFERENCIA", "");
            AlterarLinha(0, "NR_PROPOSTA", "");
            AlterarLinha(0, "DT_PROPOSTA", "");
            AlterarLinha(0, "DT_EMISSAO", "");
            AlterarLinha(0, "DT_INICIO_VIGENCIA", "");
            AlterarLinha(0, "DT_FIM_VIGENCIA", "");
            AlterarLinha(0, "NR_APOLICE", "");
            AlterarLinha(0, "NR_ENDOSSO", "");
            AlterarLinha(0, "NR_DOCUMENTO", "");
            AlterarLinha(0, "DT_VENCIMENTO", "");
            AlterarLinha(0, "VL_PREMIO_LIQUIDO", "");
            AlterarLinha(0, "VL_IOF", "");
            AlterarLinha(0, "VL_PREMIO_TOTAL", "");
            AlterarLinha(0, "VL_TAXA_MOEDA", "");
            AlterarLinha(0, "CD_STATUS_EMISSAO", "");
            AlterarLinha(0, "VL_IS", "");
            AlterarLinha(0, "VL_FRANQUIA", "");
            AlterarLinha(0, "CD_PRODUTO", "");
            AlterarLinha(0, "ID_TRANSACAO", "");
            AlterarLinha(0, "CD_UF_RISCO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: 
        /// CD_TIPO_COMISSAO CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2395_EMS_COMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Comissao, "2395", "FG01 - PROC5 - No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: CD_TIPO_COMISSAO CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1974-20200227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "");
            AlterarLinha(0, "CD_COBERTURA", "");
            AlterarLinha(0, "VL_COMISSAO", "");
            AlterarLinha(0, "VL_BASE_CALCULO", "");
            AlterarLinha(0, "PC_COMISSAO", "");
            AlterarLinha(0, "PC_PARTICIPACAO", "");
            AlterarLinha(0, "CD_SISTEMA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.EMSCMS-EV-/*R*/-20200227.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: 
        /// CD_OCORRENCIA DT_OCORRENCIA VL_PREMIO_PAGO CD_SISTEMA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2396_OCR_COBRANCA_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2396", "FG01 - PROC5 - No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_OCORRENCIA DT_OCORRENCIA VL_PREMIO_PAGO CD_SISTEMA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "");
            AlterarLinha(0, "DT_OCORRENCIA", "");
            AlterarLinha(0, "VL_PREMIO_PAGO", "");
            AlterarLinha(0, "CD_SISTEMA", "");
            
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: 
        /// CD_EXTRATO_COMISSAO NR_MES_REFERENCIA CD_LANCAMENTO VL_COMISSAO_PAGO DT_PAGAMENTO DT_BAIXA CD_SISTEMA CD_TIPO_LANCAMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2397_LANCTO_COMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2397", "FG01 - PROC5 - No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_EXTRATO_COMISSAO NR_MES_REFERENCIA CD_LANCAMENTO VL_COMISSAO_PAGO DT_PAGAMENTO DT_BAIXA CD_SISTEMA CD_TIPO_LANCAMENTO");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_EXTRATO_COMISSAO", "");
            AlterarLinha(0, "NR_MES_REFERENCIA", "");
            AlterarLinha(0, "CD_LANCAMENTO", "");
            AlterarLinha(0, "VL_COMISSAO_PAGO", "");
            AlterarLinha(0, "DT_PAGAMENTO", "");
            AlterarLinha(0, "DT_BAIXA", "");
            AlterarLinha(0, "CD_SISTEMA", "");
            AlterarLinha(0, "CD_TIPO_LANCAMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: 
        /// NM_BENEFICIARIO EN_BENEFICIARIO EN_BAIRRO_BENEFICIARIO EN_CIDADE_BENEFICIARIO EN_UF_BENEFICIARIO EN_CEP_BENEFICIARIO EN_PAIS_BENEFICIARIO 
        /// DT_NASC_BENEFICIARIO CD_COBERTURA CD_MOEDA CD_SISTEMA VL_CEDIDO CD_TIPO_BENEFICIARIO NR_DOCTO_BENEFICIARIO CD_PRODUTO TP_RAMO_SINISTRO NR_ENDOSSO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2398_SINISTRO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2398", "FG01 - PROC5 - No Body do arquivo SINISTRO não informar valor nos seguintes campos: NM_BENEFICIARIO EN_BENEFICIARIO EN_BAIRRO_BENEFICIARIO EN_CIDADE_BENEFICIARIO EN_UF_BENEFICIARIO EN_CEP_BENEFICIARIO EN_PAIS_BENEFICIARIO DT_NASC_BENEFICIARIO CD_COBERTURA CD_MOEDA CD_SISTEMA VL_CEDIDO CD_TIPO_BENEFICIARIO NR_DOCTO_BENEFICIARIO CD_PRODUTO TP_RAMO_SINISTRO NR_ENDOSSO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "NM_BENEFICIARIO", "");
            AlterarLinha(0, "EN_BENEFICIARIO", "");
            AlterarLinha(0, "EN_BAIRRO_BENEFICIARIO", "");
            AlterarLinha(0, "EN_CIDADE_BENEFICIARIO", "");
            AlterarLinha(0, "EN_UF_BENEFICIARIO", "");
            AlterarLinha(0, "EN_CEP_BENEFICIARIO", "");
            AlterarLinha(0, "EN_PAIS_BENEFICIARIO", "");
            AlterarLinha(0, "DT_NASC_BENEFICIARIO", "");
            AlterarLinha(0, "CD_COBERTURA", "");
            AlterarLinha(0, "CD_MOEDA", "");
            AlterarLinha(0, "CD_SISTEMA", "");
            AlterarLinha(0, "VL_CEDIDO", "");
            AlterarLinha(0, "CD_TIPO_BENEFICIARIO", "");
            AlterarLinha(0, "NR_DOCTO_BENEFICIARIO", "");
            AlterarLinha(0, "CD_PRODUTO", "");
            AlterarLinha(0, "TP_RAMO_SINISTRO", "");
            AlterarLinha(0, "NR_ENDOSSO", "");
            
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

       


        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2487_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2488_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2489_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2490_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2491_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2492_SINISTRO()
        {
        }

    }
}
