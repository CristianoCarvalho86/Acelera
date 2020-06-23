using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class Campo
    {
        protected string coluna;
        public virtual string Coluna { get { return coluna; } set { coluna = value; } }
        public string Valor { get; set; }

        public string ValorFormatado
        {
            get
            {
                return Valor.TrimStart().TrimEnd();
            }
        }

        public string ValorFormatadoNumerico
        {
            get
            {
                return ValorFormatado.Replace(".",",");
            }
        }

        public decimal ValorDecimal
        {
            get
            {
                return decimal.Parse(ValorFormatadoNumerico);
            }
        }

        public decimal ValorInteiro
        {
            get
            {
                return int.Parse(ValorFormatadoNumerico);
            }
        }

        public virtual string ColunaArquivo { get; }

        public Campo(string _coluna)
        {
            Coluna = _coluna;
        }

        public Campo(string _coluna, string valor)
        {
            Coluna = _coluna;
            Valor = valor;
        }
    }
}
