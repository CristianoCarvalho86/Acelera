using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC19_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo NR_PROPOSTA=00001
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2692_PARC_EMISSAO_NR_PROPOSTA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2692", "FG02 - PROC19 - Informar no arquivo PARC_EMISSAO o campo NR_PROPOSTA=00001");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "NR_PROPOSTA", "00001");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("19");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA igual ao campo NR_APÓLICE
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2693_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2693", "FG00 - PROC19 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA igual ao campo NR_APÓLICE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_PROPOSTA", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($""));

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
        
    }
}
