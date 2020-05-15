using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1046_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3851_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3851", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D+1 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValor(0, "DT_EMISSAO"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true,"1046");
            ValidarTeste();

        }

        /// <summary>
        /// Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3852_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3852", "FG02 - PROC1046 - Informar DT_INICIO_VIGENCIA=D-1 DT_EMISSAO");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1812-20200130.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_INICIO_VIGENCIA", SomarData(ObterValor(0,"DT_EMISSAO"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200130.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1046");
            ValidarTeste();

        }
    }
}
