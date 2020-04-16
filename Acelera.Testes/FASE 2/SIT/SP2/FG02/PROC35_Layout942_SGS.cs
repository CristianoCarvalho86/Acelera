using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC35_Layout94_SGS : TestesFG02
    {

        /// <summary>
        ///  Informar campo CD_MOVIMENTO VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA negativo
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2842_SINISTRO_NUMEROS_NEGATIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2836", "FG02 - PROC35 - Informar campo  VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA negativo");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_CEDIDO", "-15.99");
            AlterarLinha(1, "CD_BANCO", "-2055");
            AlterarLinha(1, "NR_AGENCIA", "-10");
            AlterarLinha(1, "NR_CONTA", "-15");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(4, "35");
            ValidarTeste();
        }


        /// <summary>
        ///  Informar campo CD_MOVIMENTO VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA positivos
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2843_SINISTRO_NUMEROS_POSITIVOS()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2843", "FG02 - PROC35 - Informar campo  VL_CEDIDO CD_BANCO NR_AGENCIA NR_CONTA positivo");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200209.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "VL_CEDIDO", "15.99");
            AlterarLinha(1, "CD_BANCO", "2055");
            AlterarLinha(1, "NR_AGENCIA", "10");
            AlterarLinha(1, "NR_CONTA", "15");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200209.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }

    }
}
