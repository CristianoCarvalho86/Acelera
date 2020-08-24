using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.Validadores.ODS
{
    public class ValidadorODS
    {
        private IMyLogger logger;
        public ValidadorODS(IMyLogger logger)
        {
            this.logger = logger;
        }

        public bool RegistroEstaNaOds(ILinhaTabela linhaStage)
        {
            switch(linhaStage.TabelaReferente)
            {
                case TabelasEnum.Cliente:
                    return ValidaCliente(linhaStage);
                case TabelasEnum.ParcEmissao:
                    return ValidaParcela(linhaStage);
                case TabelasEnum.ParcEmissaoAuto:
                    return ValidaParcAuto(linhaStage);
                case TabelasEnum.Comissao:
                    return ValidaComissao(linhaStage);
                case TabelasEnum.Sinistro:
                    return ValidaSinistro(linhaStage);
                case TabelasEnum.OCRCobranca:
                    return ValidaOCRCobranca(linhaStage);

            }
            logger.Erro("RegistroEstaNaOds - TABELA NAO ENCONTRADA");
            throw new Exception("RegistroEstaNaOds - TABELA NAO ENCONTRADA");
        }

        private bool ValidaCliente(ILinhaTabela linhaStage)
        {
            string erros = "";
            DataRow row;
            var cdParceiroNegocio = "";
            row = ValidaExistencia(TabelasEnum.OdsParceiroNegocio, "CD_EXTERNO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado);

            if (row == null)
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");
                return false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");

            cdParceiroNegocio = row["CD_PARCEIRO_NEGOCIO"].ToString();

            ValidarCamposDeNomeSemelhantes(row, linhaStage,ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsTelefone, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio),linhaStage,ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsEndereco, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio), linhaStage ,ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros,logger);
        }

        private bool ValidaParcela(ILinhaTabela linhaStage)
        {
            var cdParcela = "";
            var erros = "";

            cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado,linhaStage);
            if (cdParcela == null)
                return false;

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela),linhaStage, ref erros);

            //VERIFICAR COMO VALIDAR
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "descobrir campo", "DESCOBRIR CAMPO"), linhaStage, ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros,logger);
        }

        private bool ValidaParcAuto(ILinhaTabela linhaStage)
        {
            var erros = "";
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado,linhaStage);
            if (cdParcela == null)
            {
                return false;
            }

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsItemAuto, "CD_PARCELA", cdParcela),linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_PARCELA", cdParcela),linhaStage, ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);
        }

        private bool ValidaSinistro(ILinhaTabela linhaStage)
        {
            var erros = "";
            var cdAvisoSinistro = ObterCdAvisoSinistro(linhaStage.ObterPorColuna("CD_SINISTRO").ValorFormatado,linhaStage);
            if (string.IsNullOrEmpty(cdAvisoSinistro))
            {
                return false;
            }
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsMovimentoSinistro, "CD_AVISO_SINISTRO", cdAvisoSinistro),linhaStage, ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);
        }

        private bool ValidaOCRCobranca(ILinhaTabela linhaStage)
        {
            var erros = "";
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsParcela, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado),linhaStage, ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);
        }

        private bool ValidaComissao(ILinhaTabela linhaStage)
        {
            var erros = "";
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage);
            if (string.IsNullOrEmpty(cdParcela))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");
                return false;
            }
            var cdComissao = ObterCdComissao(cdParcela,linhaStage);
            if (string.IsNullOrEmpty(cdComissao))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsComissao.ObterTexto()}");
                return false;
            }

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao),linhaStage, ref erros);

            return StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);
        }

        private string ObterCdParcela(string cdContrato, ILinhaTabela linhaStage)
        {
            var row = ValidaExistencia(TabelasEnum.OdsParceiroNegocio, "CD_CONTRATO", cdContrato);
            if (row == null)
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");

            var erros = "";
            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_PARCELA"].ToString();

        }

        private string ObterCdAvisoSinistro(string cdSinistro, ILinhaTabela linhaStage)
        {
            var row = ValidaExistencia(TabelasEnum.OdsSinistro, "CD_SINISTRO", cdSinistro);
            if (row == null)
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");

            var erros = "";
            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_AVISO_SINISTRO"].ToString();
        }

        private string ObterCdComissao(string cdParcela, ILinhaTabela linhaStage)
        {
            //return DataAccess.ConsultaUnica($"SELECT CD_PARCELA FROM {TabelasEnum.OdsComissao} WHERE CD_PARCELA = '{cdParcela}'", false);
            var row = ValidaExistencia(TabelasEnum.OdsComissao, "CD_PARCELA", cdParcela);
            if (row == null)
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");

            var erros = "";
            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_COMISSAO"].ToString();
        }

        private DataRow ValidaExistencia(TabelasEnum tabela, string campo, string valor)
        {
            var table = DataAccess.Consulta($"SELECT * FROM {tabela.ObterTexto()} WHERE {campo} = '{valor}'", campo, logger);
            if (table.Rows.Count == 0)
            {
                return null;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {tabela.ObterTexto()}");

            return table.Rows[0];
        }

        public void ValidarCamposDeNomeSemelhantes(DataRow row, ILinhaTabela linhaStage, ref string erros)
        {
            if (row == null)
            {
                erros += "NENHUM REGISTRO PARA VALIDAÇÃO";
            }
            foreach (var campo in linhaStage.Campos)
            {
                if (row.Table.Columns.Contains(campo.Coluna))
                    if (row[campo.Coluna].ToString() != campo.ValorFormatado)
                    {
                        erros += $"Campo: {campo.Coluna} Na Stage = '{campo.ValorFormatado}' , valor encontrado : {row[campo.Coluna].ToString()}{Environment.NewLine}";
                    }
            }
        }
    }
}
