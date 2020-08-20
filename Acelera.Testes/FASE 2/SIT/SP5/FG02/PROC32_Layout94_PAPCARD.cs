using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC32_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO = "REATIVACAO". Informar qualquer um dos valores retornados.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2780_PARC_EMISSAO_REATIVACAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2780", "FG02 - PROC32 - No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO = REATIVACAO. Informar qualquer um dos valores retornados.");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", dados.ObterCDTipoEmissao("REP", true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "32");
            ValidarTeste();

        }

        /// <summary>
        /// No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO <> "REATIVACAO". Informar qualquer um dos valores retornados.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2781_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2781", "FG02 - PROC32 - No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO <> REATIVACAO. Informar qualquer um dos valores retornados.");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1934-20200213.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", dados.ObterCDTipoEmissao("REP", false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200213.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "32");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
