using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG01
{
    [TestClass]
    public class PROC01_Layout96_PITZI : TestesFG01
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7604_CLIENTE_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Cliente, "8113", "FG01 - PROC01 - No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.CLIENTE-EV-/*R*/-20200228.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7605_PARC_EMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "FG01 - PROC01 - No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.PARCEMS-EV-/*R*/-20200228.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7606_EMS_COMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "FG01 - PROC01 - No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.EMSCMS-EV-/*R*/-20200229.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7607_OCR_COBRANCA_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "8121", "FG01 - PROC01 - No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.COBRANCA-EV-/*R*/-20191128.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_7608_SINISTRO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "FG01 - PROC01 - No Header do arquivo SINISTRO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PITZI);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20191223.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("1");
            ValidarTeste();
        }

    }
}
