﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1193_Layout94_LASA : TestesFG02
    {
        /// <summary>
        /// Informar CD_LANCAMENTO = 4
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3962_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3962", "FG02 - PROC1193 - Informar CD_LANCAMENTO = 4");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-0073-20190531.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_LANCAMENTO","4");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1193");
            ValidarTeste();
        }

        /// <summary>
        /// Informar CD_LANCAMENTO = 0
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3963_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3963", "FG02 - PROC1193 - Informar CD_LANCAMENTO = 0");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.LCTCMS-EV-9623-20190311.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_LANCAMENTO", "0");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

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
