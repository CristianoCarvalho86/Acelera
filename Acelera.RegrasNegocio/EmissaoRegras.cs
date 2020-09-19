using Acelera.Contratos;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class EmissaoRegras : BaseRegras
    {
        public EmissaoRegras(IMyLogger logger) : base(logger)
        {

        }

        public void CriarNovaLinhaParaEmissao(IArquivo arquivoParc, int linhaDeReferencia = 0)
        {
            var operadora = arquivoParc.Operadora;
            if (operadora == OperadoraEnum.TIM)
                CriarNovaLinhaEmissaoTim(arquivoParc);
            else if (operadora == OperadoraEnum.PITZI)
                CriarNovaLinhaEmissaoPitzi(arquivoParc);
            else
                arquivoParc.AdicionarLinha(arquivoParc.ObterLinha(linhaDeReferencia).Clone());

            var index = arquivoParc.Linhas.Count - 1;
            arquivoParc.AlterarLinha(index, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(operadora));
            arquivoParc.AlterarLinha(index, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(arquivoParc[linhaDeReferencia]));
            arquivoParc.AlterarLinha(index, "NR_PARCELA", arquivoParc[linhaDeReferencia]["NR_PARCELA"].ObterProximoValorInteiro());
            arquivoParc.AlterarLinha(index, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(arquivoParc[linhaDeReferencia], operadora));
            arquivoParc.AjustarQtdLinhasNoFooter();
        }

        private void CriarNovaLinhaEmissaoTim(IArquivo arquivoParc)
        {
            arquivoParc.AdicionarLinha(ParametrosLinhaEmissao.CarregaLinhaEmissaoTIM(arquivoParc[0], arquivoParc.Linhas.Count - 1));
            var camposASeremIgualados = arquivoParc[0].Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            ArquivoUtils.IgualarCampos(arquivoParc[0], arquivoParc[arquivoParc.Linhas.Count - 1], camposASeremIgualados, logger);
        }

        public ILinhaArquivo CriarNovaLinhaCapa(ILinhaArquivo linhaReferencia)
        {
            var linhaCapa = ParametrosLinhaEmissao.CarregaLinhaCapaTIM(linhaReferencia);
            var camposASeremIgualados = linhaReferencia.Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            ArquivoUtils.IgualarCampos(linhaReferencia, linhaCapa, camposASeremIgualados,logger);
            return linhaCapa;
        }

        private void CriarNovaLinhaEmissaoPitzi(IArquivo arquivoParc)
        {
            arquivoParc.AdicionarLinha(ParametrosLinhaEmissao.CarregaLinhaEmissaoPITZI(arquivoParc[0], arquivoParc.Linhas.Count - 1));
            var camposASeremIgualados = arquivoParc[0].Campos.Where(x => !x.ColunaArquivo.StartsWith("VL_") && x.ColunaArquivo != "CD_TIPO_EMISSAO").Select(x => x.ColunaArquivo).ToArray();
            ArquivoUtils.IgualarCampos(arquivoParc[0], arquivoParc[arquivoParc.Linhas.Count - 1], camposASeremIgualados,logger);
        }

        public void CriarNovaLinhaParaEmissaoComMesmoEndossoEParcela(IArquivo arquivoParc, int linhaDeReferencia = 0)
        {
            arquivoParc.AdicionarLinha(arquivoParc.ObterLinha(linhaDeReferencia).Clone());
            var index = arquivoParc.Linhas.Count - 1;
            arquivoParc.AlterarLinha(index, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(index, "NR_ENDOSSO", arquivoParc[linhaDeReferencia]["NR_ENDOSSO"]);
            arquivoParc.AlterarLinha(index, "NR_PARCELA", arquivoParc[linhaDeReferencia]["NR_PARCELA"]);
            arquivoParc.AlterarLinha(index, "NR_SEQUENCIAL_EMISSAO", arquivoParc[linhaDeReferencia]["NR_SEQUENCIAL_EMISSAO"]);
        }


        public void AlterarLinhaParaPrimeiraEmissao(IArquivo arquivoParc, int linhaDeReferencia = 0)
        {
            if (arquivoParc.Operadora == OperadoraEnum.PAPCARD)


                arquivoParc.AlterarLinha(linhaDeReferencia, "ID_TRANSACAO_CANC", "");
            arquivoParc.AlterarLinha(linhaDeReferencia, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(arquivoParc[linhaDeReferencia], arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(arquivoParc.Operadora));
            arquivoParc.AlterarLinha(linhaDeReferencia, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(arquivoParc.Operadora));
            if (arquivoParc.Operadora == OperadoraEnum.PAPCARD)
            {
                arquivoParc.AlterarLinha(linhaDeReferencia, "NR_PROPOSTA", ParametrosRegrasEmissao.GerarNrApolicePapCard());
            }
        }

    }
}
