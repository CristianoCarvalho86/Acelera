using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Tabelas
{
    public abstract class EntidadeDeTabela
    {
        public abstract string NomeTabela { get; }
        public string ObterTextoWhere()
        {
            var sql = "";
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                sql += $"{pi.Name} = '{pi.GetValue(this)}' AND "; // properties[i].SetValue(newInstance, pi.GetValue(this, null), null);
            }
            return sql.Remove(sql.Length - 4);
        }

        public string ObterTextoSelect(string prefixoTabela = "")
        {
            prefixoTabela = prefixoTabela == string.Empty ? "" : prefixoTabela + ".";
            var sql = "";
            foreach (PropertyInfo pi in this.GetType().GetProperties())
            {
                sql += $"{prefixoTabela}{pi.Name} ,"; // properties[i].SetValue(newInstance, pi.GetValue(this, null), null);
            }
            return sql.Remove(sql.Length - 1);
        }

        public IList<T> CarregarEntidade<T>(DataTable table) where T:new()
        {
            List<T> entidades = new List<T>();
            T ent;
            foreach (DataRow row in table.Rows)
            {
                ent = new T();
                foreach (PropertyInfo pi in this.GetType().GetProperties())
                {
                    pi.SetValue(ent,row[pi.Name].ToString());
                }
                entidades.Add(ent);
            }
            return entidades;
        }

    }
}
