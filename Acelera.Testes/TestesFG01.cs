﻿using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.Validadores.FG01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG01 : TestesFG00
    {
        protected override string NomeFG => "FG01";

        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0041");
                    lista.Add("PRC_0074");
                    lista.Add("PRC_0126");
                    break;
                case TipoArquivo.ParcEmissao:
                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0014");
                    lista.Add("PRC_0015");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_200000");
                    break;
                case TipoArquivo.Comissao:
                case TipoArquivo.LanctoComissao:
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_200000");
                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0062");
                    lista.Add("PRC_0066");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_200000");
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }
            lista.Add("PRC_0110");
            lista.Add("PRC_0001");
            lista.Add("PRC_0005");
            lista.Add("PRC_0006");
            lista.Add("PRC_0007");
            lista.Add("PRC_0092");

            return lista;
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return TestesFG00.ObterProcedures().Concat(ObterProcedures(tipoArquivoTeste)).ToList();
        }

        public void ValidarFG00() 
        {
            if (ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            logger.EscreverBloco("Inicio da Validação da FG00.");
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(tipoArquivoTeste.ObterTarefaFG00Enum().ObterTexto());
            ValidarLogProcessamento(true,1, TestesFG00.ObterProcedures());
            ValidarControleArquivo();
            ValidarTabelaDeRetorno();
            logger.EscreverBloco("Fim da Validação da FG00. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            logger.EscreverBloco("Inicio da FG01.");
            ValidarTeste();
        }

        public override void ValidarStages(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0)
        {
            if (ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try { 
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"FG01 - Tabela:{tabela.ObterTexto()}");
            var validador = new ValidadorStagesFG01(tipoArquivoTeste.ObterTabelaEnum(), nomeArquivo, logger,
                valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

            var linhasEncontradas = new List<ILinhaTabela>();
            if (validador.ValidarTabelaFG01(deveHaverRegistro, codigoEsperado))
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"FG01 - Tabela:{tabela.ObterTexto()}");
            else
                ExplodeFalha();
            }
            catch (Exception)
            {
                sucessoDoTeste = false;
            }
        }
        public void ValidarStages(CodigoStage codigo)
        {
            ValidarStages(tipoArquivoTeste.ObterTabelaEnum(),true,(int)codigo);
        }

        public override void ValidarTabelaDeRetorno(bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            base.ValidarTabelaDeRetorno(validaQuantidadeErros, codigosDeErroEsperados);
        }
    }
}
