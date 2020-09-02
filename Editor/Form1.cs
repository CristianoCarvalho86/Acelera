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
        private const string nomeColunaId = "ID_ARQUIVO_9999";
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
            DataGridViewColumnSelector cs = new DataGridViewColumnSelector(dataGridView1);
            cs.MaxHeight = 400;
            cs.Width = 450;
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

                GC.Collect();
            }
            catch (Exception ex)
            {
                Erro(ex);
            }

        }
        private void IndexarTabela()
        {
            if(!dadosDoArquivo.Columns.Contains(nomeColunaId))
                dadosDoArquivo.Columns.Add(nomeColunaId, typeof(Guid));
            for (int i = 0; i < dadosDoArquivo.Rows.Count; i++)
                dadosDoArquivo.Rows[i][nomeColunaId] = arquivo.Linhas[i].Id;
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
                    btnCarregar_Click(null, null);
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
        }

        private void gridFooter_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            arquivo.AlterarFooter(dadosDoFooter.Columns[e.ColumnIndex].ColumnName, dadosDoFooter.Rows[e.RowIndex][e.ColumnIndex].ToString());
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var indexArquivo = ObterIndexDoArquivo(e.RowIndex);
                arquivo.AlterarLinha(indexArquivo, dadosDoArquivo.Columns[e.ColumnIndex].ColumnName, dadosDoArquivo.Rows[e.RowIndex][e.ColumnIndex].ToString());
                if (arquivo.CamposDoBody.Contains("ID_TRANSACAO"))
                {
                    arquivo.AlterarLinha(indexArquivo, "ID_TRANSACAO", CarregarIdTransacao(arquivo.ObterLinha(indexArquivo)));
                    dadosDoArquivo.Rows[e.RowIndex]["ID_TRANSACAO"] = CarregarIdTransacao(arquivo.ObterLinha(indexArquivo));
                }
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

        private Guid ObterChaveDoArquivo(int indexLinha)
        {
            return (Guid)dataGridView1.Rows[indexLinha].Cells[nomeColunaId].Value;
        }

        private int ObterIndexDoArquivo(int indexLinhaGrid)
        {
           return arquivo.ObterLinha((Guid)dataGridView1.Rows[indexLinhaGrid].Cells[nomeColunaId].Value).Index;
        }

        private void btnAddRow_Click(object sender, EventArgs e)
        {
            var novaLinhaArquivo = arquivo.CriarLinhaVazia(arquivo.Linhas.Count - 1);
            var novaLinhaTabela = dadosDoArquivo.NewRow();
            novaLinhaTabela[nomeColunaId] = novaLinhaArquivo.Id;
            if (dataGridView1.SelectedRows.Count == 0)
            {
                dadosDoArquivo.Rows.Add(novaLinhaTabela);
                arquivo.AdicionarLinha(novaLinhaArquivo);
                MessageBox.Show("Linha inserida no fim do arquivo.");
            }
            else
            {
                var indexDeInsert = dataGridView1.SelectedRows[0].Index;
                novaLinhaArquivo.Index = indexDeInsert;
                arquivo.AdicionarLinha(novaLinhaArquivo,ObterIndexDoArquivo(indexDeInsert));
                dadosDoArquivo.Rows.InsertAt(novaLinhaTabela, indexDeInsert);
            }
            AtualizarFooter();
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para remover.");
                return;
            }
            var indexDoGrid = dataGridView1.SelectedRows[0].Index;
            var chaveDoArquivo = ObterChaveDoArquivo(indexDoGrid);
            dadosDoArquivo.Rows.RemoveAt(indexDoGrid);
            arquivo.RemoverLinhaComAjuste(chaveDoArquivo);
            AtualizarFooter();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            picLoading.Visible = true;
            backgroundWorkerSalvar.RunWorkerAsync();
        }

        private void btnCopiarLinha_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione uma linha para copiar.");
                return;
            }
            var indexDoGrid = dataGridView1.SelectedRows[0].Index;
            var chaveDoArquivo = ObterChaveDoArquivo(indexDoGrid);

            var novaLinhaArquivo = arquivo.ObterLinha(chaveDoArquivo).Clone();
            arquivo.AdicionarLinha(novaLinhaArquivo, arquivo.ObterLinha(chaveDoArquivo).Index);

            var linhaTabela = DataTableUtils.ClonarLinha(dadosDoArquivo.Rows[indexDoGrid]);
            linhaTabela[nomeColunaId] = novaLinhaArquivo.Id;
            dadosDoArquivo.Rows.InsertAt(linhaTabela, indexDoGrid) ;
            
            
            AtualizarFooter();
        }

        private void AtualizarFooter()
        {
            dadosDoFooter.Rows[0]["QT_LIN"] = dadosDoArquivo.Rows.Count;
        }

        private void EstadoTelaInicial()
        {
            DefinirVisibilidadeBotoes(false);
            dadosDoArquivo = new DataTable();
            dadosDoHeader = new DataTable();
            dadosDoFooter = new DataTable();
        }

        private void DefinirVisibilidadeBotoes(bool arquivoCarregado, bool filtroAplicado = false)
        {
            btnSalvar.Visible = arquivoCarregado;
            btnAddRow.Visible = !filtroAplicado ? arquivoCarregado : filtroAplicado; ;
            btnRemoveRow.Visible = !filtroAplicado ? arquivoCarregado : filtroAplicado; ;
            btnCopiarLinha.Visible = !filtroAplicado ? arquivoCarregado : filtroAplicado;
            btnCopyText.Visible = arquivoCarregado;
            btnFiltro.Visible = arquivoCarregado;
        }

        private void backgroundWorkerSalvar_DoWork(object sender, DoWorkEventArgs e)
        {
            Salvar();
        }

        private void backgroundWorkerSalvar_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            picLoading.Visible = false;
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            panelFiltro.Visible = !panelFiltro.Visible;
            btnFiltro.Text = panelFiltro.Visible ? "Esconder Filtro" : "Filtro";
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
            DefinirVisibilidadeBotoes(true, true);
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
            DefinirVisibilidadeBotoes(true, false);
        }

        private string CarregarIdTransacao(LinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }

        private void btnCopyText_Click(object sender, EventArgs e)
        {
            var indexDoGrid = dataGridView1.SelectedRows[0].Index;
            var chaveDoArquivo = ObterChaveDoArquivo(indexDoGrid);

            Clipboard.SetText(arquivo.ObterLinha(chaveDoArquivo).ObterTexto());

            
        }

        private void btnSalvarComNovoLote_Click(object sender, EventArgs e)
        {
            var endereco = arquivo.EnderecoCompleto.Split('\\').Last().Split('-');

            //arquivo.EnderecoCompleto = 
            btnSalvar_Click(sender, e);
        }
    }
}
