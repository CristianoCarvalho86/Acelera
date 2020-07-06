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
using System.Threading;
using System.Windows.Forms;

namespace Editor
{
    public partial class FrmEditor : Form
    {
        private Arquivo arquivo;
        private DataTable dadosDoArquivo;
        private DataTable dadosDoHeader ;
        private DataTable dadosDoFooter ;
        private DataTable tabelaTemporaria;
        private const string nomeColunaId = "INDEX_ARQUIVO_TABELA";
        private IList<LinhaFiltro> linhasFiltro;
        private IList<ChaveValor> filtrosAtivos;
        public FrmEditor()
        {
            InitializeComponent();
        }

        private void FrmEditor_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            EstadoTelaInicial();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArrquivo.Text) || !File.Exists(txtArrquivo.Text))
            {
                MessageBox.Show("Informe um arquivo válido.");
                return;
            }
            picLoading.Visible = true;
            backgroundWorkerCarregar.RunWorkerAsync();
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

        private void Salvar()
        {
            try
            {
                arquivo.Salvar(arquivo.EnderecoCompleto);
            }
            catch(Exception ex)
            {
                Erro(ex);
            }
            MessageBox.Show("VALOR ALTERADO COM SUCESSO.");
        }

        private void Erro(Exception ex)
        {
            MessageBox.Show("ERRO : " + ex.Message + Environment.NewLine + "DESCRICAO : " + ex.StackTrace);

        }

        private void backgroundWorkerCarregar_DoWork(object sender, DoWorkEventArgs e)
        {
            CarregarDados();
            //var t = new Thread(x =>
            //CarregarDados());
            //t.Start();
        }

        private void backgroundWorkerCarregar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DefinirVisibilidadeBotoes(true);
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
            dadosDoArquivo.Rows.InsertAt(DataTableUtils.ClonarLinha(dadosDoArquivo.Rows[indexDaTabela]),indexDaTabela) ;
            
            arquivo.AdicionarLinha(arquivo.ObterLinha(indexDoArquivo),indexDoArquivo);
        }

        private void EstadoTelaInicial()
        {
            DefinirVisibilidadeBotoes(false);
            dadosDoArquivo = new DataTable();
            dadosDoHeader = new DataTable();
            dadosDoFooter = new DataTable();
        }

        private void DefinirVisibilidadeBotoes(bool arquivoCarregado)
        {
            btnSalvar.Visible = arquivoCarregado;
            btnAddRow.Visible = arquivoCarregado;
            btnRemoveRow.Visible = arquivoCarregado;
            btnCopiarLinha.Visible = arquivoCarregado;
            btnFiltro.Visible = arquivoCarregado;
        }

        private void backgroundWorkerSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            picLoading.Visible = true;
            Salvar();
        }

        private void backgroundWorkerSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picLoading.Visible = false;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            panelFiltro.Visible = !panelFiltro.Visible;
            CarregaPainelFiltro();
        }

        private void CarregaPainelFiltro()
        {
            if (panelFiltro.Controls.Count > 1)
                return;

            var t = new Thread(x =>
            {
                filtrosAtivos = new List<ChaveValor>();
                linhasFiltro = new List<LinhaFiltro>();
                LinhaFiltro linha;
                var posicaoLinhaAnterior = 32;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    linha = new LinhaFiltro();
                    linha.Carregar(column.HeaderText, filtrosAtivos, new Action(delegate () { AtualizarGrid();}));
                    linha.Location = new System.Drawing.Point(1, posicaoLinhaAnterior);
                    panelFiltro.Invoke(new Action(delegate ()
                    {
                        panelFiltro.Controls.Add(linha);
                    }));
                    posicaoLinhaAnterior += 22;
                    linhasFiltro.Add(linha);
                }
            });
            t.Start();
        }

        private void AtualizarGrid()
        {
            var select = "";
            foreach (var filtro in filtrosAtivos)
            {
                if(filtro.Valor.Contains("'"))
                {
                    MessageBox.Show("Filtro nao pode conter aspas simples.");
                    filtro.Valor = "";
                    return;
                }
                select += $" {filtro.Chave} = '{filtro.Valor}' AND";
            }
            if(!string.IsNullOrEmpty(select))
                select = select.Substring(0, select.Length - 4);
            tabelaTemporaria = dadosDoArquivo.Clone();
            var linhas = dadosDoArquivo.Select(select);
            foreach (var linha in linhas)
                tabelaTemporaria.ImportRow(linha);
            dataGridView1.DataSource = tabelaTemporaria;
            dataGridView1.ReadOnly = true;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            filtrosAtivos.Clear();
            var t = new Thread(x =>
            {
                foreach (var linha in linhasFiltro)
                    linha.Invoke(new Action(delegate () { linha.Limpar(); }));
                
                dataGridView1.Invoke(new Action(delegate () {
                    dataGridView1.ReadOnly = false;
                }));
            });
            t.Start();
            dataGridView1.DataSource = dadosDoArquivo;
        }

        private void panelFiltro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
