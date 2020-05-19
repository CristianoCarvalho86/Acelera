using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1067_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_SUCURSAL diferente do pametrizado na tabela ODS PARCEIRO com CD="SU"
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3871_CD_SEGURADORA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3871", "FG02 - PROC1067 - Informar CD_SUCURSAL diferente do pametrizado na tabela ODS PARCEIRO com CD=SU");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterSucursal( false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1067");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD="SU"
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3872_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3872", "FG02 - PROC1067 - Informar CD_SUCURSAL pametrizado na tabela ODS PARCEIRO com CD=SU");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3240-20200321.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SUCURSAL", dados.ObterParceiroNegocio("SU", true));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200321.txt");

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
