using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class CampoTabela
    {
        public string Coluna { get; set; }
        public string Valor { get; set; }

        public CampoTabela(string coluna)
        {
            Coluna = coluna;
        }

        public CampoTabela(string coluna, string valor)
        {
            Coluna = coluna;
            Valor = valor;
        }
    }
}
