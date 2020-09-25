using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Repositorio;
using Acelera.Testes.Validadores;
using Acelera.Testes.Validadores.FG02;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.RegrasNegocio
{
    public class ExecucaoFgsRegras : BaseRegras
    {
        public ExecucaoFgsRegras(IMyLogger logger) : base(logger)
        { }
        public bool ExecutarEValidarAteFg(IArquivo arquivo, FGs executarAteFG, CodigoStage codigoEsperadoNaStage, string msgTabelaDeRetorno, bool parcAuto = false)
        {
            var sucesso = true;
            IList<FGs> listaFgs = new List<FGs>();

            if (parcAuto)
                listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA, FGs.FG01_2, FGs.FG02, FGs.FG05 };
            else
                listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_AUTO, FGs.FG01_2, FGs.FG02, FGs.FG05 };

            foreach (var fg in listaFgs)
            {
                if (fg == executarAteFG)
                {
                    sucesso = ExecFgs(codigoEsperadoNaStage,msgTabelaDeRetorno,fg,arquivo);
                    break;
                }
                if (!ExecFgs(true, fg, arquivo))
                    return false;
            }
            return sucesso;
        }

        public bool ExecFgs(CodigoStage? codigoStage, string msgTabelaDeRetorno, FGs fg, IArquivo arquivo)
        {
            bool retornoSucesso = true;
            bool deveHaverRegistro = fg == FGs.FG00 && codigoStage == null ? false : true;

            ExecutarEValidar(arquivo, fg, codigoStage, out retornoSucesso, msgTabelaDeRetorno, deveHaverRegistro);
            if (fg == FGs.FG00)
            {
                if (!ValidarControleArquivo(arquivo))
                    retornoSucesso = false;
            }

            if (RepositorioProcedures.FgsQueRodamProcedures.Contains(fg))
                if (!ValidarLogProcessamento(arquivo, true, 1, RepositorioProcedures.ObterProcedures(fg, arquivo.tipoArquivo)))
                    retornoSucesso = false;

            return retornoSucesso;

        }

        public bool ExecFgs(bool sucesso, FGs fg, IArquivo arquivo)
        {
            bool retornoSucesso = true;
            if (sucesso || (int)fg <= (int)FGs.FG01_2)
            {
                ExecutarEValidar(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(true), out retornoSucesso);
                if (fg == FGs.FG00)
                {
                    if (!ValidarControleArquivo(arquivo))
                        retornoSucesso = false;
                }
            }
            if (RepositorioProcedures.FgsQueRodamProcedures.Contains(fg))
                if (!ValidarLogProcessamento(arquivo, true, 1, RepositorioProcedures.ObterProcedures(fg, arquivo.tipoArquivo)))
                    retornoSucesso = false;

            return retornoSucesso;

        }

        public bool ValidarLogProcessamento(IArquivo _arquivo, bool Sucesso, int vezesExecutado, IList<string> proceduresASeremExecutadas)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao || !Parametros.ValidaLogProcessamento)
                return true;

            var proceduresEsperadas = proceduresASeremExecutadas;

            if (_arquivo.Operadora != OperadoraEnum.LASA && _arquivo.Operadora != OperadoraEnum.SOFTBOX)
            {
                proceduresEsperadas = proceduresEsperadas.Where(x => x.ObterParteNumericaDoTexto() < 1000 || x.ObterParteNumericaDoTexto() == 200000).ToList();
            }

            try
            {
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", _arquivo.NomeArquivo);
                var consultas = new ConjuntoConsultas();
                consultas.AdicionarConsulta(consulta);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaLogProcessamento>(consultas, logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");

                var falha = false;
                if (!Assertions.Validar(lista.Count(), proceduresEsperadas.Count * vezesExecutado, "Quantidade de Procedures executadas", logger))
                    falha = true;
                if (!falha && !Assertions.Validar((lista.All(x => x.ObterPorColuna("CD_STATUS").Valor == "S")), true, "Todos os CD_STATUS sao igual a 'S'", logger))
                    falha = true;



                var procedureNaoEncontrada = proceduresEsperadas.Where(x => !lista.Any(z => z.ObterPorColuna("CD_PROCEDURE").Valor.Contains(x))); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Assertions.Validar(procedureNaoEncontrada.Count() > 0, false, $"Existem PROCEDURES NAO ENCONTRADAS : {procedureNaoEncontrada.ToList().ObterListaConcatenada(" ,")}", logger))
                    falha = true;

                var proceduresAMais = lista.Where(x => !proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z))).ToList(); //lista.Where(x => proceduresEsperadas.Any(z => x.ObterPorColuna("CD_PROCEDURE").Valor.Contains(z)) == false);
                if (!Assertions.Validar(proceduresAMais.Count() > 0, false, $"Existem PROCEDURES EXECUTADAS A MAIS : {proceduresAMais.Select(x => x.ObterPorColuna("CD_PROCEDURE").Valor).ObterListaConcatenada(" ,")}", logger))
                    falha = true;

                if (Sucesso && falha || !Sucesso && !falha)
                {
                    return false;
                }
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:LogProcessamento");
            }
            catch (Exception ex)
            {
                logger.Erro("Validação da LogProcessamento");
                return false;
            }
            return true;
        }

        public virtual IList<ILinhaTabela> ExecutarEValidar(IArquivo _arquivo, FGs fG, CodigoStage? codigoEsperado, out bool sucesso, string cdMensagemNaTabelaDeRetorno = "", bool deveHaverRegistro = true)
        {
            DataAccess.ChamarExecucaoHana(_arquivo.tipoArquivo.ObterTarefaDaFG(fG), logger);

            ValidarTabelaDeRetorno(_arquivo, false, true, true, new string[] { cdMensagemNaTabelaDeRetorno });

            return ValidarStages(_arquivo, deveHaverRegistro, out sucesso, (int?)codigoEsperado);
        }

        public IList<ILinhaTabela> ValidarStages(IArquivo _arquivo, bool deveHaverRegistro, out bool sucesso, int? codigoEsperado = 0, bool aoMenosUmCodigoEsperado = false)
        {
            sucesso = true;
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return null;

            IList<ILinhaTabela> linhasEncontradas;
            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                var validador = new ValidadorStages(_arquivo.tipoArquivo.ObterTabelaStageEnum(), _arquivo.NomeArquivo, logger, _arquivo);


                if (validador.ValidarTabela(new string[] { "NM_ARQUIVO_TPA" }, new string[] { _arquivo.NomeArquivo }, "ID_REGISTRO",
                    codigoEsperado, out linhasEncontradas, aoMenosUmCodigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()}");
                else
                    sucesso = false;
            }
            catch (Exception ex)
            {
                sucesso = false;
                logger.Erro($" Validação da Stage : {_arquivo.tipoArquivo.ObterTabelaStageEnum().ObterTexto()} - {ex.Message}");
                throw ex;
            }

            return linhasEncontradas;
        }

        public bool ValidarTabelaDeRetorno(IArquivo _arquivo, bool naoDeveEncontrarOsErrosDefinidos, bool validaQuantidadeErros = false, bool validaTodasAsLinhas = true, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return true;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetorno(_arquivo.NomeArquivo, logger, _arquivo);

                if (validador.ValidarTabela(TabelasEnum.TabelaRetorno, naoDeveEncontrarOsErrosDefinidos, validaQuantidadeErros, validaTodasAsLinhas, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                return false;
            }
        }

        public bool ValidarControleArquivo(IArquivo _arquivo, params string[] descricaoErroSeHouver)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return true;

            try
            {
                AjustarEntradaErros(ref descricaoErroSeHouver);
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", _arquivo.NomeArquivo);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaControleArquivo>(new ConjuntoConsultas(consulta), logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");

                var falha = false;

                if (lista.Count == 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"arquivo nao encontrado na {TabelasEnum.ControleArquivo.ObterTexto()}");
                    return false;
                }

                if (lista.Any(x => x.ObterPorColuna("ST_STATUS").Valor == "E"))
                {
                    logger.EscreverBloco("Foram encontrados erros na tabela ControleArquivo. (ST_STATUS = 'E')");
                    falha = true;
                }

                if (falha && descricaoErroSeHouver.Length == 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "NAO ERAM ESPERADAS FALHAS NO TESTE");
                    return false;
                }
                else if (!falha && descricaoErroSeHouver.Length > 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"AS FALHAS ESPERADAS NAO FORAM ENCONTRADAS : {descricaoErroSeHouver.ToList().ObterListaConcatenada(",")}");
                    return false;
                }

                foreach (var descricao in descricaoErroSeHouver)
                    if (!Assertions.Validar(lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()), true, $"Buscando Erro - {descricao} - em {TabelasEnum.ControleArquivo.ObterTexto()}:", logger))
                        return false;


                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");
            }
            catch (Exception ex)
            {
                logger.Erro("ERRO NA VALIDAÇÃO DA CONTROLE ARQUIVO.");
                return false;
            }
            return true;
        }

        private void AjustarEntradaErros(ref string[] erros)
        {
            if (erros == null || (erros.Length == 1 && (erros.Contains(string.Empty) || erros.Contains(null))))
                erros = new string[] { };

        }

    }
}
