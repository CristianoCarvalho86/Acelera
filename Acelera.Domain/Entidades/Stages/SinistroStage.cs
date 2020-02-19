using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class SinistroStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente { get => TabelasEnum.Sinistro; }

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
            AddCampo("CD_SEGURADORA");
            AddCampo("CD_TIPO_MOVIMENTO");
            AddCampo("DT_MOVIMENTO");
            AddCampo("CD_AVISO");
            AddCampo("CD_SINISTRO");
            AddCampo("CD_CONTRATO_RESSEGURO");
            AddCampo("CD_RAMO");
            AddCampo("CD_CLIENTE");
            AddCampo("DT_AVISO");
            AddCampo("DT_OCORRENCIA");
            AddCampo("DT_REGISTRO");
            AddCampo("CD_CAUSA");
            AddCampo("CD_CONTRATO");
            AddCampo("NR_SEQUENCIAL_EMISSAO");
            AddCampo("NR_APOLICE");
            AddCampo("CD_ITEM");
            AddCampo("CD_MOVIMENTO");
            AddCampo("VL_MOVIMENTO");
            AddCampo("TP_SINISTRO");
            AddCampo("VL_TAXA_PAGTO");
            AddCampo("NM_BENEFICIARIO");
            AddCampo("EN_BENEFICIARIO");
            AddCampo("EN_COMPL_BENEFICIARIO");
            AddCampo("EN_BAIRRO_BENEFICIARIO");
            AddCampo("EN_CIDADE_BENEFICIARIO");
            AddCampo("EN_UF_BENEFICIARIO");
            AddCampo("EN_CEP_BENEFICIARIO");
            AddCampo("EN_PAIS_BENEFICIARIO");
            AddCampo("DT_NASC_BENEFICIARIO");
            AddCampo("CD_COBERTURA");
            AddCampo("CD_MOEDA");
            AddCampo("CD_BANCO_SEG");
            AddCampo("NR_AGENCIA_SEG");
            AddCampo("NR_AGENCIA_DIG_SEG");
            AddCampo("NR_CONTA_SEG");
            AddCampo("NR_CONTA_DIG_SEG");
            AddCampo("CD_FORMA_PAGTO");
            AddCampo("CD_SISTEMA");
            AddCampo("DT_PAGAMENTO");
            AddCampo("NR_SEQ_MOV");
            AddCampo("VL_CEDIDO");
            AddCampo("CD_TIPO_BENEFICIARIO");
            AddCampo("NR_DOCTO_BENEFICIARIO");
            AddCampo("CD_PRODUTO");
            AddCampo("TP_RAMO_SINISTRO");
            AddCampo("NR_ENDOSSO");
            AddCampo("CD_BANCO");
            AddCampo("NR_AGENCIA");
            AddCampo("NR_AGENCIA_DIG");
            AddCampo("NR_CONTA");
            AddCampo("NR_CONTA_DIG");
            AddCampo("NR_DOCUMENTO");
            AddCampo("VL_CORRECAO_MONETARIA");
            AddCampo("VL_JUROS");
            AddCampo("ID_REGISTRO");
            
        }
    }
}
