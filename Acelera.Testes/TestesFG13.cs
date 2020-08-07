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
    }
}
