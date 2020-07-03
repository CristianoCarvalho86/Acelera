using Acelera.Domain.Layouts;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Windows.Forms;

namespace Editor
{
    public partial class FrmEditor : Form
    {
        private Arquivo arquivo;
        private DataTable dadosDoArquivo;
        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            arquivo.AlterarLinha(e.RowIndex, dadosDoArquivo.Columns[e.ColumnIndex].ColumnName, dadosDoArquivo.Rows[e.RowIndex][e.ColumnIndex].ToString());
            MessageBox.Show("VALOR ALTERADO COM SUCESSO.");
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            ValidarArquivo();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void ValidarArquivo()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var filePath = openFileDialog1.FileName;
                    using (Stream str = openFileDialog1.OpenFile())
                    {
                        txtArrquivo.Text = filePath;
                    }

                    arquivo = LayoutUtils.CarregarArquivo(txtArrquivo.Text);
                    dadosDoArquivo = ArquivoToDataTable.ConvertToDataTable(arquivo.Linhas);
                    dataGridView1.DataSource = dadosDoArquivo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }
    }
}
