using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class ArquivoRegras : BaseRegras
    {
        protected ControleNomeArquivo controleNomeArquivo = ControleNomeArquivo.Instancia;
        public ArquivoRegras(IMyLogger logger) : base(logger)
        {

        }

        public void AlterarLayout<T>(ref IArquivo _arquivo) where T : IArquivo, new()
        {
            logger.AbrirBloco($"ALTERANDO LAYOUT DE {_arquivo.GetType().Name} para {typeof(T)}");
            var novoArquivo = new T();
            novoArquivo.Linhas = new List<ILinhaArquivo>();
            novoArquivo.Header = new List<ILinhaArquivo>();
            novoArquivo.Footer = new List<ILinhaArquivo>();
            novoArquivo.AtualizarNomeArquivoFinal(_arquivo.NomeArquivo);

            novoArquivo.Header.Add(_arquivo.Header[0].Clone());
            novoArquivo.Footer.Add(_arquivo.Footer[0].Clone());
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
                novoArquivo.AdicionarLinha(novoArquivo.CriarLinhaVazia(i));

            novoArquivo.AjustarQtdLinhasNoFooter();
            ArquivoUtils.IgualarCamposQueExistirem(_arquivo, novoArquivo);

            novoArquivo.AlterarHeader("VERSAO", novoArquivo.TextoVersaoHeader);

            logger.FecharBloco();
            _arquivo = novoArquivo;

            if (_arquivo.Operadora == OperadoraEnum.PAPCARD)
                AlteracoesIniciaisPapcard(_arquivo);

        }

        protected void CarregarArquivo(IArquivo arquivo, int qtdLinhas, OperadoraEnum operadora)
        {
            logger.AbrirBloco($"INICIANDO CARREGAMENTO DE ARQUIVO DO TIPO: {arquivo.tipoArquivo.ObterTexto()} - OPERACAO: {operadora.ObterTexto()}");
            var arquivoGerado = ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem);
            arquivo.Carregar(arquivoGerado, 1, 1, qtdLinhas);
            logger.Escrever("ARQUIVO GERADO " + arquivo.NomeArquivo);
            logger.FecharBloco();
        }

        protected void AlteracoesIniciaisPapcard(IArquivo _arquivo)
        {
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
            {
                if (_arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
                {
                    _arquivo.AlterarLinhaSeExistirCampo(i, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(_arquivo.Linhas[i]));
                    _arquivo.AlterarLinhaSeExistirCampo(i, "NR_PROPOSTA", ParametrosRegrasEmissao.GerarNrApolicePapCard());
                    _arquivo.AlterarLinhaSeExistirCampo(i, "NR_APOLICE", "759303900006209");
                    _arquivo.AlterarLinhaSeExistirCampo(i, "CD_CLIENTE", RandomNumber.GerarNumeroAleatorio(8));
                }

                _arquivo.AlterarLinhaSeExistirCampo(i, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(_arquivo.Linhas[i], OperadoraEnum.PAPCARD));
                _arquivo.AlterarLinhaSeExistirCampo(i, "CD_CONTRATO", "759303900006209");

            }

        }

        public string ObterArquivoDestino(IArquivo _arquivo, string _nomeArquivo, bool AlterarNomeArquivo, out string numeroDoLote)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(_arquivo.tipoArquivo);
            numeroDoLote = numeroArquivoNovo;
            if (AlterarNomeArquivo)
            {
                _nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if (_arquivo.Header.Count > 0)
                    _arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);
            }

            var path = Parametros.pastaDestino + _arquivo.tipoArquivo.ObterPastaNoDestino() + "\\" + _nomeArquivo;

            _arquivo.AtualizarNomeArquivoFinal(_nomeArquivo);

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        public string ObterArquivoDestinoApenasCriacaoOuValidacao(IArquivo _arquivo, string _nomeArquivo, out string numeroDoLote)
        {
            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(_arquivo.tipoArquivo);
            numeroDoLote = numeroArquivoNovo;

            _nomeArquivo = _nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
            if (_arquivo.Header.Count > 0)
                _arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);

            var path = Parametros.pastaDestino + _arquivo.tipoArquivo.ObterPastaNoDestino() + _nomeArquivo;

            _arquivo.AtualizarNomeArquivoFinal(_nomeArquivo);

            logger.EscreverBloco("Salvando arquivo modificado : " + path);
            return path;
        }

        public void AlteracoesPapCardEmissao(IArquivo _arquivo)
        {
            if (_arquivo.tipoArquivo == TipoArquivo.Comissao)
                return;

            for (int i = 0; i < _arquivo.Linhas.Count; i++)
            {
                _arquivo.AlterarLinhaSeExistirCampo(i, "NR_SEQUENCIAL_EMISSAO_EST", _arquivo[i].ObterCampoSeExistir("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                _arquivo.AlterarLinhaSeExistirCampo(i, "NR_SEQUENCIAL_EMISSAO", "");
            }
        }

        public void AjusteIdTransacao(IArquivo _arquivo)
        {
            if (_arquivo.tipoArquivo == TipoArquivo.ParcEmissao || _arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
            {

                Parallel.ForEach(_arquivo.Linhas, linha =>
                {
                    var idTransacaoOld = linha["ID_TRANSACAO"];
                    var idTransacaoNew = CarregarIdtransacao(linha);
                    _arquivo.AlterarLinha(linha.Index, "ID_TRANSACAO", idTransacaoNew);
                    //REPENSAR EM COMO UTILIZAR ISSO PARA ARQUIVOS COM EMISSAO E CANCELAMENTO JUNTOS.
                    //_arquivo.AlterarLinhaComCampoIgualAValor("ID_TRANSACAO_CANC", idTransacaoOld, "ID_TRANSACAO_CANC", idTransacaoNew);
                });
            }
        }

        public string CarregarIdtransacao(ILinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }
    }
}
