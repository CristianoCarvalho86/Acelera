using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC16_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=20
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2675_PARC_EMISSAO_NR_ENDOsSO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2675", "FG02 - PROC16 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=0 para CD_TIPO_EMISSAO=20");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "NR_ENDOSSO", "0");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "20");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "16");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=CD_SUCURSAL+CD_RAMO+0000001 para CD_TIPO_EMISSAO=5
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2676_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2676", "FG00 - PROC16 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_ENDOSSO=CD_SUCURSAL+CD_RAMO+0000001 para CD_TIPO_EMISSAO=5");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1925-20200210.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "NR_ENDOSSO", MontarCamposConcatenados(3, "CD_SUCURSAL", "CD_RAMO")+ "0000001");
            AlterarLinha(3, "CD_TIPO_EMISSAO", "5");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.POMPEIA.PARCEMS-EV-/*R*/-20200210.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "16");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
