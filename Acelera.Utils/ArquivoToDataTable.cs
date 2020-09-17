using Acelera.Contratos;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ArquivoToDataTable
    {
        public static DataTable ConvertToDataTable(IList<ILinhaArquivo> LinhasDoArquivo)
        {
            var dataTable = new DataTable();
            foreach(var campo in LinhasDoArquivo.First().Campos)
            {
                dataTable.Columns.Add(campo.ColunaArquivo, typeof(string));
            }
            foreach(var linha in LinhasDoArquivo)
            {
                DataRow row = dataTable.NewRow();
                foreach (var campo in linha.Campos)
                    row[campo.ColunaArquivo] = campo.ValorFormatado;
                dataTable.Rows.Add(row);
            }
            return dataTable;
        }

    }
}
