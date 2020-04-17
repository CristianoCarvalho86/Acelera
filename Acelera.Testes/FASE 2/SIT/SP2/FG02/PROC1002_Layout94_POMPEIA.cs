﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1002_Layout94_POMPEIA : TestesFG02
    {

        /// <summary>
        /// Informar no campo Cd_PRODUTO um produto parametrizado para o CD_TPA (CD_OPERAÇÃO) na tabela TAB_PRM_PRD_COBERTURA_7009
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3802_PARCEMS_SEM_CRITICA()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3802", "FG02 - PROC1002 - PARCEMS- Informar no campo Cd_PRODUTO um produto não parametrizado para o CD_TPA (CD_OPERAÇÃO) na tabela TAB_PRM_PRD_COBERTURA_7009");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.POMPEIA.PARCEMS-EV-1979-20200229.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_PRODUTO", dados.ObterCdProdutoParaTPA(ObterValorHeader("CD_TPA"), false));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

    }
}
