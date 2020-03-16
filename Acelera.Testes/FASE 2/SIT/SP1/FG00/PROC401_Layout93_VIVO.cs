using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC401_Layout93_VIVO : TestesFG00
    {
        /// <summary>
        /// Não informar ponto entre a terceira e quarta partes. Ex.: C01.POMPEIA.CLIENTE-EV-1927-20200211TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2619_EMS_COMISSAO_NomeIncorreto()
        {
            IniciarTeste(TipoArquivo.Comissao, "2619", "FG00 - PROC401 - Não informar ponto entre a terceira e quarta partes.");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200211TXT"));

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar ponto na nomenclatura do arquivo. Ex.: C01POMPEIACLIENTE-EV-1927-20200211TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2620_OCR_COBRANCA_NomeIncorreto()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2620", "FG00 - PROC401 - Não informar ponto na nomenclatura do arquivo. Ex.: C01POMPEIACLIENTE-EV-1927-20200211TXT");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01VIVOCOBRANCA-EV-/*R*/-20200211TXT"));

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar ponto na nomenclatura do arquivo. Ex.: C01POMPEIACLIENTE-EV-1927-20200211TXT
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2621_LANCTO_COMISSAO_NomeIncorreto()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        
        /// <summary>
        /// Não informar ponto entre a segunda e terceira partes. Ex.: C01.POMPEIACLIENTE-EV-1927-20200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2618_PARC_EMISSAO_AUTO_NomeIncorreto()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2618", "FG00 - PROC401 - Não informar ponto entre a segunda e terceira partes. Ex.: C01.POMPEIACLIENTE-EV-1927-20200211.TXT");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVOPARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// Não informar ponto entre a primeira e segunda partes. Ex.: C01POMPEIA.CLIENTE-EV-1927-20200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2617_CLIENTE_NomeIncorreto()
        {
            IniciarTeste(TipoArquivo.Cliente, "2617", "FG00 - PROC401 - Não informar ponto entre a primeira e segunda partes. Ex.: C01POMPEIA.CLIENTE-EV-1927-20200211.TXT");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  CLIENTE - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2642_CLIENTE_()
        {
        }

        /// <summary>
        ///  LANCTO_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2646_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  OCR_COBRANCA - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2645_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  EMS_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2644_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  PARC_EMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2644_PARC_EMISSAO()
        {
        }

    }
}
