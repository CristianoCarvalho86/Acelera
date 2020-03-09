using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC101_Layout94_TIM : TestesFG00
    {
        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 4X o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1282_OCR_COBRANCA_2xHeader_4xTrailler()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1282", "FG00 - PROC101 - No arquivo OCR_COBRANCA repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Repetir também 4X o Trailler");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.COBRANCA-EV-9995-20191229.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarHeader(2);
            ReplicarFooter(4);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.COBRANCA-EV-/*R*/-20191229.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.OCRCobranca, false);
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir trailer
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1284_LANCTO_COMISSAO_1xHeader()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "1284", "FG00 - PROC101 - No arquivo LANCTO_COMISSAO repetir 1x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir trailer");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9624-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarHeader(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.LASA.LCTCMS-EV-/*R*/-20190311.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaLanctoComissaoStage>(TabelasEnum.LanctoComissao, false);
        }

        /// <summary>
        /// No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1287_SINISTRO_2xTrailler()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1287", "FG00 - PROC101 - No arquivo SINISTRO repetir 2x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, false);
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1280_EMS_COMISSAO_2xHeader()
        {
            IniciarTeste(TipoArquivo.Comissao, "1280", "FG00 - PROC101 - No arquivo EMS_COMISSAO repetir 2x o registro do Header, onde o TIPO REGISTRO é igual a 9. Não repetir o Trailler");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarHeader(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, false);
        }


        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 5x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 5X o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1279_PARC_EMISSAO_5xTrailler_5xHeader()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "1279", "FG00 - PROC101 - No arquivo PARC_EMISSAO repetir 5x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Repetir também 5X o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(5);
            ReplicarHeader(5);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaParcEmissaoStage>(TabelasEnum.ParcEmissao, false);
        }

        /// <summary>
        /// No arquivo CLIENTE repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1277_CLIENTE_3xTrailler()
        {
            IniciarTeste(TipoArquivo.Cliente, "1277", "FG00 - PROC101 - No arquivo CLIENTE repetir 3x o registro do Trailler, onde o TIPO REGISTRO é igual a 9. Não repetir o Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarFooter(3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Mais de um header ou footer encontrado no arquivo");
            ValidarTabelaDeRetorno("101");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2595_OCR_COBRANCA()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2595", "No arquivo OCR_COBRANCA apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.COBRANCA-EV-1770-20191220.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.POMPEIA.COBRANCA-EV-/*R*/-20191220.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.OCRCobranca, true, 110);
        }

        /// <summary>
        /// No arquivo LANCTO_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2596_LANCTO_COMISSAO()
        {
            //----------------------------------------------SEM MASSA---------------------------------
        }

        /// <summary>
        /// No arquivo SINISTRO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2597_SINISTRO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2597", "No arquivo SINISTRO apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, true, 110);
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2594_EMS_COMISSAO()
        {
            IniciarTeste(TipoArquivo.Comissao, "2594", "No arquivo EMS_COMISSAO apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.EMSCMS-EV-0002-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.EMSCMS-EV-/*R*/-20200213.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, true, 110);
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2593_PARC_EMISSAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2593", "No arquivo PARC_EMISSAO apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.PARCEMS-EV-0002-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.PARCEMS-EV-/*R*/-20200214.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaParcEmissaoAutoStage>(TabelasEnum.ParcEmissaoAuto, true, 110);
        }

        /// <summary>
        /// No arquivo CLIENTE apresentar somente um registro do Trailler e Header
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2592_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "2592", "No arquivo CLIENTE apresentar somente um registro do Trailler e Header");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, true, 110);
        }
    }
}
