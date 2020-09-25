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
        public static IList<T> ObterListaComTodos<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }

        public static T ObterEnumPelaDescricao<T>(string descricao) where T : Enum
        {
            return (T)ObterListaComTodos<T>().First(x => x.ObterTexto() == descricao);
        }
    }
}
