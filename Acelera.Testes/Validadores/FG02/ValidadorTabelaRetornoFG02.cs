using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Validadores.FG00;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG01
{
    public class ValidadorTabelaRetornoFG02 : ValidadorTabelaRetornoFG01
    {
        public ValidadorTabelaRetornoFG02(TabelasEnum tabelaEnum, string nomeArquivo, IMyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {
        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        {
            var consultaBase = FabricaConsulta.MontarConsultaParaTabelaDeRetornoFG02(tabela, nomeArquivo, valoresAlteradosBody);
            var consultas = new ConjuntoConsultas();

            if (valoresAlteradosBody != null && valoresAlteradosBody.ExisteAlteracaoValida())
            {
                var linhasAlteradas = consultaBase.Select(x => x.Key).Distinct().ToList();
                foreach (var linha in linhasAlteradas)
                {
                    var consulta = consultaBase.Where(x => x.Key == linha).First().Value;
                    consultas.AdicionarConsulta(consulta);
                }
            }
            else
            {
                consultas.AdicionarConsulta(consultaBase.First().Value);
            }

            consultas.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consultas;
        }
    }
}
