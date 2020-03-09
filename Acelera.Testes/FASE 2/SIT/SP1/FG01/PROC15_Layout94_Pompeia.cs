using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC15_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO_CANC Premissa: CD_TIPO_EMISSAO do registro ser 9 ou 10 ou 11 ou 12 ou 13 ou 21
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2421_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2421", "FG01 - PROC15 - No Body do arquivo PARC_EMISSAO não informar valor no(s) seguinte(s) campo(s), ou seja, campos em branco, respeitando a tamanho do campos: ID_TRANSACAO_CANC");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaParcEmissaoStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("15");
        }

        /// <summary>
        /// Importar arquivo com ID_TRANSACAO_CANC correto
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2547_PARC_EMISSAO_ID_TRANSACAO_CANC()
        {
        }

    }
}
