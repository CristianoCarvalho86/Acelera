using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC122_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=01
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2932_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2932", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=01");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_2933_CD_FORMA_PAGTO_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2933", "FG02 - PROC122 - Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=02");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "02");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

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
        public void SAP_2934_ParcEmissaoAuto_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2934", "Informar CD_TIPO_EMISSAO=1 e CD_MOVTO_COBRANCA=03");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(0, "CD_MOVTO_COBRANCA", "03");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
