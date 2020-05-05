﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC184_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = "SN"
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3687_CD_BANCO_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3687", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO não parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3312-20200325.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoParaAtuacao("SN",false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200325.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "184");
            ValidarTeste();
        }

        /// <summary>
        ///Informar CD_TIPO_MOVIMENTO parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = "SN"
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3688_Sinistro_semcritica()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3688", "FG02 - PROC184 - Informar CD_TIPO_MOVIMENTO parametrizado na tabela TAB_PRM_TIPO_MOVIMENTO_7024 com o CD_ATUACAO = SN");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", dados.ObterCDTipoMovimentoParaAtuacao("SN",true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();
        } 
    }
}