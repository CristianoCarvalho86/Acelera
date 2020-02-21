using Acelera.Domain.Entidades.Consultas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Tabelas
{
    public class Tabela<T> where T : LinhaTabela, new()
    {
        public List<T> Linhas { get; set; }
        private T linhaReferencia;

        public Tabela()
        {
            Linhas = new List<T>();
            linhaReferencia = new T();
        }

        public void  AddLinha(T linha)
        {
            Linhas.Add(linha);
        }

        public string ObterQuery(Consulta consulta)
        {
            var linha = new T();
            var sql = "select ";
            foreach (var i in linha.Campos)
                sql += $"(CONCAT('{i.Coluna}:',{i.Coluna})) as {i.Coluna},";
            sql = sql.Remove(sql.Length - 1);
            sql += $" from HDIQAS_1.{linha.ObterNomeTabela()} ";
            sql += consulta.MontarConsulta();
            return sql;
        }

        public void ObterRetornoQuery(string resultadoCMD)
        {
            var linhas = resultadoCMD.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var linhasResultado = linhas.Where(x => x.Contains(linhaReferencia.Campos[0].Coluna) && !x.Contains("CONCAT"));
            foreach (var l in linhasResultado)
            {
                var linhaNova = new T();
                linhaNova.CarregarLinha(l);
                AddLinha(linhaNova);
            }
        }
    }
}
