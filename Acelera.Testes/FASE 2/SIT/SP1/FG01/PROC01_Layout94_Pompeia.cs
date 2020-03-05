using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC01_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2375_CLIENTE_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Cliente, "2375", "No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1924-20200210"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.CLIENTE-EV-/*R*/-20200210"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaClienteStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2376_PARC_EMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2376", "No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.PARCEMS-EV-/*R*/-20200210"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2377_EMS_COMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Comissao, "2377", "No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1917-20200207"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.EMSCMS-EV-/*R*/-20200207"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaComissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2378_OCR_COBRANCA_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2378", "No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1693-20191128"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaOCRCobrancaStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 9.3
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2379_LANCTO_COMISSAO_CD_TPA_9_3()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2380_SINISTRO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2380", "No Header do arquivo SINISTRO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.SINISTRO-EV-/*R*/-20191223"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaSinistroStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2462_CLIENTE()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2463_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2464_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2465_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2466_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2467_SINISTRO()
        {
        }

    }
}
