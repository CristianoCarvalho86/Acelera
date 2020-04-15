﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC52_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Alterar duas linhas para o mesmo CD_CONTRATO e CD_TiPO COMISSAO = R.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2848_COMISSAO_CD_TIPO_EMISSAO_DUP()
        {
            IniciarTeste(TipoArquivo.Comissao, "2848", "FG02 - PROC52 - Alterar duas linhas para o mesmo CD_CONTRATO e CD_TiPO COMISSAO = R.");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3226-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(3, "CD_CONTRATO", ObterValor(2,"CD_CONTRATO"));
            AlterarLinha(3, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(4, "CD_CONTRATO", ObterValor(2, "CD_CONTRATO"));
            AlterarLinha(4, "CD_TIPO_COMISSAO", "R");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.EMSCMS-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(3, "52");
            ValidarTeste();

        }

        /// <summary>
        /// Mais de uma linha com o mesmo CD_CONTRATO, porém todas apenas uma com CD-TIPO_COMISSAO = R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2849_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.Comissao, "2849", "FG02 - PROC52 - Mais de uma linha com o mesmo CD_CONTRATO, porém todas apenas uma com CD-TIPO_COMISSAO = R");
            
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3226-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(3, "CD_CONTRATO", "12345");
            AlterarLinha(2, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(3, "CD_CONTRATO", "12345");
            AlterarLinha(3, "CD_TIPO_COMISSAO", "C");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.EMSCMS-EV-/*R*/-20200320.txt");
            
            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
        
    }
}