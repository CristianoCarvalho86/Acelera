﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC28_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar no campo CD_MOVTO_COBRANCA valor diferente do parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2776_PARC_EMISSAO_CD_MOVTO_COBRANCA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2776", "FG02 - PROC28 - Informar no campo CD_MOVTO_COBRANCA valor diferente do parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_MOVTO_COBRANCA", dados.ObterMovimentoCobranca(false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200318.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "28");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no campo CD_PRODUTO valor parametrizado na tabela TAB_PRM_PRODUTO_7003
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2777_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2777", "FG02 - PROC28 - Informar no campo CD_MOVTO_COBRANCA valor parametrizado na tabela TAB_PRM_MOVTO_COBRANCA_7025");
            
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(7, "CD_PRODUTO", dados.ObterMovimentoCobranca(true));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.PARCEMS-EV-/*R*/-20200318.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "28");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
