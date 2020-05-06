using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG05
{
    public class ValidadorODSFG05
    {
        private Arquivo arquivo;
        private IMyLogger logger;
        private TabelasEnum tabelaEnum;

        public ValidadorODSFG05(IMyLogger logger, Arquivo arquivo)
        {
            this.arquivo = arquivo;
            this.logger = logger;
            tabelaEnum = arquivo.tipoArquivo.ObterTabelaODSEnum();
        }

        public ConjuntoConsultas MontarConsulta()
        {
            return FabricaConsulta.MontarConsultaParaODS(tabelaEnum, arquivo);
        }

        public DataRowCollection ValidarODS()
        {
            logger.AbrirBloco("VALIDANDO EXPORTAÇÃO DE ARQUIVO PARA ODS.");
            var table = DataAccess.Consulta(MontarConsulta().MontarConsulta(),"LINHAS DA ODS IMPORTADAS",logger);
            logger.Escrever($"Linhas encontradas na ODS : {table.Rows.Count}");
            if (arquivo.Linhas.Count != table.Rows.Count)
                throw new Exception("ERRO NA IMPORTAÇÃO DA ODS");

            return table.Rows;
        }

        public bool HouveAlteracaoODS(DataRowCollection linhasAntigas)
        {
            var linhasNovas = ValidarODS();
            for (int i = 0; i < linhasAntigas.Count; i++)
            {
                for (int j = 0; j < linhasAntigas[0].Table.Columns.Count; j++)
                {
                    if (linhasAntigas[i][j].Equals(linhasNovas[i][j]))
                        return true;
                }
            }
            return true;
        }

    }
}
