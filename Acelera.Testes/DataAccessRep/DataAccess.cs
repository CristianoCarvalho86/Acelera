using Acelera.Data;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Logger;
using Acelera.Testes.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.DataAccessRep
{
    public static class DataAccess
    {
        public static IList<T> ChamarConsultaAoBanco<T>(Consulta consulta, MyLogger logger) where T : ILinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                var c = tabela.ObterQuery(consulta).Replace("/*R*/","");
                logger.Escrever("Consulta Realizada :" + c);
                var resultado = DBHelper.Instance.GetData(c);

                logger.LogRetornoQuery(resultado,c);

                tabela.ObterRetornoQuery(resultado);

                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
                throw ex;
            }
            return tabela.Linhas;
        }

        [Obsolete]
        public static IList<T> ChamarConsultaAoBancoViaCMD<T>(Consulta consulta, MyLogger logger) where T : LinhaTabela, new()
        {
            var tabela = new Tabela<T>();
            try
            {
                logger.InicioOperacao(OperacaoEnum.ConsultaBanco,tabela.ObterNomeTabela());
                var integracao = new IntegracaoCMD();
                integracao.AbrirCMD();

                integracao.ExecutarQuery(tabela.ObterQueryParaCMD(consulta));
                var resultado = integracao.ObterTextoCMD();
                tabela.ObterRetornoQueryCMD(resultado);

                logger.LogRetornoCMD(resultado);
                logger.SucessoDaOperacao(OperacaoEnum.ConsultaBanco, tabela.ObterNomeTabela());

                integracao.FecharCMD();

            }
            catch (Exception ex)
            {
                logger.Erro(ex);
            }
            return tabela.Linhas;
        }

    }
}
