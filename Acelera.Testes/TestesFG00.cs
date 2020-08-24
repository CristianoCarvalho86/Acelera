﻿using Acelera.Domain.Entidades;
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
using Acelera.Testes.Validadores;
using Acelera.Testes.Validadores.FG02;
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
            ValidarControleArquivo(this.arquivo, descricaoErroSeHouver);
        }
        public void ValidarControleArquivo(Arquivo _arquivo, params string[] descricaoErroSeHouver)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref descricaoErroSeHouver);
                var consulta = new Consulta();
                consulta.AdicionarConsulta("NM__arquivo_TPA", _arquivo.NomeArquivo);
                var lista = DataAccess.ChamarConsultaAoBanco<LinhaControleArquivo>(new ConjuntoConsultas(consulta), logger);

                logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:Controle_arquivo");

                var falha = false;

                if (lista.Count == 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"_arquivo nao encontrado na {TabelasEnum.ControleArquivo.ObterTexto()}");
                    ExplodeFalha();
                }

                if (lista.Any(x => x.ObterPorColuna("ST_STATUS").Valor == "E"))
                {
                    logger.EscreverBloco("Foram encontrados erros na tabela Controle_arquivo. (ST_STATUS = 'E')");
                    falha = true;
                }

                if (falha && descricaoErroSeHouver.Length == 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, "NAO ERAM ESPERADAS FALHAS NO TESTE");
                    ExplodeFalha();
                }
                else if (!falha && descricaoErroSeHouver.Length > 0)
                {
                    logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"AS FALHAS ESPERADAS NAO FORAM ENCONTRADAS : {descricaoErroSeHouver.ToList().ObterListaConcatenada(",")}");
                    ExplodeFalha();
                }

                foreach (var descricao in descricaoErroSeHouver)
                    if (!Validar(lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()), true, $"Buscando Erro - {descricao} - em {TabelasEnum.Controle_arquivo.ObterTexto()}:"))
                        ExplodeFalha();


                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:Controle_arquivo");
            }
            catch (Exception ex)
            {
                TratarErro($"FG00: Validação da Controle_arquivo");
            }
        }

        public void ValidarTabelaDeRetorno(bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(naoDeveEncontrar, validaQuantidadeErros, arquivo, codigosDeErroEsperados);
        }

        public override void ValidarTabelaDeRetorno(Arquivo arquivo, bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(naoDeveEncontrar, validaQuantidadeErros, arquivo, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(false, false, arquivo, codigosDeErroEsperados);
        }
        public void ValidarTabelaDeRetorno(Arquivo arquivo, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG00(false, false, arquivo, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetornoFG00(bool naoDeveEncontrar = false ,bool validaQuantidadeErros = false, Arquivo arquivo = null, params string[] codigosDeErroEsperados)
        {
            arquivo = arquivo == null ? this.arquivo : arquivo;

            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try { 
            AjustarEntradaErros(ref codigosDeErroEsperados);
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            var validador = new ValidadorTabelaRetorno(arquivo.tipoArquivo.ObterTabelaStageEnum(),arquivo.NomeArquivo,logger,
                valoresAlteradosBody,valoresAlteradosHeader,valoresAlteradosFooter);
            
            if (validador.ValidarTabela(TabelasEnum.TabelaRetorno, naoDeveEncontrar, validaQuantidadeErros,codigosDeErroEsperados))
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            else
                ExplodeFalha();
            }
            catch (Exception ex)
            {
                TratarErro("FG00: Validação da Tabela de Retorno - " + ex.Message);
            }
        }

        public void ValidarStages(bool deveEncontrarRegistro, int codigoEsperado = 0, Arquivo arquivo = null)
        {
            arquivo = arquivo == null ? this.arquivo : arquivo;
            ValidarStages(arquivo, deveEncontrarRegistro, codigoEsperado);
        }

        [Obsolete]
        public void ValidarStages<T>(Arquivo arquivo, TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            ValidarStages(arquivo, deveHaverRegistro, codigoEsperado);
        }

        public static IList<string> ObterProceduresFG00()
        {
            var lista = new List<string>();
            lista.Add("PRC_0093_IMP");
            lista.Add("PRC_0094_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0101_IMP");
            lista.Add("PRC_0002_IMP");
            lista.Add("PRC_0091_IMP");
            lista.Add("PRC_0400_IMP");
            lista.Add("PRC_0003_IMP");
            lista.Add("PRC_0004_IMP");
            lista.Add("PRC_0100_IMP");
            lista.Add("PRC_0095_IMP");
            lista.Add("PRC_0092_IMP");
            lista.Add("PRC_0401_IMP");
            return lista;
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return ObterProceduresFG00();
        }
    }
}
