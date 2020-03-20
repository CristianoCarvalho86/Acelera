using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC92_Layout942_SGS : TestesFG00
    {

        /// <summary>
        ///  No Header do arquivo SINISTRO no campo VERSAO informar o código 9
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2293_SINISTRO_VERSAO_9()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2293", "FG00 - PROC92 - No Header do arquivo SINISTRO no campo VERSAO informar o código 9");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarHeader("VERSAO", "9");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT");

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Versao layout informada nï¿½o existente");
            ValidarTabelaDeRetorno("92");
            ValidarStages(false);
            ValidarTeste();
        }

        /// <summary>
        ///  Importar arquivo com Versão Layout correta
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2581_SINISTRO()
        {
        }
    }
}
