using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class SemCritica_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// PARC_EMISSAO_AUTO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4721_SemCritica_PARC_EMISSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4721", "FG02 - PARC_EMISSAO_AUTO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3256-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);
            RemoverLinhasExcetoAsPrimeiras(100);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(false);
            ValidarTeste();
        }

        /// <summary>
        /// OCR_COBRANCA - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4717_SemCritica_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4717", "FG02 - OCR_COBRANCA - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2785-20200214.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("");
            ValidarTeste();
        }

        /// <summary>
        /// EMS_COMISSAO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4713_SemCritica_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "4713", "FG02 - EMS_COMISSAO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3194-20200318.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(false);
            ValidarTeste();
        }

        /// <summary>
        /// CLIENTE - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4704_SemCritica_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "4704", "FG02 - CLIENTE - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3241-20200321.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(false);
            ValidarTeste();

        }

        /// <summary>
        /// CLIENTE - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4710_SemCritica_Sinistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4710", "FG02 - CLIENTE - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2758-20200211.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(false);
            ValidarTeste();

        }
        
        /// <summary>
        /// CLIENTE - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4725_SemCritica_LANCTO()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "4725", "FG02 - CLIENTE - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

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
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(false);
            ValidarTeste();

        }
    }
}
