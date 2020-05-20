using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1190_Layout94_LASA : TestesFG02
    {
        /// <summary>
        /// Lancto- CD_LANCAMENTO diferente de 3
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3952_LANCTO_CD_LANCAMENTO_DIF_3()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "3952", "FG02 - PROC1190 - COBRANCA- CD_LANCAMENTO diferente de 3");

            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_LANCAMENTO", "4");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("1190");
            ValidarTeste();

        }

        /// <summary>
        /// COBRANCA- CD_LANCAMENTO IGUAL 3
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3953_LANCTO_semcritica()
        {
            IniciarTeste(TipoArquivo.LanctoComissao, "3953", "FG02 - PROC1190 - COBRANCA- CD_LANCAMENTO diferente de 3");

            arquivo = new Arquivo_Layout_9_4_LanctoComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_LANCAMENTO", "3");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.LanctoComissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1190");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
