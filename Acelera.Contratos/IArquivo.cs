using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acelera.Contratos
{
    public interface IArquivo
    {
        IList<ILinhaArquivo> Header { get; set; }
        IList<ILinhaArquivo> Linhas { get; set; }
        IList<ILinhaArquivo> Footer { get; set; }

        TipoArquivo tipoArquivo { get; }

        string TextoVersaoHeader { get; }

        string EnderecoCompleto { get; }

        string EnderecoCompletoArquivoSalvo { get; }

        IList<string> CamposDoBody { get; }

        string NomeArquivo { get; }

        string NomeArquivoOriginal { get; }

        //string[] CamposChaves { get; }

        ILinhaArquivo UltimaLinha { get; }

        IAlteracoesArquivo valoresAlteradosBody { get; set; }
        IAlteracoesArquivo valoresAlteradosHeader { get; set; }
        IAlteracoesArquivo valoresAlteradosFooter { get; set; }

        OperadoraEnum Operadora { get; }

        void AtualizarNomeArquivoFinal(string nomeArquivo);

        IArquivo Clone();

        IArquivo Carregar(string enderecoArquivo, int? qtdHeader = 1, int? qtdFooter = 1, int limiteDeLinhas = 0);

        ///void CarregarEstrutura(int qtdHeader, int qtdFooter);

        void CarregarNovasLinhasNoBody(string enderecoArquivo);

        void Salvar(string endereco);

        void RemoverLinhasRepetidas();

        void AdicionaLinhaNoBody(ILinhaArquivo linha);
        void AdicionaLinhaNoBody(IList<ILinhaArquivo> linhas);

        void AjustarQtdLinhasNoFooter();

        string ObterValorFormatadoSeExistirCampo(int posicaoLinha, string campo);

        string ObterValorFormatado(int posicaoLinha, string campo);

        int ObterValorInteiro(int posicaoLinha, string campo);

        decimal ObterValorDecimal(int posicaoLinha, string campo);

        ILinhaArquivo ObterLinha(int posicaoLinha);
        ILinhaArquivo ObterLinha(Guid idLinha);
        bool ExisteCampo(string nomeCampo);

        IList<ILinhaArquivo> ObterLinhasOndeCampoIgualAValor(string campo, string valor);

        IList<ILinhaArquivo> ObterLinhasComValores(string[] nomeCampo, string[] valor);

        IList<ILinhaArquivo> ObterLinhasComValores(string nomeCampo, string valorFormatado);

        ILinhaArquivo ObterLinhaHeader(int posicaoLinha = 0);

        ILinhaArquivo ObterLinhaFooter(int posicaoLinha = 0);

        void AlterarLinha(int posicaoLinha, string campo, string textoNovo);
        void AlterarLinhaComCampoIgualAValor(string campoBusca, string valorBusca, string campoAlteracao, string valorAlteracao);

        bool AlterarLinhaSeExistirCampo(int posicaoLinha, string campo, string textoNovo);

        void AlterarTodasAsLinhas(string campo, string textoNovo);

        void AlterarHeader(string campo, string textoNovo, int posicaoLinhaHeader = 0);

        void ReplicarHeader(int quantidadeVezes, int posicaoLinhaHeader = 0);

        void ReplicarFooter(int quantidadeVezes, int posicaoLinhaFooter = 0);

        void AlterarFooter(string campo, string textoNovo, int posicaoLinhaFooter = 0);

        bool ValidarCampo(int posicaoLinha, string campo, string valor);

        void AdicionarLinha(ILinhaArquivo linha, int? posicaoLinha = null);

        void ReplicarLinha(int posicaoLinha, int quantidadeVezes);
        void ReplicarLinhaComAjusteFooter(int posicaoLinha, int quantidadeVezes);

        void RemoverLinha(int posicaoLinha);
        void RemoverLinhaComAjuste(Guid idLinha);

        void RemoverLinhaComAjuste(int posicaoLinha);

        void RemoverHeader();

        void RemoverFooter();

        void RemoverLinhas(int posicaoLinhaInicial, int quantidadeLinhas);
        void RemoverTodasLinhasDoBody();

        void RemoverExcetoEstas(int posicaoLinhaInicial, int quantidadeLinhas);

        void RemoverLinhasMenosUma(int posicaoLinhaAManter);
        void ReIndexar();
        //void CarregaCamposDoLayout(ILinhaArquivo linha);

        IList<ILinhaArquivo> CarregaLinhas(IEnumerable<string> linhas);

        IList<ILinhaArquivo> CarregaHeader(IEnumerable<string> linhas);

        IList<ILinhaArquivo> CarregaFooter(IEnumerable<string> linhas);
        ILinhaArquivo this[int posicao] { get; }

        /// <summary>
        /// Busca a primeira linha para cada valor no campo especificado, removendo as outras.
        /// </summary>
        /// <param name="nomeCampo"></param>
        void RemoverValoresRepetidosNoCampo(string nomeCampo);

        string MontarCamposChaveParaLog(int posicaoLinha);

        decimal SomarLinhasDoArquivo(string nomeCampo);

        void SelecionarLinhas(string nomeCampo, string valorFormatado);

        ILinhaArquivo SelecionarPrimeiraLinhaEncontrada(IList<KeyValuePair<string, string>> valoresDosCampos);


        IList<KeyValuePair<string, string>> ObterValoresDosCamposChaves(ILinhaArquivo linha);
        ILinhaArquivo CriarLinhaVazia(int index);
    }
}
