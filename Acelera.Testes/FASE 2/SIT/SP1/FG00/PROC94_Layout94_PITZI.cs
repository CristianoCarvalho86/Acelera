using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC94_Layout94_PITZI : TestesFG00
    {
        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7922_CLIENTE_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Cliente, "7922", "FG00 - PROC94 - Não informar o registro do Trailler no arquivo");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de body (03) nao encontrada");
            ValidarTabelaDeRetorno("94");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7923_PARC_EMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7923", "FG00 - PROC94 - No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de body (03) nao encontrada");
            ValidarTabelaDeRetorno("94");
            ValidarStages(false); 
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7924_COMISSAO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Comissao, "7924", "FG00 - PROC94 - No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1977-20200228.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.EMSCMS-EV-/*R*/-20200228.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de body (03) nao encontrada");
            ValidarTabelaDeRetorno("94");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7925_OCR_COBRANCA_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7925", "FG00 - PROC94 - No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1695-20191128.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de body (03) nao encontrada");
            ValidarTabelaDeRetorno("94");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7926_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7926", "FG00 - PROC94 - No Body do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20191217.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverTodasAsLinhas();

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.SINISTRO-EV-/*R*/-20191217.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de body (03) nao encontrada");
            ValidarTabelaDeRetorno("94");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///No Body do arquivo CLIENTE no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1402_CLIENTE_TipoRegistro100()
        {
        }

        /// <summary>
        ///No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1403_PARC_EMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        ///No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1404_COMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        ///No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1405_OCR_COBRANCA_TipoRegistro100()
        {
        }

        /// <summary>
        ///No Body do arquivo LANCTO_COMISSAO no campo TIPO_REGISTRO informar código 100
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1406_LANCTO_COMISSAO_TipoRegistro100()
        {
        }

        /// <summary>
        ///No Body do arquivo SINISTRO no campo TIPO_REGISTRO informar código 103
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1407_SINISTRO_TipoRegistro100()
        {
        }

        /// <summary>
        /// No Body do arquivo CLIENTE no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1480_CLIENTE_TipoRegistro03()
        {


        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1481_PARC_EMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo EMS_COMISSAO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1482_EMS_COMISSAO_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1483_OCR_COBRANCA_TipoRegistro03()
        {

        }

        /// <summary>
        /// No Body do arquivo SINISTRO no campo TIPO_REGISTRO informar código 03
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1485_SINISTRO_TipoRegistro03()
        {

        }
    }
}
