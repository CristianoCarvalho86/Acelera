using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC33_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO-7, CD_ENDOSSO=7, nr_Seq_emissao=2
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2794_PARC_EMISSAO_AUTO_CD_ENDOSSO_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2794", "FG02 - PROC33 - Enviar 1 arquivo PARC_EMS_AUTO com CD_TIPO_EMISSAO-7, CD_ENDOSSO=7, nr_Seq_emissao=2");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "7");
            AlterarLinha(2, "NR_ENDOSSO", "7");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "2");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "33");
            ValidarTeste();

        }

        /// <summary>
        /// Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=5, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2795_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2795", "FG02 - PROC33 - Enviar 1 arquivo com CD_TIPO_EMISSAO=1; CD_ENDOSSO=0 e NR_SEQ_EMISSAO=1. Em seguida, enviar outro arquivo, com CD_TIPO_EMISSAO=5, NR_ENDOSSO diferente de 0 e NR_SEQ_EMISSAO=2");
            
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "1");
            AlterarLinha(2, "NR_ENDOSSO", "0");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "1");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200211.txt");

            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", "5");
            AlterarLinha(2, "NR_ENDOSSO", "1");
            AlterarLinha(2, "NR_SEQUENCIAL_EMISSAO", "2");

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
