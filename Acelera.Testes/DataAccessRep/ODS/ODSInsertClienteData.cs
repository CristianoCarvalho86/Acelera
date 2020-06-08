﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep.ODS
{
    public static class ODSInsertClienteData
    {
        public static void Insert(string nomeArquivo)
        {
            var sql = "do "+
            " begin  " +
            " query_int_cliente = " +
            " select distinct id_registro " +
            " FROM tab_stg_cliente_1000 " +
            $" WHERE NM_ARQUIVO_TPA = '{nomeArquivo}'; " +
            "             insert into tab_ods_parceiro_negocio_2000 " +
            "             select  SEQ_ODS_PARCEIRO_NEGOCIO_2000.nextval as cd_parceiro_negocio, " +
            " 		'CL' as cd_tipo_parceiro_negocio, " +
            " 		a.cd_cliente as cd_externo, " +
            " 		tp_pessoa as cd_tipo_pessoa, " +
            " 		nm_cliente as nm_parceiro, " +
            " 		nr_cnpj_cpf as nr_cnpj_cpf_rne, " +
            " 		cast(dt_nascimento as date), " +
            " 		nm_arquivo_tpa, " +
            " 		cd_sexo as cd_tip_sexo, " +
            " 		'' as cd_susep, " +
            " 		'' as dt_inicio_vigencia, " +
            " 		'' as dt_fim_vigencia, " +
            " 		'S' as cd_situacao, " +
            " 		ds_email as email, " +
            " 		null as nr_banco, " +
            " 		null as nr_agencia, " +
            " 		null as nr_agencia_dig, " +
            " 		null as nr_conta, " +
            " 		null as nr_conta_dig, " +
            " 		null as cd_forma_pagto, " +
            " 		null as cd_pessoa_sgs, " +
            " 		cd_operacao, " +
            " 		'N' as fl_comissao_calculada, " +
            " 		dt_inclusao, " +
            " 		'POC_SAC_20200517' as nm_usuario, " +
            " 		'N' as flag_migrado, " +
            " 		tp_mudanca, " +
            " 		dt_mudanca " +
            " from tab_stg_cliente_1000 a " +
            " inner join :query_int_cliente b " +
            " on a.id_registro = b.id_registro; " +
            "             end";
        }
    }
}