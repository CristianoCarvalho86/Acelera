using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC01_Layout94_TIM : TestesFG01
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2306_SINISTRO_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2306", "FG01 - PROC01 - No Header do arquivo SINISTRO no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2311_LANCTO_COMISSAO_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "2311", "FG01 - PROC01 - No Header do arquivo LANCTO_COMISSAO no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2307_CLIENTE_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.Cliente, "2306", "FG01 - PROC01 - No Header do arquivo CLIENTE no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2308_PARC_EMISSAO_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2308", "FG01 - PROC01 - No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.PARCEMS-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2309_EMS_COMISSAO_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.Comissao, "2309", "FG01 - PROC01 - No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.EMSCMS-EV-/*R*/-20200207.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 999
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2310_OCR_COBRANCA_CD_TPA_999()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2310", "FG01 - PROC01 - No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 999");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9994-20191230.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "999");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.COBRANCA-EV-/*R*/-20191230.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }


        /// <summary>
        /// Importar arquivo c/ CD_TPA válido
        /// </summary>
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
