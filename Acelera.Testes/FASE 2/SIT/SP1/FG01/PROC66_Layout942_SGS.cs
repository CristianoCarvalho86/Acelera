using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC66_Layout942_SGS : TestesFG01
    {

        /// <summary>
        /// Não informar CD_AVISO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2292_SINISTRO_SemCD_AVISO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2292", "FG01 - PROC66 - Não informar CD_AVISO ");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_AVISO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT"));

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
        ///  Importar arquivo com CD_AVISO valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2558_SINISTRO()
        {
        }

    }
}
