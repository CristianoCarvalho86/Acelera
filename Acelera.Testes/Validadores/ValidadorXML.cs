using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
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
using System.Xml;

namespace Acelera.Testes.Validadores
{
    public class ValidadorXML
    {
        protected IMyLogger logger;

        public ValidadorXML(IMyLogger logger)
        {
            this.logger = logger;
        }

        public bool Validar(XmlElement noh, TabelasOIMEnum tabelaOIM)
        {
            var campoValor = "";
            foreach (XmlNode child in noh.ChildNodes)
                campoValor += $"{child.Name} = '{child.InnerText}'";
            var retorno = DataAccess.ConsultaUnica($"SELECT '1' FROM {tabelaOIM.ObterTexto()} where {campoValor} ", logger, false);
            return string.IsNullOrEmpty(retorno);
        }

        public bool ValidarInclusaoNasTabelas(ILinhaTabela linhaDaStage, string cdStatusEsperado, bool ehParcAuto,out string idArquivo)
        {
            logger.AbrirBloco("VALIDANDO INCLUSAO NAS TABELAS.");
            var listaDeTabelas = EnumUtils.ObterListaComTodos<TabelasOIMEnum>();
            var where = "";
            var erros = "";
            var campoConsulta = "'1'";
            idArquivo = "";
            var retorno = "";
            if (!ehParcAuto)
                listaDeTabelas.Remove(TabelasOIMEnum.OIM_ITAUTO01);

            foreach (var tabela in listaDeTabelas)
            {
                if (tabela == TabelasOIMEnum.OIM_APL01)
                    campoConsulta = "id_arquivo";

                where = ObterWhereCamposChaves(linhaDaStage, tabela.ObterCamposChaves());
                retorno = DataAccess.ConsultaUnica($"SELECT {campoConsulta} FROM {Parametros.instanciaDB}.{tabela.ObterTexto()} where {where} ", $"VALIDACAO REGISTRO INSERIDO {tabela.ObterTexto()}",DBEnum.Hana, logger,false);
                if (string.IsNullOrEmpty(retorno))
                    erros += $"NENHUM REGISTRO ENCONTRADO NA TABELA: {tabela.ObterTexto()} {Environment.NewLine}";
                else
                    logger.Escrever("REGISTRO ENCONTRADO NA TABELA : " +tabela.ObterTexto());
                
                if (tabela == TabelasOIMEnum.OIM_APL01)
                    idArquivo = retorno;
            }

            retorno = DataAccess.ConsultaUnica($"SELECT CD_STATUS FROM {Parametros.instanciaDB}.TAB_OIM_XML_CONTROLE_8003 where id_arquivo = '{idArquivo}' ", $"VALIDACAO REGISTRO INSERIDO TAB_OIM_XML_CONTROLE_8003", DBEnum.Hana, logger, false);
            if(string.IsNullOrEmpty(retorno))
            {
                logger.Erro($"ID_ARQUIVO DA TABELA TAB_OIM_APL01_5000 : '{idArquivo}', NAO ENCONTRADO NA TABELA TAB_OIM_XML_CONTROLE_8003");
                return false;
            }
            if (retorno != cdStatusEsperado)
            {
                logger.Erro($"CD_STATUS DA TABELA TAB_OIM_XML_CONTROLE_8003 NAO ERA O ESPERADO {Environment.NewLine} OBTIDO :{retorno} ; ESPERADO :{cdStatusEsperado}");
                return false;
            }

            logger.Escrever($"CD_STATUS DA TABELA TAB_OIM_XML_CONTROLE_8003 ENCONTRADO COMO O ESPERADO {Environment.NewLine} OBTIDO :{retorno} ; ESPERADO :{cdStatusEsperado}");
            logger.Escrever($"ID_ARQUIVO DA TABELA TAB_OIM_APL01_5000 : '{idArquivo}', ENCONTRADO NA TABELA TAB_OIM_XML_CONTROLE_8003 COM SUCESSO.");

            logger.FecharBloco();
            if(string.IsNullOrEmpty(erros))
            {
                logger.Erro(erros);
                return false;
            }
            return true;
        }

        public bool ValidarXML(XmlDocument documentoXML, TabelasOIMEnum tabelaOIM)
        {
            var nomeTag = tabelaOIM.ObterTagNoXML();
            var camposChaves = tabelaOIM.ObterCamposChaves();
            logger.AbrirBloco("INICIAR VALIDACAO DO XML PARA " + nomeTag);
            var nodes = documentoXML.GetElementsByTagName(nomeTag);
            logger.Escrever($"{nodes.Count} Nós encontrados com a tag {nomeTag}.");
            DataTable tabelaResultado;
            var where = "";
            foreach (XmlNode node in nodes)
            {
                where = ObterWhereCamposChaves(node, camposChaves);
                logger.Escrever("Iniciando validacao com campos chaves :" + camposChaves);
                tabelaResultado = DataAccess.Consulta($"SELECT * FROM {tabelaOIM.ObterTexto()} where {where} ", $"VALIDACAO {nomeTag}", DBEnum.Hana, logger, false);
                if (!ValidarTabela(tabelaResultado, node))
                    return false;
            }
            logger.Escrever("");
            return true;
        }

        private bool ValidarTabela(DataTable tabela, XmlNode node)
        {
            if (tabela.Rows.Count == 0)
            {
                logger.Erro("NENHUMA LINHA ENCONTRADA PARA OS DADOS DESSE NÓ NO BANCO");
                return false;
            }
            if (tabela.Rows.Count > 1)
            {
                logger.Erro("MAIS DE UMA LINHA ENCONTRADA NO BANCO PARA OS DADOS DESSE NÓ NO XML");
                return false;
            }
            var erros = "";
            foreach (DataColumn column in tabela.Columns)
            {
                if (tabela.Rows[0][column].ToString() != node[column.ColumnName].InnerText)
                    erros += $"ERRO EM {column.ColumnName}, VALOR DO XML : {node[column.ColumnName].InnerText}, VALOR DO BANCO : {tabela.Rows[0][column].ToString()} {Environment.NewLine}";
            }
            if(!string.IsNullOrEmpty(erros))
            {
                logger.Erro(erros);
                return false;
            }
            return true;
        }

        private string ObterWhereCamposChaves(XmlNode node, string[] camposChaves)
        {
            var where = "";
            foreach (var campo in camposChaves)
            {
                where += $"{campo} = '{node[campo].InnerText}' AND";
            }
            return where.Substring(0, where.Length - 3);
        }

        private string ObterWhereCamposChaves(ILinhaTabela linha, string[] camposChaves)
        {
            var where = "";
            var campoAjustado = "";
            foreach (var campo in camposChaves)
            {
                if (campo == "vl_premio")
                    campoAjustado = "VL_PREMIO_LIQUIDO";
                where += $"{campoAjustado} = '{linha.ObterPorColuna(campoAjustado.ToUpper()).ValorFormatado}' AND";
            }
            return where.Substring(0, where.Length - 3);
        }
    }
}
