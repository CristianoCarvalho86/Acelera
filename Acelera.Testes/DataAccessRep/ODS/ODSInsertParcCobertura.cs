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
    public static class ODSInsertParcCobertura
    {
        public static string InsertText(string dadosWhere, TabelasEnum tabelaStage)
        {
            return $" insert into {Parametros.instanciaDB}.TAB_ODS_COBERTURA_2005( "+
            $" CD_PARCELA, "+
            $" ID_COBERTURA, "+
            $" CD_ITEM , "+
            $" CD_MOEDA ,"+
            $" VL_ADIC_FRACIONAMENTO,"+
            $" VL_CUSTO_APOLICE ,"+
            $" VL_FRANQUIA , "+
            $" VL_IOF ,"+
            $" VL_IS,"+
            $" VL_LMI ,"+
            $" VL_PREMIO_BRUTO , "+
            $" VL_PREMIO_LIQUIDO,"+
            $" VL_JUROS ,"+
            $" VL_DESCONTO , "+
            $" VL_TAXA_MOEDA,"+
            $" DT_INCLUSAO,"+
            $" NM_USUARIO ,"+
            $" FL_MIGRADO, "+
            $" TP_MUDANCA, "+
            $" DT_MUDANCA )"+
            $" select "+
            $" CD_PARCELA, "+
            $" cob.id_cobertura as ID_COBERTURA, "+
            $" CD_ITEM,"+
            $" stg.CD_MOEDA, "+
            $" stg.VL_ADIC_FRACIONADO AS VL_ADIC_FRACIONAMENTO,"+
            $" stg.VL_CUSTO_APOLICE ,"+
            $" VL_FRANQUIA , "+
            $" stg.VL_IOF ,"+
            $" VL_IS,"+
            $" VL_LMI ,"+
            $" stg.VL_PREMIO_TOTAL AS VL_PREMIO_BRUTO, "+
            $" stg.VL_PREMIO_LIQUIDO,"+
            $" stg.VL_JUROS, "+
            $" stg.VL_DESCONTO,"+
            $" stg.VL_TAXA_MOEDA,"+
            $" stg.DT_INCLUSAO,"+
            $" ODS.NM_USUARIO ,"+
            $" 'N' as FL_MIGRADO,"+
            $" stg.TP_MUDANCA, "+
            $" stg.DT_MUDANCA"+
            $" from {Parametros.instanciaDB}.{tabelaStage.ObterTexto()} STG" +
            $" INNER JOIN ({dadosWhere}) TMP " +
            $" ON STG.ID_REGISTRO = TMP.ID_REGISTRO                               "+
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCELA_2003 ODS " +
            $" ON STG.NR_APOLICE = ODS.NR_APOLICE"+
            $" AND STG.NR_ENDOSSO = ODS.NR_ENDOSSO "+
            $" AND STG.NR_PARCELA = ODS.NR_PARCELA "+
            $" AND STG.NR_SEQUENCIAL_EMISSAO = ODS.NR_SEQ_EMISSAO"+
            $" AND STG.CD_CONTRATO = ODS.CD_CONTRATO "+
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 OP " +
            $" ON OP.CD_PARCEIRO_NEGOCIO = ODS.CD_PN_OPERACAO"+
            $" AND CAST(STG.CD_OPERACAO AS INT) = CAST(OP.CD_EXTERNO AS INT) "+
            $" AND OP.CD_TIPO_PARCEIRO_NEGOCIO = 'OP'"+
            $" INNER JOIN {Parametros.instanciaDB}.TAB_ODS_PARCEIRO_NEGOCIO_2000 SE " +
            $" ON SE.CD_PARCEIRO_NEGOCIO = ODS.CD_PN_SEGURADORA"+
            $" AND CAST(STG.CD_SEGURADORA AS INT) = CAST(SE.CD_EXTERNO AS INT) "+
            $" AND SE.CD_TIPO_PARCEIRO_NEGOCIO = 'SE'"+
            $" INNER JOIN {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 COB " +
            $" ON STG.CD_COBERTURA = COB.CD_COBERTURA"+
            $" AND STG.CD_PRODUTO = COB.CD_PRODUTO "+
            $" and STG.CD_RAMO = COB.CD_RAMO_COBERTURA "+
            $" WHERE CD_TIPO_EMISSAO IN(1, 18, 20); "; 

        }

        public static void Insert(string idRegistro, TabelasEnum tabelaStage, IMyLogger logger)
        {
            var detalheLinha = $" select '{idRegistro}' AS ID_REGISTRO FROM DUMMY ";
            var sql = InsertText(detalheLinha,tabelaStage);

            var count1 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsCobertura.ObterTexto(), logger);
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
            var count2 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsCobertura.ObterTexto(), logger);
            if (count1 == count2)
            {
                logger.Erro($"ERRO NO INSERT DA {TabelasEnum.OdsCobertura.ObterTexto()} PARA O ID_REGISTRO : '{idRegistro}' - NENHUMA LINHA INSERIDA");
                throw new Exception($"NENHUMA LINHA INSERIDA NA {TabelasEnum.OdsCobertura.ObterTexto()} PARA O ID_REGISTRO: " + idRegistro);
            }
        }

    }
}
