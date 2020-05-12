using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC124_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar DT_OCORRENCIA=D-30 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4142_DT_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4142", "FG02 - PROC124 -Informar DT_OCORRENCIA=D-30 da data atual");
            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2598-20200130.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(dados.ObterDataDoBanco(),30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.COBRANCA-EV-/*R*/-20200130.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "124");
            ValidarTeste();
        }

        /// <summary>
        ///Informar DT_OCORRENCIA igual a data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4143_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4143", "FG02 - PROC124 - Informar DT_OCORRENCIA igual a data atual");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2784-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.COBRANCA-EV-/*R*/-20200214.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "124");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }

        /// <summary>
        ///Informar DT_OCORRENCIA igual a D+30 da data atual
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4144_OCRCobranca_semcritica()
        {
            IniciarTeste(TipoArquivo.OCRCobranca, "4144", "FG02 - PROC124 - Informar DT_OCORRENCIA igual a D+30 da data atual");

            arquivo = new Arquivo_Layout_9_4_OcrCobranca();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.COBRANCA-EV-2785-20200214.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(dados.ObterDataDoBanco(), -30));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.COBRANCA-EV-/*R*/-20200214.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.OCRCobranca.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "124");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
