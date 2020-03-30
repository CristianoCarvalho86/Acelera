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
        public ValidadorTabelaRetornoFG02(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter) 
            : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {
        }

        public override ConjuntoConsultas MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaTabelaDeRetornoFG01(tabela, nomeArquivo, valoresAlteradosBody);
            return new ConjuntoConsultas(consulta);
        }
    }
}
