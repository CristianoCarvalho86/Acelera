using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC14_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO (Será criiticado também pela PROC 5)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2260_PARC_EMISSAO_AUTO_ID_TRANSACAO_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2260", "FG01 - PROC14 - No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoAutoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("14");
        }

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO no campo ID_TRANSACAO informar o número na sequência: CD_RAMO, NR_PARCELA, NR_ENDOSSO, NR_APOLICE
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2261_PARC_EMISSAO_AUTO_ID_TRANSACAO_Dif()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2261", "FG01 - PROC14 - No Body do arquivo PARC_EMISSAO_AUTO no campo ID_TRANSACAO informar o número na sequência: CD_RAMO, NR_PARCELA, NR_ENDOSSO, NR_APOLICE");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "ID_TRANSACAO", "53107231000015412");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoAutoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("14");
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2542_PARC_EMISSAO_AUTO_ID_TRANSACAO()
        {
        }

    }
}
