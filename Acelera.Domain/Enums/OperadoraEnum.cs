using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum OperadoraEnum
    {
        [Description("VIVO")]
        VIVO,
        [Description("LASA")]
        LASA,
        [Description("TIM")]
        TIM,
        [Description("SOFTBOX")]
        SOFTBOX,
        [Description("SGS")]
        SGS,
        [Description("POMPEIA")]
        POMPEIA,
        [Description("PITZI")]
        PITZI,
        [Description("PAPCARD")]
        PAPCARD,
        [Description("COOP")]
        COOP
    }
}
