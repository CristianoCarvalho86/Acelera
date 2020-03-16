using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC2_Layout93_VIVO : TestesFG00
    {

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1075_LANCTO_COMISSAO_MesmoNome()
        {

            //-------------------------------------------SEM MASSA--------------------------------------------------
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1074_OCR_COBRANCA_MesmoNome()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1074", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1073_COMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Comissao, "1073", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1072_PARC_EMISSAO_AUTO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1072", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1071_CLIENTE_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Cliente, "1071", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1123_LANCTO_COMISSAO()
        {
            //-------------------------------------------SEM MASSA--------------------------------------------------

        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1122_OCR_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1122", " Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1121_EMS_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "1121", "Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1120_PARC_EMISSAO_AUTO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1120", " Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages( true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1119_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "1119", "Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
            ValidarTeste();
        }

    }
}
