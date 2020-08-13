using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class DataTableExtensions
    {
        public static string ObterTextoEmLinhas(this DataTable dataTable)
        {
            var texto = string.Empty;
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in row.Table.Columns)
                    texto += $"{column.ColumnName} : {row[column.ColumnName]}";
                texto += Environment.NewLine;
            }
            return texto;
        }

        public static string ObterTextoTabular(this DataTable dataTable)
        {
            var output = new StringBuilder();

            var columnsWidths = new int[dataTable.Columns.Count];

            // Get column widths
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var length = row[i].ToString().Length;
                    if (columnsWidths[i] < length)
                        columnsWidths[i] = length;
                }
            }

            // Get Column Titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var length = dataTable.Columns[i].ColumnName.Length;
                if (columnsWidths[i] < length)
                    columnsWidths[i] = length;
            }

            // Write Column titles
            for (int i = 0; i < dataTable.Columns.Count; i++)
            {
                var text = dataTable.Columns[i].ColumnName;
                output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
            }
            output.Append("|\n" + new string('=', output.Length) + "\n");
            output.Append(Environment.NewLine);
            // Write Rows
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    var text = row[i].ToString();
                    output.Append("|" + PadCenter(text, columnsWidths[i] + 2));
                }
                output.Append("|" + Environment.NewLine);
            }
            return output.ToString();
        }

        private static string PadCenter(string text, int maxLength)
        {
            int diff = maxLength - text.Length;
            return new string(' ', diff / 2) + text + new string(' ', (int)(diff / 2.0 + 0.5));

        }

        public static bool ValidarValorUnico(this DataTable dataTable, string campoDaValidacao, string valorEsperado)
        {
            foreach (DataRow row in dataTable.Rows)
                if (row[campoDaValidacao].ToString() != valorEsperado)
                    return false;
            return true;
        }   

        public static string ValidarValoresEntreLinhaDasTabelas(this IEnumerable<DataTable> tabelas, int linhaAValidar = 0)
        {
            string valor;
            string erros = null;
            foreach(DataTable tabela in tabelas)
            {
                foreach(DataColumn column in tabela.Columns)
                {
                    if (column.ColumnName == "id_reg")
                        continue;

                    valor = tabela.Rows[linhaAValidar][column].ToString();
                    var listaDeTabelasAValidar = ObterTabelasComOCampo(tabelas, column.ColumnName);
                    foreach(DataTable tab in listaDeTabelasAValidar)
                    {
                        if(tab.Rows[linhaAValidar][column.ColumnName].ToString() != valor)
                        {
                            erros += $"ERRO : TABELA '{tab.TableName}' COM VALOR DIFERENTE DA TABELA '{tabela.TableName}' NO CAMPO '{column.ColumnName}'{Environment.NewLine}";
                        }
                    }
                }
            }
            return erros;
        }

        private static IEnumerable<DataTable> ObterTabelasComOCampo(IEnumerable<DataTable> tabelas, string campo)
        {
            return tabelas.Where(x => x.Columns.Contains(campo));
        }

    }
}

