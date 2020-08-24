﻿using Acelera.Domain.Entidades.Interfaces;
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
        public ValidadorODS(ref IMyLogger logger)
        {
            this.logger = logger;
        }

        public bool RegistroEstaNaOds(ILinhaTabela linhaStage, bool deveHaverRegistro = true)
        {
            logger.Escrever("DEVE ENCONTRAR REGISTROS NA ODS: " + deveHaverRegistro.ToString());
            var erros = "";
            switch (linhaStage.TabelaReferente)
            {
                case TabelasEnum.Cliente:
                    ValidaCliente(linhaStage, deveHaverRegistro, ref erros);
                    break;
                case TabelasEnum.ParcEmissao:
                    ValidaParcela(linhaStage, deveHaverRegistro, ref erros);
                    break;
                case TabelasEnum.ParcEmissaoAuto:
                    ValidaParcAuto(linhaStage, deveHaverRegistro, ref erros);
                    break;
                case TabelasEnum.Comissao:
                    ValidaComissao(linhaStage, deveHaverRegistro, ref erros);
                    break;
                case TabelasEnum.Sinistro:
                    ValidaSinistro(linhaStage, deveHaverRegistro, ref erros);
                    break;
                case TabelasEnum.OCRCobranca:
                    ValidaOCRCobranca(linhaStage, deveHaverRegistro, ref erros);
                    break;
                default:
                    logger.Erro($"RegistroEstaNaOds - {linhaStage.TabelaReferente} - TABELA NAO ENCONTRADA");
                    throw new Exception("RegistroEstaNaOds - TABELA NAO ENCONTRADA");
            }

            return StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);
        }

        private void ValidaCliente(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            DataRow row;
            row = ValidaExistencia(TabelasEnum.OdsParceiroNegocio, "CD_EXTERNO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, deveHaverRegistro, ref erros);

            if (row == null && deveHaverRegistro)
            {
                erros += $"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}{Environment.NewLine}";
                return;
            }
            else if (row != null && !deveHaverRegistro)
                erros += $"REGISTRO ERRONEAMENTE ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}{Environment.NewLine}";
            else
                logger.Escrever($"REGISTRO CORRETAMENTE ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");

            var cdParceiroNegocio = row["CD_PARCEIRO_NEGOCIO"].ToString();

            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsTelefone, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio, deveHaverRegistro, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsEndereco, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio, deveHaverRegistro, ref erros), linhaStage, ref erros);


        }

        private void ValidaParcela(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro, ref erros);
            if (cdParcela == null)
                return;

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            //VERIFICAR COMO VALIDAR
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "descobrir campo", "DESCOBRIR CAMPO", deveHaverRegistro, ref erros), linhaStage, ref erros);
        }

        private void ValidaParcAuto(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro, ref erros);
            if (cdParcela == null)
            {
                return;
            }

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsItemAuto, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);
        }

        private void ValidaSinistro(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var cdAvisoSinistro = ObterCdAvisoSinistro(linhaStage.ObterPorColuna("CD_SINISTRO").ValorFormatado, linhaStage, deveHaverRegistro, ref erros);
            if (string.IsNullOrEmpty(cdAvisoSinistro))
            {
                return;
            }
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsMovimentoSinistro, "CD_AVISO_SINISTRO", cdAvisoSinistro, deveHaverRegistro, ref erros),
                linhaStage, ref erros);
        }

        private void ValidaOCRCobranca(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsParcela, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, deveHaverRegistro, ref erros)
                , linhaStage, ref erros);
        }

        private void ValidaComissao(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro, ref erros);
            if (string.IsNullOrEmpty(cdParcela))
            {
                erros += $"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}{Environment.NewLine}";
                return;
            }
            var cdComissao = ObterCdComissao(cdParcela, linhaStage, deveHaverRegistro, ref erros);
            if (string.IsNullOrEmpty(cdComissao))
            {
                erros += $"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsComissao.ObterTexto()}{Environment.NewLine}";
                return;
            }

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao, deveHaverRegistro, ref erros), linhaStage, ref erros);
        }

        private string ObterCdParcela(string cdContrato, ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var row = ValidaExistencia(TabelasEnum.OdsParcela, "CD_CONTRATO", cdContrato, deveHaverRegistro, ref erros);
            if (row == null)
            {
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");

            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_PARCELA"].ToString();

        }

        private string ObterCdAvisoSinistro(string cdSinistro, ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var row = ValidaExistencia(TabelasEnum.OdsSinistro, "CD_SINISTRO", cdSinistro, deveHaverRegistro, ref erros);
            if (row == null)
            {
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");

            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_AVISO_SINISTRO"].ToString();
        }

        private string ObterCdComissao(string cdParcela, ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var row = ValidaExistencia(TabelasEnum.OdsComissao, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros);
            if (row == null)
            {
                return null;
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");

            ValidarCamposDeNomeSemelhantes(row, linhaStage, ref erros);
            StringUtils.ValidarTextoDeErrosEncontrados(erros, logger);

            return row["CD_COMISSAO"].ToString();
        }

        private DataRow ValidaExistencia(TabelasEnum tabela, string campo, string valor, bool deveHaverRegistro, ref string erros)
        {
            var table = DataAccess.Consulta($"SELECT * FROM {tabela.ObterTexto()} WHERE {campo} = '{valor}'", campo, logger);
            if (table.Rows.Count == 0 && deveHaverRegistro)
            {
                erros += $"REGISTRO NAO ENCONTRADO EM {tabela.ObterTexto()}{Environment.NewLine}";
                return null;
            }
            else if (table.Rows.Count > 0 && !deveHaverRegistro)
                erros += $"REGISTRO ENCONTRADO EM : {tabela.ObterTexto()}{Environment.NewLine}";
            else if (table.Rows.Count > 1)
                erros += $"MAIS DE UM REGISTRO ENCONTRADO EM : {tabela.ObterTexto()}. QUANTIDADE DE REGISTROS ENCONTRADOS: {table.Rows.Count}{Environment.NewLine}";

            return table.Rows[0];
        }

        public void ValidarCamposDeNomeSemelhantes(DataRow row, ILinhaTabela linhaStage, ref string erros)
        {
            if (row == null)
            {
                return;
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