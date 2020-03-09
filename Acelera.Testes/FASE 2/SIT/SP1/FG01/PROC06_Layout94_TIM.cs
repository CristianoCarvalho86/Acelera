using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2330_CLIENTE_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.Cliente, "2330", "No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaClienteStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2331_PARC_EMISSAO_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2331", "No Header do arquivo PARC_EMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2332_EMS_COMISSAO_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.Comissao, "2332", "No Header do arquivo EMS_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.EMSCMS-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaComissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2333_OCR_COBRANCA_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2333", "No Header do arquivo OCR_COBRANCA no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9996-20191227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.COBRANCA-EV-/*R*/-20191227.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaOCRCobrancaStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2334_LANCTO_COMISSAO_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2334", "No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaLanctoComissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2335_SINISTRO_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2335", "No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.SINISTRO-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaSinistroStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2325_CLIENTE_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2325", "No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_NASCIMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaClienteStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2326_PARC_EMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2326", "No Body do arquivo PARC_EMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_REFERENCIA DT_PROPOSTA DT_EMISSAO DT_EMISSAO_ORIGINAL");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_REFERENCIA", "32131234");
            AlterarLinha(0,"DT_PROPOSTA", "32131234");
            AlterarLinha(0,"DT_EMISSAO", "32131234");
            AlterarLinha(0,"DT_EMISSAO_ORIGINAL", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2327_OCR_COBRANCA_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2327", "No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9996-20191227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.COBRANCA-EV-/*R*/-20191227.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaOCRCobrancaStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Body do arquivo LANCTO_COMISSAO nos campos abaixo informar data inválida (Ex. 32131234) DT_PAGAMENTO DT_BAIXA
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2328_LANCTO_COMISSAO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2328", "No Header do arquivo LANCTO_COMISSAO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_PAGAMENTO", "32131234");
            AlterarLinha(0, "DT_BAIXA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaLanctoComissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2329_SINISTRO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2329", "No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "32131234");
            AlterarLinha(0, "DT_AVISO", "32131234");
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.SINISTRO-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaSinistroStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2500_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2501_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2502_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2503_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2504_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2505_SINISTRO()
        {
        }

    }
}
