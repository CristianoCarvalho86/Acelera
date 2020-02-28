using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum FG00_Tarefas
    {
        [Description("FGR_00_CLIENTE")]
        Cliente,
        [Description("FGR_00_COMISSAO")]
        Comissao,
        [Description("FGR_00_BAIXA_COMISSAO")]
        LanctoComissao,
        [Description("FGR_00_BAIXA_PARCELA")]
        OCRCobranca,
        [Description("FGR_00_PARCELA")]
        ParcEmissao,
        [Description("FGR_00_SINISTRO")]
        Sinistro,
        [Description("FGR_00_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }
}
