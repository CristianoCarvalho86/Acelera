using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC129_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_0001_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "0001", "FG02 - PROC129 ");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-2757-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_AVISO", "1234567");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(1, "CD_AVISO", "1234567");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "129");
            ValidarTeste();
        }

        /// <summary>
        /// Criar dois arquivos. Ambos devem possuir o mesmo CD_SINISTRO (informar numero aleatorio) e CD_TIPO_MOVIMENTO=1. Importar os arquivos separadamente.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_0002_CD_TIPO_MOVIMENTO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "0002", "FG02 - PROC129 ");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.SINISTRO-EV-3238-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_AVISO", "10111213");
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(1, "CD_AVISO", "10111213");
            AlterarLinha(1, "CD_TIPO_MOVIMENTO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "129");
            ValidarTeste();
        }

       
    }
}
