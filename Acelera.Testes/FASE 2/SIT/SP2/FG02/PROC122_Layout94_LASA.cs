using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC122_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2938_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2938", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=01");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

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
        /// Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=02
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2939_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2939", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=02");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

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
        ///Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=03
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2940_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2940", "Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=03");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3321-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "18");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200326.txt");

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
