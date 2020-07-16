using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
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
            

            ValidarFGsAnterioresEErros(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros(arquivoComissaoCancelamento);

            ChamarExecucao(FG06_Tarefas.TrincaCancelamento.ObterTexto()) ;
            
            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.AprovadoFG06);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.AprovadoFG06);
        }

        [TestMethod]
        public void SAP_5947()
        {
            // VIVO - PARC rejeitado e CMS sucesso - Canc = 10
            InicioTesteFG06("5947", "SAP-5947:FG06 - VIVO - PARC rejeitado e CMS sucesso - Canc = 10", OperadoraEnum.VIVO);

            CriarEmissaoCompleta();

            CriarCancelamento(false, false, OperadoraEnum.VIVO, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            AdicionaErro(TipoArquivo.ParcEmissaoAuto);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);


            ValidarFGsAnterioresEErros(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros(arquivoComissaoCancelamento);

            ChamarExecucao(FG06_Tarefas.TrincaCancelamento.ObterTexto());

            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.AprovadoFG06);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.AprovadoFG06);
        }


    }
}
