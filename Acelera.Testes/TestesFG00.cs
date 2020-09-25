using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Repositorio;
using Acelera.Testes.Validadores;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public abstract class TestesFG00 : TesteFG
    {
        protected override string NomeFG => "FG00";

        public void ValidarControleArquivo(params string[] descricaoErroSeHouver)
        {
            if (!execucaoRegras.ValidarControleArquivo(this.arquivo, descricaoErroSeHouver))
                ExplodeFalha();
            
        }

        public void ValidarTabelaDeRetorno(bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(naoDeveEncontrar, validaQuantidadeErros, arquivo, codigosDeErroEsperados);
        }


        public override void ValidarTabelaDeRetorno(IArquivo _arquivo, bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(naoDeveEncontrar, validaQuantidadeErros, _arquivo, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(false, false, arquivo, codigosDeErroEsperados);
        }
        public void ValidarTabelaDeRetorno(IArquivo arquivo, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(false, false, arquivo, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetornoFG00(bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, IArquivo _arquivo = null, params string[] codigosDeErroEsperados)
        {
            _arquivo = _arquivo == null ? this.arquivo : _arquivo;

            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetorno(_arquivo.NomeArquivo, logger, _arquivo);

                if (validador.ValidarTabela(TabelasEnum.TabelaRetorno, naoDeveEncontrar, validaQuantidadeErros,false, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception ex)
            {
                TratarErro("FG00: Validação da Tabela de Retorno - " + ex.Message);
            }
        }

        public IList<ILinhaTabela> ValidarStages(bool deveEncontrarRegistro, int codigoEsperado = 0,IArquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            return ValidarStages(_arquivo, deveEncontrarRegistro, codigoEsperado);
        }

        protected override IList<string> ObterProceduresASeremExecutadas(IArquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG00, _arquivo.tipoArquivo);
        }

        [Obsolete]
        public void ValidarStages<T>(IArquivo arquivo, TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            ValidarStages(arquivo, deveHaverRegistro, codigoEsperado);
        }

    }
}
