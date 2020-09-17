using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Acelera.Data
{
    public interface IDBHelper
    {
        string ConnectionString { get; set; }

        void SetConnection(string ConnectionString);

        DataTable GetData(string sql);

        string ObterResultadoUnico(string sql, bool validaResultadoUnico = true);

        int Execute(string sql);

        void GeraAdapter(string sql);

        void End();
    }
}