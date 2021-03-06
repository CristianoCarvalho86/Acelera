﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1048_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CD_SEGURADORA diferente do parametrizado como "SE" na tabela ODS PARCEIRO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3853_CD_SEGURADORA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3853", "FG02 - PROC1048 - Informar CD_SEGURADORA diferente do parametrizado como SE na tabela ODS PARCEIRO");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3158-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SU"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200316.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1048");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_SEGURADORA diferente do parametrizado como "SE" na tabela ODS PARCEIRO
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3878_CD_SEGURADORA_inv()
        {
            IniciarTeste(TipoArquivo.Sinistro, "3878", "FG02 - PROC1048 - Informar CD_SEGURADORA diferente do parametrizado como SE na tabela ODS PARCEIRO");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3329-20200326.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SU"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC1048");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1048");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3877_CD_SEGURADORA_inv()
        {
            IniciarTeste(TipoArquivo.Comissao, "3877", "FG02 - PROC1048 - Informar CD_TIPO_EMISSAO não parametrizado na tabela TAB_PRM_CONFIG_NEGOCIO_7004");
            arquivo = new Arquivo_Layout_9_4_EmsComissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.EMSCMS-EV-3290-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEGURADORA", dados.ObterCDSeguradoraDoTipoParceiro("SU"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.EMSCMS-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Comissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1048");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CD_SEGURADORA igual ao parametrizado como "SE" na tabela ODS PARCEIRO
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3854_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3854", "FG02 - PROC1048 - Informar CD_SEGURADORA igual ao parametrizado como SE na tabela ODS PARCEIRO");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "CD_SEGURADORA", "5908");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(true, "1048");
            ValidarTeste();

        }
    }
}
