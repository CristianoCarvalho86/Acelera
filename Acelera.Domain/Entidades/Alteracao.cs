using Acelera.Contratos;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    [Serializable]
    public class AlteracoesArquivo : IAlteracoesArquivo
    {
        public List<IAlteracao> Alteracoes { get; set; }

        public AlteracoesArquivo()
        {
            Alteracoes = new List<IAlteracao>();
        }
        
        public void AdicionaAlteracao(IAlteracao alteracao)
        {
            Alteracoes.Add(alteracao);
        }

        public bool ExisteAlteracaoValidaParaOArquivo(string arquivo)
        {
            return Alteracoes.Any(x => x.AlteracaoNula == false && x.NomeArquivo == arquivo);
        }

        public IEnumerable<IAlteracao> AlteracoesPorLinha(string nomeArquivo, int linha)
        {
            return Alteracoes.Where(x => x.PosicaoDaLinha == linha && x.NomeArquivo == nomeArquivo);
        }

        public IEnumerable<KeyValuePair<string, int>> LinhasAlteradasPorArquivo(string nomeArquivo)
        {
            return Alteracoes.Where(x => x.NomeArquivo == nomeArquivo).Select(x => new KeyValuePair<string, int>(x.NomeArquivo, x.PosicaoDaLinha)).Distinct();
        }

        public void FinalizarAlteracaoArquivo(string nomeArquivoAntigo, string novoNomeArquivo)
        {
            foreach (var alteracao in Alteracoes.Where(x => x.NomeArquivo == nomeArquivoAntigo))
            {
                alteracao.NomeArquivo = novoNomeArquivo;
                alteracao.LinhaAlterada = alteracao.LinhaAlterada.Clone();
            }
            
        }
    }

    [Serializable]
    public class Alteracao : IAlteracao
    {
        public ILinhaArquivo LinhaAlterada { get; set; }
        public List<ICampo> CamposAlterados { get; set; }
        public int RepeticoesLinha { get; set; }
        public bool SemHeaderOuFooter { get; set; }

        public bool NomeArquivoAlterado { get; set; }

        public string NomeArquivo { get; set; }

        public bool AlteracaoNula { get => CamposAlterados.Count == 0; }
        public int PosicaoDaLinha { get; set; }
        public Alteracao(ILinhaArquivo linhaArquivo, int posicaoLinha)
        {
            LinhaAlterada = linhaArquivo;
            PosicaoDaLinha = posicaoLinha;
            CamposAlterados = new List<ICampo>();
            RepeticoesLinha = 0;
            SemHeaderOuFooter = false;
            NomeArquivoAlterado = false;
        }

        public void AdicionarAlteracao(string campo, string valor, string nomeArquivo)
        {
            if(!string.IsNullOrEmpty(campo))
                CamposAlterados.Add(new Campo(campo, valor));
            NomeArquivo = nomeArquivo;
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
