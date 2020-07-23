using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC101_Layout94_PITZI : TestesFG00
    {
        /// <summary>
        /// No arquivo CLIENTE repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7452_CLIENTE_2xHeader_2xTrailler()
        {
            IniciarTeste(TipoArquivo.Cliente, "7452", "FG00 - PROC101 - No arquivo CLIENTE repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Trailler");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            ReplicarHeader(2);
            ReplicarFooter(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 4x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7453_PARC_EMISSAO_4xTrailler()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7453", "FG00 - PROC101 - No arquivo PARC_EMISSAO repetir 4x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(4);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7454_EMS_COMISSAO_3xTrailler()
        {
            IniciarTeste(TipoArquivo.Comissao, "7454", "FG00 - PROC101 - No arquivo EMS_COMISSAO repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7455_OCR_COBRANCA_2xTrailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7455", "FG00 - PROC101 - No arquivo OCR_COBRANCA repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7456_SINISTRO_1xHeader()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7456", "FG00 - PROC101 - No arquivo SINISTRO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            ReplicarHeader(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages(false);
            ValidarTeste();
        }

    }
}
