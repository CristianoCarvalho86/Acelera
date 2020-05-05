using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum TabelasEnum
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
        TabelaRetorno,
        [Description("TAB_LOG_PROCESSAMENTO_8000")]
        TabelaLogProcessamento,
        [Description("TAB_LOG_CONTROLE_ARQUIVO_8001")]
        ControleArquivo,
        [Description("TAB_ODS_COBERTURA_2005")]
        OdsCobertura,
        [Description("TAB_ODS_COMISSAO_2006")]
        OdsComissao,
        [Description("TAB_ODS_ENDERECO_2001")]
        OdsEndereco,
        [Description("TAB_ODS_ITEM_AUTO_2004")]
        OdsItemAuto,
        [Description("TAB_ODS_PARCEIRO_NEGOCIO_2000")]
        OdsParceiroNegocio,
        [Description("TAB_ODS_PARCELA_2003")]
        OdsParcela,
        [Description("TAB_ODS_SINISTRO_2007")]
        OdsSinistro,
        [Description("TAB_ODS_TELEFONE_2002")]
        OdsTelefone
    }
}
