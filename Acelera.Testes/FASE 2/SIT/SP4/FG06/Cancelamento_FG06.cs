using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class Cancelamento_FG06 : FG06_Base
    {
        [TestMethod]
        public void SAP_5946()
        {
            // VIVO, PARC OK, COMISSAO OK, CD_TIPO_EMISSAO = 9
            InicioTesteFG06("5946", "SAP-5936:FG06 - VIVO, PARC OK, COMISSAO OK, CD_TIPO_EMISSAO = 9", OperadoraEnum.VIVO);

            CriarEmissaoCompleta();

            CriarCancelamento(false, false, OperadoraEnum.VIVO, "9", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros_Cancelamento(arquivoComissaoCancelamento);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto()) ;
            
            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.AprovadoFG10);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.AprovadoFG10);
        }

        [TestMethod]
        public void SAP_5947()
        {
            // VIVO - PARC rejeitado e CMS sucesso - Canc = 10
            InicioTesteFG06("5947", "SAP-5947:FG06 - VIVO - PARC rejeitado e CMS sucesso - Canc = 10", OperadoraEnum.VIVO);

            CriarEmissaoCompleta();

            CriarCancelamento(true, false, OperadoraEnum.VIVO, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);


            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento, false);
            ValidarFGsAnterioresEErros_Cancelamento(arquivoComissaoCancelamento);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.ReprovadoFG10);
        }

        [TestMethod]
        public void SAP_5948()
        {
            // VIVO - PARC rejeitado e CMS sucesso - Canc = 10
            InicioTesteFG06("5948", "SAP-5947:FG06 - VIVO - PARC rejeitado e CMS sucesso - Canc = 10", OperadoraEnum.VIVO);

            CriarEmissaoCompleta();

            CriarCancelamento(false, true, OperadoraEnum.POMPEIA, "13", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros_Cancelamento(arquivoComissaoCancelamento, false);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoFG10);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void SAP_5949()
        {
            // VIVO - PARC rejeitado e CMS sucesso - Canc = 10
            InicioTesteFG06("5949", "SAP-5947:FG06 - VIVO - PARC rejeitado e CMS sucesso - Canc = 10", OperadoraEnum.POMPEIA);

            CriarEmissaoCompleta();

            CriarCancelamento(true, true, OperadoraEnum.POMPEIA, "11", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);


            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento,false);
            ValidarFGsAnterioresEErros_Cancelamento(arquivoComissaoCancelamento,false);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void SAP_5950()
        {
            InicioTesteFG06("5950", "SAP-5950:FG06 - POMPEIA - PARC ñ enviado e CMS sucesso - Canc = 10", OperadoraEnum.POMPEIA);

            CriarEmissaoCompleta();

            CriarCancelamento(false, false, OperadoraEnum.POMPEIA, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoComissaoCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoComissaoCancelamento);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.ReprovadoFG10);

        }

        [TestMethod]
        public void SAP_5951()
        {
            InicioTesteFG06("5951", "SAP-5950:FG06 - POMPEIA - PARC ñ enviado e CMS sucesso - Canc = 10", OperadoraEnum.LASA);

            CriarEmissaoCompleta();

            CriarCancelamento(false, false, OperadoraEnum.POMPEIA, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoFG10);

        }

        [TestMethod]
        public void SAP_5953()
        {

            InicioTesteFG06("5953", "FG06 - SOFTBOX - PARC rejeitado e CMS ñ enviado - Canc=10", OperadoraEnum.TIM);

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(1), trinca.ArquivoComissao.ObterLinha(0));

            CriarEmissaoCompleta();

            CriarCancelamento(true, false, OperadoraEnum.POMPEIA, "11", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento, false);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);


        }

        [TestMethod]
        public void SAP_5954()
        {

            InicioTesteFG06("5954", "FG06 - SOFTBOX - PARC ñ enviado e CMS rejeitado - Canc = 11", OperadoraEnum.TIM);

            CriarNovaLinhaParaEmissao(trinca.ArquivoParcEmissao);
            AtualizarLinhaDeReferenciaParaComissao(trinca.ArquivoParcEmissao.ObterLinha(1), trinca.ArquivoComissao.ObterLinha(0));
            CriarEmissaoCompleta();

            CriarCancelamento(true, false, OperadoraEnum.POMPEIA, "11", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);

            ValidarFGsAnterioresEErros_Cancelamento(arquivoParcCancelamento, false);

            ChamarExecucao(FG10_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.ReprovadoNegocioSemDependencia);


        }


    }
}
