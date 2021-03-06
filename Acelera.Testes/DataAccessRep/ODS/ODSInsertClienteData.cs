﻿using Acelera.Domain;
using Acelera.Domain.DataAccess;
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
    public static class ODSInsertClienteData
    {
        public static string InsertText(string dadosWhere)
        {
            return $" insert into {Parametros.instanciaDB}.tab_ods_parceiro_negocio_2000 " +
            $" select  {Parametros.instanciaDB}.SEQ_ODS_PARCEIRO_NEGOCIO_2000.nextval as cd_parceiro_negocio  , " +// {Parametros.instanciaDB}.SEQ_ODS_PARCEIRO_NEGOCIO_2000.nextval as cd_parceiro_negocio, " +
            @" 'CL' as cd_tipo_parceiro_negocio, " +
            @" a.cd_cliente as cd_externo, " +
            @" tp_pessoa as cd_tipo_pessoa, " +
            @" nm_cliente as nm_parceiro, " +
            @" nr_cnpj_cpf as nr_cnpj_cpf_rne, " +
            @" cast(dt_nascimento as date) as dt_nascimento, " +
            @" nm_arquivo_tpa, " +
            @" cd_sexo as cd_tip_sexo, " +
            @" '' as cd_susep, " +
            @" '' as dt_inicio_vigencia, " +
            @" '' as dt_fim_vigencia, " +
            @" 'S' as cd_situacao, " +
            @" ds_email as email, " +
            @" null as nr_banco, " +
            @" null as nr_agencia, " +
            @" null as nr_agencia_dig, " +
            @" null as nr_conta, " +
            @" null as nr_conta_dig, " +
            @" null as cd_forma_pagto, " +
            @" null as cd_pessoa_sgs, " +
            @" cd_operacao, " +
            @" 'N' as fl_comissao_calculada, " +
            @" dt_inclusao, " +
            @" 'POC_SAC_20200517' as nm_usuario, " +
            @" 'N' as flag_migrado, " +
            @" tp_mudanca, " +
            @" dt_mudanca, "+
            @" 'N' as fl_retorno_complementar" +
            $" from {Parametros.instanciaDB}.tab_stg_cliente_1000 a " +
            $" inner join ({dadosWhere}) b " +
            @" ON a.id_registro = b.id_registro; ";
        }
        public static void Insert(Massa_Cliente_Sinistro cliente, IMyLogger logger)
        {
            var dadosdaLinha = @" select distinct id_registro " +
            $" FROM {Parametros.instanciaDB}.tab_stg_cliente_1000 " +
            $" WHERE {cliente.ObterTextoWhere(StageCliente.CamposDaTabela().Where(x => new string[] { "DT_ARQUIVO", "ID_REGISTRO", "CD_STATUS_PROCESSAMENTO" }.Contains(x) == false).ToList())} ";
            var sql = InsertText(dadosdaLinha);

            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
        }


        public static void Insert(string idRegistro, IMyLogger logger)
        {
            var detalheLinha = $" select '{idRegistro}' AS ID_REGISTRO FROM DUMMY ";
            var sql = InsertText(detalheLinha);

            var count1 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsParceiroNegocio.ObterTexto(),logger);
            DataAccess.ExecutarComando(sql, DBEnum.Hana, logger);
            var count2 = DataAccess.ObterTotalLinhas(TabelasEnum.OdsParceiroNegocio.ObterTexto(), logger);
            if (count1 == count2)
            {
                logger.Erro($"ERRO NO INSERT DO CLIENTE PARA O ID REGISTRO : '{idRegistro}' - NENHUMA LINHA INSERIDA");
                throw new Exception("NENHUMA LINHA INSERIDA NA ODS PARCEIRO NEGOCIO PARA O ID REGISTRO: " + idRegistro);
            }
        }
    }
}
