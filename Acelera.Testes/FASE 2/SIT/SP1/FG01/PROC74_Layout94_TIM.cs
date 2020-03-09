using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC66_Layout94_TIM : TestesFG01
    {

        /// <summary>
        /// CLIENTE - Não informar CD_CLIENTE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2353_CLIENTE_SemCD_CLIENTE()
        {
            IniciarTeste(TipoArquivo.Cliente, "2353", "FG01 - PROC74 - CLIENTE - Não informar CD_CLIENTE");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.CLIENTE-EV-0001-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CLIENTE", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.CLIENTE-EV-/*R*/-20200214.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("74");
        }

        /// <summary>
        ///  SINISTRO - Importar arquivo com Beneficiário ok
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2560_SINISTRO()
        {
        }

    }
}
