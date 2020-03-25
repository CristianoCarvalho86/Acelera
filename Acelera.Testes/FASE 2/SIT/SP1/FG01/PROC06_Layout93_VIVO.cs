using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout93_VIVO : TestesFG01
    {
        /// <summary>
        /// No Body do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2240_CLIENTE_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Cliente, "2240", "FG01 - PROC6 - No Header do arquivo CLIENTE no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_NASCIMENTO");
            arquivo = new Arquivo_Layout_9_3_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.CLIENTE-EV-1867-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_NASCIMENTO", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.CLIENTE-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO nos campos abaixo informar data inválida (Ex. 32131234) DT_INICIO_VIGENCIA DT_FIM_VIGENCIA DT_VENCIMENTO DT_NASC_CONDUTOR
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2241_PARC_EMISSAO_AUTO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2241", "FG01 - PROC6 - No Header do arquivo PARC_EMISSAO_AUTO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_INICIO_VIGENCIA DT_FIM_VIGENCIA DT_VENCIMENTO DT_NASC_CONDUTOR");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0,"DT_INICIO_VIGENCIA", "32131234");
            AlterarLinha(0,"DT_FIM_VIGENCIA", "32131234");
            AlterarLinha(0,"DT_VENCIMENTO", "32131234");
            AlterarLinha(0, "DT_NASC_CONDUTOR", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2242_OCR_COBRANCA_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "2401", "FG01 - PROC6 - No Body do arquivo OCR_COBRANCA nos campos abaixo informar data inválida (Ex. 32131234) DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_3_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.COBRANCA-EV-1870-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.COBRANCA-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }


        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2494_CLIENTE()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2495_PARC_EMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2496_EMS_COMISSAO()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2497_OCR_COBRANCA()
        {
        }

        /// <summary>
        /// Arquivo c/ tds datas válidas
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2498_LANCTO_COMISSAO()
        {
        }

    }
}
