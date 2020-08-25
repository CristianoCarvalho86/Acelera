using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum BatEnumDia
    {
        [Description("cliente\\Cliente.bat")]
        Cliente,
        [Description("emscms\\comissao.bat")]
        Comissao,
        [Description("baixa_comissao\\lctcms.bat")]
        LanctoComissao,
        [Description("baixa_parcela\\cobranca.bat")]
        OCRCobranca,
        [Description("parcems\\parcela.bat")]
        ParcEmissao,
        [Description("sinistro\\sinistro.bat")]
        Sinistro,
        [Description("parcela_auto\\parcemsauto.bat")]
        ParcEmissaoAuto
    }

    public enum BatEnumNoite
    {
        [Description("noite.bat")]
        BatNoite
    }
}
