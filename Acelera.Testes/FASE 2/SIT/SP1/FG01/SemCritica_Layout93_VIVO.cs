using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class SemCritica_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// PARC_EMISSAO_AUTO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SemCritica_Geral_PARC_EMISSAO_AUTO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "SemCritica_Geral", "Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoAutoStage>(CodigoStage.AprovadoNaFG01);
        }

        /// <summary>
        /// LANCTO_COMISSAO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SemCritica_Geral_LANCTO_COMISSAO()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// OCR_COBRANCA - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SemCritica_Geral_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "SemCritica_Geral", "OCR_COBRANCA - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);


            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaOCRCobrancaStage>(CodigoStage.AprovadoNaFG01);
        }

        /// <summary>
        /// EMS_COMISSAO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SemCritica_Geral_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "SemCritica_Geral", "EMS_COMISSAO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaComissaoStage>(CodigoStage.AprovadoNaFG01);
        }

        /// <summary>
        /// CLIENTE - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SemCritica_Geral_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "SemCritica_Geral", "CLIENTE - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaClienteStage>(CodigoStage.AprovadoNaFG01);

        }
    }
}
