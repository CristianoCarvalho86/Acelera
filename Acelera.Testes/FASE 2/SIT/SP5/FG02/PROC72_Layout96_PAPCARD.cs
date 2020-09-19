using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Domain.Layouts._9_6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP5.FG02
{
    [TestClass]
    public class PROC72_Layout96_PAPCARD : TestesFG02
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_8922()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8922:FG02 - 72 - C/C - PAPCARD - SINISTRO - CD_TIPO_MOVIMENTO = 2 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_Sinistro>(ref arquivo);

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
        public void SAP_8923()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8923:FG02 - 72 - C/C - PAPCARD - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_2();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_Sinistro>(ref arquivo);

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
            //ValidarStages(CodigoStage.RecusadoNaFG01);
            //ValidarTabelaDeRetorno("72");
            ValidarTeste();
        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8924()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8924:FG02 - 72 - S/C - PAPCARD - SINISTRO - CD_TIPO_MOVIMENTO = 2 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_Sinistro>(ref arquivo);

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
        public void SAP_8925()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8925:FG02 - 72 - S/C - PAPCARD - SINISTRO - CD_TIPO_MOVIMENTO = 30 e não informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);
            arquivoRegras.AlterarLayout<Arquivo_Layout_9_6_Sinistro>(ref arquivo);

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
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8926()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8926:FG02 - 72 - S/C - SOFTBOX - SINISTRO - CD_TIPO_MOVIMENTO = 30 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "30");
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
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8927()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8927:FG02 - 72 - S/C - Softbox - SINISTRO - CD_TIPO_MOVIMENTO = 2 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.SOFTBOX);

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
            ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetorno();
            ValidarTeste();
        }
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_8928()
        {
            IniciarTeste(TipoArquivo.Sinistro, "", "SAP-8928:FG02 - 72 - S/C - PAPCARD - SINISTRO - CD_TIPO_MOVIMENTO = 7 e informar DT_PAGAMENTO");

            arquivo = new Arquivo_Layout_9_6_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.PAPCARD);

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
