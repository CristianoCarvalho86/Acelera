﻿using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC1040_Layout94_Softbox : TestesFG02
    {

        /// <summary>
        /// Informar CNPJ no campo NR_CNPJ_CPF
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_3829_NR_CNPJ_CPF_inv()
        {
            IniciarTeste(TipoArquivo.Cliente, "3829", "FG02 - PROC1040 - Informar CNPJ no campo NR_CNPJ_CPF");
            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-2750-20200211.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "77812487000131");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200211.txt");

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
        public void SAP_3830_Cliente_semcritica()
        {
            IniciarTeste(TipoArquivo.Cliente, "3830", "FG02 - PROC1040 - Informar CPF no campo NR_CNPJ_CPF");

            arquivo = new Arquivo_Layout_9_4_Cliente();
            arquivo.Carregar(ObterArquivoOrigem("C01.SOFTBOX.CLIENTE-EV-3211-20200319.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(1, "NR_CNPJ_CPF", "17077754782");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SOFTBOX.CLIENTE-EV-/*R*/-20200319.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Cliente.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarTabelaDeRetorno(false);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTeste();

        }
    }
}