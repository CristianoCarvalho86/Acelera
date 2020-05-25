using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Tabelas
{
    public abstract class EntidadeDeTabela<T> where T : EntidadeDeTabela<T>,new()
    {
        public abstract string nomeTabela { get; }
        public static string NomeTabela { get { var a = new T(); return a.nomeTabela; } }
        public string ObterTextoWhere()
        {
            var sql = "";
            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                sql += $"{pi.Name} = '{pi.GetValue(this)}' AND "; // properties[i].SetValue(newInstance, pi.GetValue(this, null), null);
            }
            return sql.Remove(sql.Length - 4);
        }

        public static string ObterTextoSelect(string prefixoTabela = "")
        {
            prefixoTabela = prefixoTabela == string.Empty ? "" : prefixoTabela + ".";
            var sql = "";
            var a = new T();
            foreach (PropertyInfo pi in a.GetType().GetProperties())
            {
                sql += $"{prefixoTabela}{pi.Name} ,"; // properties[i].SetValue(newInstance, pi.GetValue(this, null), null);
            }
            return sql.Remove(sql.Length - 1);
        }

        public static IList<T> CarregarEntidade(DataTable table)
        {
            List<T> entidades = new List<T>();
            T ent;
            foreach (DataRow row in table.Rows)
            {
                ent = new T();
                foreach (PropertyInfo pi in ent.GetType().GetProperties())
                {
                    pi.SetValue(ent,row[pi.Name].ToString());
                }
                entidades.Add(ent);
            }
            return entidades;
        }

    }
}
