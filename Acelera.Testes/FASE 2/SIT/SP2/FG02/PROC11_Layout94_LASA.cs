﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC11_Layout94_LASA : TestesFG02
    {
        /// <summary>
        /// Informar no arquivo PARC_EMISSAO dt_fim_vigencia 1 dia menor que o dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2659_PARC_EMISSAO_dt_fim_vigência_Menos1()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2659", "FG02 - PROC11 - Informar no arquivo PARC_EMISSAO dt_fim_vigencia 1 dia menor que o dt_inicio_vigencia");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3321-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), -1));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno( "11");
            ValidarTeste();

        }

        /// <summary>
        /// PARC_EMISSAO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2660_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2660", "FG00 - PARC_EMISSAO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3321-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200326.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "11");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
