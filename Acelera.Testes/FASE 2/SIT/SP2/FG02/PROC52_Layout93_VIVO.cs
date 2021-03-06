﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC52_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Alterar duas linhas para o mesmo CD_CONTRATO e CD_TiPO COMISSAO = R.
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2844_COMISSAO_CD_TIPO_EMISSAO_DUP()
        {
            IniciarTeste(TipoArquivo.Comissao, "2844", "FG02 - PROC52 - Alterar duas linhas para o mesmo CD_CONTRATO e CD_TiPO COMISSAO = R.");
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(1, "CD_CONTRATO", ObterValor(0,"CD_CONTRATO"));
            AlterarLinha(1, "CD_TIPO_COMISSAO", "R");
            RemoverLinhasExcetoAsPrimeiras(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(2, "52");
            ValidarTeste();

        }

        /// <summary>
        /// Mais de uma linha com o mesmo CD_CONTRATO, porém todas apenas uma com CD-TIPO_COMISSAO = R
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2845_COMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.Comissao, "2845", "FG02 - PROC52 - Mais de uma linha com o mesmo CD_CONTRATO, porém todas apenas uma com CD-TIPO_COMISSAO = R");
            
            arquivo = new Arquivo_Layout_9_3_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.EMSCMS-EV-1865-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_CONTRATO", "12345");
            AlterarLinha(0, "CD_TIPO_COMISSAO", "R");
            AlterarLinha(1, "CD_CONTRATO", "12345");
            AlterarLinha(1, "CD_TIPO_COMISSAO", "C");
            RemoverLinhasExcetoAsPrimeiras(2);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.EMSCMS-EV-/*R*/-20200211.txt");
            
            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
