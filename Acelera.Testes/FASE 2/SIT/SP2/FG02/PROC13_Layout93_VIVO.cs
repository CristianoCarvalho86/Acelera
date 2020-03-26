using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC13_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS = 0.00
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2665_PARC_EMISSAO_VL_IS_negativo()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2665", "FG02 - PROC13 - Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS = 0.00");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "VL_IS", "0.00");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("13");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS= 0.01
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2666_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2666", "FG00 - PROC13 - Informar no arquivo PARC_EMISSAO_AUTO o campo VL_IS= 0.01");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "VL_IS", " 0.01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

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
}
