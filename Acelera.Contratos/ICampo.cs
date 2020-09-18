using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acelera.Contratos
{
    public interface ICampo
    {
        string Coluna { get; set; }
        string Valor { get; set; }

        string ValorFormatado { get; }

        string ValorFormatadoNumerico { get; }

        decimal ValorDecimal { get; }

        int ValorInteiro { get; }

        string ColunaArquivo { get; }

    }
}
