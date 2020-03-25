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

    public enum FG01_Tarefas
    {
        [Description("FGR_01_CLIENTE")]
        Cliente,
        [Description("FGR_01_COMISSAO")]
        Comissao,
        [Description("FGR_01_BAIXA_COMISSAO")]
        LanctoComissao,
        [Description("FGR_01_BAIXA_PARCELA")]
        OCRCobranca,
        [Description("FGR_01_PARCELA")]
        ParcEmissao,
        [Description("FGR_01_SINISTRO")]
        Sinistro,
        [Description("FGR_01_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }

    public enum FG02_Tarefas
    {
        [Description("FGR_02_CLIENTE")]
        Cliente,
        [Description("FGR_02_COMISSAO")]
        Comissao,
        [Description("FGR_02_BAIXA_COMISSAO")]
        LanctoComissao,
        [Description("FGR_02_BAIXA_PARCELA")]
        OCRCobranca,
        [Description("FGR_02_PARCELA")]
        ParcEmissao,
        [Description("FGR_02_SINISTRO")]
        Sinistro,
        [Description("FGR_02_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }
}
