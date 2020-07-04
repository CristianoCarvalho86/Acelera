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
        private DataTable dadosDoArquivo = new DataTable();
        private DataTable dadosDoHeader = new DataTable();
        private DataTable dadosDoFooter = new DataTable();
        private const string nomeColunaId = "INDEX_ARQUIVO_TABELA";
        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            btnSalvar.Visible = false;
            dataGridView1.MultiSelect = false;
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArrquivo.Text))
            {
                MessageBox.Show("Informe um arquivo válido.");
                return;
            }
            picLoading.Visible = true;
            backgroundWorkerCarregar.RunWorkerAsync();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CarregarDados()
        {
            try
            {
                arquivo = LayoutUtils.CarregarArquivo(txtArrquivo.Text);

                dadosDoArquivo = ArquivoToDataTable.ConvertToDataTable(arquivo.Linhas);

                dadosDoHeader = ArquivoToDataTable.ConvertToDataTable(arquivo.Header);

                dadosDoFooter = ArquivoToDataTable.ConvertToDataTable(arquivo.Footer);
            }
            catch (Exception ex)
            {
                Erro(ex);
            }

        }
        private void IndexarTabela()
        {
            if(!dadosDoArquivo.Columns.Contains(nomeColunaId))
                dadosDoArquivo.Columns.Add(nomeColunaId, typeof(int));
            for (int i = 0; i < dadosDoArquivo.Rows.Count; i++)
                dadosDoArquivo.Rows[i][nomeColunaId] = i;
            dataGridView1.Columns[nomeColunaId].Visible = false;
        }

        private void DefinirDataSources()
        {
            dataGridView1.DataSource = dadosDoArquivo;
            gridHeader.DataSource = dadosDoHeader;
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
                    Erro(ex);
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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                arquivo.AlterarLinha(ObterIndexDoArquivo(e.RowIndex), dadosDoArquivo.Columns[e.ColumnIndex].ColumnName, dadosDoArquivo.Rows[e.RowIndex][e.ColumnIndex].ToString());
                //Salvar();
            }
            catch (Exception ex)
            {
                Erro(ex);
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            try
            {
                arquivo.RemoverLinha(ObterIndexDoArquivo(e.Row.Index));
                //Salvar();
            }
            catch (Exception ex)
            {
                Erro(ex);
            }
        }
        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {

        }

        private void Salvar()
        {
            arquivo.Salvar(arquivo.EnderecoCompleto);
            MessageBox.Show("VALOR ALTERADO COM SUCESSO.");
        }

        private void Erro(Exception ex)
        {
            MessageBox.Show("ERRO : " + ex.Message + Environment.NewLine + "DESCRICAO : " + ex.StackTrace);

        }

        private void backgroundWorkerCarregar_DoWork(object sender, DoWorkEventArgs e)
        {
            CarregarDados();
        }

        private void backgroundWorkerCarregar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSalvar.Visible = true;
            picLoading.Visible = false;
            DefinirDataSources();
            IndexarTabela();
        }

        private int ObterIndexDoArquivo(int indexLinha)
        {
            return Convert.ToInt32(dataGridView1.Rows[indexLinha].Cells[nomeColunaId].Value);
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            dadosDoArquivo.Rows.Add(dadosDoArquivo.NewRow());
            dadosDoArquivo.Rows[dadosDoArquivo.Rows.Count - 1][nomeColunaId] = dadosDoArquivo.Rows.Count - 1;
            arquivo.AdicionarLinha(arquivo.CriarLinhaVazia());
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para remover.");
                return;
            }
            var indexDaTabela = dataGridView1.SelectedRows[0].Index;
            var indexDoArquivo = ObterIndexDoArquivo(dataGridView1.SelectedRows[0].Index);
            dadosDoArquivo.Rows.RemoveAt(indexDaTabela);
            arquivo.RemoverLinha(indexDoArquivo);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btnCopiarLinha_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para copiar.");
                return;
            }
            var indexDaTabela = dataGridView1.SelectedRows[0].Index;
            var indexDoArquivo = ObterIndexDoArquivo(dataGridView1.SelectedRows[0].Index);
            dadosDoArquivo.Rows.InsertAt(ClonarLinha(dadosDoArquivo.Rows[indexDaTabela]),indexDaTabela) ;
            
            arquivo.AdicionarLinha(arquivo.ObterLinha(indexDoArquivo),indexDoArquivo);
        }

        private DataRow ClonarLinha(DataRow row)
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
