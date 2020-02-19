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

        public Consulta()
        {
            Valores = new Dictionary<string, string>();
        }
        public void AdicionarConsulta(string campo, string valor)
        {
            Valores.Add(campo, valor);
        }

        public virtual string MontarConsulta()
        {
            var sql = " WHERE ";
            foreach (var item in Valores)
            {
                sql += item.Key + $" = '{item.Value}' AND ";
            }
            sql = sql.Remove(sql.Length - 4);
            return sql;
        }
    }
}
