using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC110_Layout942_SGS : TestesFG01
    {

        /// <summary>
        /// No arquivo LANCTO_COMISSAO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2281_SINISTRO_3xBody()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2281", "FG01 - PROC110 - No arquivo SINISTRO repetir 3x o mesmo registro do Body onde o TIPO REGISTRO é igual a 03");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            ReplicarLinha(0, 3);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("110");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo s/ registro duplicado
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2455_SINISTRO()
        {
        }

    }
}
