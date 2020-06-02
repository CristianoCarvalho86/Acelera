using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class QueryContratoParaArquivo : EntidadeDeTabela<QueryContratoParaArquivo>
    {
        public override string nomeTabela => throw new NotImplementedException();

        public string NR_PARCELA { get; set; }
        public string CD_SUCURSAL { get; set; }
        public string CD_CORRETOR { get; set; }
        public string CD_CONTRATO { get; set; }
        public string CD_CLIENTE { get; set; }
        public string CD_TIPO_OPERACAO { get; set; }
        public string CD_TIPO_EMISSAO { get; set; }
        public string NR_SEQUENCIAL_EMISSAO { get; set; }
        public string CD_MOEDA { get; set; }
        public string DT_REFERENCIA { get; set; }
        public string NR_PROPOSTA { get; set; }
        public string DT_PROPOSTA { get; set; }
        public string DT_EMISSAO { get; set; }
        public string DT_EMISSAO_ORIGINAL { get; set; }
        public string DT_INICIO_VIGENCIA { get; set; }
        public string DT_FIM_VIGENCIA { get; set; }
        public string NR_APOLICE { get; set; }
        public string NR_ENDOSSO { get; set; }
        public string CD_STATUS_EMISSAO { get; set; }
        public string CD_PRODUTO { get; set; }
        public string NR_APOLICE_ORIGINAL { get; set; }
        public string ID_TRANSACAO { get; set; }

        public static string ObterTextoSelect(string prefixoTabela = "")
        {
            prefixoTabela = prefixoTabela == string.Empty ? "" : prefixoTabela + ".";
            var sql = "SELECT top 1 PARCELA.cod_parc_prem AS NR_PARCELA, " +
            " CONTRATO.cod_suc AS CD_SUCURSAL, " +
            " CONTRATO.cod_corretor AS CD_CORRETOR, " +
            " CONTRATO.cod_ctrt AS CD_CONTRATO, " +
            " CONTRATO.cod_pess AS CD_CLIENTE, " +
            " EMISSAO.tip_docto_seg AS CD_TIPO_OPERACAO, " +
            " EMISSAO.tip_emis AS CD_TIPO_EMISSAO, " +
            " EMISSAO.cod_emis AS NR_SEQUENCIAL_EMISSAO, " +
            " EMISSAO.cod_moeda AS CD_MOEDA, " +
            " EMISSAO.dat_refr AS DT_REFERENCIA, " +
            " EMISSAO.num_proposta AS NR_PROPOSTA, " +
            " EMISSAO.data_proposta AS DT_PROPOSTA, " +
            " EMISSAO.data_apolice AS DT_EMISSAO, " +
            " EMISSAO.data_apolice AS DT_EMISSAO_ORIGINAL, " +
            " EMISSAO.dat_ini_segr AS DT_INICIO_VIGENCIA, " +
            " EMISSAO.dat_fim_segr AS DT_FIM_VIGENCIA, " +
            " EMISSAO.num_apolice AS NR_APOLICE, " +
            " EMISSAO.num_endosso AS NR_ENDOSSO, " +
            " EMISSAO.sts_emis AS CD_STATUS_EMISSAO, " +
            " EMISSAO.cod_prod AS CD_PRODUTO, " +
            " (CASE WHEN EMISSAO.tip_docto_seg = 12 then EMISSAO.num_apolice_csa else EMISSAO.num_apolice END) AS NR_APOLICE_ORIGINAL, " +
            " (EMISSAO.num_apolice + isnull(EMISSAO.num_endosso, 0) + " +
            "   convert(varchar(10), isnull(ITEM_COBERTURA.cod_ramo, 0)) + " +
            "   convert(varchar(10), isnull(PARCELA.cod_parc_prem, 0))) AS ID_TRANSACAO " +
            " FROM " +
            " ems_parcela PARCELA " +
            " inner join ems_item_cobertura ITEM_COBERTURA ON PARCELA.cod_ctrt = ITEM_COBERTURA.cod_ctrt " +
            " INNER JOIN EMS_CONTRATO CONTRATO ON PARCELA.cod_ctrt = CONTRATO.cod_ctrt " +
            " INNER JOIN ems_emissao EMISSAO on PARCELA.cod_ctrt = EMISSAO.cod_ctrt ";
            return sql;
        }

    }
}
