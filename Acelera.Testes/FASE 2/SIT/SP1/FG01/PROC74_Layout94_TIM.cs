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
        /// CLIENTE - Não informar CD_CLIENTE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2353_SINISTRO_SemCD_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2353", "FG01 - PROC74 - SINISTRO - Não informar CD_CLIENTE");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0003-20200227.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.TIM.SINISTRO-EV-/*R*/-20200227.TXT");

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("74");
            ValidarTeste();
        }

        /// <summary>
        ///   Cliente - Importar arquivo com Beneficiário ok
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2556_Cliente()
        {
        }

    }
}
