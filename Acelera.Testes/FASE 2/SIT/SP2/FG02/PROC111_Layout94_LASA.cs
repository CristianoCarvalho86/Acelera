using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Acelera.Testes.FASE_2.SIT.SP2.FG02
{
    [TestClass]
    public class PROC111_Layout94_LASA : TestesFG02
    {

        /// <summary>
        /// 	Informar CD SINISTRO = Ramo + Ano + Sucursal + Sequencial (9)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2926_CD_SINISTRO_MONTADO_ERRADO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2926", "FG02 - PROC111 - Informar CD SINISTRO = Ramo + Ano + Sucursal + Sequencial (9)");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO",
                GerarNumeroAleatorio(6) +
                ObterValorFormatado(0, "CD_RAMO")
                + DateTime.Now.ToString("yy")
                + "SUCURSAL" ) ;


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20191217.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno(1,"111");
            ValidarTeste();

        }
        /// <summary>
        /// Informar CD SINISTRO = Sucursal(2)+Ramo(2)+Ano(2)+ Sequencial(9)
        /// </summary>
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_2927_CD_SINISTRO_MONTADO_OK()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2927", "FG02 - PROC111 - Informar CD SINISTRO = Sucursal(2)+Ramo(2)+Ano(2)+ Sequencial(9)");
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            arquivo.Carregar(ObterArquivoOrigem("C01.LASA.SINISTRO-EV-3303-20200324.txt"));

            //ALTERAR O VALOR SELECIONADO
            AlterarLinha(0, "CD_SINISTRO",
                "SUCURSAL"
                + ObterValorFormatado(0, "CD_RAMO")
                + DateTime.Now.ToString("yy")
                + ObterValorHeader("CD_TPA")
                + GerarNumeroAleatorio(6));


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.LASA.SINISTRO-EV-/*R*/-20200324.txt");

            //VALIDAR FG's ANTERIORES
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG02
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetorno();
            ValidarTeste();

        }

    }
}
