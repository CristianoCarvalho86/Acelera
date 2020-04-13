using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC24_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2744_PARC_EMISSAO_CD_COBERTURA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2744", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor diferente do parametrizado na tabela TAB_PRM_COBERTURA_7007");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_COBERTURA", dados.ObterCobertura(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "24");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2745_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2745", "FG02 - PROC24 - Informar no campo CD_COBERTURA valor parametrizado na tabela TAB_PRM_COBERTURA_7007");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3260-20200322.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_COBERTURA", dados.ObterCobertura(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200322.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
        
    }
}
