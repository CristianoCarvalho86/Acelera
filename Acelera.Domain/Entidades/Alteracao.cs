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
            var alteracaoExistente = Alteracoes.Where(x => x.PosicaoDaLinha == alteracao.PosicaoDaLinha).FirstOrDefault() ?? alteracao;
            Alteracoes.Add(alteracaoExistente);
        }
    }

    public class Alteracao
    {
        public LinhaArquivo LinhaAlterada { get; set; }
        public List<Campo> CamposAlterados { get; set; }

        public int PosicaoDaLinha { get; set; }
        public Alteracao(LinhaArquivo linhaAlterada, int posicaoLinha)
        {
            LinhaAlterada = linhaAlterada;
            PosicaoDaLinha = posicaoLinha;
            CamposAlterados = new List<Campo>();
        }

        public void AdicionarAlteracao(string campo, string valor)
        {
            CamposAlterados.Add(new Campo(campo, valor));
        }
    }
}
