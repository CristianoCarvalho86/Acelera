using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
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

        public ValidadorODSFG05(TabelasEnum tabelaEnum, IMyLogger logger, Arquivo arquivo)
        {
            this.arquivo = arquivo;
            this.logger = logger;
            this.tabelaEnum = tabelaEnum;
        }

        //public ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        //{
        //    return FabricaConsulta.MontarConsultaParaODS(tabela,arquivo);
        //}

    }
}
