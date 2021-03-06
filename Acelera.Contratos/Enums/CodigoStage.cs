﻿using System;
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
        AprovadoNaFG01_2 = 160,
        RepovadoNaFG01_2 = 170,
        AprovadoNegocioSemDependencia = 210,
        ReprovadoNegocioSemDependencia = 220,
        ExtracaoDaParcelaEDoCliente = 310,
        ExtracaoDaComissao = 410,
        AprovadoNegocioComDependencia = 510,
        ReprovadoNegocioComDependencia = 520,
        AprovadoFG06 = 610,
        ReprovadoFG06 = 620,
        AprovadoFG10 = 1010,
        ReprovadoFG10 = 1020,
        AprovadoFG07 = 710,
        AprovadoFG07_1 = 711,
        ReprovadoFG07_1 = 712,
        AprovadoNaFG08 = 810,
        ReprovadoNaFG08 = 820,
        AprovadoNaFG09 = 910,
        ReprovadoNaFG09 = 920,
        AprovadoNaFG13 = 1310,
        ReprovadoNaFG13 = 1320
    }
}
