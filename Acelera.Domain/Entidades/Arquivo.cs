using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts
{
    public abstract class Arquivo
    {
        protected string textoArquivo;
        public LinhaArquivo Header { get; set; }
        public IList<LinhaArquivo> Linhas { get; set; }
        public LinhaArquivo Footer { get; set; }

        public string NomeArquivo {get; private set;}

        public Arquivo Carregar(string enderecoArquivo)
        {
            NomeArquivo = enderecoArquivo.Split('\\').LastOrDefault();
            textoArquivo = File.ReadAllText(enderecoArquivo);
            CarregarEstrutura();
            return this;
        }

        protected void CarregarEstrutura()
        {
            var linhas = textoArquivo.Split(new[] { Environment.NewLine },StringSplitOptions.None).Where(x => x != string.Empty);
            Header = CarregaHeader(linhas.First());
            Footer = CarregaFooter(linhas.Last());
            var linhasBody = linhas.Skip(1).ToList();
            linhasBody.RemoveAt(linhasBody.Count - 1);
            Linhas = CarregaLinhas(linhasBody);

        }

        public void Salvar(string endereco)
        {
            var file = File.CreateText(endereco);
            file.WriteLine(Header.ObterTexto());
            int count = 1;
            foreach (var item in Linhas)
            {
                file.WriteLine(item.ObterTexto());
                count++;
            }
            file.WriteLine(Footer.ObterTexto());
            file.Close();
        }

        public LinhaArquivo ObterLinha(int posicaoLinha)
        {
            return Linhas.ToList()[posicaoLinha];
        }

        public void AlterarLinha(int posicaoLinha, string campo,  string textoNovo)
        {
            ObterLinha(posicaoLinha).ObterCampo(campo).AlterarValor(textoNovo);
        }

        public void AdicionarLinha(LinhaArquivo linha, int? posicaoLinha)
        {
            if(posicaoLinha.HasValue)
                Linhas.Insert(posicaoLinha.Value,linha);
            else
                Linhas.Add(linha);
        }

        public void ReplicarLinha(int posicaoLinha, int quantidadeVezes)
        {
            for (int i = 0; i < quantidadeVezes; i++)
            {
                AdicionarLinha(ObterLinha(posicaoLinha), posicaoLinha + 1);
            }
            
        }

        public void RemoverLinha(int posicaoLinha)
        {
            Linhas.RemoveAt(posicaoLinha);
        }

        public void RemoverLinhas(int posicaoLinhaInicial, int quantidadeLinhas)
        {
            int posicao = posicaoLinhaInicial;
            //for
        }

        protected abstract void CarregaCamposDoLayout(LinhaArquivo linha);

        protected IList<LinhaArquivo> CarregaLinhas(IEnumerable<string> linhas)
        {
            var linhasPreenchidas = new List<LinhaArquivo>();
            LinhaArquivo linha;
            foreach (var l in linhas)
            {
                linha = new LinhaArquivo();
                CarregaCamposDoLayout(linha);
                linha.CarregaTexto(l);
                linhasPreenchidas.Add(linha);
            }
            return linhasPreenchidas;
        }
    
        protected virtual LinhaArquivo CarregaHeader(string linha)
        {
            var header = new LinhaArquivo();
            header.Campos.Add(new Campo("TIPO REGISTRO", 2));
            header.Campos.Add(new Campo("NM_ARQ", 30));
            header.Campos.Add(new Campo("DT_ARQ", 10));
            header.Campos.Add(new Campo("NR_ARQ", 6));
            header.Campos.Add(new Campo("NM_BRIDGE", 30));
            header.Campos.Add(new Campo("CD_TPA", 3));
            header.Campos.Add(new Campo("NOMEARQ", 40));
            header.Campos.Add(new Campo("VERSAO", 4));
            header.Campos.Add(new Campo("FILLER", 575));
            header.CarregaTexto(linha);
            return header;
        }
        protected virtual LinhaArquivo CarregaFooter(string linha)
        {
            var footer = new LinhaArquivo();
            footer.Campos.Add(new Campo("TIPO REGISTRO", 2));
            footer.Campos.Add(new Campo("NM_ARQ", 30));
            footer.Campos.Add(new Campo("QT_LIN", 6));
            footer.Campos.Add(new Campo("Filler", 662));
            footer.CarregaTexto(linha);
            return footer;
        }

        private void AddCampoAlterado()
        {

        }
    }
}
