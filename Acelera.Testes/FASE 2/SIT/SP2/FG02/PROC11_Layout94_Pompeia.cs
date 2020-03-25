using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC11_Layout93_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo dt_fim_vigencia 365 dias menor que o dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2657_PARC_EMISSAO_dt_fim_vigência_Menos10()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2655", "FG02 - PROC11 - Informar no arquivo PARC_EMISSAO o campo dt_fim_vigencia 365 dias menor que o dt_inicio_vigencia");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), 365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("11");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO dt_fim_vigencia 1 dia maior que dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2656_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2656", "FG00 - PROC11 - Informar no arquivo PARC_EMISSAO dt_fim_vigencia 1 dia maior que dt_inicio_vigencia");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
}
