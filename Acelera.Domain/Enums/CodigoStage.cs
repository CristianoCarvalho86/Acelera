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
        PlanoB = 150,
        AprovadoNegocioSemDependencia = 210,
        ReprovadoNegocioSemDependencia = 220
    }
}
