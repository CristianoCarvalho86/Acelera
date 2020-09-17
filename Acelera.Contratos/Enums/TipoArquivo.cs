using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum TipoArquivo
    {
        [Description("Cliente")]
        Cliente,
        [Description("Comissao")]
        Comissao,
        [Description("LanctoComissao")]
        LanctoComissao,
        [Description("OCRCobranca")]
        OCRCobranca,
        [Description("ParcEmissao")]
        ParcEmissao,
        [Description("Sinistro")]
        Sinistro,
        [Description("ParcEmissaoAuto")]
        ParcEmissaoAuto
    }
}
