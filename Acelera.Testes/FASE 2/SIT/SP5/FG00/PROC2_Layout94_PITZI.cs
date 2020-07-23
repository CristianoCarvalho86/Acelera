using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC2_Layout94_PITZI : TestesFG00
    {
        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7986_SINISTRO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7986", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(true, 110);

            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7985_OCR_COBRANCA_MesmoNome()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7985", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7984_COMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Comissao, "7984", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7983_PARC_EMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7983", " FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(true, 110);
            ValidarTeste();
        }

        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7982_CLIENTE_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Cliente, "7982", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());
            ValidarLogProcessamento(true);

            //REPROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());
            ValidarLogProcessamento(true, 2);

            //VALIDAR NO BANCO A ALTERACAO
            ValidarControleArquivo("Arquivo ja importado.");
            ValidarTabelaDeRetorno("2");
            ValidarStages(true, 110);
            ValidarTeste();
        }

    }
}
