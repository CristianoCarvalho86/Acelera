using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum TabelasOIMEnum
    {
        [Description("TAB_OIM_APL01_5000")]
        OIM_APL01,
        [Description("TAB_OIM_PARC01_5001")]
        OIM_PARC01,
        [Description("TAB_OIM_COB01_5002")]
        OIM_COB01,
        [Description("TAB_OIM_CMS01_5003")]
        OIM_CMS01,
        [Description("TAB_OIM_ITAUTO01_5004")]
        OIM_ITAUTO01,
    }
}
