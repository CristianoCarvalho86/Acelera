using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC06_Layout942_SGS : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2287_SINISTRO_DataInv_Body()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2287", "FG01 - PROC6 - No Body do arquivo SINISTRO nos campos abaixo informar data inválida (Ex. 32131234) DT_MOVIMENTO DT_AVISO DT_OCORRENCIA");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_MOVIMENTO", "32131234");
            AlterarLinha(0, "DT_AVISO", "32131234");
            AlterarLinha(0, "DT_OCORRENCIA", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("6");
            ValidarTeste();
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2288_SINISTRO_DataInv_Header()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2288", "FG01 - PROC6 - No Header do arquivo SINISTRO no(s) campo(s) abaixo informar data inválida (Ex. 32131234) DT_ARQ");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("DT_ARQ", "32131234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

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
        public void SAP_2512_SINISTRO()
        {
        }

    }
}
