﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC11_Layout93_VIVO : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo dt_fim_vigencia 10 dias menor que o dt_inicio_vigencia
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2655_PARC_EMISSAO_AUTO_dt_fim_vigência_Menos10()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2655", "FG02 - PROC11 - Informar no arquivo PARC_EMISSAO_AUTO o campo dt_fim_vigencia 10 dias menor que o dt_inicio_vigencia");
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            //arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1868-20200212.txt"));
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "DT_FIM_VIGENCIA", SomarData(ObterValor(1, "DT_INICIO_VIGENCIA"), -10));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"11");
            ValidarTeste();

        }

        /// <summary>
        /// PARC_EMISSAO_AUTO - Sem Critica
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2656_PARC_EMISSAO_AUTO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissaoAuto, "2656", "FG00 - PARC_EMISSAO_AUTO - Sem Critica");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_3_ParcEmissaoAuto();
            arquivo.Carregar(ObterArquivoOrigem("C01.VIVO.PARCEMSAUTO-EV-1864-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            SelecionarLinhaParaValidacao(0);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.VIVO.PARCEMSAUTO-EV-/*R*/-20200212.TXT");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissaoAuto.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "11");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();
        }
    }
}
