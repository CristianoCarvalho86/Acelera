using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2228_CLIENTE_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2228", "FG01 - PROC5 - No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO EN_BAIRRO EN_CIDADE EN_UF EN_CEP EN_PAIS TIPO SEXO DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "");
            AlterarLinha(0, "NM_CLIENTE", "");
            AlterarLinha(0, "NR_CNPJ_CPF", "");
            AlterarLinha(0, "EN_ENDERECO", "");
            AlterarLinha(0, "EN_NUMERO", "");
            AlterarLinha(0, "EN_BAIRRO", "");
            AlterarLinha(0, "EN_CIDADE", "");
            AlterarLinha(0, "EN_UF", "");
            AlterarLinha(0, "EN_CEP", "");
            AlterarLinha(0, "EN_PAIS", "");
            AlterarLinha(0, "TIPO", "");
            AlterarLinha(0, "SEXO", "");
            AlterarLinha(0, "DT_NASCIMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: 
        /// CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO 
        /// CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA 
        /// CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2229_PARC_EMISSAO_AUTO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2229", "FG01 - PROC5 - No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA DT_REFERENCIA NR_PROPOSTA DT_PROPOSTA DT_EMISSAO DT_INICIO_VIGENCIA DT_FIM_VIGENCIA");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "");
            AlterarLinha(0, "CD_SEGURADORA", "");
            AlterarLinha(0, "CD_SUCURSAL", "");
            AlterarLinha(0, "CD_CORRETOR", "");
            AlterarLinha(0, "CD_TIPO_OPERACAO", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "");
            AlterarLinha(0, "CD_FORMA_PAGTO", "");
            AlterarLinha(0, "CD_CATEGORIA", "");
            AlterarLinha(0, "CD_FRANQUIA", "");
            AlterarLinha(0, "CD_SUSEP_CONTRATO", "");
            AlterarLinha(0, "CD_SISTEMA", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "CD_COBERTURA", "");
            AlterarLinha(0, "CD_ITEM", "");
            AlterarLinha(0, "CD_CLIENTE", "");
            AlterarLinha(0, "CD_MOEDA", "");
            AlterarLinha(0, "DT_REFERENCIA", "");
            AlterarLinha(0, "NR_PROPOSTA", "");
            AlterarLinha(0, "DT_PROPOSTA", "");
            AlterarLinha(0, "DT_EMISSAO", "");
            AlterarLinha(0, "DT_INICIO_VIGENCIA", "");
            AlterarLinha(0, "DT_FIM_VIGENCIA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: 
        /// CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM CD_TIPO_COMISSAO 
        /// CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2230_EMS_COMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Comissao, "2230", "FG01 - PROC5 - No Body do arquivo EMS_COMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM CD_TIPO_COMISSAO CD_COBERTURA VL_COMISSAO VL_BASE_CALCULO PC_COMISSAO PC_PARTICIPACAO CD_SISTEMA");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "");
            AlterarLinha(0, "CD_SEGURADORA", "");
            AlterarLinha(0, "CD_CORRETOR", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "CD_ITEM", "");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "");
            AlterarLinha(0, "CD_COBERTURA", "");
            AlterarLinha(0, "VL_COMISSAO", "");
            AlterarLinha(0, "VL_BASE_CALCULO", "");
            AlterarLinha(0, "PC_COMISSAO", "");
            AlterarLinha(0, "PC_PARTICIPACAO", "");
            AlterarLinha(0, "CD_SISTEMA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: 
        /// CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_OCORRENCIA DT_OCORRENCIA VL_PREMIO_PAGO CD_SISTEMA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2231_OCR_COBRANCA_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2231", "FG01 - PROC5 - No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_OCORRENCIA DT_OCORRENCIA VL_PREMIO_PAGO CD_SISTEMA");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "CD_OCORRENCIA", "");
            AlterarLinha(0, "DT_OCORRENCIA", "");
            AlterarLinha(0, "VL_PREMIO_PAGO", "");
            AlterarLinha(0, "CD_SISTEMA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_RAMO CD_CORRETOR CD_CONTRATO NR_SEQ_EMISSAO CD_TIPO_COMISSAO NR_PARCELA NR_APOLICE NR_ENDOSSO CD_EXTRATO_COMISSAO NR_MES_REFERENCIA CD_LANCAMENTO VL_COMISSAO_PAGO DT_PAGAMENTO DT_BAIXA CD_SISTEMA CD_TIPO_LANCAMENTO
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2232_LANCTO_COMISSAO_SemCampObrig_Body()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }


        /// <summary>
        /// No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2224_EMS_COMISSAO_SemCampObrig_Header()
        {
            IniciarTeste(TipoArquivo.Comissao, "2224", "FG01 - PROC5 - No Header do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NM_ARQ", "");
            AlterarHeader("DT_ARQ", "");
            AlterarHeader("NR_ARQ", "");
            AlterarHeader("NM_BRIDGE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2225_OCR_COBRANCA_SemCampObrig_Header()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2225", "FG01 - PROC5 - No Header do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NM_ARQ", "");
            AlterarHeader("DT_ARQ", "");
            AlterarHeader("NR_ARQ", "");
            AlterarHeader("NM_BRIDGE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

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
        /// No Header do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2226_LANCTO_COMISSAO_SemCampObrig_Header()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2223_PARC_EMISSAO_AUTO_SemCampObrig_Header()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2223", "FG01 - PROC5 - No Header do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NM_ARQ", "");
            AlterarHeader("DT_ARQ", "");
            AlterarHeader("NR_ARQ", "");
            AlterarHeader("NM_BRIDGE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2222_CLIENTE_SemCampObrig_Header()
        {
            IniciarTeste(TipoArquivo.Cliente, "2222", "FG01 - PROC5 - No Header do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ DT_ARQ NR_ARQ NM_BRIDGE");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NM_ARQ", "");
            AlterarHeader("DT_ARQ", "");
            AlterarHeader("NR_ARQ", "");
            AlterarHeader("NM_BRIDGE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

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
        /// No Trailler do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2234_CLIENTE_SemCampObrig_Trailler()
        {
            IniciarTeste(TipoArquivo.Cliente, "2234", "FG01 - PROC5 - No Trailler do arquivo CLIENTE não informar valor nos seguintes campos: NM_ARQ");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("NM_ARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

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
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: 
        /// NR_APOLICE NR_ENDOSSO DT_VENCIMENTO VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA 
        /// CD_PRODUTO ID_TRANSACAO CD_UF_RISCO CD_MODALIDADE CD_MODELO ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS CD_CLASSE_BONUS SEXO_CONDUTOR 
        /// DT_NASC_CONDUTOR TEMPO_HAB CD_UTILIZACAO CEP_UTILIZACAO CEP_PERNOITE 
        /// No Trailler do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2235_PARC_EMISSAO_AUTO_SemCampObrig_Body_Trailler()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2235", "FG01 - PROC5 - No Body do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NR_APOLICE NR_ENDOSSO DT_VENCIMENTO VL_PREMIO_LIQUIDO VL_IOF VL_PREMIO_TOTAL VL_TAXA_MOEDA CD_STATUS_EMISSAO VL_IS VL_FRANQUIA CD_PRODUTO ID_TRANSACAO CD_UF_RISCO CD_MODALIDADE CD_MODELO ANO_MODELO VL_PERC_FATOR VL_PERC_BONUS CD_CLASSE_BONUS SEXO_CONDUTOR DT_NASC_CONDUTOR TEMPO_HAB CD_UTILIZACAO CEP_UTILIZACAO CEP_PERNOITE No Trailler do arquivo PARC_EMISSAO_AUTO não informar valor nos seguintes campos: NM_ARQ");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_APOLICE", "");
            AlterarLinha(1, "NR_ENDOSSO", "");
            AlterarLinha(1, "DT_VENCIMENTO", "");
            AlterarLinha(1, "VL_PREMIO_LIQUIDO", "");
            AlterarLinha(1, "VL_IOF", "");
            AlterarLinha(1, "VL_PREMIO_TOTAL", "");
            AlterarLinha(1, "VL_TAXA_MOEDA", "");
            AlterarLinha(1, "CD_STATUS_EMISSAO", "");
            AlterarLinha(1, "VL_IS", "");
            AlterarLinha(1, "VL_FRANQUIA", "");
            AlterarLinha(1, "ID_TRANSACAO", "");
            AlterarLinha(1, "CD_UF_RISCO", "");
            AlterarLinha(1, "CD_MODALIDADE", "");
            AlterarLinha(1, "CD_MODELO", "");
            AlterarLinha(1, "ANO_MODELO", "");
            AlterarLinha(1, "VL_PERC_FATOR", "");
            AlterarLinha(1, "VL_PERC_BONUS", "");
            AlterarLinha(1, "CD_CLASSE_BONUS", "");
            AlterarLinha(1, "SEXO_CONDUTOR", "");
            AlterarLinha(1, "DT_NASC_CONDUTOR", "");
            AlterarLinha(1, "TEMPO_HAB", "");
            AlterarLinha(1, "CD_UTILIZACAO", "");
            AlterarLinha(1, "CEP_UTILIZACAO", "");
            AlterarLinha(1, "CEP_PERNOITE", "");
            AlterarFooter("NM_ARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("5");
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2236_PARC_EMS_COMISSAO_SemCampObrig_Trailler()
        {
            IniciarTeste(TipoArquivo.Comissao, "2236", "FG01 - PROC5 - No Trailler do arquivo EMS_COMISSAO não informar valor nos seguintes campos: NM_ARQ");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("NM_ARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT");

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
        /// No Trailler do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2237_OCR_COBRANCA_SemCampObrig_Trailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2237", "FG01 - PROC5 - No Trailler do arquivo OCR_COBRANCA não informar valor nos seguintes campos: NM_ARQ");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("NM_ARQ", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

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
        /// No Trailler do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: NM_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2238_LANCTO_COMISSAO_SemCampObrig_Trailler()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2475_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2476_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2477_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2478_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2479_LANCTO_COMISSAO()
        {
        }

    }
}
