using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class DecimalExtensions
    {
        public static string ValorFormatado(this decimal numero)
        {
            var t = numero.ToString("0.00000000000000");
            return t.Remove(t.Length - 12).Replace(',', '.');
        }
    }
}
