using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class Massa_Sinistro_Parcela : EntidadeDeTabela<Massa_Sinistro_Parcela>
    {

        public string ID_SEQ { get; set; }
        public string ID_REGISTRO { get; set; }
        public string TP_REGISTRO { get; set; }
        public string CD_INTERNO_RESSEGURADOR { get; set; }
        public string CD_RAMO { get; set; }
        public string CD_MOVTO_COBRANCA { get; set; }
        public string CD_SEGURADORA { get; set; }
        public string CD_SUCURSAL { get; set; }
        public string CD_CORRETOR { get; set; }
        public string CD_TIPO_OPERACAO { get; set; }
        public string CD_TIPO_EMISSAO { get; set; }
        public string CD_FORMA_PAGTO { get; set; }
        public string CD_CATEGORIA { get; set; }
        public string CD_FRANQUIA { get; set; }
        public string CD_SUSEP_CONTRATO { get; set; }
        public string CD_SISTEMA { get; set; }
        public string CD_CONTRATO { get; set; }
        public string NR_SEQUENCIAL_EMISSAO { get; set; }
        public string NR_PARCELA { get; set; }
        public string CD_COBERTURA { get; set; }
        public string CD_ITEM { get; set; }
        public string CD_CLIENTE { get; set; }
        public string CD_MOEDA { get; set; }
        public string DT_REFERENCIA { get; set; }
        public string NR_PROPOSTA { get; set; }
        public string DT_PROPOSTA { get; set; }
        public string DT_EMISSAO { get; set; }
        public string DT_EMISSAO_ORIGINAL { get; set; }
        public string DT_INICIO_VIGENCIA { get; set; }
        public string DT_FIM_VIGENCIA { get; set; }
        public string NR_APOLICE { get; set; }
        public string NR_APOLICE_ORIGINAL { get; set; }
        public string NR_ENDOSSO { get; set; }
        public string NR_DOCUMENTO { get; set; }
        public string VL_JUROS { get; set; }
        public string VL_DESCONTO { get; set; }
        public string DT_VENCIMENTO { get; set; }
        public string VL_PREMIO_LIQUIDO { get; set; }
        public string VL_IOF { get; set; }
        public string VL_ADIC_FRACIONADO { get; set; }
        public string VL_CUSTO_APOLICE { get; set; }
        public string VL_PREMIO_TOTAL { get; set; }
        public string VL_TAXA_MOEDA { get; set; }
        public string CD_STATUS_EMISSAO { get; set; }
        public string VL_LMI { get; set; }
        public string VL_IS { get; set; }
        public string VL_PERCENTUAL_COSSEGURO { get; set; }
        public string VL_PREMIO_CEDIDO { get; set; }
        public string VL_COMISSAO_CEDIDO { get; set; }
        public string CD_REGIAO { get; set; }
        public string VL_FRANQUIA { get; set; }
        public string CD_PRODUTO { get; set; }
        public string ID_TRANSACAO { get; set; }
        public string ID_TRANSACAO_CANC { get; set; }
        public string CD_PLANO { get; set; }
        public string CD_UF_RISCO { get; set; }
        public string CD_MODALIDADE { get; set; }
        public string CD_MODELO { get; set; }
        public string ANO_MODELO { get; set; }
        public string VL_PERC_FATOR { get; set; }
        public string VL_PERC_BONUS { get; set; }
        public string CD_CLASSE_BONUS { get; set; }
        public string SEXO_CONDUTOR { get; set; }
        public string DT_NASC_CONDUTOR { get; set; }
        public string TEMPO_HAB { get; set; }
        public string CD_UTILIZACAO { get; set; }
        public string CEP_UTILIZACAO { get; set; }
        public string CEP_PERNOITE { get; set; }
        public string CD_OPERACAO { get; set; }
        public string DT_INCLUSAO { get; set; }
        public string NM_ARQUIVO_TPA { get; set; }
        public string TP_ARQUIVO { get; set; }
        public string NM_TPA { get; set; }
        public string CD_STATUS_PROCESSAMENTO { get; set; }
        public string DT_ARQUIVO { get; set; }
        public string CD_VERSAO_ARQUIVO { get; set; }
        public string QT_LINHA_ARQUIVO { get; set; }
        public override string nomeTabela => "TB_MASS_SGS_SINISTRO_PARCELA_0032";

    }
}
