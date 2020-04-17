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
    }
}
