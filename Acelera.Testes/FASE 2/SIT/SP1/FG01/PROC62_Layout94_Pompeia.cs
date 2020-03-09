﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP1.FG01
{
    [TestClass]
    public class PROC62_Layout94_Pompeia : TestesFG01
    {

        /// <summary>
        /// No Body do arquivo SINISTRO no campo CD_SINISTRO não informar o número do sinistro (Será criiticado também plea PROC 5)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2263_SINISTRO_SemCD_SINISTRO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2263", "No Body do arquivo SINISTRO no campo CD_SINISTRO não informar o número do sinistro");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.TIM.SINISTRO-EV-0002-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO", "01");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino("C01.TIM.SINISTRO-EV-/*R*/-20200212.TXT"));

            //VALIDAR NA FG00
            ValidarFG00();

            //Executar FG01
            ChamarExecucao(FG01_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages<LinhaSinistroStage>(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("62");
        }

        /// <summary>
        ///  Importar arquivo com NR_SINISTRO valido
        /// </summary>
        [Ignore]
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2553_SINISTRO()
        {
        }

    }
}
