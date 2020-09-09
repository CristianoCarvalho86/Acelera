using Acelera.Domain.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class LinhaTabelaExtensions
    {
        public static string ObterWhereCamposChaves(this ILinhaTabela linha, string[] camposChaves, bool comAspasNoCampo = false)
        {
            var where = "";
            var campoAjustado = "";
            var aspas = comAspasNoCampo ? "\"" : "";
            foreach (var campo in camposChaves)
            {
                campoAjustado = campo;
                if (campo == "vl_premio")
                    continue;
                if (linha.ObterNomeTabela().Contains("STG") && campo == "nr_linha")
                    continue;

                where += $" {aspas}{campo}{aspas} = '{linha.ObterPorColuna(campoAjustado).ValorFormatado}' AND ";
            }
            return where.Substring(0, where.Length - 4);
        }
    }
}
