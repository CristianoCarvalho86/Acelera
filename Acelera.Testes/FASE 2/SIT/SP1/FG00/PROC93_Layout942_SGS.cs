using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC93_Layout942_SGS : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1193_SINISTRO_TipoRegistro13()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1193", "FG00 - PROC93 - No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 13");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "13");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1187_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1187", "FG00 - PROC93 - No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de footer (09) nao encontrada");
            ValidarTabelaDeRetorno("93");
            ValidarStages(false);
        }

        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo TIPO_REGISTRO informar código 09
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1203_SINISTRO_TipoRegistro09()
        {
        }

    }
}
