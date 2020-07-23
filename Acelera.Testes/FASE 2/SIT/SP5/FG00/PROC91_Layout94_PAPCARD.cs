using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC91_Layout94_PAPCARD : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8061_SINISTRO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "8061", "FG00 - PROC91 - No Header do arquivo SINISTRO no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8060_OCR_COBRANCA_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "8060", "FG00 - PROC91 - No Header do arquivo OCR_COBRANCA no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8059_EMS_COMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "8059", "FG00 - PROC91 - No Header do arquivo EMS_COMISSAO no campo VERSAO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8058_PARC_EMISSAO_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8058", "FG00 - PROC91 - No Header do arquivo PARC_EMISSAO no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo CLIENTE no campo VERSAO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8057_CLIENTE_SemVERSAO()
        {
            IniciarTeste(TipoArquivo.Cliente, "8057", "FG00 - PROC91 - No Header do arquivo VERSAO no campo CD_TPA não informar valor, campo em branco, respeitando a tamanho do campo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout nao informada no header");
            ValidarTabelaDeRetorno("91");
            ValidarStages(false);
            ValidarTeste();
        }
    }
}
