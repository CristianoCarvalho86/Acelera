using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
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

        public bool RegistroEstaNaOds(ILinhaTabela linhaStage)
        {
            if (linhaStage.TabelaReferente == TabelasEnum.Cliente)
            {
                return ValidaCliente(linhaStage);
            }
            else if(linhaStage.TabelaReferente == TabelasEnum.ParcEmissao)
            {
                return ValidaParcela(linhaStage);
            }
            else if (linhaStage.TabelaReferente == TabelasEnum.ParcEmissaoAuto)
            {
                return ValidaParcAuto(linhaStage);
            }
            else if (linhaStage.TabelaReferente == TabelasEnum.Comissao)
            {
                return ValidaComissao(linhaStage);
            }
            else if (linhaStage.TabelaReferente == TabelasEnum.Sinistro)
            {
                return ValidaSinistro(linhaStage);
            }
            else if (linhaStage.TabelaReferente == TabelasEnum.OCRCobranca)
            {
                return ValidaSinistro(linhaStage);
            }
            return false;
        }

        private bool ValidaCliente(ILinhaTabela linhaStage)
        {
            bool existe = true;

            var cdParceiroNegocio = DataAccess.ConsultaUnica($"SELECT CD_PARCEIRO_NEGOCIO FROM {TabelasEnum.OdsParceiroNegocio.ObterTexto()}" +
                $" WHERE CD_EXTERNO = '{linhaStage.ObterPorColuna("CD_CLIENTE").ValorFormatado}'");

            if (string.IsNullOrEmpty(cdParceiroNegocio))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");
                return false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParceiroNegocio.ObterTexto()}");


            ValidaExistencia(TabelasEnum.OdsTelefone, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio, ref existe);

            ValidaExistencia(TabelasEnum.OdsEndereco, "CD_PARCEIRO_NEGOCIO", cdParceiroNegocio, ref existe);

            return existe;
        }

        private bool ValidaParcela(ILinhaTabela linhaStage)
        {
            bool existe = true;
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado);
            if (string.IsNullOrEmpty(cdParcela))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");
                return false;
            }

            ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, ref existe);

            //VERIFICAR COMO VALIDAR
            ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "DESCOBRIR O CAMPO", "DESCOBRIR O CAMPO",ref existe);

            return existe;
        }

        private bool ValidaParcAuto(ILinhaTabela linhaStage)
        {
            bool existe = true;
            var cdParcela = "";
            cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado);
            if (string.IsNullOrEmpty(cdParcela))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");
                return false;
            }

            ValidaExistencia(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, ref existe);

            ValidaExistencia(TabelasEnum.OdsItemAuto, "CD_PARCELA", cdParcela, ref existe);

            ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_PARCELA", cdParcela, ref existe);

            return existe;
        }

        private bool ValidaSinistro(ILinhaTabela linhaStage)
        {
            bool existe = true;
            var cdAvisoSinistro = ObterCdAvisoSinistro(linhaStage.ObterPorColuna("CD_SINISTRO").ValorFormatado);
            if (string.IsNullOrEmpty(cdAvisoSinistro))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsSinistro.ObterTexto()}");
                return false;
            }
            ValidaExistencia(TabelasEnum.OdsMovimentoSinistro, "CD_AVISO_SINISTRO", cdAvisoSinistro, ref existe);

            return existe;
        }

        private bool ValidaOCRCobranca(ILinhaTabela linhaStage)
        {
            bool existe = true;
            ValidaExistencia(TabelasEnum.OdsParcela, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_SINISTRO").ValorFormatado, ref existe);

            return existe;
        }

        private bool ValidaComissao(ILinhaTabela linhaStage)
        {
            bool existe = true;
            var cdParcela = "";
            cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado);
            if (string.IsNullOrEmpty(cdParcela))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");
                return false;
            }
            var cdComissao = ObterCdComissao(cdParcela);
            if (string.IsNullOrEmpty(cdComissao))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {TabelasEnum.OdsComissao.ObterTexto()}");
                return false;
            }
            ValidaExistencia(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao, ref existe);

            return existe;
        }

        private string ObterCdParcela(string cdContrato)
        {
            return DataAccess.ConsultaUnica($"SELECT CD_PARCELA FROM {TabelasEnum.OdsParcela} WHERE CD_CONTRATO = '{cdContrato}'", false);
        }

        private string ObterCdAvisoSinistro(string cdSinistro)
        {
            return DataAccess.ConsultaUnica($"SELECT CD_AVISO_SINISTRO FROM {TabelasEnum.OdsSinistro} WHERE CD_SINISTRO = '{cdSinistro}'", false);
        }

        private string ObterCdComissao(string cdParcela)
        {
            return DataAccess.ConsultaUnica($"SELECT CD_PARCELA FROM {TabelasEnum.OdsComissao} WHERE CD_PARCELA = '{cdParcela}'", false);
        }

        private void ValidaExistencia(TabelasEnum tabela, string campo, string valor,ref bool existe)
        {
            if (!DataAccess.ExisteRegistro(tabela.ObterTexto(), campo, valor, logger))
            {
                logger.Escrever($"REGISTRO NAO ENCONTRADO EM : {tabela.ObterTexto()}");
                existe = false;
            }
            else
                logger.Escrever($"REGISTRO ENCONTRADO EM : {tabela.ObterTexto()}");
        }
    }
}
