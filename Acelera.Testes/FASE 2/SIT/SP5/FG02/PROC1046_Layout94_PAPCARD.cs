using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC1046_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3849_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3849", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValor(0,"DT_EMISSAO"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1046");
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3850_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3850", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValor(0,"DT_EMISSAO"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1046");
            ValidarTeste();

        }
    }
}
