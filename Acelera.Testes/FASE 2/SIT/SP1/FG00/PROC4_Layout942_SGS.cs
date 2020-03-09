using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG00
{
    [TestClass]
    public class PROC4_Layout942_SGS : TestesFG00
    {
        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial, respeitando a tamanho do campo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_1185_SINISTRO_QT_LIN_CarEsp()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1185", "FG00 - PROC4 - No Trailler do arquivo SINISTRO no campo QT_LIN informar valor com um ou mais caracter especial");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarFooter("QT_LIN", "&*", 0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("Erro no numero verificador no footer.");
            ValidarTabelaDeRetorno("4");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, false);
        }


        /// <summary>
        /// No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe, sem caracteres inválidos
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_1201_SINISTRO_QT_LIN()
        {
            IniciarTeste(TipoArquivo.Sinistro, "1201", "No Trailler do arquivo SINISTRO no campo QT_LIN informar valor igual da soma de linhas do Detalhe");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO


            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($"C01.SGS.SINISTRO-EV-/*R*/-20200209.TXT"));

            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(FG00_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NO BANCO A ALTERACAO
            ValidarLogProcessamento(true);
            ValidarControleArquivo("");
            ValidarTabelaDeRetorno("");
            ValidarStages<LinhaSinistroStage>(TabelasEnum.Sinistro, true, 110);
        }

    }
}
