using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG00
{
    [TestClass]
    public class PROC4_Layout96_PAPCARD : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7299_SINISTRO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Sinistro, "7299", "FG00 - PROC4 - No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "**", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7297_OCR_COBRANCA_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "7297", "FG00 - PROC4 - No Trailler do arquivo OCR_COBRANCA no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "$$", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7296_EMS_COMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Comissao, "7296", "FG00 - PROC4 - No Trailler do arquivo EMS_COMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "#!", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Comissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7295_PARC_EMISSAO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "7295", "FG00 - PROC4 - No Trailler do arquivo PARC_EMISSAO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "9+", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        /// No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7294_CLIENTE_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Cliente, "7294", "FG00 - PROC4 - No Trailler do arquivo CLIENTE no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "-5", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Cliente.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages(false);
            ValidarTeste();
        }


    }
}
