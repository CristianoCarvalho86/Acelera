﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Sap.Data.Hana;

namespace Acelera.Data
{
    public class DBHelperHana:IDBHelper
    {
        public string ConnectionString { get; set; }
        private HanaConnection Conn { get; set; }
        private HanaDataAdapter adapter { get; set; }
        private HanaCommand command { get; set; }
        DataTable table;
        private static DBHelperHana instance;

        private DBHelperHana()
        {
            Conn = new HanaConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
        }

        public void SetConnection(string ConnectionString)
        {
            Conn = new HanaConnection(ConnectionString);
        }

        public static DBHelperHana Instance
        {
            get
            {
                try
                {
                    if (instance == null)
                    {
                        instance = new DBHelperHana();
                    }
                    return instance;
                }
                catch(Exception ex)
                {
                    throw new Exception("Erro ao obter Instancia");
                }
            }
        }
        public DataTable GetData(string sql)
        {
            try
            {
                if (table != null)
                {
                    table.Dispose();
                    table = null;
                }

                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }

                GeraAdapter(sql);
                table = new DataTable();
                adapter.Fill(table);
                adapter.Dispose();
                command.Dispose();
                adapter = null;
                command = null;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO EM GETDATA : " + ex.ToString());
            }

            return table.Copy();
        }

        public string ObterResultadoUnico(string sql, bool validaResultadoUnico = true)
        {
            var table = GetData(sql);
            if (table.Rows.Count == 0 && validaResultadoUnico)
                throw new Exception("NENHUM VALOR ENCONTRADO PARA A CONSULTA : " + sql);
            else if (table.Rows.Count == 0 && !validaResultadoUnico)
                return null;

            if (table.Rows.Count > 1)
                throw new Exception("MULTIPLOS VALORES ENCONTRADOS PARA CONSULTA UNICA : " + sql);

            return table.Rows[0][0].ToString();
        }

        public int Execute(string sql)
        {
            return Execute(sql, out string erro);
        }

        public int Execute(string sql, out string erro)
        {
            erro = "";
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            try
            {
                command = new HanaCommand(sql);
                command.Connection = Conn;
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                if (!ex.Message.ToUpper().Contains("WRONG NUMBER OR TYPES OF PARAMETERS IN CALL") && !ex.Message.ToUpper().Contains("PASSWORD WILL EXPIRE WITHIN FEW DAYS"))
                    throw new Exception("ERRO AO EXECUTAR : " + ex.ToString());
            }
            return 999;
        }

        public void GeraAdapter(string sql)
        {
            try
            {
                command = new HanaCommand(sql, Conn);
                adapter = new HanaDataAdapter();
                adapter.SelectCommand = command;
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO NA GERAÇÃO DO ADAPTER : " + ex.Message);
            }
        }

        public void End()
        {
            Conn.Close();
            Conn.Dispose();
        }
    }
}