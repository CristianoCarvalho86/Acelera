using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public IList<LinhaArquivo> Header { get; set; }
        public IList<LinhaArquivo> Linhas { get; set; }
        public IList<LinhaArquivo> Footer { get; set; }

        public string NomeArquivo {get; private set;}

        public Arquivo Carregar(string enderecoArquivo, int? qtdHeader = 1, int? qtdFooter = 1)
        {
            NomeArquivo = enderecoArquivo.Split('\\').LastOrDefault();
            textoArquivo = File.ReadAllText(enderecoArquivo);
            CarregarEstrutura(qtdHeader.HasValue ? qtdHeader.Value : 1, qtdFooter.HasValue ? qtdFooter.Value : 1);
            return this;
        }

        protected void CarregarEstrutura(int qtdHeader, int qtdFooter)
        {
            var linhas = textoArquivo.Split(new[] { Environment.NewLine },StringSplitOptions.None).Where(x => x != string.Empty);
            Header = CarregaHeader(linhas.Take(qtdHeader));
            Footer = CarregaFooter(linhas.Reverse().Take(qtdFooter).Reverse());
            var linhasBody = linhas.Skip(1).ToList();
            linhasBody.RemoveAt(linhasBody.Count - 1);
            Linhas = CarregaLinhas(linhasBody);

        }

        public void Salvar(string endereco)
        {
            var file = File.CreateText(endereco);

            foreach(var header in Header)
                file.WriteLine(header.ObterTexto());
            foreach (var item in Linhas)
                file.WriteLine(item.ObterTexto());
            foreach (var footer in Footer)
                file.WriteLine(footer.ObterTexto());

            file.Close();
        }

        public LinhaArquivo ObterLinha(int posicaoLinha)
        {
            return Linhas.ToList()[posicaoLinha];
        }

        public LinhaArquivo ObterLinhaHeader(int posicaoLinha = 0)
        {
            return Header[posicaoLinha];
        }

        public LinhaArquivo ObterLinhaFooter(int posicaoLinha = 0)
        {
            return Footer[posicaoLinha];
        }

        public void AlterarLinha(int posicaoLinha, string campo,  string textoNovo)
        {
            Assert.IsTrue(posicaoLinha < Linhas.Count, $"Linha Informada nao pertece ao BODY, Body contem : {Linhas.Count} , valor informado{posicaoLinha}");
            ObterLinha(posicaoLinha).ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }

        public void AlterarHeader(string campo, string textoNovo, int posicaoLinhaHeader = 0)
        {
            Header[posicaoLinhaHeader].ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }

        public void ReplicarHeader(int quantidadeVezes, int posicaoLinhaHeader = 0)
        {
            Header.Add(Header[posicaoLinhaHeader]);
        }

        public void ReplicarFooter(int quantidadeVezes, int posicaoLinhaFooter = 0)
        {
            for (int i = 0; i < quantidadeVezes; i++)
                Footer.Add(Footer[posicaoLinhaFooter]);
        }

        public void AlterarFooter(string campo, string textoNovo, int posicaoLinhaFooter = 0)
        {
            Footer[posicaoLinhaFooter].ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
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

        public void RemoverHeader()
        {
            Header.RemoveAt(0);
        }

        public void RemoverFooter()
        {
            Footer.RemoveAt(0);
        }

        public void RemoverLinhas(int posicaoLinhaInicial, int quantidadeLinhas)
        {
            Linhas = Linhas.TakeWhile(x => x.Index < posicaoLinhaInicial || x.Index > (posicaoLinhaInicial + quantidadeLinhas)).ToList();
        }

        protected abstract void CarregaCamposDoLayout(LinhaArquivo linha);

        protected IList<LinhaArquivo> CarregaLinhas(IEnumerable<string> linhas)
        {
            var linhasPreenchidas = new List<LinhaArquivo>();
            LinhaArquivo linha;
            var count = 0;
            foreach (var l in linhas)
            {
                linha = new LinhaArquivo(count);
                CarregaCamposDoLayout(linha);
                linha.CarregaTexto(l);
                linhasPreenchidas.Add(linha);
                count++;
            }
            return linhasPreenchidas;
        }
    
        protected virtual IList<LinhaArquivo> CarregaHeader(IEnumerable<string> linhas)
        {
            var listaHeader = new List<LinhaArquivo>();
            var count = 0;
            foreach (var linha in linhas)
            {
                var header = new LinhaArquivo(count);
                header.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
                header.Campos.Add(new CampoDoArquivo("NM_ARQ", 30));
                header.Campos.Add(new CampoDoArquivo("DT_ARQ", 10));
                header.Campos.Add(new CampoDoArquivo("NR_ARQ", 6));
                header.Campos.Add(new CampoDoArquivo("NM_BRIDGE", 30));
                header.Campos.Add(new CampoDoArquivo("CD_TPA", 3, "CD_OPERACAO"));
                header.Campos.Add(new CampoDoArquivo("NOMEARQ", 40));
                header.Campos.Add(new CampoDoArquivo("VERSAO", 4));
                header.Campos.Add(new CampoDoArquivo("FILLER", 575));
                header.CarregaTexto(linha);
                listaHeader.Add(header);
                count++;
            }
            return listaHeader;
        }
        protected virtual IList<LinhaArquivo> CarregaFooter(IEnumerable<string> linhas)
        {
            var listaFooter = new List<LinhaArquivo>();
            var count = 0;
            foreach (var linha in linhas)
            {
                var footer = new LinhaArquivo(count);
                footer.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
                footer.Campos.Add(new CampoDoArquivo("NM_ARQ", 30));
                footer.Campos.Add(new CampoDoArquivo("QT_LIN", 6));
                footer.Campos.Add(new CampoDoArquivo("Filler", 662));
                footer.CarregaTexto(linha);
                listaFooter.Add(footer);
                count++;
            }
            return listaFooter;
        }

        private void AddCampoAlterado()
        {

        }
    }
}
