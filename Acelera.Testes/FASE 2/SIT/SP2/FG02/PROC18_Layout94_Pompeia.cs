﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC18_Layout94_Pompeia : TestesFG02
    {

        /// <summary>
        /// Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE=01234567890123 (14 digitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2687_PARC_EMISSAO_NR_APÓLICE_Inv()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2687", "FG02 - PROC18 - Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE=01234567890123 (14 digitos)");
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(2, "NR_APÓLICE", "01234567890123");

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
        /// Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE = 0123456789012 (13 dígitos)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2684_PARC_EMISSAO_semcritica()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "2684", "FG00 - PROC18 - Informar no arquivo PARC_EMISSAO o campo NR_APÓLICE = 0123456789012 (13 dígitos)");

            //CARREGAR O ARQUIVO BASE
            arquivo = new Arquivo_Layout_9_4_ParcEmissao();
            arquivo.Carregar(ObterArquivoOrigem(""));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(6, "NR_APÓLICE", "0123456789012");

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
