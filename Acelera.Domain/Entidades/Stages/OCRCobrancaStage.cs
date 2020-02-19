using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class OCRCobrancaStage : LinhaTabela
    {
        public override TiposArquivosEnum TipoArquivo => TiposArquivosEnum.OCRCobranca;

        protected override void CarregarCampos()
        {
            AddCampo("NM_ARQUIVO_TPA");
            AddCampo("CD_STATUS_PROCESSAMENTO");
            AddCampo("DT_INCLUSAO");
            AddCampo("DT_ARQUIVO");
            AddCampo("DT_PROCESSAMENTO");
            AddCampo("NM_TPA");
            AddCampo("CD_OPERACAO");
            AddCampo("CD_VERSAO_ARQUIVO");
            AddCampo("QT_LINHA_ARQUIVO");
            AddCampo("TIPO_REGISTRO");
            AddCampo("CD_CONTRATO");
            AddCampo("NR_SEQUENCIAL_EMISSAO");
            AddCampo("NR_PARCELA");
            AddCampo("CD_OCORRENCIA");
            AddCampo("DT_OCORRENCIA");
            AddCampo("VL_DESCONTO");
            AddCampo("VL_PREMIO_PAGO");
            AddCampo("VL_MULTA");
            AddCampo("VL_IOF_RETIDO");
            AddCampo("VL_ADC_FRC");
            AddCampo("VL_ADC_FRC_DVI");
            AddCampo("VL_MULTA_DEVIDO");
            AddCampo("VL_JUROS_COBRADO");
            AddCampo("VL_JUROS_DEVIDO");
            AddCampo("VL_DIF_PREMIO");
            AddCampo("CD_SISTEMA");
            AddCampo("ID_REGISTRO");
            
        }
    }
}
