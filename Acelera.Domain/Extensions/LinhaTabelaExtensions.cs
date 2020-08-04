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
        public static string ObterWhereCamposChaves(this ILinhaTabela linha, string[] camposChaves)
        {
            var where = "";
            var campoAjustado = "";
            foreach (var campo in camposChaves)
            {
                if (campo == "vl_premio")
                    campoAjustado = "VL_PREMIO_LIQUIDO";
                where += $"{campoAjustado} = '{linha.ObterPorColuna(campoAjustado.ToUpper()).ValorFormatado}' AND";
            }
            return where.Substring(0, where.Length - 3);
        }
    }
}
