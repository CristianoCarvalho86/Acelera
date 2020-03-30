using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{

    public class ConjuntoConsultas
    {
        protected IList<Consulta> ListaConsultas { get; private set; }
        protected string OrderBy { get; set; }
        public ConjuntoConsultas()
        {
            ListaConsultas = new List<Consulta>();
        }

        public ConjuntoConsultas(Consulta consulta) : this()
        {
            ListaConsultas.Add(consulta);
        }

        public void AdicionarOrderBy(string valor)
        {
            OrderBy = valor;
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            ListaConsultas.Add(consulta);
        }

        public Consulta ObterConsultaUnica()
        {
            if (ListaConsultas.Count > 1)
                throw new Exception("MAIS DE UMA CONSULTA ENCONTRADA.");
            return ListaConsultas.First();
        }

        public virtual string MontarConsulta()
        {
            var sql = " WHERE ";
            var primeiro = true;
            foreach (var consulta in ListaConsultas)
            {
                if (!primeiro)
                    sql += " OR ";
                else
                    primeiro = false;
                sql += "(";
                foreach (var item in consulta.Valores)
                {
                    
                    var valor = string.Empty;
                    valor = item.Value.TrimStart();

                    if (!string.IsNullOrEmpty(valor))
                        sql += item.Key + $" = '{valor}' AND ";
                    else
                        sql += item.Key + $" IS NULL AND ";
                    
                }
                sql = sql.Remove(sql.Length - 4);
                sql += ") ";
            }
            sql += OrderBy;
            return sql;
        }

        private IList<string> CamposQueNaoModificamZero()
        {
            var lista = new List<string>();
            lista.Add("CD_COBERTURA");
            return lista;
        }

    }

    public class Consulta : ICloneable
    {
        public Dictionary<string, string> Valores { get; set; }

        public Consulta()
        {
            Valores = new Dictionary<string, string>();
        }

        public void AdicionarConsulta(string campo, string valor)
        {
            if (!Valores.Any(x => x.Key == campo))
                Valores.Add(campo, valor);
        }


        public void ContemCampo(string campo)
        {
            Valores.ContainsKey(campo);
        }

        public object Clone()
        {
            var consulta = new Consulta();
            consulta.Valores = this.Valores.ToDictionary(entry => entry.Key,
                                               entry => entry.Value);
            return consulta;
        }
    }
}
