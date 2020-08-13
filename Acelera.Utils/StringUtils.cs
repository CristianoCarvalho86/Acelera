using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class StringUtils
    {
        public static bool ValidarTextoDeErrosEncontrados(this string texto, IMyLogger logger)
        {
            if (!string.IsNullOrEmpty(texto))
            {
                logger.Erro(texto);
                return false;
            }
            return true;
        }
    }
}
