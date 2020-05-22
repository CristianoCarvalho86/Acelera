using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1067_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CD_SUCURSAL diferente do pametrizado na tabela ODS PARCEIRO com CD="SU"
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3873_CD_SEGURADORA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3873", "FG02 - PROC1067 - Informar CD_SUCURSAL diferente do pametrizado na tabela ODS PARCEIRO com CD=SU");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3244-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterSucursal( false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200321.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1067");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD="SU"
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3874_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3874", "FG02 - PROC1067 - Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD=SU");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3292-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            RemoverLinhasExcetoAsPrimeiras(1);
            AlterarLinha(0, "CD_SUCURSAL",/* dados.ObterParceiroNegocio("SU", true)*/"74");
            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1067");
            ValidarTeste();

        }
    }
}
