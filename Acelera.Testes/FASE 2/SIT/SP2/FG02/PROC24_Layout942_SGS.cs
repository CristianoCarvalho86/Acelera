using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC24_Layout94_SGS : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_4028_SINISTRO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4024", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC24");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4029_SINISTRO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "4027", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(8, "CD_COBERTURA", dados.ObterCDCobertura(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTabelaDeRetorno(true, "24");
            ValidarTeste();

        }

    }
}
