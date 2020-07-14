using Acelera.Domain.Enums;
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

            ChamarExecucao("FGR_10_TRINCA_CANCELAMENTO");
            
            ValidarEsperandoErro(arquivoParcCancelamento, CodigoStage.AprovadoFG06);
            ValidarEsperandoErro(arquivoComissaoCancelamento, CodigoStage.AprovadoFG06);
        }


    }
}
