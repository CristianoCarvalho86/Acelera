using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG13 : FG07_Base
    {
        protected void SalvaExecutaEValidaTrinca(bool enviarParaOds = true)
        {
            LimparValidacao();
            CriarEmissaoCompletaFG06(true, true);
            if (enviarParaOds)
            {
                EnviarParaOds(triplice.ArquivoCliente, false, true, CodigoStage.AprovadoFG06);
                EnviarParaOds(triplice.ArquivoParcEmissao, false, true, CodigoStage.AprovadoFG06);
                EnviarParaOds(triplice.ArquivoComissao, false, true, CodigoStage.AprovadoFG06);
            }
        }

        protected void ExecutarEValidarAteFG13(Arquivo arquivo, CodigoStage codigoEsperado, string mensagemNaTabelaDeRetorno = "")
        {
            ExecutarEValidarAteFg02(arquivo, mensagemNaTabelaDeRetorno);
            ValidarTeste();
        }

        protected void CriarCancelamentoDaTrincaFG13(OperadoraEnum operadora, out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento, string cdTipoEmissao = "10", bool enviarParaOds = true)
        {
            CriarCancelamento(false, false, operadora, cdTipoEmissao, out arquivoParcCancelamento, out arquivoComissaoCancelamento);

            SalvarArquivo(arquivoParcCancelamento);
            SalvarArquivo(arquivoComissaoCancelamento);

            ValidarFGsAnterioresEErros(arquivoParcCancelamento);
            ValidarFGsAnterioresEErros(arquivoComissaoCancelamento);

            if (enviarParaOds)
            {
                EnviarParaOds(arquivoParcCancelamento, false, false, CodigoStage.AprovadoNaFG09);
                EnviarParaOds(arquivoComissaoCancelamento, false, false, CodigoStage.AprovadoNaFG09);
            }
        }
        protected void CriarCancelamentoDaTrincaFG13(OperadoraEnum operadora, string cdTipoEmissao = "10", bool enviarParaOds = true)
        {
            CriarCancelamentoDaTrincaFG13(operadora, out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento, cdTipoEmissao, enviarParaOds);
        }
    }
}
