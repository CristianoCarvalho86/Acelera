﻿using Sap.Data.Hana;
using System;
using System.Data;

namespace Acelera.Data.Core
{
    public class DBHelper
    {
        public string ConnectionString { get; set; }
        private HanaConnection Conn { get; set; }
        private HanaDataAdapter adapter { get; set; }
        private HanaCommand command { get; set; }
        DataTable table;
        private static DBHelper instance;

        private DBHelper()
        {
            Conn = new HanaConnection("DSN=zeus.hana.prod.sa-east-1.whitney.dbaas.ondemand.com:20274;UID=CCARVALHO;PWD=Cristiano@03;");
        }

        public void SetConnection(string ConnectionString)
        {
            Conn = new HanaConnection(ConnectionString);
        }

        public static DBHelper Instance
        {
            get
            {
                try
                {
                    if (instance == null)
                    {
                        instance = new DBHelper();
                    }
                    return instance;
                }
                catch (Exception ex)
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

        public void Execute(string sql)
        {
            if (Conn.State == ConnectionState.Closed)
            {
                Conn.Open();
            }
            try
            {
                command.Connection = Conn;
                command = new HanaCommand(sql);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("ERRO AO EXECUTAR : " + ex.ToString());
            }
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
