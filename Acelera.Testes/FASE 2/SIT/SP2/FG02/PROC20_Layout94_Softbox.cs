using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC20_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo CD_CONTRATO=123456
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2704_PARC_EMISSAO_CD_CONTRATO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2704", "FG02 - PROC20 - Informar no arquivo PARC_EMISSAO_AUTO o campo CD_CONTRATO=123456");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3228-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "CD_CONTRATO", "123456");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "20");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo CD_CONTRATO igual ao campo NR_APOLICE
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2705_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2705", "FG00 - PROC19 - Informar no arquivo PARC_EMISSAO_AUTO o campo CD_CONTRATO igual ao campo NR_APOLICE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3228-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "CD_CONTRATO", ObterValor(6, "NR_APOLICE"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
