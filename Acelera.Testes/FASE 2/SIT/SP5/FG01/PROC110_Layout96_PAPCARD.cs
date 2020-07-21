using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG01
{
    [TestClass]
    public class PROC110_Layout96_PAPCARD : TestesFG01
    {

        /// <summary>
        /// No arquivo SINISTRO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8097_SINISTRO_1xBody()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8097:FG01 - Proc 110 - C/C - Lyt 9.4 POMPEIA - SINISTRO - repetir 1x o mesmo registro do Body");
            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }


        /// <summary>
        /// No arquivo CLIENTE repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8093_CLIENTE_1xBody()
        {
            IniciarTeste(TipoArquivo.Cliente, "", "SAP-8093:FG01 - Proc 110 - C/C - Lyt 9.6 PAPCARD - CLIENTE - repetir 1x o mesmo registro do Body");
            arquivo = new Arquivo_Layout_9_6_Cliente();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo PARC_EMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8094_PARC_EMISSAO_1xBody()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "", "SAP-8094:FG01 - Proc 110 - C/C - Lyt 9.4 POMPEIA - PARC_EMISSAO - repetir 1x o mesmo registro do Body");
            arquivo = new Arquivo_Layout_9_6_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01, true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo EMS_COMISSAO repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8095_EMS_COMISSAO_1xBody()
        {
            IniciarTeste(TipoArquivo.Comissao, "", "SAP-8095:FG01 - Proc 110 - C/C - Lyt 9.6 PAPCARD - COMISSAO - repetir 1x o mesmo registro do Body");
            arquivo = new Arquivo_Layout_9_6_EmsComissao();
            CarregarArquivo(arquivo, 100, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AumentarLinhasNoFooter(1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// No arquivo OCR_COBRANCA repetir 1x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8096_OCR_COBRANCA_1xBody()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "", "SAP-8096:FG01 - Proc 110 - C/C - Lyt 9.4 POMPEIA - OCR_COBRANCA - repetir 1x o mesmo registro do Body");
            arquivo = new Arquivo_Layout_9_6_OcrCobranca();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinhaComCorrecao(0, 1);
            AumentarLinhasNoFooter(1);
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01,true);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }


    }
}
