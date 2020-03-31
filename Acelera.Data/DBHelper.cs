using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Sap.Data.Hana;

namespace Acelera.Data
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
            Conn = new HanaConnection(ConfigurationSettings.AppSettings["ConnectionString"]);
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

        public string ObterResultadoUnico(string sql)
        {
            var table = GetData(sql);
            if (table.Rows.Count == 0)
                throw new Exception("NENHUM VALOR ENCONTRADO PARA A CONSULTA : " + sql);
            if(table.Rows.Count > 1)
                throw new Exception("MULTIPLOS VALORES ENCONTRADOS PARA CONSULTA UNICA : " + sql);

            return table.Rows[0][0].ToString();
        }

        public int Execute(string sql)
        {
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
                if(!ex.Message.ToUpper().Contains("WRONG NUMBER OR TYPES OF PARAMETERS IN CALL"))
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