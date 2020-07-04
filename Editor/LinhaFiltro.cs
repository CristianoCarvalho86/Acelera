using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor
{
    public partial class LinhaFiltro : UserControl
    {
        public IList<ChaveValor> listaDeFiltros { get; set; }
        private string valorPropriedade;
        private Action acao;
        public LinhaFiltro()
        {
            InitializeComponent();
        }

        private void LinhaFiltro_Load(object sender, EventArgs e)
        {

        }

        public void Carregar(string texto, IList<ChaveValor> listaDeFiltros, Action acao)
        {
            this.acao = acao;
            this.listaDeFiltros = listaDeFiltros;
            lblPropriedade.Text = texto;
            valorPropriedade = texto;
        }

        public string ObterValor()
        {
            return txtValorPropriedade.Text;
        }

        public void Limpar()
        {
            txtValorPropriedade.Text = "";
        }

        public void AdicionarAlteracaoNaLista()
        {
            var itemAtual = listaDeFiltros.Where(x => x.Chave == valorPropriedade).FirstOrDefault();
            if (itemAtual == null)
            {
                listaDeFiltros.Add(new ChaveValor(valorPropriedade, txtValorPropriedade.Text));
                acao.Invoke();
            }
            else if (itemAtual.Valor != txtValorPropriedade.Text)
            {
                itemAtual.Valor = txtValorPropriedade.Text;
                acao.Invoke();
            }
        }

        public void RemoveAlteracaoNaLista()
        {
            var itemAtual = listaDeFiltros.Where(x => x.Chave == valorPropriedade).FirstOrDefault();
            if (itemAtual != null)
            {
                listaDeFiltros.Remove(itemAtual);
                acao.Invoke();
            }
        }

        private void txtValorPropriedade_Leave(object sender, EventArgs e)
        {
            AcionarFiltro();
        }

        private void txtValorPropriedade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AcionarFiltro();
            }
        }

        private void AcionarFiltro()
        {
            if (!string.IsNullOrWhiteSpace(txtValorPropriedade.Text))
            {
                AdicionarAlteracaoNaLista();
            }
            else
            {
                RemoveAlteracaoNaLista();
            }
        }
    }
}
