using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string ObterUltimosCaracteres(this string texto, int qtdCaracteresDireitaParaEsquerda)
        {
            return texto.Substring(texto.Length - qtdCaracteresDireitaParaEsquerda);
        }

        public static int? ObterValorInteiro(this string texto)
        {
            string b = string.Empty;

            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsDigit(texto[i]))
                    b += texto[i];
            }

            if (b.Length > 0)
                return int.Parse(b);
            else
                return null;
        }

        public static decimal ObterValorDecimal(this string texto)
        {
            return decimal.Parse(texto.Replace(".", ","));
        }
    }
}
