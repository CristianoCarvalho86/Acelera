using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC95_Layout942_SGS : TestesFG00
    {
        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 13
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1195_SINISTRO_TipoRegistro13()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1195", "FG00 - PROC95 - No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 13");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "13");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, false);
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor, campo em branco, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1189_SINISTRO_SemTipoRegistro()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1189", "FG00 - PROC95 - No Header do arquivo SINISTRO no campo TIPO_REGISTRO, não informar valor");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("TIPO_REGISTRO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.SGS.SINISTRO-EV-/*R*/-20200211.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Estrutura de header (01) nao encontrada");
            ValidarTabelaDeRetorno("95");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, false);
        }

        /// <summary>
        /// No Header do arquivo SINISTRO no campo TIPO_REGISTRO informar código 01
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1205_SINISTRO_TipoRegistro01()
        {
        }

    }
}
