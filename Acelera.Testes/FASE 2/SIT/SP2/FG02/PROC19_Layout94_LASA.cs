﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC19_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA=5555
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2694_PARC_EMISSAO_NR_PROPOSTA_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2694", "FG02 - PROC19 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA=5555");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(9, "NR_PROPOSTA", "5555");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "19");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA igual ao campo NR_APOLICE
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2695_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2695", "FG00 - PROC19 - Informar no arquivo PARC_EMISSAO_AUTO o campo NR_PROPOSTA igual ao campo NR_APOLICE");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.PARCEMS-EV-3192-20200318.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_PROPOSTA", ObterValor(6, "NR_APOLICE"));

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.PARCEMS-EV-/*R*/-20200318.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "19");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
        
    }
}
