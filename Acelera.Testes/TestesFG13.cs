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
        protected void SalvaExecutaEValida(bool enviarParaOds = true)
        {
            CriarEmissaoCompletaFG06(true,true);
            if (enviarParaOds)
            {
                EnviarParaOds(triplice.ArquivoParcEmissao, false);
                EnviarParaOds(triplice.ArquivoComissao, false);
                EnviarParaOds(triplice.ArquivoCliente, false);
            }
        }
    }
}
