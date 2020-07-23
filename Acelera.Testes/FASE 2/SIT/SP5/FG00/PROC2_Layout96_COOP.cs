using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC2_Layout94_COOP : TestesFG00
    {
        /// <summary>
        /// Importar um arquivo já importado - sem alterar a nomenclatura do arquivo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7343_SINISTRO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7343", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

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
        public void SAP_7341_OCR_COBRANCA_MesmoNome()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7341", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

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
        public void SAP_7340_COMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Comissao, "7340", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

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
        public void SAP_7339_PARC_EMISSAO_MesmoNome()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7339", " FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

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
        public void SAP_7338_CLIENTE_MesmoNome()
        {
            IniciarTeste(TipoArquivo.Cliente, "7338", "FG00 - PROC2 - Importar um arquivo já importado - sem alterar a nomenclatura do arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

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
