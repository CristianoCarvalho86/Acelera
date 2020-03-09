using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC2_Layout94_Pompeia : TestesFG00
    {
        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1365_SINISTRO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1365", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1364_LANCTO_COMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1364", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9999-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV-/*R*/-20190531.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1363_OCR_COBRANCA_MesmoNome()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1363", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1770-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191220.TXT"));

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
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1362_COMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Comissao, "1362", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200211.TXT"));

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
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1361_PARC_EMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1361", " FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1360_CLIENTE_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Cliente, "1360", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT"));

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
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1455_SINISTRO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1455", "Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191223.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(false);
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1454_LANCTO_COMISSAO()
        {
            //-------------------------------------------SEM MASSA---------------------------------------------------

        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1453_OCR_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1453", " Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1770-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191220.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1452_EMS_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "1452", "Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1451_PARC_EMISSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1120", " Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
        }

        /// <summary>
        /// Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1450_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "1450", "Importar um arquivo somente uma vez - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.CLIENTE-EV-1927-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.CLIENTE-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages(true, 110);
        }

    }
}
