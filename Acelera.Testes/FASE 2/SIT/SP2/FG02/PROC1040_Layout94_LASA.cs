﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1040_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// Informar CNPJ no campo NR_CNPJ_CPF
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3827_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3827", "FG02 - PROC1040 - Informar CNPJ no campo NR_CNPJ_CPF");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3209-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "TIPO", "J");
            AlterarLinha(1, "NR_CNPJ_CPF", "77812487000131");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.CLIENTE-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1, "1040");
            ValidarTeste();

        }

        /// <summary>
        /// Informar CPF no campo NR_CNPJ_CPF
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_3828_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3828", "FG02 - PROC1040 - Informar CPF no campo NR_CNPJ_CPF");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.CLIENTE-EV-3225-20200320.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "17077754782");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.CLIENTE-EV-/*R*/-20200320.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(true, "1040");
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia, true);
            ValidarTeste();

        }
    }
}
