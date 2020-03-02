using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class Campo
    {
        public virtual string Coluna { get; set; }
        public string Valor { get; set; }

        public Campo(string coluna)
        {
            Coluna = coluna;
        }

        public Campo(string coluna, string valor)
        {
            Coluna = coluna;
            Valor = valor;
        }
    }
}
