﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC32_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO = "REATIVACAO". Informar qualquer um dos valores retornados.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2778_PARC_EMISSAO_REATIVACAO()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2778", "FG02 - PROC32 - No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO = REATIVACAO. Informar qualquer um dos valores retornados.");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", dados.ObterCDTipoEmissao("REP", true));// REATIVAÇÃO = REP

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC32");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "32");
            ValidarTeste();

        }

        /// <summary>
        /// No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO <> "REATIVACAO". Informar qualquer um dos valores retornados.
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2779_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2779", "FG02 - PROC32 - No campo CD_TIPO_EMISSAO do arquivo PARC_EMISSAO_AUTO, buscar na tabela TAB_PRM_TIPO_MOVIMENTO e selecionar TP_ACAO <> REATIVACAO. Informar qualquer um dos valores retornados.");
            
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_EMISSAO", dados.ObterCDTipoEmissao("REP", false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true,"32");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
