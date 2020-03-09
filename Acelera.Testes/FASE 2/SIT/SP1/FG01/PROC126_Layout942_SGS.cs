using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC126_Layout942_SGS : TestesFG01
    {

        /// <summary>
        ///  No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código 56
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2294_SINISTRO_EN_UF_BENEFICIARIO_56()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2294", "FG01 - PROC126 - No Body do arquivo SINISTRO no campo EN_UF_BENEFICIARIO informar código 56");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "EN_UF_BENEFICIARIO", "56");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaSinistroStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("126");
        }

        /// <summary>
        ///  Importar arquivo com UF válido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2591_SINISTRO()
        {
        }
    }
}
