using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor
{
    public class ChaveValor
    {
        public string Chave { get; set; }
        public string Valor { get; set; }

        public ChaveValor(string chave, string valor)
        {
            Chave = chave;
            Valor = valor;
        }
    }
}
