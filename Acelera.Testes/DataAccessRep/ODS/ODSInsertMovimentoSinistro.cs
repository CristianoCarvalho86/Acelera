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
    public static class ODSInsertMovimentoSinistro
    {
        public static string InsertText(string cdAviso)
        {
            return $" insert into {Parametros.instanciaDB}.TAB_ODS_MOVIMENTO_SINISTRO_2009(" +
            $" cd_mov_sinistro,"+
            $" cd_aviso_sinistro,"+
            $" tp_sinistro,"+
            $" cd_atuacao, "+
            $" cd_tipo_movimento,"+
            $" id_cobertura, "+
            $" nr_seq_oimx,"+
            $" dt_movimento, "+
            $" cd_movimento, "+
            $" cd_status,"+
            $" dt_pagamento, "+
            $" cd_forma_pagto, "+
            $" dt_nasc_condutor, "+
            $" in_sexo_condutor, "+
            $" cd_tipo_beneficiario, "+
            $" nr_docto_beneficiario,"+
            $" nm_beneficiario,"+
            $" en_beneficiario,"+
            $" en_compl_beneficiario,"+
            $" en_bairro_beneficiario, "+
            $" en_cidade_beneficiario, "+
            $" en_uf_beneficiario, "+
            $" en_cep_beneficiario,"+
            $" en_pais_beneficiario, "+
            $" dt_nasc_beneficiario, "+
            $" cd_banco, "+
            $" nr_agencia, "+
            $" nr_agencia_dig, "+
            $" nr_conta, "+
            $" nr_conta_dig, "+
            $" cd_banco_seg, "+
            $" nr_agencia_seg, "+
            $" nr_agencia_dig_seg, "+
            $" nr_conta_seg, "+
            $" nr_conta_dig_seg, "+
            $" nr_cheque,"+
            $" vl_movimento, "+
            $" vl_taxa_pagto,"+
            $" vl_correcao_monetaria,"+
            $" vl_juros, "+
            $" nm_arquivo_tpa, "+
            $" cd_seq_origem,"+
            $" fl_migrado, "+
            $" dt_inclusao,"+
            $" nm_usuario, "+
            $" nr_apolice_arquivo, "+
            $" dt_movimento_oimx,"+
            $" dt_pagamento_oimx,"+
            $" tp_mudanca, "+
            $" dt_mudanca, "+
            $" nr_item)"+
            $" select"+
            $" {Parametros.instanciaDB}.SEQ_ODS_MOVIMENTO_SINISTRO_2009.nextval as cd_mov_sinistro, " +
            $" a.cd_aviso_sinistro,"+
            $" tp_sinistro,"+
            $" 'SN' as cd_atuacao, "+
            $" cd_tipo_movimento,"+
            $" id_cobertura, "+
            $" 0 as nr_seq_oimx, "+
            $" dt_movimento, "+
            $" cd_movimento, "+
            $" null as cd_status,"+
            $" null as dt_pagamento, "+
            $" null as cd_forma_pagto, "+
            $" null as dt_nasc_condutor, "+
            $" null as in_sexo_condutor, "+
            $" cd_tipo_beneficiario, "+
            $" nr_docto_beneficiario,"+
            $" nm_beneficiario,"+
            $" en_beneficiario,"+
            $" en_compl_beneficiario,"+
            $" en_bairro_beneficiario, "+
            $" en_cidade_beneficiario, "+
            $" en_uf_beneficiario, "+
            $" en_cep_beneficiario,"+
            $" en_pais_beneficiario, "+
            $" dt_nasc_beneficiario, "+
            $" cd_banco, "+
            $" nr_agencia, "+
            $" nr_agencia_dig, "+
            $" nr_conta, "+
            $" nr_conta_dig, "+
            $" cd_banco_seg, "+
            $" nr_agencia_seg, "+
            $" nr_agencia_dig_seg, "+
            $" nr_conta_seg, "+
            $" nr_conta_dig_seg, "+
            $" null as nr_cheque,"+
            $" vl_movimento, "+
            $" vl_taxa_pagto,"+
            $" vl_correcao_monetaria,"+
            $" vl_juros, "+
            $" a.nm_arquivo_tpa, "+
            $" a.cd_seq_origem,"+
            $" a.fl_migrado, "+
            $" a.dt_inclusao,"+
            $" a.nm_usuario, "+
            $" a.nr_apolice_arquivo, "+
            $" null as dt_movimento_oimx,"+
            $" null as dt_pagamento_oimx,"+
            $" a.tp_mudanca, "+
            $" a.dt_mudanca, "+
            $" b.nr_item "+
            $" from {Parametros.instanciaDB}.TAB_ODS_SINISTRO_2007 a"+
            $" inner join {Parametros.instanciaDB}.TAB_STG_SINISTRO_1006 b" +
            $" on a.cd_aviso = b.cd_aviso"+
            $" and a.cd_sinistro = b.cd_sinistro "+
            $" inner join {Parametros.instanciaDB}.TAB_PRM_COBERTURA_7007 c " +
            $" on b.cd_cobertura = c.cd_cobertura"+
            $" and b.cd_produto = c.cd_produto "+
            $" where a.cd_aviso = '{cdAviso}'";
        }

        public static void Insert(string cdAviso, IMyLogger logger)
        {
            var sql = InsertText(cdAviso);

            var count1 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsMovimentoSinistro.ObterTexto(), logger);
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
            var count2 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsMovimentoSinistro.ObterTexto(), logger);
            if (count1 == count2)
            {
                logger.Erro($"ERRO NO INSERT DA {TabelasEnum.OdsMovimentoSinistro.ObterTexto()} PARA O CD_AVISO : '{cdAviso}' - NENHUMA LINHA INSERIDA");
                throw new Exception($"NENHUMA LINHA INSERIDA NA {TabelasEnum.OdsMovimentoSinistro.ObterTexto()} PARA O CD_AVISO: " + cdAviso);
            }
        }
    }
}
