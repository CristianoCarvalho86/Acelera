using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout93_VIVO : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1081_LANCTO_COMISSAO_QT_LIN_CarEsp()
        {
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1080_OCR_COBRANCA_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "1080", "FG00 - PROC4 - No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1866-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "&&", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.COBRANCA-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages<LinhaOCRCobrancaStage>(TabelasEnum.OCRCobranca, false);
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1079_EMS_COMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Comissao, "1079", "FG00 - PROC4 - No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "##", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, false);
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1078_PARC_EMISSAO_AUTO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1078", "FG00 - PROC4 - No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "1%", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages<LinhaParcEmissaoAutoStage>(TabelasEnum.ParcEmissaoAuto, false);
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1077_CLIENTE_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Cliente, "1077", "FG00 - PROC4 - No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1867-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "(8)", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, false);
        }

        /// <summary>
        /// No Trailler do arquivo LANCTO_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1135_LANCTO_COMISSAO_QT_LIN()
        {          
            //------------------------------------------------SEM MASSA------------------------------------------------------------------
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1131_CLIENTE_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Cliente, "1131", "No Trailler do arquivo CLIENTE no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1847-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.CLIENTE-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaClienteStage>(TabelasEnum.Cliente, true, 110);
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1134_OCR_COBRANCA_QT_LIN()
        {
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1133_EMS_COMISSAO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Comissao, "1133", "No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1869-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaComissaoStage>(TabelasEnum.Comissao, true, 110);
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1132_PARC_EMISSAO_AUTO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "1132", "No Trailler do arquivo PARC_EMISSAO_AUTO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaParcEmissaoAutoStage>(TabelasEnum.ParcEmissaoAuto, true, 110);
        }

    }
}
