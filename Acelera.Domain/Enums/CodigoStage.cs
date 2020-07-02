using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum CodigoStage
    {
        AprovadoNAFG00 = 110,
        AprovadoNaFG01 = 120,
        RecusadoNaFG01 = 130,
        AguardandoEmissaoSGS = 140,
        PlanoB = 150,
        ExtracaoDaParcelaEDoCliente = 160,
        AprovadoNegocioSemDependencia = 210,
        ReprovadoNegocioSemDependencia = 220,
        AprovadoNegocioComDependencia = 510,
        ReprovadoNegocioComDependencia = 520,
        AprovadoFG06 = 610,
        ReprovadoFG06 = 620,
        AprovadoNaFG09 = 910,
        ReprovadoNaFG09 = 920
    }
}
