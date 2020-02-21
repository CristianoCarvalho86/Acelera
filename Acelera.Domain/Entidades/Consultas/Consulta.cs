using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{
    public class Consulta
    {
        protected Dictionary<string, string> Valores { get; set; }
        string consulta;

        public Consulta()
        {
            Valores = new Dictionary<string, string>();
        }
        public void AdicionarConsulta(string campo, string valor)
        {
            if(!Valores.Any(x => x.Key == campo))
                Valores.Add(campo, valor);
        }

        public virtual string MontarConsulta()
        {
            var sql = " WHERE (";
            sql = ObterWhereItens();
            return sql + ")"; ;
        }

        private string ObterWhereItens()
        {
            var sql = string.Empty;
            foreach (var item in Valores)
            {
                sql += item.Key + $" = '{item.Value}' AND ";
            }
            return sql.Remove(sql.Length - 4);
        }


    }
}
