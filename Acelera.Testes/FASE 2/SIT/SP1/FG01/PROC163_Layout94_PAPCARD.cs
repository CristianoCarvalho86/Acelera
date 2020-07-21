using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PRO163_Layout94_PAPCARD : TestesFG01
    {

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8936_PARC_EMISSAO_ID_SemTRANSACAO_CANC()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "8936", "PAPCARD - PARCELA - CD_TIPO_EMISSAO = 7 com prêmio dif. de zero");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL","");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("163");
            ValidarTeste();
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
