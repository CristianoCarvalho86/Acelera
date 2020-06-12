﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum FGs
    {
        [Description("FGR_00")]
        FG00,
        [Description("FGR_01")]
        FG01,
        [Description("FGR_02")]
        FG02,
        [Description("FGR_03")]
        FG03,
        [Description("FGR_04")]
        FG04,
        [Description("FGR_05")]
        FG05
    }
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


    public enum FG01_1_Tarefas
    {
        [Description("FGR_01_1_SINISTRO")]
        Sinistro,
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

    public enum FG03_Tarefas
    {
        [Description("FGR_03_CLIENTE")]
        Cliente,           
        [Description("FGR_03_COMISSAO")]
        Comissao,          
        [Description("FGR_03_BAIXA_COMISSAO")]
        LanctoComissao,    
        [Description("FGR_03_BAIXA_PARCELA")]
        OCRCobranca,       
        [Description("FGR_03_PARCELA")]
        ParcEmissao,       
        [Description("FGR_03_SINISTRO")]
        Sinistro,          
        [Description("FGR_03_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }

    public enum FG05_Tarefas
    {
        [Description("FGR_05_CLIENTE")]
        Cliente,
        [Description("FGR_05_COMISSAO")]
        Comissao,
        [Description("FGR_05_BAIXA_COMISSAO")]
        LanctoComissao,
        [Description("FGR_05_BAIXA_PARCELA")]
        OCRCobranca,
        [Description("FGR_05_PARCELA")]
        ParcEmissao,
        [Description("FGR_05_SINISTRO")]
        Sinistro,
        [Description("FGR_05_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }
}
