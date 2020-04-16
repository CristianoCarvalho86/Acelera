using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1067_Layout93_VIVO : TestesFG02
    {
        /// <summary>
        /// Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD="SU"
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3876_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "3876", "FG02 - PROC1067 - Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD=SU");

            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU", true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
