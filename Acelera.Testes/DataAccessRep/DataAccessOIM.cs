using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public class DataAccessOIM
    {
        protected IMyLogger logger { get; private set; }
        public DataAccessOIM(IMyLogger logger)
        {
            this.logger = logger;

        }

        public bool ValidarRegistrosOIM(ILinhaTabela linhaStage)
        {
            logger.AbrirBloco("VALIDANDO REGISTROS NA APL01 - OIM - SQL SERVER.");
            var where = linhaStage.ObterWhereCamposChaves(TabelasOIMEnum.OIM_APL01.ObterCamposChaves(),true);
            var sql = $"SELECT COUNT(*) AS TOTAL FROM {Parametros.instanciaDB}.{TabelasOIMEnum.OIM_APL01.ObterTexto()} WHERE {where}";
            var countOIMHana = DataAccess.ConsultaUnica(sql, $"QUANTIDADE DE REGISTROS NA {TabelasOIMEnum.OIM_APL01.ObterTexto()}", DBEnum.Hana, logger);

            sql = $"SELECT \"st_interface\" AS st_interface FROM oim_apl01 WHERE {where}";
            var table = DataAccess.Consulta(sql, $"QUANTIDADE DE REGISTROS NA {TabelasOIMEnum.OIM_APL01.ObterTexto()}", DBEnum.SqlServerOIM, logger);
            
            logger.Escrever($"FORAM ENCONTRADOS {countOIMHana} na tabela do {TabelasOIMEnum.OIM_APL01.ObterTexto()} - HANA");

            if (countOIMHana.ObterValorInteiro() != table.Rows.Count)
            {
                logger.Erro($"FORAM ENCONTRADOS: {countOIMHana} NA TABELA {TabelasOIMEnum.OIM_APL01.ObterTexto()} E {table.Rows.Count} NA TABELA: oim_apl01");
                return false;
            }
            logger.Escrever("QUANTIDADE DE REGISTROS OBTIDOS VALIDADA COM SUCESSO");
            logger.Escrever("VALIDANDO CAMPO st_interface :");

            logger.Escrever(table.ObterTextoEmLinhas());

            var retorno = table.ValidarValorUnico("st_interface", "A");

            logger.Escrever($"HOUVE ERRO NA VALIDAÇÃO: {!retorno}");

            return retorno;
        }

        public bool LogarErrosEncontradosRetornandoSeHouveErro(string idArquivo)
        {
            var sql = $"select * from oim_validacoes_imp where oag_id_arquivo = '{idArquivo}'";
            var table = DataAccess.Consulta(sql, $"", DBEnum.SqlServerOIM, logger,false);
            if (table != null && table.Rows.Count > 0)
            {
                logger.Escrever(table.ObterTextoTabular());
                return true;
            }
            return false;
        }

    }
}
