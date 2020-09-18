using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acelera.Contratos
{
    public interface ICampoDoArquivo : ICampo
    {
        ICampoDoArquivo Clone();
        int Posicoes { get; set; }

        string NomeBanco { get; set; }

        void AlterarValor(string novoValor);
    }
}
