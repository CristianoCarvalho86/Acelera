using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC400_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1293_SINISTRO_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1293", "FG00 - PROC400 - No Header do arquivo SINISTRO no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0002-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1292_LANCTO_COMISSAO_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1292", "FG00 - PROC400 - No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1291_OCR_COBRANCA_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1291", "FG00 - PROC400 - No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9994-20191230.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.COBRANCA-EV-/*R*/-20191230.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo COMISSAO no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1290_COMISSAO_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.Comissao, "1290", "FG00 - PROC400 - No Header do arquivo COMISSAO no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200109.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.EMSCMS-EV-/*R*/-20200109.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1289_PARC_EMISSAO_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1289", " FG00 - PROC400 - No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o valor TESTE respeitando a tamanho do campo Não alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1288_CLIENTE_NOMEARQ_TESTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "1288", "FG00 - PROC400 - No Header do arquivo CLIENTE no campo NOMEARQ informar o valor TESTE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("NOMEARQ", "TESTE");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Nome do arquivo diferente do header");
            ValidarTabelaDeRetorno("400");
            ValidarStages(false);
            ValidarTeste();
        }



        /// <summary>
        /// No Header do arquivo CLIENTE no campo NOMEARQ informar o código CLIENTE Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1354_CLIENTE_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo NOMEARQ informar o código PARCEMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1355_PARC_EMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo NOMEARQ informar o código EMSCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1356_EMS_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo NOMEARQ informar o código COBRANCA Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1357_OCR_COBRANCA_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo NOMEARQ informar o código LCTCMS Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1358_LANCTO_COMISSAO_NOMEARQ()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo NOMEARQ informar o código SINISTRO Não alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1359_SINISTRO_NOMEARQ()
        {
        }

    }
}
