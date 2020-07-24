using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC100_Layout96_PAPCARD : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8008_CLIENTE_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.Cliente, "8008", "FG00 - PROC100 - No Header do arquivo CLIENTE no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Identificador de operacao TPA não encontrado");
            ValidarTabelaDeRetorno("100");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8009_PARC_EMISSAO_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8009", "FG00 - PROC100 - No Header do arquivo PARC_EMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Identificador de operacao TPA não encontrado");
            ValidarTabelaDeRetorno("100");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8010_EMS_COMISSAO_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.Comissao, "8010", "FG00 - PROC100 - No Header do arquivo EMS_COMISSAO no campo CD_TPA não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Identificador de operacao TPA não encontrado");
            ValidarTabelaDeRetorno("100");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8011_OCR_COBRANCA_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "8011", "FG00 - PROC100 - No Header do arquivo OCR_COBRANCA no campo CD_TPA não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Identificador de operacao TPA não encontrado");
            ValidarTabelaDeRetorno("100");
            ValidarStages(false); 
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8012_SINISTRO_SemCD_TPA()
        {
            IniciarTeste(TipoArquivo.Sinistro, "8012", "FG00 - PROC100 - No Header do arquivo SINISTRO no campo CD_TPA não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Identificador de operacao TPA não encontrado");
            ValidarTabelaDeRetorno("100");
            ValidarStages(false);
            ValidarTeste();
        }


    }
}
