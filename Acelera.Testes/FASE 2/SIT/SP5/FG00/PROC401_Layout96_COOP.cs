using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC401_Layout96_COOP : TestesFG00
    {
        /// <summary>
        /// CLIENTE - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7205_CLIENTE_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Cliente, "7205", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// PARC_EMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7206_PARC_EMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7206", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// COMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7207_EMS_COMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Comissao, "7207", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// OCR_COBRANCA - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7208_OCR_COBRANCA_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7208", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// LANCTO_COMISSAO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7209_LANCTO_COMISSAO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "7209", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_LanctoComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// SINISTRO - Importar arquivo com parceiro inexistente
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7210_SINISTRO_ParceiroInex()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7210", "FG00 - PROC401 - Importar arquivo com parceiro inexistente");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            AlterarNomeArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura da Mascara do arquivo não é a esperada.");
            ValidarTabelaDeRetorno("401");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  LANCTO_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2640_LANCTO_COMISSAO()
        {
        }

        /// <summary>
        ///  SINISTRO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2641_SINISTRO()
        {
        }

        /// <summary>
        ///  OCR_COBRANCA - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2639_OCR_COBRANCA()
        {
        }

        /// <summary>
        ///  CLIENTE - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2636_CLIENTE()
        {
        }

        /// <summary>
        ///  EMS_COMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2638_EMS_COMISSAO()
        {
        }

        /// <summary>
        ///  PARC_EMISSAO - Importar arquivo com nomenclatura correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2637_PARC_EMISSAO()
        {
        }
    }
}
