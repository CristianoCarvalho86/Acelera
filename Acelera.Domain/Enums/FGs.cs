using System;
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
        [Description("FGR_01")]
        FG01_2,
        [Description("FGR_02")]
        FG02,
        [Description("FGR_03")]
        FG03,
        [Description("FGR_04")]
        FG04,
        [Description("FGR_05")]
        FG05,
        [Description("FGR_06")]
        FG06,
        [Description("FGR_09")]
        FG09
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

    public enum FG01_2_Tarefas
    {
        [Description("FGR_01_2_CLIENTE")]
        Cliente,
        [Description("FGR_01_2_COMISSAO")]
        Comissao,
        [Description("FGR_01_2_BAIXA_COMISSAO")]
        LanctoComissao,
        [Description("FGR_01_2_BAIXA_PARCELA")]
        OCRCobranca,
        [Description("FGR_01_2_PARCELA")]
        ParcEmissao,
        [Description("FGR_01_2_SINISTRO")]
        Sinistro,
        [Description("FGR_01_2_PARCELA_AUTO")]
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
        [Description("FGR_03_SINISTRO")]
        Sinistro
    }

    public enum FG04_Tarefas
    {

        [Description("FGR_04_CALC_COMISSAO")]
        Comissao,

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

    public enum FG06_Tarefas
    {
        [Description("FGR_06_TRINCA_EMISSAO")]
        Trinca,
        [Description("FGR_10_TRINCA_CANCELAMENTO")]
        TrincaCancelamento,
    }

    public enum FG07_Tarefas
    {
        [Description("FGR_07_TRINCA_EMISSAO")]
        Trinca
    }

    public enum FG09_Tarefas
    {
        [Description("FGR_09_CLIENTE")]
        Cliente,           
        [Description("FGR_09_COMISSAO")]
        Comissao,          
        [Description("FGR_09_BAIXA_COMISSAO")]
        LanctoComissao,    
        [Description("FGR_09_BAIXA_PARCELA")]
        OCRCobranca,       
        [Description("FGR_09_PARCELA")]
        ParcEmissao,       
        [Description("FGR_09_SINISTRO")]
        Sinistro,          
        [Description("FGR_09_PARCELA_AUTO")]
        ParcEmissaoAuto,

    }
}
