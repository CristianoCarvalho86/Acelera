using Acelera.Domain.Entidades;
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
        private TabelaParametrosDataSP3 dados;
        public ValidadorODS(TabelaParametrosDataSP3 dados,ref IMyLogger logger)
        {
            this.dados = dados;
            this.logger = logger;
        }

        public bool RegistroEstaNaOds(ILinhaTabela linhaStage, bool deveHaverRegistro = true)
        {
            logger.Escrever("DEVE ENCONTRAR REGISTROS NA ODS: " + deveHaverRegistro.ToString());
            var erros = "";

            if (linhaStage.ObterPorColuna("CD_TIPO_EMISSAO") != null &&
                ParametrosRegrasEmissao.CdTipoEmissaoCapa.ToList().Contains(linhaStage.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado))
                return true;

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
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro);
            if (cdParcela == null)
                return;

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsParcela, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);

            //VERIFICAR COMO VALIDAR
            var cdComissao = ObterCdComissao(cdParcela, linhaStage, true, ref erros);
            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);
        }

        private void ValidaParcAuto(ILinhaTabela linhaStage, bool deveHaverRegistro, ref string erros)
        {
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro);
            if (cdParcela == null)
            {
                return;
            }

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsParcela, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsCobertura, "CD_PARCELA", cdParcela, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistencia(TabelasEnum.OdsItemAuto, "CD_PARCELA", cdParcela, deveHaverRegistro, ref erros), linhaStage, ref erros);

            var cdComissao = ObterCdComissao(cdParcela, linhaStage, true, ref erros);
            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);
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
            var cdParcela = ObterCdParcela(linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage, deveHaverRegistro);
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

            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsComissao, "CD_COMISSAO", cdComissao, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);

            ValidarCamposDeNomeSemelhantes(ValidaExistenciaCobertura(TabelasEnum.OdsCoberturaComissao, "CD_COMISSAO", cdComissao, deveHaverRegistro, linhaStage, ref erros), linhaStage, ref erros);
        }

        private string ObterCdParcela(string cdContrato, ILinhaTabela linhaStage, bool deveHaverRegistro)
        {
            var table = DataAccess.Consulta($"SELECT * FROM {Parametros.instanciaDB}.{TabelasEnum.OdsParcela.ObterTexto()} WHERE " +
                $" CD_CONTRATO = '{linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado}' AND " +
                $" NR_SEQ_EMISSAO = '{linhaStage.ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado}' AND" +
                $" NR_PARCELA = '{linhaStage.ObterPorColuna("NR_PARCELA").ValorFormatado}' ","REGISTRO ODS PARCELA",logger);
            if (table == null || table.Rows.Count == 0)
            {
                return null;
            }
            if(table.Rows.Count > 1)
            {
                logger.Erro($"MAIS DE UM REGISTRO ENCONTRADO: {Environment.NewLine}{table.ObterTextoTabular()}");
            }

            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsParcela.ObterTexto()}");

            return table.Rows[0]["CD_PARCELA"].ToString();

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
            var cdTipoComissao = "";
            if (linhaStage.TabelaReferente == TabelasEnum.ParcEmissao || linhaStage.TabelaReferente == TabelasEnum.ParcEmissaoAuto)
                cdTipoComissao = dados.ObterLinhaStageComissaoReferenteALinhaParcela(linhaStage).ObterPorColuna("CD_TIPO_COMISSAO").ValorFormatado;
            else
                cdTipoComissao = linhaStage.ObterPorColuna("CD_TIPO_COMISSAO").ValorFormatado;

            var table = DataAccess.Consulta($"SELECT * FROM {Parametros.instanciaDB}.{TabelasEnum.OdsComissao.ObterTexto()} WHERE " +
                $" CD_PARCELA = '{cdParcela}' AND " +
                $" CD_PN_CORRETOR = '{dados.ObterCdPNCorretor(linhaStage.ObterPorColuna("CD_CORRETOR").ValorFormatado)}' AND" +
                $" CD_TIPO_COMISSAO = '{cdTipoComissao}' ", "REGISTRO ODS COMISSAO", logger);
            if (table == null || table.Rows.Count == 0)
            {
                return null;
            }
            if (table.Rows.Count > 1)
            {
                logger.Erro($"MAIS DE UM REGISTRO ENCONTRADO: {Environment.NewLine}{table.ObterTextoTabular()}");
            }
            logger.Escrever($"REGISTRO ENCONTRADO EM : {TabelasEnum.OdsComissao.ObterTexto()}");

            return table.Rows[0]["CD_COMISSAO"].ToString();
        }

        private DataRow ValidaExistenciaCobertura(TabelasEnum tabela, string campo, string valor, bool deveHaverRegistro, ILinhaTabela linhaStage, ref string erros)
        {
            var idCobertura = "";
            if (tabela == TabelasEnum.OdsCoberturaComissao || tabela == TabelasEnum.OdsCobertura)
            {
                if (linhaStage.TabelaReferente == TabelasEnum.Comissao)
                    idCobertura = dados.ObterIdCoberturaParaCodigosCoberturaEProduto(linhaStage.ObterPorColuna("CD_COBERTURA").ValorFormatado, dados.ObterLinhaStageParcelaReferenteALinhaComissao(linhaStage).ObterPorColuna("CD_PRODUTO").ValorFormatado);
                else
                    idCobertura = dados.ObterIdCoberturaParaCodigosCoberturaEProduto(linhaStage.ObterPorColuna("CD_COBERTURA").ValorFormatado, linhaStage.ObterPorColuna("CD_PRODUTO").ValorFormatado);
            }

            var sql = $"SELECT * FROM {Parametros.instanciaDB}.{tabela.ObterTexto()} WHERE {campo} = '{valor}'";
            if(tabela == TabelasEnum.OdsCoberturaComissao || tabela == TabelasEnum.OdsCobertura)
                sql += $" AND ID_COBERTURA = '{idCobertura}'";

            var table = DataAccess.Consulta(sql, "COMISSAO", logger);
            table.TableName = tabela.ObterTexto();
            return ObterLinhaExistente(table, deveHaverRegistro, ref erros);
        }
        private DataRow ValidaExistencia(TabelasEnum tabela, string campo, string valor, bool deveHaverRegistro, ref string erros)
        {
            var table = DataAccess.Consulta($"SELECT * FROM {Parametros.instanciaDB}.{tabela.ObterTexto()} WHERE {campo} = '{valor}'", campo, logger);
            table.TableName = tabela.ObterTexto();
            return ObterLinhaExistente(table, deveHaverRegistro, ref erros);
        }

        private DataRow ObterLinhaExistente(DataTable table, bool deveHaverRegistro, ref string erros)
        {
            if (table.Rows.Count == 0 && deveHaverRegistro)
            {
                erros += $"REGISTRO NAO ENCONTRADO EM {table.TableName}{Environment.NewLine}";
                return null;
            }
            else if (table.Rows.Count > 0 && !deveHaverRegistro)
                erros += $"REGISTRO ENCONTRADO EM : {table.TableName}{Environment.NewLine}";
            else if (table.Rows.Count > 1)
                erros += $"MAIS DE UM REGISTRO ENCONTRADO EM : {table.TableName}. QUANTIDADE DE REGISTROS ENCONTRADOS: {table.Rows.Count}{Environment.NewLine}";

            return table.Rows[0];
        }

        public void ValidarCamposDeNomeSemelhantes(DataRow rowOds, ILinhaTabela linhaStage, ref string erros)
        {
            if (rowOds == null)
            {
                return;
            }
            foreach (var campo in linhaStage.Campos)
            {
                var valorDaStage = "";
                if (rowOds.Table.Columns.Contains(campo.Coluna))
                {
                    valorDaStage = campo.ValorFormatado;
                    if (campo.Coluna == "DT_MUDANCA" || campo.Coluna == "NM_ARQUIVO_TPA")
                        continue;

                    if (campo.Coluna.Contains("VL_") || campo.Coluna.Contains("PC_"))
                    {
                        decimal decStage = 0;
                        decimal decOds = 0;
                        if (linhaStage.TabelaReferente == TabelasEnum.ParcEmissao && rowOds.Table.TableName == TabelasEnum.OdsParcela.ObterTexto())
                        {
                            decStage = ObterSomatorio(campo.Coluna, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage.ObterNomeTabela());
                            decOds = ObterSomatorio(campo.Coluna, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, rowOds.Table.TableName);
                        }
                        else if (linhaStage.TabelaReferente == TabelasEnum.ParcEmissao &&
                            (rowOds.Table.TableName == TabelasEnum.OdsCobertura.ObterTexto() ||
                            rowOds.Table.TableName == TabelasEnum.OdsCoberturaComissao.ObterTexto()))
                            continue;

                        if (linhaStage.TabelaReferente == TabelasEnum.Comissao)
                        {
                            decStage = ObterSomatorio(campo.Coluna, "CD_CONTRATO", linhaStage.ObterPorColuna("CD_CONTRATO").ValorFormatado, linhaStage.ObterNomeTabela(),
                                $" AND CD_COBERTURA = '{linhaStage.ObterPorColuna("CD_COBERTURA").ValorFormatado}' AND NR_SEQUENCIAL_EMISSAO = '{linhaStage.ObterPorColuna("NR_SEQUENCIAL_EMISSAO").ValorFormatado}' ");
                            var idCobertura = dados.ObterIdCoberturaParaCodigosCoberturaEProduto(linhaStage.ObterPorColuna("CD_COBERTURA").ValorFormatado, dados.ObterLinhaStageParcelaReferenteALinhaComissao(linhaStage).ObterPorColuna("CD_PRODUTO").ValorFormatado);
                            if (rowOds.Table.Columns.Contains("ID_COBERTURA"))
                                decOds = ObterSomatorio(campo.Coluna, "CD_COMISSAO", rowOds["CD_COMISSAO"].ToString(), rowOds.Table.TableName, $" AND ID_COBERTURA = '{idCobertura}'");
                            else
                                continue;
                        }

                        //decimal.TryParse(rowOds[campo.Coluna].ToString(),out decimal dec1);
                        //decimal.TryParse(valorDaStage.Replace(".",","), out decimal dec2);
                        if (decStage != decOds)
                        {
                            erros += $"decStage : {decStage}";
                            erros += $"decOds : {decOds}";
                            erros += MensagemErroCampo(rowOds, linhaStage, erros, campo, valorDaStage);
                        }
                    }
                    else if (campo.Coluna.Contains("DT_"))
                    {
                        if (valorDaStage.Length == 8)
                        {
                            if (new DateTime(int.Parse(valorDaStage.Substring(0, 4)), int.Parse(valorDaStage.Substring(4, 2)), int.Parse(valorDaStage.Substring(6, 2))).Date
                            != Convert.ToDateTime(rowOds[campo.Coluna]).Date)
                            {
                                erros += MensagemErroCampo(rowOds, linhaStage, erros, campo, valorDaStage);
                            }
                        }
                        else if (Convert.ToDateTime(valorDaStage).Date != Convert.ToDateTime(rowOds[campo.Coluna]).Date)
                        {
                            erros += MensagemErroCampo(rowOds, linhaStage, erros, campo, valorDaStage);
                        }
                    }
                    else if (rowOds[campo.Coluna].ToString() != valorDaStage)
                    {
                        erros += MensagemErroCampo(rowOds, linhaStage, erros, campo, valorDaStage);
                    }
                }
            }
        }

        private static string MensagemErroCampo(DataRow rowOds, ILinhaTabela linhaStage, string erros, Campo campo, string valorDaStage)
        {
            erros += $"Campo: {campo.Coluna} Na Stage '{linhaStage.TabelaReferente}' = '{valorDaStage}' , valor encontrado em '{rowOds.Table.TableName}' : '{rowOds[campo.Coluna].ToString()}'{Environment.NewLine}";
            return erros;
        }

        private decimal ObterSomatorio(string campoBusca, string campoComparacao, string valorComparacao, string tabela, string clausula = "")
        {
            var sql = $"SELECT SUM(TO_DECIMAL({campoBusca})) FROM {Parametros.instanciaDB}.{tabela} WHERE {campoComparacao} = '{valorComparacao}' {clausula}";
            var resultado = DataAccess.ConsultaUnica(sql).ObterValorDecimal();
            logger.Escrever("CONSULTA DE SOMATORIO : "+ sql);
            logger.Escrever($"RESULTADO DA SOMA DE '{campoBusca}' NA TABELA {tabela} : '{resultado}'");
            return resultado;
        }

        private decimal ObterSomatorioOdsComissao(string campoBusca, string campoComparacao, string valorComparacao, string tabela)
        {
            var sql = $"SELECT SUM({campoBusca}) FROM {Parametros.instanciaDB}.{tabela} WHERE {campoComparacao} = '{valorComparacao}'";
            var resultado = DataAccess.ConsultaUnica(sql).ObterValorDecimal();
            logger.Escrever("CONSULTA DE SOMATORIO : " + sql);
            logger.Escrever($"RESULTADO DA SOMA DE '{campoBusca}' NA TABELA {tabela} : '{resultado}'");
            return resultado;
        }
    }
}
