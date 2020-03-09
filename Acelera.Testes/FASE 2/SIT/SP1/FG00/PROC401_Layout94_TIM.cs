using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC401_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// CLIENTE - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2624_CLIENTE_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Cliente, "2624", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0002-20200213.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.CLIENTE-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaParcEmissaoStage>( false);
        }

        /// <summary>
        /// PARC_EMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2625_PARC_EMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2625", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0003-20200213.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.PARCEMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaParcEmissaoStage>( false);
        }

        /// <summary>
        /// COMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2626_EMS_COMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Comissao, "2626", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0003-20200213.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.EMSCMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaComissaoStage>( false);
        }

        /// <summary>
        /// OCR_COBRANCA - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2627_OCR_COBRANCA_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2627", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9997-20191227.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.COBRANCA-EV-/*R*/-20191227.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaOCRCobrancaStage>( false);
        }

        /// <summary>
        /// LANCTO_COMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2628_LANCTO_COMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2628", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.LCTCMS-EV-/*R*/-20190531.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages<LinhaLanctoComissaoStage>(false);
        }

        /// <summary>
        /// SINISTRO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2629_SINISTRO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2629", "Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0002-20200214.txt"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.PARCEIRO.SINISTRO-EV-/*R*/-20200214.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
        }

        /// <summary>
        ///  LANCTO_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2640_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  SINISTRO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2641_SINISTRO()
        {
        }

        /// <summary>
        ///  OCR_COBRANCA - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2639_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  CLIENTE - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2636_CLIENTE()
        {
        }

        /// <summary>
        ///  EMS_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2638_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  PARC_EMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2637_PARC_EMISSAO()
        {
        }
    }
}
