using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC72_Layout96_LASA: TestesFG02
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9011()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9011:FG02 - 72 - C/C - LASA - SINISTRO - CD_TIPO_MOVIMENTO = 2 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "DT_PAGAMENTO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("72");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_9012()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9012:FG02 - 72 - C/C - LASA - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
            AlterarLinha(0, "DT_PAGAMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.RecusadoNaFG01);
            ValidarTabelaDeRetorno("72");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9013()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9013:FG02 - 72 - S/C - LASA - SINISTRO - CD_TIPO_MOVIMENTO = 2 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "DT_PAGAMENTO", "");

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9009()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9009:FG02 - 72 - S/C - LASA - SINISTRO - CD_TIPO_MOVIMENTO = 30 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");


            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_9010()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-9010:FG02 - 72 - S/C - SOFTBOX - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "DT_PAGAMENTO", dados.ObterDataDoBanco());

            //SALVAR O NOVO ARQUIVO ALTERADO
            SalvarArquivo();

            //VALIDAR NA FG00
            ValidarFGsAnteriores();

            //Executar FG01
            ChamarExecucao(FG02_Tarefas.Sinistro.ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }


    }
}
