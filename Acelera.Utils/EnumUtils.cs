using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class EnumUtils
    {
        public static OperadoraEnum ObterOperadoraDoArquivo(string nomeArquivo)
        {
            var lista = ObterListaComTodos<OperadoraEnum>();
            foreach(var operadora in lista)
            {
                if (nomeArquivo.Contains(operadora.ObterTexto()))
                    return operadora;
            }
            throw new Exception("OPERACAO NAO ENCONTRADA NO NOME DO ARQUIVO : " + nomeArquivo);
        }

        public static IList<T> ObterListaComTodos<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
