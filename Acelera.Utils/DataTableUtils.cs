using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class DataTableUtils
    {
        public static DataRow ClonarLinha(DataRow row)
        {
            var linha = row.Table.NewRow();
            for (int i = 0; i < row.Table.Columns.Count; i++)
            {
                linha[i] = row[i];
            }
            return linha;
        }
    }
}
