using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC92_Layout94_Pompeia : TestesFG00
    {

        /// <summary>
        ///  No Header do arquivo CLIENTE no campo VERSAO informar o código 6.9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2428_CLIENTE_VERSAO_6_9()
        {
            IniciarTeste(TipoArquivo.Cliente, "2428", "FG00 - PROC92 - No Header do arquivo CLIENTE no campo VERSAO informar o código 6.9");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "6.9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT");

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
        ///  No Header do arquivo PARC_EMISSAO no campo VERSAO informar o código 11
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2429_PARC_EMISSAO_VERSAO_1_1()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2429", "FG00 - PROC92 - No Header do arquivo PARC_EMISSAO no campo VERSAO informar o código 11");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "11");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");
            
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo EMS_COMISSAO no campo VERSAO informar o código 9.6
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2430_EMS_COMISSAO_VERSAO_9_6()
        {
            IniciarTeste(TipoArquivo.Comissao, "2430", "FG00 - PROC92 - No Header do arquivo EMS_COMISSAO no campo VERSAO informar o código 9.6");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1920-20200208.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.6");
            
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.EMSCMS-EV-/*R*/-20200208.TXT");

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
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO informar o código 9.8
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2431_OCR_COBRANCA_VERSAO_9_8()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2431", "FG00 - PROC92 - No Header do arquivo OCR_COBRANCA no campo VERSAO informar o código 9.8");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.8");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

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
        /// No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar o código 9.9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2432_LANCTO_COMISSAO_VERSAO_9_9()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2432", "FG00 - PROC92 -  No Header do arquivo LANCTO_COMISSAO no campo VERSAO informar o código 9.9");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  No Header do arquivo SINISTRO no campo VERSAO informar o código 9.9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2433_SINISTRO_VERSAO_9_9()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2433", "FG00 - PROC92 - No Header do arquivo SINISTRO no campo VERSAO informar o código 9.4");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200117.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9.9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200117.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2575_CLIENTE()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2576_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2577_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2578_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2579_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2580_SINISTRO()
        {
        }

        
    }
}
