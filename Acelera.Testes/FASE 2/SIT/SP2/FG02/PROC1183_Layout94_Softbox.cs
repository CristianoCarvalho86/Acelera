﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1183_Layout94_Softbox : TestesFG02
    {
        /// <summary>
        /// Informar VL_JUROS superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3943_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3943", "FG02 - PROC1183 - Informar VL_JUROS superior ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-2751-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_JUROS", SomarValores(cobertura.ValorJurosMaior, "1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1183");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_JUROS inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3944_CD_OCORRENCIA_inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3944", "FG02 - PROC1183 - Informar VL_JUROS inferior ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3162-20200316.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_JUROS", SomarValores(cobertura.ValorJurosMenor, "-1"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1183");
            ValidarTeste();
        }

        /// <summary>
        /// Informar VL_JUROS compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3945_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "3945", "FG02 - PROC1183 - Informar VL_JUROS compreendido entre o valor mínimo e máximo do desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3179-20200317.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_JUROS", MediaEntreValores(cobertura.ValorJurosMaior, cobertura.ValorJurosMenor));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1183");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }


        /// <summary>
        /// Informar VL_JUROS igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4155_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4155", "FG02 - PROC1183 - Informar VL_JUROS igual ao valor mínimo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3196-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_JUROS", SomarValores(cobertura.ValorJurosMenor, "0"));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1183");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }

        /// <summary>
        /// Informar VL_JUROS igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_4156_ParcEmissao_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "4156", "FG02 - PROC1183 - Informar VL_JUROS igual ao valor máximo de desconto parametrizado na tabela TAB_PRM_PERCENT_PREMIO_7012 ");

            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.PARCEMS-EV-3212-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            var cobertura = dados.ObterCobertura();
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "VL_JUROS", SomarValores(cobertura.ValorJurosMaior, "0"));
            RemoverLinhasExcetoAsPrimeiras(1);

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1183");
            ValidarStagesSemGerarErro(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}
