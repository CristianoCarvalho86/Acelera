using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class SemCritica_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// PARC_EMISSAO_AUTO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4698_SemCritica_PARC_EMISSAO_AUTO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "4698", "FG02 - PARC_EMISSAO_AUTO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(100);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno("");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        /// OCR_COBRANCA - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4701_SemCritica_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4701", "FG02 - OCR_COBRANCA - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(100);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno("");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        /// EMS_COMISSAO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4700_SemCritica_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "4700", "FG02 - EMS_COMISSAO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(100);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno("");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        }

        /// <summary>
        /// CLIENTE - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4699_SemCritica_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "4698", "FG02 - CLIENTE - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1867-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(100);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno("");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
