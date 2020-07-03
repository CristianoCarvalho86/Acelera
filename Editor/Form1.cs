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
        private DataTable dadosDoHeader;
        private DataTable dadosDoFooter;
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
            Salvar();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            CarregarDados();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CarregarDados()
        {
            arquivo = LayoutUtils.CarregarArquivo(txtArrquivo.Text);

            dadosDoArquivo = ArquivoToDataTable.ConvertToDataTable(arquivo.Linhas);
            dataGridView1.DataSource = dadosDoArquivo;

            dadosDoHeader = ArquivoToDataTable.ConvertToDataTable(arquivo.Header);
            gridHeader.DataSource = dadosDoHeader;

            dadosDoFooter = ArquivoToDataTable.ConvertToDataTable(arquivo.Footer);
            gridFooter.DataSource = dadosDoFooter;

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                }
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            ValidarArquivo();
        }

        private void gridHeader_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            arquivo.AlterarHeader(dadosDoHeader.Columns[e.ColumnIndex].ColumnName, dadosDoHeader.Rows[e.RowIndex][e.ColumnIndex].ToString());
            Salvar();
        }

        private void gridFooter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            arquivo.AlterarFooter(dadosDoFooter.Columns[e.ColumnIndex].ColumnName, dadosDoFooter.Rows[e.RowIndex][e.ColumnIndex].ToString());
            Salvar();
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            arquivo.RemoverLinha(e.Row.Index);
            Salvar();
        }

        private void Salvar()
        {
            arquivo.Salvar(arquivo.EnderecoCompleto);
            MessageBox.Show("VALOR ALTERADO COM SUCESSO.");
        }
    }
}
