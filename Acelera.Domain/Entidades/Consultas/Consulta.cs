using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{

    public class Consultas
    {
        protected IList<Consulta> ListaConsultas { get; private set; }
        protected string OrderBy { get; set; }
        public Consultas()
        {
            ListaConsultas = new List<Consulta>();
        }


        public virtual string MontarConsulta()
        {
            var sql = " WHERE ";
            foreach (var consulta in ListaConsultas)
            {
                foreach (var item in consulta.Valores)
                {
                    sql += "(";
                    var valor = string.Empty;
                    valor = item.Value.TrimStart();

                    if (!string.IsNullOrEmpty(valor))
                        sql += item.Key + $" = '{valor}' AND ";
                    else
                        sql += item.Key + $" IS NULL AND ";
                    sql = sql.Remove(sql.Length - 4);
                    sql += ") ";
                }
            }
            sql += OrderBy
            return sql;
        }

        private IList<string> CamposQueNaoModificamZero()
        {
            var lista = new List<string>();
            lista.Add("CD_COBERTURA");
            return lista;
        }

    }

    public class Consulta
    {
        public Dictionary<string, string> Valores { get; set; }

        public Consulta()
        {
            Valores = new Dictionary<string, string>();
        }

        public Consulta Copy()
        {
            var consulta = new Consulta();
            consulta.Valores = this.Valores;
            consulta.OrderBy = this.OrderBy;
            return consulta;
        }

        public void AdicionarConsulta(string campo, string valor)
        {
            if (!Valores.Any(x => x.Key == campo))
                Valores.Add(campo, valor);
        }

        public void AdicionarOrderBy(string valor)
        {
            OrderBy = valor;
        }


        public void ContemCampo(string campo)
        {
            Valores.ContainsKey(campo);
        }


    }
}
