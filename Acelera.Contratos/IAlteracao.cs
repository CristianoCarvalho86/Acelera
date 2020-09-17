using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acelera.Contratos
{
    public interface IAlteracoesArquivo
    {
        List<IAlteracao> Alteracoes { get; set; }

        void AdicionaAlteracao(IAlteracao alteracao);

        bool ExisteAlteracaoValidaParaOArquivo(string arquivo);

        IEnumerable<IAlteracao> AlteracoesPorLinha(string nomeArquivo, int linha);

        IEnumerable<KeyValuePair<string, int>> LinhasAlteradasPorArquivo(string nomeArquivo);

        void FinalizarAlteracaoArquivo(string nomeArquivoAntigo, string novoNomeArquivo);
    }

    public interface IAlteracao
    {
        ILinhaArquivo LinhaAlterada { get; set; }
        List<ICampo> CamposAlterados { get; set; }
        int RepeticoesLinha { get; set; }
        bool SemHeaderOuFooter { get; set; }

        bool NomeArquivoAlterado { get; set; }

        string NomeArquivo { get; set; }

        bool AlteracaoNula { get; }
        int PosicaoDaLinha { get; set; }

        void AdicionarAlteracao(string campo, string valor, string nomeArquivo);

        void DefinirQtdRepeticoes(int qtdRepeticoes);

        void DefinirSemHeaderOuFooter(bool semHeaderOuFooter);

        void DefinirAlteracaoNomeArquivo(bool nomeArquivoAlterado);
    }
}
