using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2;
using Acelera.Testes.Validadores.FG05;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG05 : TestesFG02
    {
        protected TabelaParametrosDataSP3 dados { get; set; }

        protected IList<DataRow> linhasInseridasODS { get; set; }

        protected ValidadorODSFG05 validadorODS { get; set; }

        protected IList<Arquivo> arquivosOds { get; set; }
        protected Arquivo arquivoOds { get; set; }

        public TestesFG05()
        {
            
        }

        public void EnviarParaOds(Arquivo arquivo)
        {
            arquivosOds.Add(arquivo.Clone());
        }

        public void ValidarODS()
        {
            validadorODS = new ValidadorODSFG05(logger, arquivoOds);
        }


        public void IgualarCampos(Arquivo arquivoOrigem, Arquivo arquivoDestino, string[] campos)
        {
            foreach (var linha in arquivo.Linhas)
                foreach (var campo in campos)
                    AlterarLinha(arquivoDestino, linha.Index, campo, arquivoDestino.ObterLinha(linha.Index).ObterCampoDoArquivo(campo).Valor);
        }

        protected void CarregarArquivo(Arquivo arquivo,int qtdLinhas, OperadoraEnum operadora)
        {
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(tipoArquivoTeste, operadora, Parametros.pastaOrigem), 1, 1, qtdLinhas);
        }
        protected void CarregarArquivo(Arquivo arquivo, TipoArquivo tipo, int qtdLinhas, OperadoraEnum operadora)
        {
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(tipo, operadora, Parametros.pastaOrigem), 1, 1, qtdLinhas);
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            dados = new TabelaParametrosDataSP3(logger);
        }

        protected void ExecutarEValidar(CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno = "", int qtdErrosNaTabelaDeRetorno = 0)
        {
            ValidarFGsAnteriores();

            //Executar FG02
            ChamarExecucao(tipoArquivoTeste.ObterTarefaFG05Enum().ObterTexto());

            //VALIDAR NA FG01
            ValidarLogProcessamento(true);
            ValidarStages(codigoEsperadoStage);
            if(qtdErrosNaTabelaDeRetorno > 0)
                ValidarTabelaDeRetorno(qtdErrosNaTabelaDeRetorno, erroEsperadoNaTabelaDeRetorno);
            if (erroEsperadoNaTabelaDeRetorno == string.Empty)
                ValidarTabelaDeRetorno();

            ValidarTeste();
        }
        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return base.ObterProceduresASeremExecutadas().Concat(ObterProcedures(tipoArquivoTeste)).ToList();
        }

        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0022_NEG");
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0038_NEG");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");
                    break;

                case TipoArquivo.Comissao:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");

                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0022_NEG");
                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0022_NEG");
                    break;

                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");

                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }


        [TestMethod]
        public void Teste1()
        {
           var a = dados.ObterCdClienteParceiro(true);
        }
    }
}
