using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1233_SINISTRO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1233", "FG00 - PROC91 - No Header do arquivo SINISTRO no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1232_LANCTO_COMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1232", "FG00 - PROC91 - No Header do arquivo LANCTO_COMISSAO no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.TXT"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1231_OCR_COBRANCA_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1231", "FG00 - PROC91 - No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9994-20191230.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.COBRANCA-EV-/*R*/-20191230.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1230_EMS_COMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "1230", "FG00 - PROC91 - No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200108.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.EMSCMS-EV-/*R*/-20200108.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1229_PARC_EMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1229", "FG00 - PROC91 - No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1228_CLIENTE_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Cliente, "1228", "FG00 - PROC91 - No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1312_CLIENTE_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1313_PARC_EMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1317_SINISTRO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1316_LANCTO_COMISSAO_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1315_OCR_COBRANCA_VERSAO_9_4()
        {
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO informar código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1314_EMS_COMISSAO_VERSAO_9_4()
        {
        }


    }
}
