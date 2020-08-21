using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep.ODS
{
    public class ODSInsertParcAuto
    {
        public static string InsertText(string dadosWhere)
        {
            return $" Insert into {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003( " +
"CD_PARCELA, " +
"CD_PN_SEGURADORA, " +
"CD_PN_SUCURSAL, " +
"CD_PN_OPERACAO, " +
"CD_PN_TPA, " +
"CD_PN_CLIENTE, " +
"CD_PN_CORRETOR, " +
"CD_PN_ESTIPULANTE, " +
"CD_CONTRATO, " +
"NR_APOLICE, " +
"NR_SEQ_EMISSAO, " +
"NR_SEQ_OIMX, " +
"NR_ENDOSSO, " +
"NR_PARCELA, " +
"ID_PRM_PRODUTO, " +
"CD_FORMA_PAGTO, " +
"CD_FRANQUIA, " +
"CD_MOEDA, " +
"CD_MOVTO_COBRANCA, " +
"CD_TIPO_MOVIMENTO_EMISSAO, " +
"CD_ATUACAO, " +
"DT_EMISSAO, " +
"DT_EMISSAO_OIM, " +
"DT_INICIO_VIGENCIA, " +
"DT_FIM_VIGENCIA, " +
"DT_PROPOSTA, " +
"DT_VENCIMENTO, " +
"DT_PAGAMENTO, " +
"DT_CANCELAMENTO, " +
"CD_STATUS_APOLICE, " +
"CD_STATUS_PARCELA, " +
"ID_TRANSACAO_CANC, " +
"CD_PARCELA_CANCELAMENTO, " +
"NM_ARQUIVO_TPA, " +
"NR_APOLICE_ORIGINAL, " +
"NR_DOCUMENTO, " +
"NR_PROPOSTA, " +
"VL_PREMIO_BRUTO, " +
" VL_PREMIO_LIQUIDO, " +
" VL_ADIC_FRACIONAMENTO, " +
" VL_CUSTO_APOLICE, " +
" VL_DESCONTO, " +
" VL_JUROS, " +
" VL_IOF, " +
" VL_PREMIO_PAGO, " +
" VL_DESCONTO_PAGO, " +
" VL_MULTA_PAGO, " +
" VL_IOF_RETIDO, " +
" VL_DIF_PREMIO, " +
" VL_JUROS_COBRADO, " +
" VL_JUROS_DEVIDO, " +
" VL_ADIC_FRACIONAMENTO_PAGO, " +
" VL_ADIC_FRACIONAMENTO_DEVIDO, " +
" CD_SEQ_ORIGEM, " +
" FL_MIGRADO, " +
" DT_INCLUSAO, " +
" NM_USUARIO, " +
" TP_MUDANCA, " +
" DT_MUDANCA " +
" ) " +
" select " +
$" {Parametros.instanciaDB}.SEQ_ODS_PARCELA_2003.nextval AS CD_PARCELA, " +
" se.cd_parceiro_negocio AS CD_PN_SEGURADORA, " +
" su.cd_parceiro_negocio AS CD_PN_SUCURSAL, " +
" op.cd_parceiro_negocio AS CD_PN_OPERACAO, " +
" tp.cd_parceiro_negocio AS CD_PN_TPA , " +
" cli.cd_parceiro_negocio AS CD_PN_CLIENTE, " +
" co.cd_parceiro_negocio as CD_PN_CORRETOR, " +
" 1 as CD_PN_ESTIPULANTE, " +
" a.CD_CONTRATO, " +
" a.NR_APOLICE, " +
" a.nr_sequencial_emissao as NR_SEQ_EMISSAO, " +
" 0 AS NR_SEQ_OIMX, " +
" a.NR_ENDOSSO, " +
" a.NR_PARCELA , " +
" id_prm_produto as ID_PRM_PRODUTO, " +
" a.CD_FORMA_PAGTO, " +
" CD_FRANQUIA, " +
" cast(CD_MOEDA as int), " +
" CD_MOVTO_COBRANCA, " +
" CD_TIPO_EMISSAO as CD_TIPO_MOVIMENTO_EMISSAO, " +
" 'EM' as CD_ATUACAO, " +
" max(DT_EMISSAO), " +
" max(DT_EMISSAO) AS DT_EMISSAO_OIM, " +
" max(a.DT_INICIO_VIGENCIA) , " +
" max(a.DT_FIM_VIGENCIA), " +
" max(CAST(DT_PROPOSTA AS DATE)), " +
" max(DT_VENCIMENTO), " +
" '' AS DT_PAGAMENTO, " +
" '' AS DT_CANCELAMENTO, " +
" '' AS CD_STATUS_APOLICE, " +
" '' AS CD_STATUS_PARCELA, " +
" ID_TRANSACAO_CANC, " +
" null AS CD_PARCELA_CANCELAMENTO, " +
" a.NM_ARQUIVO_TPA, " +
" NR_APOLICE_ORIGINAL, " +
" NR_DOCUMENTO, " +
" NR_PROPOSTA, " +
" sum(cast(VL_PREMIO_TOTAL as numeric)) AS VL_PREMIO_BRUTO, " +
" sum(cast(VL_PREMIO_LIQUIDO as numeric)), " +
" sum(cast(VL_ADIC_FRACIONADO as numeric)) AS VL_ADIC_FRACIONAMENTO, " +
" sum(cast(VL_CUSTO_APOLICE as numeric)), " +
" sum(cast(VL_DESCONTO as numeric)), " +
" sum(cast(VL_JUROS as numeric)), " +
" sum(cast(VL_IOF as numeric)), " +
" 0.00 AS VL_PREMIO_PAGO, " +
" 0.00 AS VL_DESCONTO_PAGO, " +
" 0.00 AS VL_MULTA_PAGO, " +
" 0.00 AS VL_IOF_RETIDO, " +
" 0.00 AS VL_DIF_PREMIO, " +
" 0.00 AS VL_JUROS_COBRADO, " +
" 0.00 AS VL_JUROS_DEVIDO, " +
" 0.00 AS VL_ADIC_FRACIONAMENTO_PAGO, " +
" 0.00 AS VL_ADIC_FRACIONAMENTO_DEVIDO, " +
" 0.00 AS CD_SEQ_ORIGEM, " +
" 'N' AS FL_MIGRADO, " +
" a.DT_MUDANCA, " +
" 'POC_SAC_20200520' AS NM_USUARIO, " +
" max(a.TP_MUDANCA), " +
" max(a.DT_MUDANCA) " +
$" from {Parametros.instanciaDB}.tab_stg_parcela_auto_1002 a " +
$" INNER JOIN ({dadosWhere}) b " +
"     on a.id_registro = b.id_registro " +
$" inner join {Parametros.instanciaDB}.tab_prm_produto_7003 prd " +
"     on a.cd_produto = prd.cd_produto " +
"     and now() between prd.dt_inicio_vigencia and prd.dt_fim_vigencia " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 cli " +
"     on cast(a.cd_cliente as int) = cast(cli.cd_externo as int) " +
"     and cast(a.cd_operacao as int) = cast(cli.cd_operacao as int) " +
"     and cli.cd_tipo_parceiro_negocio = 'CL' " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 op " +
"     on cast(a.cd_operacao as int) = cast(op.cd_externo as int) " +
"     and op.cd_tipo_parceiro_negocio = 'OP' " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 tp " +
"     on upper(a.nm_tpa) = upper(tp.cd_externo) " +
"     and tp.cd_tipo_parceiro_negocio = 'TP' " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 su " +
"     on cast(a.cd_sucursal as int) = cast(su.cd_externo as int) " +
"     and su.cd_tipo_parceiro_negocio = 'SU' " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 se " +
"     on cast(a.cd_seguradora as int) = cast(se.cd_externo as int) " +
"     and se.cd_tipo_parceiro_negocio = 'SE' " +
$" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 co " +
"     on cast(a.cd_corretor as int) = cast(co.cd_externo as int) " +
"     and co.cd_tipo_parceiro_negocio = 'CO' " +
" WHERE CD_TIPO_EMISSAO IN(1, 18, 20) " +
" group by " +
" se.cd_parceiro_negocio, " +
" su.cd_parceiro_negocio, " +
" op.cd_parceiro_negocio, " +
" tp.cd_parceiro_negocio, " +
" cli.cd_parceiro_negocio, " +
" co.cd_parceiro_negocio, " +
" a.CD_CONTRATO, " +
" a.NR_APOLICE, " +
" a.nr_sequencial_emissao, " +
" a.NR_ENDOSSO, " +
" a.NR_PARCELA , " +
" id_prm_produto, " +
" a.CD_FORMA_PAGTO, " +
" CD_FRANQUIA, " +
" cast(CD_MOEDA as int), " +
" CD_MOVTO_COBRANCA, " +
" CD_TIPO_EMISSAO, " +
" ID_TRANSACAO_CANC, " +
" a.NM_ARQUIVO_TPA, " +
" NR_APOLICE_ORIGINAL, " +
" NR_DOCUMENTO, " +
" NR_PROPOSTA," +
" a.DT_MUDANCA ; ";
        }

        public static void Insert(Massa_Sinistro_Parcela parcela, IMyLogger logger)
        {
            var detalheLinha = " select " +
" id_registro " +
$" from {Parametros.instanciaDB}.tab_stg_parcela_auto_1002 " +
$" WHERE {parcela.ObterTextoWhere(StageParcAuto.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())} ";
            var sql = InsertText(detalheLinha);

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }

        public static void Insert(string idRegistro, IMyLogger logger)
        {
            var detalheLinha = $" select '{idRegistro}' AS ID_REGISTRO FROM DUMMY ";
            var sql = InsertText(detalheLinha);

            var count1 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsParcela.ObterTexto(), logger);
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
            var count2 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsParcela.ObterTexto(), logger);
            if (count1 == count2)
            {
                logger.Erro($"ERRO NO INSERT DA PARCELA PARA O ID_REGISTRO : '{idRegistro}' - NENHUMA LINHA INSERIDA");
                throw new Exception("NENHUMA LINHA INSERIDA NA ODS PARCELA PARA O ID_REGISTRO: " + idRegistro);
            }
        }
    }
}
