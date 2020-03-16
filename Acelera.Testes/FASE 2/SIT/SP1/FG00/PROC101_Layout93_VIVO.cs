using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout93_VIVO : TestesFG00
    {

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir trailer
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1109_LANCTO_COMISSAO_2xHeader()
        {
            //-------------------------------------------------------SEM MASSA----------------------------------------------------
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1108_OCR_COBRANCA_1xTrailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1108", "FG00 - PROC101 - No arquivo OCR_COBRANCA repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT"));

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
        /// No arquivo EMS_COMISSAO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1106_EMS_COMISSAO_2xTrailler_2xHeader()
        {
            IniciarTeste(TipoArquivo.Comissao, "1106", "FG00 - PROC101 -No arquivo EMS_COMISSAO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 2X o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(2);
            ReplicarHeader(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200212.TXT"));

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
        /// No arquivo PARC_EMISSAO_AUTO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1104_PARC_EMISSAO_AUTO_2xTrailler_1xHeader()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1104", "FG00 - PROC101 -No arquivo PARC_EMISSAO_AUTO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(2);
            ReplicarHeader(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages( false);
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1102_CLIENTE_1xTrailler_1xHeader()
        {
            IniciarTeste(TipoArquivo.Cliente, "1102", "FG00 - PROC101 -No arquivo CLIENTE repetir 1x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 1X o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200207.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(1);
            ReplicarHeader(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200207.TXT"));

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
        /// No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1174_OCR_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1174", "No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT"));

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
        /// No arquivo LANCTO_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1176_LANCTO_COMISSAO()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1172_EMS_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "1172", "No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200212.TXT"));

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
        /// No arquivo PARC_EMISSAO_AUTO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1170_PARC_EMISSAO_AUTO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1170", "No arquivo PARC_EMISSAO_AUTO apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

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
        /// No arquivo CLIENTE apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1168_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "1168", "No arquivo CLIENTE apresentar somente um registro do Trailler e Header");

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
