using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC33_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO=20, CD_ENDOSSO=123, nr_Seq_emissao=2
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2798_PARC_EMISSAO_CD_ENDOSSO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2798", "FG02 - PROC33 - Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO=20, CD_ENDOSSO=123, nr_Seq_emissao=2");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(2, "CD_ENDOSSO", "123");
            AlterarLinha(2, "NR_SEQ_EMISSAO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("33");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=5, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2799_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2799", "FG02 - PROC33 - Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=5, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3272-20200323.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(2, "CD_ENDOSSO", "0");
            AlterarLinha(2, "NR_SEQ_EMISSAO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3288-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(2, "CD_ENDOSSO", "1");
            AlterarLinha(2, "NR_SEQ_EMISSAO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200324.txt");

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
