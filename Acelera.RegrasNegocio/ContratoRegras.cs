using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.DataAccess;
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
    public class ContratoRegras: BaseRegras
    {
        public ContratoRegras(IMyLogger logger) : base(logger)
        {

        }

        public void CriarNovoContrato(int posicaoLinha, IArquivo arquivo, string novoContrato = "", bool colocarEmTodasAsLinhas = false)
        {
            var contrato = "";
            if (!string.IsNullOrEmpty(novoContrato))
                contrato = novoContrato;
            else if (arquivo.Operadora == OperadoraEnum.PAPCARD)
            {
                contrato = "759303900006209";
            }
            else
            {
                contrato = GerarNovoContratoAleatorio(arquivo.ObterValorFormatado(0, "CD_CONTRATO"), true);
            }
            if (colocarEmTodasAsLinhas)
                AlterarContratoNoArquivo(arquivo, contrato);
            else
                AlterarContrato(arquivo, posicaoLinha, contrato);
        }

        public void AlterarContratoNoArquivo(IArquivo arquivo, string contrato)
        {
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                AlterarContrato(arquivo, i, contrato);
            }
        }

        public void AlterarContrato(IArquivo arquivo, int posicaoLinha, string contrato)
        {
            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
            {
                arquivo.AlterarLinha(posicaoLinha, "CD_CONTRATO", contrato);
                arquivo.AlterarLinha(posicaoLinha, "NR_APOLICE", contrato);
                arquivo.AlterarLinha(posicaoLinha, "NR_PROPOSTA", contrato);
            }
        }

        public string GerarNovoContratoAleatorio(string contratoBase, bool validaExistencia)
        {
            var contrato = "";
            while (true)
            {
                contrato = StringUtils.AlterarUltimasPosicoes(contratoBase, RandomNumber.GerarNumeroAleatorio(8));
                if (!validaExistencia)
                    break;

                if (!DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.ParcEmissao.ObterTexto()} WHERE CD_CONTRATO = '{contrato}'", logger) &&
                   !DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.ParcEmissaoAuto.ObterTexto()} WHERE CD_CONTRATO = '{contrato}'", logger) &&
                   !DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.OdsParcela.ObterTexto()} WHERE CD_CONTRATO = '{contrato}'", logger) &&
                   !DataAccessOIM.ExisteRegistro($"SELECT '1' FROM oim_apl01 where nr_doc_apolice = '{contrato}'", logger))
                    break;
            }
            return contrato;
        }
    }
}
