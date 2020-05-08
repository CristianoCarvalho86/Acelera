using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2;
using Acelera.Testes.Validadores.FG05;
using Acelera.Utils;
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

        protected override string NomeFG => "FG05";
        public TestesFG05()
        {
            arquivosOds = new List<Arquivo>();
        }

        protected void SalvarArquivo(bool alterarCdCliente , string nomeProc = "")
        {
            if(alterarCdCliente)
            {
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(linha.Index, "CD_CLIENTE", ObterCDClienteCadastrado());
            }
            base.SalvarArquivo(nomeProc);
        }

        //protected override void SalvarArquivo()
        //{
        //    //foreach (var linha in arquivo.Linhas)
        //    //    arquivo.AlterarLinhaSeExistirCampo(linha.Index, "CD_CLIENTE", ObterCDClienteCadastrado());
        //    base.SalvarArquivo();
        //}


        public void EnviarParaOds(Arquivo arquivo,  bool alterarCdCliente = true, string nomeProc = "")
        {
            if (alterarCdCliente)
            {
                //TODO LEMBRAR DE ALTERAR CD_CLIENTE POR UM DA LISTA
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(linha.Index, "CD_CLIENTE", ObterCDClienteCadastrado());
            }
            if(!string.IsNullOrEmpty(nomeProc))
                SalvarArquivo($"ODS - {nomeProc}");
            arquivosOds.Add(arquivo.Clone());
        }

        public void ValidarODS()
        {
            foreach(var arquivo in arquivosOds)
                validadorODS = new ValidadorODSFG05(logger, arquivo);
        }


        public void IgualarCampos(Arquivo arquivoOrigem, Arquivo arquivoDestino, string[] campos, bool linhaUnicaNaOrigem = false)
        {
            foreach (var linha in arquivoDestino.Linhas)
                foreach (var campo in campos)
                {
                    var index = linhaUnicaNaOrigem ? 0 : linha.Index;
                    AlterarLinha(arquivoDestino, index, campo, arquivoOrigem.ObterLinha(index).ObterCampoDoArquivo(campo).Valor);
                }
        }

        protected void CarregarArquivo(Arquivo arquivo,int qtdLinhas, OperadoraEnum operadora)
        {
            arquivo.Carregar(ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem), 1, 1, qtdLinhas);
            nomeArquivo = arquivo.NomeArquivo;
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

        private string ObterCDClienteCadastrado()
        {
            if (operadora == OperadoraEnum.VIVO)
                return "10876063";
            else if (operadora == OperadoraEnum.LASA)
                return "00952570";
            else if (operadora == OperadoraEnum.SOFTBOX)
                return "00952146";
            else if (operadora == OperadoraEnum.POMPEIA)
                return "00952570";

            throw new Exception("ERRO AO OBTER CD CLIENTE CADASTRADO");

            //var list = new string[] { "abc","teste" };
            //return list[new Random(DateTime.Now.Millisecond).Next(0, list.Length - 1)];
        }

        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0097_NEG");
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0038_NEG");
                    lista.Add("PRC_0044_NEG");
                    lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0212_NEG");
                    lista.Add("PRC_1012_NEG");
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");
                    lista.Add("PRC_0044_NEG");
                    lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0212_NEG");
                    lista.Add("PRC_0213_NEG");
                    lista.Add("PRC_0227_NEG");
                    lista.Add("PRC_0228_NEG");
                    lista.Add("PRC_1012_NEG"); 
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.Comissao:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");
                    lista.Add("PRC_0054_NEG");
                    lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0108_NEG");
                    lista.Add("PRC_0216_NEG");
                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0022_NEG");
                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0220_NEG");
                    break;

                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0022_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0034_NEG");
                    lista.Add("PRC_0038_NEG");
                    lista.Add("PRC_0081_NEG");
                    lista.Add("PRC_0181_NEG");
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
