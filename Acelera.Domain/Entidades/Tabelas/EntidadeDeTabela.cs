using Acelera.Contratos;
using Acelera.Domain.Layouts;
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

        public virtual void TransformacoesDeDados()
        {

        }

        public static IList<string> CamposDaTabela()
        {
            var lista = new List<string>();
            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                lista.Add(pi.Name);
            }
            return lista;
        }
        public string ObterTextoWhere(IList<string> Campos, string prefixo = "")
        {
            var sql = "";
            prefixo = prefixo == "" ? string.Empty : prefixo + ".";
            foreach (PropertyInfo pi in typeof(T).GetProperties())
            {
                if (pi.Name.ToUpper() == "NOMETABELA" || (Campos != null && !Campos.Contains(pi.Name.ToUpper())))
                    continue;
                var valor = "";
                if (pi.GetValue(this).ToString() == string.Empty)
                    valor = $"({prefixo}{pi.Name} = '' OR {pi.Name} IS NULL)";
                else
                    valor = $"{prefixo}{pi.Name} = '{pi.GetValue(this)}'";

                sql += $" {valor} AND "; // properties[i].SetValue(newInstance, pi.GetValue(this, null), null);
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
                if (pi.Name.ToUpper() == "NOMETABELA")
                    continue;
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
                    if (pi.Name.ToUpper() == "NOMETABELA")
                        continue;
                    pi.SetValue(ent,row[pi.Name].ToString());
                }
                entidades.Add(ent);
            }
            return entidades;
        }

        public bool CompararCampos(T objetoAComparar)
        {
            bool campoEncontrado = false;
            foreach (PropertyInfo pi in objetoAComparar.GetType().GetProperties())
            {
                var propriedade = this.GetType().GetProperties().Where(x => x.Name == pi.Name).FirstOrDefault();
                if (propriedade == null)
                    continue;
                else
                    campoEncontrado = true;

                if (pi.Name.ToUpper() == "NOMETABELA")
                    continue;
                if (pi.GetValue(objetoAComparar).ToString() != propriedade.GetValue(this).ToString())
                    return false;
            }
            if (!campoEncontrado)
                throw new Exception("NENHUM CAMPO A COMPARAR!");
            return true;
        }

        public void CarregaLinhaArquivo(ILinhaArquivo linhaArquivo)
        {
            var propriedades = this.GetType().GetProperties();
            foreach (var prop in propriedades)
            {
                var campo = linhaArquivo.ObterCampoSeExistir(prop.Name);
                if (campo == null)
                    continue;
                campo.AlterarValor(prop.GetValue(this).ToString());
            }
        }

    }
}
