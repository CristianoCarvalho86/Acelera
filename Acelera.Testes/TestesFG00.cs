using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Entidades.TabelaRetorno;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Logger;
using Acelera.Testes.Validadores.FG00;
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
        public void ValidarControleArquivo(params string[] descricaoErroSeHouver)
        {
            AjustarEntradaErros(ref descricaoErroSeHouver);
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            var lista = DataAccess.ChamarConsultaAoBanco<LinhaControleArquivo>(consulta, logger);

            logger.InicioOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");

            var falha = false;

            if (lista.Count == 0)
            {
                logger.ErroNaOperacao(OperacaoEnum.ValidarResultado, $"Arquivo nao encontrado na {TabelasEnum.ControleArquivo.ObterTexto()}");
                ExplodeFalha();
            }

            if (!Validar((lista.All(x => x.ObterPorColuna("ST_STATUS").Valor == "S")),
                descricaoErroSeHouver.Length > 0 ? true : false,
                "O Campo ST_STATUS dos registros é igual a 'S'"))
                falha = true;

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
                if (!Validar(lista.Any(x => x.ObterPorColuna("DS_ERRO").Valor.ToUpper() == descricao.ToUpper()), true, $"Buscando Erro - {descricao} - em {TabelasEnum.ControleArquivo.ObterTexto()}:"))
                    ExplodeFalha();


            logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, "Tabela:ControleArquivo");
        }

        public virtual void ValidarStages(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0)
        {
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            var validador = new ValidadorStagesFG00(tipoArquivoTeste.ObterTabelaEnum(), nomeArquivo, logger,
                valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

            var linhasEncontradas = new List<ILinhaTabela>();
            if (validador.ValidarTabelaFG00(deveHaverRegistro, out linhasEncontradas, codigoEsperado))
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            else
                ExplodeFalha();
        }

        public override void ValidarTabelaDeRetorno(params string[] codigosDeErroEsperados)
        {
            AjustarEntradaErros(ref codigosDeErroEsperados);
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            var validador = new ValidadorTabelaRetornoFG00(tipoArquivoTeste.ObterTabelaEnum(),nomeArquivo,logger,
                valoresAlteradosBody,valoresAlteradosHeader,valoresAlteradosFooter);
            
            if (validador.ValidarTabela(codigosDeErroEsperados.Length, codigosDeErroEsperados))
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
            else
                ExplodeFalha();
        }


        public void ValidarStages<T>(bool deveEncontrarRegistro ,int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            ValidarStages<T>(tipoArquivoTeste.ObterTabelaEnum(), deveEncontrarRegistro, codigoEsperado);
        }
        public void ValidarStages<T>(int codigoEsperado) where T : LinhaTabela, new()
        {
            ValidarStages<T>(tipoArquivoTeste.ObterTabelaEnum(), true, codigoEsperado);
        }
        public void ValidarStages<T>(CodigoStage codigo) where T : LinhaTabela, new()
        {
            ValidarStages<T>((int)codigo);
        }
        public void ValidarStages(bool deveEncontrarRegistro, int codigoEsperado = 0)
        {
            ValidarStages(tipoArquivoTeste.ObterTabelaEnum(), deveEncontrarRegistro, codigoEsperado);
        }

        [Obsolete]
        public void ValidarStages<T>(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0) where T : LinhaTabela, new()
        {
            ValidarStages(tabela, deveHaverRegistro, codigoEsperado);
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
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
            lista.Add("PRC_0401_IMP");
            return lista;
        }
    }
}
