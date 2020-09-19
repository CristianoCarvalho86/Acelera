using Acelera.Contratos;
using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class ComissaoRegras : BaseRegras
    {
        public ComissaoRegras(IMyLogger logger) : base(logger)
        {

        }

        public IArquivo CriarComissao<T>(OperadoraEnum operadora, IArquivo arquivoParcela, bool alterarVersaoHeader = false, bool alteraTipoComissao = true) where T : Arquivo, new()
        {
            if (alterarVersaoHeader)
                return CriarComissao<T>(operadora, arquivoParcela, "9.6", alteraTipoComissao);
            return CriarComissao<T>(operadora, arquivoParcela, "", alteraTipoComissao);

        }

        public IArquivo CriarComissao<T>(OperadoraEnum operadora, IArquivo arquivoParcela, string alterarVersaoHeader, bool alteraTipoComissao = true) where T : Arquivo, new()
        {
            var arquivo = new T();
            ArquivoUtils.CarregarArquivo(arquivo, arquivoParcela.Linhas.Count, operadora,logger);

            ArquivoUtils.IgualarCamposQueExistirem(arquivoParcela, arquivo);

            var dados = new DadosParametrosData(logger);

            if (alteraTipoComissao)
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinha(linha.Index, "CD_TIPO_COMISSAO", dados.ObterTipoRemuneracaoDoCorretor(arquivo[linha.Index]["CD_CORRETOR"], arquivo[linha.Index]["CD_COBERTURA"], arquivoParcela[linha.Index]["CD_PRODUTO"]));

            if (!string.IsNullOrEmpty(alterarVersaoHeader))
                arquivo.AlterarHeader("VERSAO", alterarVersaoHeader);

            return arquivo;
        }

    }
}
