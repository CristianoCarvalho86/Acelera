using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC33_Layout94_PAPCARD : TestesFG02
    {

        /// <summary>
        /// Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO=7, CD_ENDOSSO=7, nr_Seq_emissao=1
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2796_PARC_EMISSAO_CD_ENDOSSO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2796", "FG02 - PROC33 - Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO=20, CD_ENDOSSO=123, nr_Seq_emissao=1");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(0, "NR_ENDOSSO", "7");
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "33");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=20, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2797_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2797", "FG02 - PROC33 - Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=20, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1928-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(2, "NR_ENDOSSO", "0");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200323.txt");

            arquivo.Carregar(ObterArquivoOrigem("C01.PAPCARD.PARCEMS-EV-1931-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "20");
            AlterarLinha(2, "NR_ENDOSSO", "1");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.PAPCARD.PARCEMS-EV-/*R*/-20200212.txt");

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
