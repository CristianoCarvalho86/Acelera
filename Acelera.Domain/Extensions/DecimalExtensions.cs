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
            return numero.ToString("0.00").Replace(',', '.');
        }
    }
}
