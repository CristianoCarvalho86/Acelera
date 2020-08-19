using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02.PrioridadeB.PROC11
{
    [TestClass]
    public class PROC11_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo dt_fim_vigencia 365 dias menor que o dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2657_COOP()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2657", "FG02 - PROC11 - Informar no arquivo PARC_EMISSAO o campo dt_fim_vigencia 365 dias menor que o dt_inicio_vigencia");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), -365));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "11");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO dt_fim_vigencia 1 dia maior que dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2658_COOP()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2658", "FG00 - PARC_EMISSAO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2_new_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.COOP);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), 1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
