using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC401_Layout94_Pompeia : TestesFG00
    {
        /// <summary>
        /// Importar arquivo sem hifen entre a primeira e segunda partes. Ex.: C01.PARCEIRO.CLIENTEEV-1927-20200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2630_CLIENTE_HifenDif()
        {
            IniciarTeste(TipoArquivo.Cliente, "2630", "Importar arquivo sem hifen entre a primeira e segunda partes.");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1924-20200210.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.CLIENTEEV-/*R*/-20200210.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }

        /// <summary>
        /// Importar arquivo sem hifen entre a segunda e terceira partes. Ex.: C01.PARCEIRO.CLIENTE-EV1927-20200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2631_PARC_EMISSAO_HifenDif()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2631", "Importar arquivo sem hifen entre a segunda e terceira partes");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.PARCEMS-EV/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaClienteStage>( false);
        }

        /// <summary>
        /// Importar arquivo sem hifen entre a terceira e quarta partes Ex.: C01.PARCEIRO.CLIENTE-EV-192720200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2632_EMS_COMISSAO_HifenDif()
        {
            IniciarTeste(TipoArquivo.Comissao, "2632", "Importar arquivo sem hifen entre a terceira e quarta partes");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1926-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.EMSCMS-EV-/*R*/20200210.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaClienteStage>( false);
        }

        /// <summary>
        /// Importar arquivo sem hifen na nomenclatura. Ex.: C01.PARCEIRO.CLIENTEEV192720200211.TXT
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2633_OCR_COBRANCA_HifenDif()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2633", "Importar arquivo sem hifen na nomenclatura");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.COBRANCAEV/*R*/20191128.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaClienteStage>( false);
        }

        /// <summary>
        /// Importar arquivo com número de partes separadas por hifen na nomenclatura diferente de 4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2634_LANCTO_COMISSAO_HifenDif()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2634", "Importar arquivo com número de partes separadas por hifen na nomenclatura diferente de 4");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9999-20190531.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV/*R*/20190531.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaLanctoComissaoStage>(false);
        }

        /// <summary>
        /// Importar arquivo com número de partes separadas por hifen na nomenclatura diferente de 4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2635_SINISTRO_HifenDif()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2635", "Importar arquivo com número de partes separadas por hifen na nomenclatura diferente de 4");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200211.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA-SINISTRO-EV/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, false);

        }

        /// <summary>
        ///  CLIENTE - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2648_CLIENTE()
        {
        }

        /// <summary>
        ///  PARC_EMISSAO  - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2649_PARC_EMISSAO()
        {
        }

        /// <summary>
        ///  COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2650_COMISSAO()
        {
        }

        /// <summary>
        ///  OCR_COBRANCA - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2651_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  LANCTO_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2652_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  SINISTRO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2637_SINISTRO()
        {
        }
    }
}
