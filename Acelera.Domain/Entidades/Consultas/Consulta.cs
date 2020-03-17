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
        protected string OrderBy { get; set; }

        public Consulta()
        {
            Valores = new Dictionary<string, string>();
        }
        public void AdicionarConsulta(string campo, string valor)
        {
            if(!Valores.Any(x => x.Key == campo))
                Valores.Add(campo, valor);
        }

        public void AdicionarOrderBy(string valor)
        {
            OrderBy = valor;
        }

        public virtual string MontarConsulta()
        {
            var sql = " WHERE (";
            sql += ObterWhereItens();
            return sql + ")/*R*/" + OrderBy ;
        }

        public virtual string AdicionarNovaConsulta(Consulta consulta)
        {
            var novaCondicao = $" OR ({consulta.ObterWhereItens()})";
            var sql = MontarConsulta().Replace("/*R*/", novaCondicao) + "/*R*/";
            return sql ;
        }


        private string ObterWhereItens()
        {
            var sql = string.Empty;
            foreach (var item in Valores)
            {
                var valor = string.Empty;
                    valor = item.Value.TrimStart();

                if(!string.IsNullOrEmpty(valor))
                sql += item.Key + $" = '{valor}' AND ";
                else
                    sql += item.Key + $" IS NULL AND ";
            }
            return sql.Remove(sql.Length - 4);
        }

        private IList<string> CamposQueNaoModificamZero()
        {
            var lista = new List<string>();
            lista.Add("CD_COBERTURA");
            return lista;
        }

        public void ContemCampo(string campo)
        {
            Valores.ContainsKey(campo);
        }


    }
}
