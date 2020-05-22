using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1048_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar CD_SEGURADORA diferente do parametrizado como "SE" na tabela ODS PARCEIRO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3858_CLIENTE_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3858", "FG02 - PROC1048 - Informar CD_SEGURADORA diferente do parametrizado como SE na tabela ODS PARCEIRO");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SU"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1048");
            ValidarTeste();

        }
    }
}
