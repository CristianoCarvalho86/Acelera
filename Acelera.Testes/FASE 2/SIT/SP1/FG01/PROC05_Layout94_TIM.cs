using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC05_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: 
        /// CD_RAMO CD_CORRETOR CD_CONTRATO NR_SEQ_EMISSAO CD_TIPO_COMISSAO NR_PARCELA NR_APOLICE NR_ENDOSSO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2323_LANCTO_COMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2323", "FG01 - PROC5 - No Body do arquivo LANCTO_COMISSAO não informar valor nos seguintes campos: CD_RAMO CD_CORRETOR CD_CONTRATO NR_SEQ_EMISSAO CD_TIPO_COMISSAO NR_PARCELA NR_APOLICE NR_ENDOSSO");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CORRETOR", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQ_EMISSAO", "");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "NR_APOLICE", "");
            AlterarLinha(0, "NR_ENDOSSO", "");

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
        /// No Body do arquivo COMISSAO não informar valor nos seguintes campos: 
        /// CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2321_COMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Comissao, "2321", "FG01 - PROC5 - No Body do arquivo COMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "");
            AlterarLinha(0, "CD_SEGURADORA", "");
            AlterarLinha(0, "CD_CORRETOR", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            AlterarLinha(0, "CD_ITEM", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT");

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
        /// No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2319_CLIENTE_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2319", "FG01 - PROC5 - No Body do arquivo CLIENTE não informar valor nos seguintes campos: CD_CLIENTE NM_CLIENTE NR_CNPJ_CPF EN_ENDERECO EN_NUMERO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "");
            AlterarLinha(0, "NM_CLIENTE", "");
            AlterarLinha(0, "NR_CNPJ_CPF", "");
            AlterarLinha(0, "EN_ENDERECO", "");
            AlterarLinha(0, "EN_NUMERO", "");
            
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.CLIENTE-EV-/*R*/-20200213.TXT");

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
        /// CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO 
        /// CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2320_PARC_EMISSAO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2320", "FG01 - PROC5 - No Body do arquivo PARC_EMISSAO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_RAMO CD_MOVTO_COBRANCA CD_SEGURADORA CD_SUCURSAL CD_CORRETOR CD_TIPO_OPERACAO CD_TIPO_EMISSAO CD_FORMA_PAGTO CD_CATEGORIA CD_FRANQUIA CD_SUSEP_CONTRATO CD_SISTEMA CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_COBERTURA CD_ITEM CD_CLIENTE CD_MOEDA");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200214.txt"));

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

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT");

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
        /// No Body do arquivo SINISTRO não informar valor nos seguintes campos: 
        /// CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2324_SINISTRO_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2324", "FG01 - PROC5 - No Body do arquivo SINISTRO não informar valor nos seguintes campos: CD_INTERNO_RESSEGURADOR CD_SEGURADORA CD_CORRETOR CD_RAMO CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA CD_ITEM");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", "");
            AlterarLinha(0, "CD_SEGURADORA", "");
            AlterarLinha(0, "CD_RAMO", "");
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQ_EMISSAO", "");
            AlterarLinha(0, "CD_ITEM", "");
  
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200213.TXT");

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
        /// No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2322_OCR_COBRANCA_SemCampObrig_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2322", "FG01 - PROC5 - No Body do arquivo OCR_COBRANCA não informar valor nos seguintes campos: CD_CONTRATO NR_SEQUENCIAL_EMISSAO NR_PARCELA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", "");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "");
            AlterarLinha(0, "NR_PARCELA", "");
            
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT");

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
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2481_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2482_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2483_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2484_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2485_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds os campos obrig. preenchidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2486_SINISTRO()
        {
        }

    }
}
