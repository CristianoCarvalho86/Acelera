using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC18_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_APÓLICE=01234567890 (11 digitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2681_PARC_EMISSAO_NR_APÓLICE_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2681", "FG02 - PROC18 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_APÓLICE=01234567890 (11 digitos)");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_APÓLICE", "01234567890");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("18");
            ValidarTeste();

        }

        /// <summary>
        /// Informar NR_APÓLICE = 012345678901 (12 dígitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2682_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2682", "FG00 - PROC18 - Informar NR_APÓLICE = 012345678901 (12 dígitos)");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_APÓLICE", "012345678901");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($""));

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
