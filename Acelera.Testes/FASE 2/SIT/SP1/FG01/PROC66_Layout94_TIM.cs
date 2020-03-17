using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC74_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// SINISTRO - Não informar CD_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2353_SINISTRO_SemCD_AVISO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2353", "FG01 - PROC66 - SINISTRO - Não informar CD_AVISO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.SINISTRO-EV-0001-20200127.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_AVISO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.POMPEIA.SINISTRO-EV-/*R*/-20200127.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("66");
            ValidarTeste();
        }

        /// <summary>
        ///   SINISTRO - Importar arquivo com Beneficiário ok
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2556_SINISTRO()
        {
        }

    }
}
