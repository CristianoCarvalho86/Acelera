﻿using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Validadores.FG00;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.FG01
{
    public class ValidadorStagesFG01 : ValidadorStagesFG00
    {
        public ValidadorStagesFG01(TabelasEnum tabelaEnum, string nomeArquivo, MyLogger logger, AlteracoesArquivo valoresAlteradosBody, AlteracoesArquivo valoresAlteradosHeader, AlteracoesArquivo valoresAlteradosFooter)
        : base(tabelaEnum, nomeArquivo, logger, valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter)
        {

        }

        public override Consulta MontarConsulta(TabelasEnum tabela)
        {
            var consulta = FabricaConsulta.MontarConsultaParaStage(tabela, nomeArquivo, valoresAlteradosBody, ExisteAlteracaoHeaderOuFooter(), ExistemLinhasNoArquivo());
            AdicionaConsulta(consulta, valoresAlteradosHeader);
            AdicionaConsulta(consulta, valoresAlteradosFooter);
            consulta.AdicionarOrderBy(" ORDER BY DT_MUDANCA DESC ");

            return consulta;
        }

        public bool ValidarTabelaFG01(bool deveHaverRegistro, int codigoEsperado = 0)
        {
            var linhas = new List<ILinhaTabela>();
            return base.ValidarTabelaFG00(deveHaverRegistro,out linhas, codigoEsperado);
        }

    }
}
