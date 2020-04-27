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
    public class PROC111_Layout94_SGS : TestesFG02
    {

        /// <summary>
        /// 	Informar CD SINISTRO = Ramo + Ano + Sucursal + Sequencial (9)
        /// </summary>
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_2930_CD_SINISTRO_MONTADO_ERRADO()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2930", "FG02 - PROC111 - Informar CD SINISTRO = Ramo + Ano + Sucursal + Sequencial (9)");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sucursal = ObterValorFormatado(0, "CD_SINISTRO").Substring(0, 2);
            AlterarLinha(0, "CD_SINISTRO",
                sucursal
                + GerarNumeroAleatorio(11)
                + ObterValorFormatado(0, "CD_RAMO").ObterUltimosCaracteres(2)
                + DateTime.Now.ToString("yy")
                ) ;


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo($"C01.SGS.SINISTRO-EV-/*R*/-20200212.txt");

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
        public void SAP_2931_CD_SINISTRO_MONTADO_OK()
        {
            IniciarTeste(TipoArquivo.Sinistro, "2931", "FG02 - PROC111 - Informar CD SINISTRO = Sucursal(2)+Ramo(2)+Ano(2)+ Sequencial(9)");
            arquivo = new Arquivo_Layout_9_4_2();
            arquivo.Carregar(ObterArquivoOrigem("C01.SGS.SINISTRO-EV-000001-20200212.txt"));

            //ALTERAR O VALOR SELECIONADO
            var sucursal = ObterValorFormatado(0, "CD_SINISTRO").Substring(0, 2);
            AlterarLinha(0, "CD_SINISTRO",
                sucursal
                + ObterValorFormatado(0, "CD_RAMO").ObterUltimosCaracteres(2)
                + DateTime.Now.ToString("yy")
                + ObterValorHeader("CD_TPA")
                + GerarNumeroAleatorio(11));


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo("PROC111");

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
