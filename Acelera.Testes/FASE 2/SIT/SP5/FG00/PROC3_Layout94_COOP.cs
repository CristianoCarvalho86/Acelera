using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC3_Layout94_COOP : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8078_CLIENTE_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Cliente, "8078", "FG00 - PROC3 - No Trailler do arquivo CLIENTE no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.CLIENTE-EV-/*R*/-20200228.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8079_PARC_EMISSAO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8079", "FG00 - PROC3 - No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200211.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8080_EMS_COMISSAO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Comissao, "8080", "FG00 - PROC3 - No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.EMSCMS-EV-/*R*/-20200228.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8081_OCR_COBRANCA_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "8081", "FG00 - PROC3 - No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.COBRANCA-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8082_SINISTRO_QT_LIN_Diferente()
        {
            IniciarTeste(TipoArquivo.Sinistro, "8082", "FG00 - PROC3 - No Trailler do arquivo SINISTRO no campo QT_LIN informar valor diferente da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "10", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.SINISTRO-EV-/*R*/-20191128.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Linhas do arquivo diferente do numero verificador no footer.");
            ValidarTabelaDeRetorno("3");
            ValidarStages(false);
            ValidarTeste();
        }

    }
}
