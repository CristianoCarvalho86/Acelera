using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using System;
using System.Collections.Generic;
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
            var where = linhaStage.ObterWhereCamposChaves(TabelasOIMEnum.OIM_APL01.ObterCamposChaves());
            var sql = $"SELECT COUNT(*) AS TOTAL FROM {Parametros.instanciaDB}.{TabelasOIMEnum.OIM_APL01.ObterTexto()} WHERE {where}";
            var countOIMHana = DataAccess.ConsultaUnica(sql, $"QUANTIDADE DE REGISTROS NA {TabelasOIMEnum.OIM_APL01.ObterTexto()}", DBEnum.Hana, logger);
            logger.Escrever($"FORAM ENCONTRADOS {countOIMHana} na tabela do {TabelasOIMEnum.OIM_APL01.ObterTexto()} - HANA");

            sql = $"SELECT st_interface AS TOTAL FROM oim_apl01 WHERE {where}";
            var table = DataAccess.Consulta(sql, $"QUANTIDADE DE REGISTROS NA {TabelasOIMEnum.OIM_APL01.ObterTexto()}", DBEnum.SqlServerOIM, logger);
            logger.Escrever($"FORAM ENCONTRADOS {countOIMHana} na tabela do {TabelasOIMEnum.OIM_APL01.ObterTexto()} - HANA");

            if (countOIMHana.ObterValorInteiro() != table.Rows.Count)
            {
                logger.Erro($"FORAM ENCONTRADOS: {countOIMHana} NA TABELA {TabelasOIMEnum.OIM_APL01.ObterTexto()} E {table.Rows.Count} NA TABELA: oim_apl01");
                return false;
            }
            logger.Escrever("QUANTIDADE DE REGISTROS OBTIDOS VALIDADA COM SUCESSO");
            logger.Escrever("VALIDANDO CAMPO st_interface :");

            var retorno = table.ValidarValorUnico("st_interface", "A");

            logger.Escrever($"HOUVE ERRO NA VALIDAÇÃO: {!retorno}");

            return retorno;
        }

    }
}
