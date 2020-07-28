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

        public static string AlterarUltimosCaracteres(this string texto, string novoTexto)
        {
            if (novoTexto.Length > texto.Length)
                throw new Exception("OPERACAO DE AlterarUltimosCaracteres NAO PODE SER REALIZADA.");

            return texto.Remove(novoTexto.Length - 1) + novoTexto;
        }

        public static int? ObterParteNumericaDoTexto(this string texto)
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

        public static long ObterValorLong(this string texto)
        {
            return long.Parse(texto.Replace(".", ","));
        }

        public static int ObterValorInteiro(this string texto)
        {
            return int.Parse(texto.Replace(".", ","));
        }
    }
}
