﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC18_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE=0123456789012345 (16 digitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2685_PARC_EMISSAO_NR_APÓLICE_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2685", "FG02 - PROC18 - Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE=0123456789012345 (16 digitos)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_APÓLICE", "0123456789012345");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.ParcEmissao.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno("18");
            ValidarTeste();

        }

        /// <summary>
        /// Informar no arquivo PARC EMISSAO o campo NR_APÓLICE = 012345678901234 (15 dígitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2686_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2686", "FG00 - PROC18 - Informar no arquivo PARC EMISSAO o campo NR_APÓLICE = 012345678901234 (15 dígitos)");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_APÓLICE", "012345678901234");

            //SALVAR O NOVO ARQUIVO ALTERADO
            arquivo.Salvar(ObterArquivoDestino($""));

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