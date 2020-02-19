using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum TiposArquivosEnum
    {
        [Description("TAB_STG_CLIENTE_1000")]
        Cliente,
        [Description("TAB_STG_COMISSAO_1003")]
        Comissao,
        [Description("TAB_STG_BAIXA_COMISSAO_1005")]
        LanctoComissao,
        [Description("TAB_STG_BAIXA_PARCELA_1004")]
        OCRCobranca,
        [Description("TAB_STG_PARCELA_1001")]
        ParcEmissao,
        [Description("TAB_STG_SINISTRO_1006")]
        Sinistro,
        [Description("TAB_STG_PARCELA_AUTO_1002")]
        ParcEmissaoAuto,
        [Description("TAB_ARQ_RETORNO_8002")]
        NaoSeAplica,
    }
}
