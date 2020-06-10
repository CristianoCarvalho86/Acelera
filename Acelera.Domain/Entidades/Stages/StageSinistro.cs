using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Stages
{
    public class StageSinistro : EntidadeDeTabela<StageSinistro>
    {
        public override string nomeTabela => "TAB_STG_SINISTRO_1006";
        public string ID_REGISTRO { get; set; }
        public string TIPO_REGISTRO { get; set; }
        public string CD_INTERNO_RESSEGURADOR { get; set; }
        public string CD_SEGURADORA { get; set; }
        public string CD_TIPO_MOVIMENTO { get; set; }
        public string DT_MOVIMENTO { get; set; }
        public string CD_AVISO { get; set; }
        public string CD_SINISTRO { get; set; }
        public string CD_CONTRATO_RESSEGURO { get; set; }
        public string CD_RAMO { get; set; }
        public string CD_CLIENTE { get; set; }
        public string DT_AVISO { get; set; }
        public string DT_OCORRENCIA { get; set; }
        public string DT_REGISTRO { get; set; }
        public string CD_CAUSA { get; set; }
        public string CD_CONTRATO { get; set; }
        public string NR_SEQUENCIAL_EMISSAO { get; set; }
        public string NR_APOLICE { get; set; }
        public string CD_ITEM { get; set; }
        public string CD_MOVIMENTO { get; set; }
        public string VL_MOVIMENTO { get; set; }
        public string TP_SINISTRO { get; set; }
        public string VL_TAXA_PAGTO { get; set; }
        public string NM_BENEFICIARIO { get; set; }
        public string EN_BENEFICIARIO { get; set; }
        public string EN_COMPL_BENEFICIARIO { get; set; }
        public string EN_BAIRRO_BENEFICIARIO { get; set; }
        public string EN_CIDADE_BENEFICIARIO { get; set; }
        public string EN_UF_BENEFICIARIO { get; set; }
        public string EN_CEP_BENEFICIARIO { get; set; }
        public string EN_PAIS_BENEFICIARIO { get; set; }
        public string DT_NASC_BENEFICIARIO { get; set; }
        public string CD_COBERTURA { get; set; }
        public string CD_MOEDA { get; set; }
        public string CD_BANCO_SEG { get; set; }
        public string NR_AGENCIA_SEG { get; set; }
        public string NR_AGENCIA_DIG_SEG { get; set; }
        public string NR_CONTA_SEG { get; set; }
        public string NR_CONTA_DIG_SEG { get; set; }
        public string CD_FORMA_PAGTO { get; set; }
        public string CD_SISTEMA { get; set; }
        public string DT_PAGAMENTO { get; set; }
        public string NR_SEQ_MOV { get; set; }
        public string VL_CEDIDO { get; set; }
        public string CD_TIPO_BENEFICIARIO { get; set; }
        public string NR_DOCTO_BENEFICIARIO { get; set; }
        public string CD_PRODUTO { get; set; }
        public string TP_RAMO_SINISTRO { get; set; }
        public string NR_ENDOSSO { get; set; }
        public string CD_BANCO { get; set; }
        public string NR_AGENCIA { get; set; }
        public string NR_AGENCIA_DIG { get; set; }
        public string NR_CONTA { get; set; }
        public string NR_CONTA_DIG { get; set; }
        public string NR_DOCUMENTO { get; set; }
        public string VL_CORRECAO_MONETARIA { get; set; }
        public string VL_JUROS { get; set; }
        public string CD_OPERACAO { get; set; }
        public string NM_ARQUIVO_TPA { get; set; }
        public string NM_TPA { get; set; }
        public string DT_ARQUIVO { get; set; }
        public string CD_VERSAO_ARQUIVO { get; set; }
        public string QT_LINHA_ARQUIVO { get; set; }
        public string DT_INCLUSAO { get; set; }
        public string DT_PROCESSAMENTO { get; set; }
        public string CD_STATUS_PROCESSAMENTO { get; set; }
        public string TP_MUDANCA { get; set; }
        public string DT_MUDANCA { get; set; }
    }
}
