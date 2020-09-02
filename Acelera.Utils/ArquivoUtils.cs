using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ArquivoUtils
    {
        public static string ObterNumeroDoLote(string nomeArquivo)
        {
            return nomeArquivo.Split('-')[2];
        }

        public static string AlterarNumeroDoLote(string nomeArquivo)
        {
            return nomeArquivo.Split('-')[2];
        }

    }
}
