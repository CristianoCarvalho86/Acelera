﻿using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Tabelas
{
    public class Tabela<T> where T : ILinhaTabela, new()
    {
        public List<T> Linhas { get; set; }
        private T linhaReferencia;

        public Tabela()
        {
            Linhas = new List<T>();
            linhaReferencia = new T();
        }

        public string ObterNomeTabela()
        {
            return linhaReferencia.ObterNomeTabela();
        }

        public void  AddLinha(T linha)
        {
            Linhas.Add(linha);
        }

        public string ObterQuery(ConjuntoConsultas consulta, string instanciaDB)
        {
            var linha = new T();
            var sql = "select ";
            //foreach (var i in linha.Campos)
            //    sql += $"{i.Coluna},";
            //sql = sql.Remove(sql.Length - 1);
            sql += $" * from {instanciaDB}.{linha.ObterNomeTabela()} ";
            sql += consulta.MontarConsulta();
            return sql;
        }

        public void ObterRetornoQuery(DataTable tabela)
        {
            foreach (var row in tabela.Rows)
            {
                var linhaNova = new T();
                linhaNova.CarregarLinha((DataRow)row);
                AddLinha(linhaNova);
            }
        }

        [Obsolete("Utilize os metodos de acesso a banco")]
        public string ObterQueryParaCMD(ConjuntoConsultas consultas)
        {
            var linha = new T();
            var sql = "select ";
            foreach (var i in linha.Campos)
                sql += $"(CONCAT('{i.Coluna}:',{i.Coluna})) as {i.Coluna},";
            sql = sql.Remove(sql.Length - 1);
            sql += $" from HDIQAS_1.{linha.ObterNomeTabela()} ";
            sql += consultas.MontarConsulta();
            return sql;
        }



        [Obsolete("Utilize os metodos de acesso a banco")]
        public void ObterRetornoQueryCMD(string resultadoCMD)
        {
            var linhas = resultadoCMD.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var linhasResultado = linhas.Where(x => x.Contains(linhaReferencia.Campos[0].Coluna) && !x.Contains("CONCAT"));
            foreach (var l in linhasResultado)
            {
                var linhaNova = new T();
                linhaNova.CarregarLinhaPeloCMD(l);
                AddLinha(linhaNova);
            }
        }

    }
}
