using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC92_Layout93_VIVO : TestesFG00
    {

        /// <summary>
        ///  No Header do arquivo CLIENTE no campo VERSAO informar o código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2269_CLIENTE_VERSAO_9_4()
        {
            IniciarTeste(TipoArquivo.Cliente, "2269", "FG00 - PROC92 - No Header do arquivo CLIENTE no campo VERSAO informar o código 9.4");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader( "VERSAO", "9.4");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar o código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2270_PARC_EMISSAO_AUTO_VERSAO_9_5()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2270", "FG00 - PROC92 - o Header do arquivo PARC_EMISSAO_AUTO no campo VERSAO informar o código 9.5");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.5");
      
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo EMS_COMISSAO no campo VERSAO informar o código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2271_EMS_COMISSAO_VERSAO_9_6()
        {
            IniciarTeste(TipoArquivo.Comissao, "2271", "FG00 - PROC92 - No Header do arquivo EMS_COMISSAO no campo VERSAO informar o código 9.6");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.6");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo OCR_COBRANCA no campo VERSAO informar o código 9.4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2272_OCR_COBRANCA_VERSAO_9_8()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2272", " FG00 - PROC92 - No Header do arquivo OCR_COBRANCA no campo VERSAO informar o código 9.8");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.8");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar o código 9.4
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2273_LANCTO_COMISSAO_VERSAO_9_9()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2563_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2564_PARC_EMISSAO_AUTO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2565_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2566_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2567_LANCTO_COMISSAO()
        {
        }

    }
}
