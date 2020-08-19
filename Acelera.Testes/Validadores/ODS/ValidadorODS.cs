using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using System;
using System.Collections.Generic;
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

        public bool RegistroEstaNaOds(ILinhaTabela linhaStage, TipoArquivo tipoArquivo)
        {
            bool existe = true;
            if (tipoArquivo == TipoArquivo.Cliente)
            {
                existe = ValidaCliente(linhaStage, existe);
            }

            return false;
        }

        private bool ValidaCliente(ILinhaTabela linhaStage)
        {
            bool existe = true;
            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsParceiroNegocio.ObterTexto(), "CD_EXTERNO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");

            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsEndereco.ObterTexto(), "CD_PARCEIRO_NEGOCIO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsEndereco.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsEndereco.ObterTexto()}");

            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsTelefone.ObterTexto(), "CD_PARCEIRO_NEGOCIO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsTelefone.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsTelefone.ObterTexto()}");
            return existe;
        }

        private bool ValidaParcela(ILinhaTabela linhaStage)
        {
            bool existe = true;
            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsCobertura.ObterTexto(), "CD_EXTERNO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");

            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsEndereco.ObterTexto(), "CD_PARCEIRO_NEGOCIO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsEndereco.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsEndereco.ObterTexto()}");

            if (!DataAccess.ExisteRegistro(TabelasEnum.OdsTelefone.ObterTexto(), "CD_PARCEIRO_NEGOCIO", linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsTelefone.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsTelefone.ObterTexto()}");
            return existe;
        }
    }
}
