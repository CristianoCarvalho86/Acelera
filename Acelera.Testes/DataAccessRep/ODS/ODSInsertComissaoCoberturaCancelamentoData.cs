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
    public static class ODSInsertComissaoCoberturaCancelamentoData
    {
        public static string InsertText(string dadosWhere)
        {
            return "insert into TAB_ODS_COBERTURA_COMISSAO_2008(" +
" CD_COMISSAO," +
" ID_COBERTURA" +
" VL_COMISSAO ," +
" VL_BASE_CALCULO, " +
" DT_INCLUSAO," +
" NM_USUARIO ," +
" FL_MIGRADO ," +
" TP_MUDANCA ," +
" DT_MUDANCA" +
" )" +
" select" +
" CMSODS.CD_COMISSAO," +
" COB.ID_COBERTURA," +
" sum(CAST(A.VL_COMISSAO AS NUMERIC)) AS VL_COMISSAO," +
" sum(CAST(A.VL_BASE_CALCULO AS NUMERIC)) AS VL_BASE_CALCULO," +
" max(A.DT_INCLUSAO)," +
" CMSODS.NM_USUARIO ," +
" 'N' AS FL_MIGRADO," +
" A.TP_MUDANCA ," +
" max(A.DT_MUDANCA)" +
" from tab_stg_comissao_1003 a" +
$" INNER JOIN ({dadosWhere}) b" +
"     on a.id_registro = b.id_registro" +
" INNER JOIN TAB_STG_PARCELA_1001 PARCSTG" +
"     ON a.cd_contrato = PARCSTG.cd_contrato" +
"     and a.nr_parcela = PARCSTG.nr_parcela" +
"     and a.nr_sequencial_emissao = PARCSTG.nr_sequencial_emissao" +
"     and a.cd_cobertura = PARCSTG.cd_cobertura" +
" INNER JOIN TAB_ODS_PARCELA_2003 PARCODS" +
"     ON PARCODS.cd_contrato = PARCSTG.cd_contrato" +
"     and PARCODS.nr_apolice = PARCSTG.nr_apolice" +
"     and PARCODS.nr_seq_emissao = PARCSTG.nr_sequencial_emissao" +
" INNER JOIN TAB_ODS_COMISSAO_2006 CMSODS" +
"     ON CMSODS.CD_PARCELA = PARCODS.CD_PARCELA" +
"     AND CMSODS.cd_tipo_comissao = a.cd_tipo_comissao" +
" INNER JOIN TAB_PRM_COBERTURA_7007 COB" +
"     ON A.CD_COBERTURA = COB.CD_COBERTURA" +
"     AND PARCSTG.CD_PRODUTO = COB.CD_PRODUTO" +
"     AND PARCSTG.CD_RAMO = COB.CD_RAMO_COBERTURA" +
" where PARCSTG.cd_tipo_emissao IN('9','10', '11','12', '13')" +
" group by" +
" CMSODS.CD_COMISSAO," +
" COB.ID_COBERTURA," +
" CMSODS.NM_USUARIO ," +
" A.TP_MUDANCA; "; 
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
                throw new Exception("NENHUMA LINHA INSERIDA NA ODS COMISSAO COBERTURA CANCELAMENTO PARA O ID_REGISTRO: " + idRegistro);
            }
        }
    }
}
