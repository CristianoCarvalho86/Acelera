using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG01
{
    [TestClass]
    public class PROC01_Layout94_COOP : TestesFG01
    {

        /// <summary>
        /// No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8118_CLIENTE_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Cliente, "8118", "FG01 - PROC01 - No Header do arquivo CLIENTE no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        public void SAP_8119_PARC_EMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8119", "FG01 - PROC01 - No Header do arquivo PARC_EMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        public void SAP_8120_EMS_COMISSAO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Comissao, "8120", "FG01 - PROC01 - No Header do arquivo EMS_COMISSAO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        public void SAP_8121_OCR_COBRANCA_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "8121", "FG01 - PROC01 - No Header do arquivo OCR_COBRANCA no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
        public void SAP_8122_SINISTRO_CD_TPA_9_3()
        {
            IniciarTeste(TipoArquivo.Sinistro, "8122", "FG01 - PROC01 - No Header do arquivo SINISTRO no campo CD_TPA informar código 9.3");
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("CD_TPA", "9.3");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
