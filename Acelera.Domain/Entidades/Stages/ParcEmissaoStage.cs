using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class ParcEmissaoStage : LinhaTabela
    {
        public override TiposArquivosEnum TipoArquivo => TiposArquivosEnum.ParcEmissao;

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
            AddCampo("CD_INTERNO_RESSEGURADOR");
            AddCampo("CD_RAMO");
            AddCampo("CD_MOVTO_COBRANCA");
            AddCampo("CD_SEGURADORA");
            AddCampo("CD_SUCURSAL");
            AddCampo("CD_CORRETOR");
            AddCampo("CD_TIPO_OPERACAO");
            AddCampo("CD_TIPO_EMISSAO");
            AddCampo("CD_FORMA_PAGTO");
            AddCampo("CD_CATEGORIA");
            AddCampo("CD_FRANQUIA");
            AddCampo("CD_SUSEP_CONTRATO");
            AddCampo("CD_SISTEMA");
            AddCampo("CD_CONTRATO");
            AddCampo("NR_SEQUENCIAL_EMISSAO");
            AddCampo("NR_PARCELA");
            AddCampo("CD_COBERTURA");
            AddCampo("CD_ITEM");
            AddCampo("CD_CLIENTE");
            AddCampo("CD_MOEDA");
            AddCampo("DT_REFERENCIA");
            AddCampo("NR_PROPOSTA");
            AddCampo("DT_PROPOSTA");
            AddCampo("DT_EMISSAO");
            AddCampo("DT_EMISSAO_ORIGINAL");
            AddCampo("DT_INICIO_VIGENCIA");
            AddCampo("DT_FIM_VIGENCIA");
            AddCampo("NR_APOLICE");
            AddCampo("NR_APOLICE_ORIGINAL");
            AddCampo("NR_ENDOSSO");
            AddCampo("NR_DOCUMENTO");
            AddCampo("VL_JUROS");
            AddCampo("VL_DESCONTO");
            AddCampo("DT_VENCIMENTO");
            AddCampo("VL_PREMIO_LIQUIDO");
            AddCampo("VL_IOF");
            AddCampo("VL_ADIC_FRACIONADO");
            AddCampo("VL_CUSTO_APOLICE");
            AddCampo("VL_PREMIO_TOTAL");
            AddCampo("VL_TAXA_MOEDA");
            AddCampo("CD_STATUS_EMISSAO");
            AddCampo("VL_LMI");
            AddCampo("VL_IS");
            AddCampo("VL_PERCENTUAL_COSSEGURO");
            AddCampo("VL_PREMIO_CEDIDO");
            AddCampo("VL_COMISSAO_CEDIDO");
            AddCampo("CD_REGIAO");
            AddCampo("VL_FRANQUIA");
            AddCampo("CD_PRODUTO");
            AddCampo("ID_TRANSACAO");
            AddCampo("ID_TRANSACAO_CANC");
            AddCampo("CD_PLANO");
            AddCampo("CD_UF_RISCO");
            AddCampo("ID_REGISTRO");
            
        }
    }
}
