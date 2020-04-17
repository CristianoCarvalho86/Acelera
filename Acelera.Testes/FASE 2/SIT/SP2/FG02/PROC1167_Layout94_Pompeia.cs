using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1167_Layout94_Pompeia: TestesFG02
    {
        /// <summary>
        /// Informar CD_OCORRENCIA diferente de 18, 31 e 46 (ex:20)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3933_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "3933", "FG02 - PROC1167 - Informar CD_OCORRENCIA diferente de 18, 31 e 46 (ex:20)");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.EMSCMS-EV-1929-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_OCORRENCIA", "20");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
