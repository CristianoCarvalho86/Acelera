using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class QueryMassaParcelaAutoSGS : QueryMassaParcelaSGS
    {
        public string CD_MODALIDADE { get; set; }
        public string ANO_MODELO { get; set; }
        public string CD_CLASSE_BONUS { get; set; }
        public string CD_UTILIZACAO { get; set; }
        public string CEP_PERNOITE { get; set; }
        public string CEP_UTILIZACAO { get; set; }
        public string SEXO_CONDUTOR { get; set; }

        public static string ObterTextoSelect(string prefixoTabela = "")
        {
            prefixoTabela = prefixoTabela == string.Empty ? "" : prefixoTabela + ".";
            var sql = "SELECT " +
            " PARCELA.cod_parc_prem AS NR_PARCELA," +
            " ITEM_COBERTURA.cod_ramo AS CD_RAMO," +
            " ITEM_COBERTURA.cod_cobt AS CD_COBERTURA," +
            " ITEM_COBERTURA.cod_item AS CD_ITEM," +
            " ITEM_COBERTURA.vlr_is AS VL_LMI," +
            " ITEM_COBERTURA.vlr_is AS VL_IS," +
            " ITEM_COBERTURA.vlr_fraq AS VL_FRANQUIA," +
            " CONTRATO.cod_suc AS CD_SUCURSAL," +
            " CONTRATO.cod_corretor AS CD_CORRETOR," +
            " CONTRATO.cod_ctrt AS CD_CONTRATO," +
            " CONTRATO.cod_pess AS CD_CLIENTE," +
            " EMISSAO.tip_docto_seg AS CD_TIPO_OPERACAO," +
            " EMISSAO.tip_emis AS CD_TIPO_EMISSAO," +
            " EMISSAO.cod_emis AS NR_SEQUENCIAL_EMISSAO," +
            " EMISSAO.cod_moeda AS CD_MOEDA," +
            " EMISSAO.dat_refr AS DT_REFERENCIA," +
            " EMISSAO.num_proposta AS NR_PROPOSTA," +
            " EMISSAO.data_proposta AS DT_PROPOSTA," +
            " EMISSAO.data_apolice AS DT_EMISSAO," +
            " EMISSAO.data_apolice AS DT_EMISSAO_ORIGINAL," +
            " EMISSAO.dat_ini_segr AS DT_INICIO_VIGENCIA," +
            " EMISSAO.dat_fim_segr AS DT_FIM_VIGENCIA," +
            " EMISSAO.num_apolice AS NR_APOLICE," +
            " EMISSAO.num_endosso AS NR_ENDOSSO," +
            " EMISSAO.sts_emis AS CD_STATUS_EMISSAO," +
            " EMISSAO.cod_prod AS CD_PRODUTO," +
            " TITULOS.tip_cob AS CD_FORMA_PAGTO," +
            " TITULOS.num_idc_dcm_bna AS NR_DOCUMENTO," +
            " TITULOS.val_jro AS VL_JUROS," +
            " TITULOS.val_dso AS VL_DESCONTO," +
            " TITULOS.dat_vct_prl AS DT_VENCIMENTO," +
            " PARTCO.cos_segura AS CD_SEGURADORA," +
            " ENDERECO.cod_uf AS CD_UF_RISCO," +
            " ITEM_AUTO.tip_modalidade AS CD_MODALIDADE," +
            " ITEM_AUTO.ano_modl AS ANO_MODELO," +
            " ITEM_AUTO.cod_bonu AS CD_CLASSE_BONUS," +
            " ITEM_AUTO.uso_veic AS CD_UTILIZACAO," +
            " ITEM_AUTO.cep_pernoite AS CEP_PERNOITE," +
            " ITEM_AUTO.cep_pernoite AS CEP_UTILIZACAO," +
            " (CASE WHEN ITEM_PERFIL.subgrupo = 1 THEN 'M' WHEN ITEM_PERFIL.subgrupo = 2 THEN 'F' ELSE 'I' END) AS SEXO_CONDUTOR," +
            " (CASE WHEN EMISSAO.tip_docto_seg = 12 then EMISSAO.num_apolice_csa else EMISSAO.num_apolice END) AS NR_APOLICE_ORIGINAL," +
            " (EMISSAO.num_apolice + isnull(EMISSAO.num_endosso, 0) +" +
            "   convert(varchar(10), isnull(ITEM_COBERTURA.cod_ramo, 0)) +" +
            "   convert(varchar(10), isnull(PARCELA.cod_parc_prem, 0))) AS ID_TRANSACAO" +
            " FROM" +
            " ems_parcela PARCELA" +
            " inner join ems_item_cobertura ITEM_COBERTURA ON PARCELA.cod_ctrt = ITEM_COBERTURA.cod_ctrt" +
            " INNER JOIN EMS_CONTRATO CONTRATO ON PARCELA.cod_ctrt = CONTRATO.cod_ctrt" +
            " INNER JOIN ems_emissao EMISSAO on PARCELA.cod_ctrt = EMISSAO.cod_ctrt" +
            " inner JOIN ems_partcosseguro PARTCO ON PARCELA.cod_ctrt = PARTCO.cos_ctrt" +
            " inner JOIN tkgs_cobranca.dbo.cob_titulos TITULOS ON PARCELA.cod_ctrt = TITULOS.COD_CTR" +
            " inner join ems_item_auto ITEM_AUTO ON ITEM_AUTO.cod_ctrt = PARCELA.cod_ctrt" +
            " INNER JOIN ems_item_perfil ITEM_PERFIL ON ITEM_PERFIL.cod_ctrt = PARCELA.cod_ctrt" +
            " inner JOIN cli_endereco ENDERECO ON ENDERECO.cod_pess =" +
            " (SELECT  TOP 1 cod_pess FROM cli_endereco WHERE cod_pess = CONTRATO.cod_pess) ";
            return sql;
        }

    }
}
