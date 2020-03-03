using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class ListaExtensions
    {
        public static string ObterListaConcatenada(this List<string> lista, string separador)
        {
            if (lista.Count == 0)
                return string.Empty;

            var retorno = string.Empty;
            foreach (var l in lista)
                retorno += l + separador;
            return retorno.Remove(retorno.Length - separador.Length);
        }
    }
}
