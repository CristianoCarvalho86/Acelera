using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC122_Layout94_COOP : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=18 e CD_MOVTO_COBRANCA=01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2935_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2935", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=01");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "122");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=18 e CD_MOVTO_COBRANCA=02
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2936_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2936", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=02");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "122");
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_TIPO_EMISSAO=18 e CD_MOVTO_COBRANCA=03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2967_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2967", "Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=03");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.COOP.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.COOP.PARCEMS-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "122");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
