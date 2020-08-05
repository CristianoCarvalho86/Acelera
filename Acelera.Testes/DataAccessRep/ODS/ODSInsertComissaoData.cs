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
    public static class ODSInsertComissaoData
    {
        public static string InsertText(string dadosWhere)
        {
            return $"insert into {Parametros.instanciaDB}.TAB_ODS_COMISSAO_2006(" +
            " CD_COMISSAO," +
            " CD_PARCELA," +
            " CD_PN_CORRETOR ," +
            " CD_TIPO_COMISSAO," +
            " VL_COMISSAO ," +
            " VL_BASE_CALCULO ," +
            " PC_COMISSAO ," +
            " PC_PARTICIPACAO, " +
            " NM_ARQUIVO_TPA ," +
            " CD_STATUS_COMISSAO ," +
            " NR_SEQ_OIMX ," +
            " CD_ATUACAO," +
            " CD_TIPO_LANCAMENTO ," +
            " AN_MES_REFERENCIA," +
            " VL_COMISSAO_PAGO ," +
            " DT_PAGO ," +
            " DT_BAIXA," +
            " DT_CANCELAMENTO ," +
            " CD_PARCELA_CANCELAMENTO," +
            " CD_SEQ_ORIGEM," +
            " DT_INCLUSAO," +
            " NM_USUARIO ," +
            " FL_MIGRADO ," +
            " TP_MUDANCA ," +
            " DT_MUDANCA" +
            " )" +
            " select" +
            $" {Parametros.instanciaDB}.SEQ_ODS_COMISSAO_2006.nextval AS CD_COMISSAO," +
            " PARCODS.CD_PARCELA," +
            " co.cd_parceiro_negocio as CD_PN_CORRETOR," +
            " CD_TIPO_COMISSAO," +
            " SUM(CAST(VL_COMISSAO AS NUMERIC)) AS VL_COMISSAO," +
            " SUM(CAST(VL_BASE_CALCULO AS NUMERIC)) AS VL_BASE_CALCULO," +
            " max(CAST(PC_COMISSAO AS NUMERIC)) AS PC_COMISSAO," +
            " max(CAST(PC_PARTICIPACAO AS NUMERIC)) AS PC_PARTICIPACAO," +
            " A.NM_ARQUIVO_TPA," +
            " 'EM' AS CD_STATUS_COMISSAO," +
            " 0 AS NR_SEQ_OIMX," +
            " 'EM' AS CD_ATUACAO," +
            " NULL AS CD_TIPO_LANCAMENTO," +
            " NULL AS AN_MES_REFERENCIA," +
            " 0.00 AS VL_COMISSAO_PAGO," +
            " NULL AS DT_PAGO," +
            " NULL AS DT_BAIXA," +
            " NULL AS DT_CANCELAMENTO," +
            " NULL AS CD_PARCELA_CANCELAMENTO," +
            " NULL AS CD_SEQ_ORIGEM," +
            " MAX(A.DT_INCLUSAO)," +
            " PARCODS.NM_USUARIO ," +
            " 'N' AS FL_MIGRADO," +
            " A.TP_MUDANCA ," +
            " MAX(A.DT_MUDANCA)" +
            $" from {Parametros.instanciaDB}.tab_stg_comissao_1003 a" +
            $" INNER JOIN ({dadosWhere}) b" +
            "     on a.id_registro = b.id_registro" +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_STG_PARCELA_1001 PARCSTG" +
            "     ON a.cd_contrato = PARCSTG.cd_contrato" +
            "     and a.nr_parcela = PARCSTG.nr_parcela" +
            "     and a.nr_sequencial_emissao = PARCSTG.nr_sequencial_emissao" +
            "     and a.cd_cobertura = PARCSTG.cd_cobertura" +
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 PARCODS" +
            "     ON PARCODS.cd_contrato = PARCSTG.cd_contrato" +
            "     and PARCODS.nr_apolice = PARCSTG.nr_apolice" +
            "     and PARCODS.nr_seq_emissao = PARCSTG.nr_sequencial_emissao" +
            "     and PARCODS.nr_endosso = PARCSTG.nr_endosso" +
            $" inner join {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 co" +
            "     on cast(a.cd_corretor as int) = cast(co.cd_externo as int)" +
            "     and co.cd_tipo_parceiro_negocio = 'CO'" +
            " where PARCSTG.cd_tipo_emissao in (1, 18, 20)" +
            " group by" +
            " PARCODS.CD_PARCELA," +
            " co.cd_parceiro_negocio," +
            " CD_TIPO_COMISSAO," +
            " A.NM_ARQUIVO_TPA," +
            " PARCODS.NM_USUARIO," +
            " A.TP_MUDANCA;";
        }


        public static void Insert(string idRegistro, IMyLogger logger)
        {
            var detalheLinha = $" select '{idRegistro}' AS ID_REGISTRO FROM DUMMY ";
            var sql = InsertText(detalheLinha);

            var count1 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsComissao.ObterTexto(), logger);
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
            var count2 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsComissao.ObterTexto(), logger);
            if (count1 == count2)
            {
                logger.Erro($"ERRO NO INSERT DA PARCELA PARA O ID_REGISTRO : '{idRegistro}' - NENHUMA LINHA INSERIDA");
                throw new Exception("NENHUMA LINHA INSERIDA NA ODS PARCELA PARA O ID_REGISTRO: " + idRegistro);
            }
        }
    }
}
