using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC16_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=5
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2673_PARC_EMISSAO_AUTO_NR_ENDOSSO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2673", "FG02 - PROC16 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=5");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "NR_ENDOSSO", "0");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "5");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC16");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "16");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=1
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2674_PARC_EMISSAO_AUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2674", "FG00 - PROC16 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=1");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "NR_ENDOSSO", "0");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

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
