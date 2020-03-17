using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class AlteracoesArquivo
    {

        public List<Alteracao> Alteracoes { get; set; }

        public AlteracoesArquivo()
        {
            Alteracoes = new List<Alteracao>();
        }
        
        public void AdicionaAlteracao(Alteracao alteracao)
        {
            Alteracoes.Add(alteracao);
        }

        public bool ExisteAlteracaoValida()
        {
            return Alteracoes.Any(x => x.AlteracaoNula == false);
        }
    }

    public class Alteracao
    {
        public LinhaArquivo LinhaAlterada { get; set; }
        public List<Campo> CamposAlterados { get; set; }
        public int RepeticoesLinha { get; set; }
        public bool SemHeaderOuFooter { get; set; }

        public bool NomeArquivoAlterado { get; set; }

        public bool AlteracaoNula { get => CamposAlterados.Count == 0; }
        public int PosicaoDaLinha { get; set; }
        public Alteracao(LinhaArquivo linhaAlterada, int posicaoLinha)
        {
            LinhaAlterada = linhaAlterada;
            PosicaoDaLinha = posicaoLinha;
            CamposAlterados = new List<Campo>();
            RepeticoesLinha = 0;
            SemHeaderOuFooter = false;
            NomeArquivoAlterado = false;
        }

        public void AdicionarAlteracao(string campo, string valor)
        {
            if(!string.IsNullOrEmpty(campo))
                CamposAlterados.Add(new Campo(campo, valor));
        }

        public void DefinirQtdRepeticoes(int qtdRepeticoes)
        {
            RepeticoesLinha = qtdRepeticoes;
        }

        public void DefinirSemHeaderOuFooter(bool semHeaderOuFooter)
        {
            SemHeaderOuFooter = semHeaderOuFooter;
        }

        public void DefinirAlteracaoNomeArquivo(bool nomeArquivoAlterado)
        {
            NomeArquivoAlterado = nomeArquivoAlterado;
        }
    }
}
