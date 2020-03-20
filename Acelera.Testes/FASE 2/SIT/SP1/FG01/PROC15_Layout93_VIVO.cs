using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC15_Layout93_VIVO : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO_CANC Premissa: CD_TIPO_EMISSAO do registro ser 9 ou 10 ou 11 ou 12 ou 13 ou 21
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2262_PARC_EMISSAO_AUTO_SemID_TRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2262", "FG01 - PROC15 - No Body do arquivo PARC_EMISSAO_AUTO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            AlterarLinha(0, "CD_TIPO_EMISSAO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("15");
            ValidarTeste();
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2543_PARC_EMISSAO_AUTO_ID_TRANSACAO_CANC()
        {
        }

    }
}
