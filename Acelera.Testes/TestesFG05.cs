using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.DataAccessRep.ODS;
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
        private bool alterarCobertura;

        protected TabelaParametrosDataSP3 dados { get; set; }

        protected IList<DataRow> linhasInseridasODS { get; set; }

        protected ValidadorODSFG05 validadorODS { get; set; }

        protected IList<Arquivo> arquivosOds { get; set; }

        protected override string NomeFG => "FG05";
        public TestesFG05()
        {
            arquivosOds = new List<Arquivo>();
            alterarCobertura = true;
        }

        protected decimal ObterValorPremioTotalBruto(decimal valorIS, Cobertura cobertura)
        {
            return valorIS * cobertura.VL_PERC_DISTRIBUICAO_decimal * cobertura.VL_PERC_TAXA_SEGURO_decimal;
        }

        protected decimal ObterValorPremioTotalLiquido(decimal valorIS, Cobertura cobertura)
        {
            return ObterValorPremioTotalBruto(valorIS, cobertura) *
                (((1M + (cobertura.ValorPercentualAlicotaIofDecimal * 100)) / 100) * (cobertura.VL_PERC_DISTRIBUICAO_decimal * 100));
        }

        protected decimal ObterValorCalculadoIOF(decimal valorIS, Cobertura cobertura)
        {
            return (ObterValorPremioTotalLiquido(valorIS, cobertura) * (cobertura.ValorPercentualAlicotaIofDecimal * 100) / 100) *
                    (cobertura.VL_PERC_DISTRIBUICAO_decimal * 100);
        }

        protected override void SalvarArquivo(bool alterarCdCliente, string nomeProc = "")
        {
            if (alterarCdCliente)
            {
                var i = 0;
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", ObterCDClienteCadastrado());
            }


            base.SalvarArquivo(nomeProc);
        }

        public override void FinalizarAlteracaoArquivo()
        {
            Parametrizacoes();
            base.FinalizarAlteracaoArquivo();
        }

        protected void AlterarCobertura(bool alterar)
        {
            alterarCobertura = alterar;
        }

        private void Parametrizacoes()
        {
            if (alterarCobertura)
                for (int i = 0; i < arquivo.Linhas.Count; i++)
                {
                    var cobertura = dados.ObterCoberturaSimples(ObterValorHeader("CD_TPA"));
                    AlterarLinha(i, "CD_COBERTURA", cobertura.CdCobertura);
                    AlterarLinha(i, "CD_RAMO", cobertura.CdRamo);
                    AlterarLinha(i, "CD_PRODUTO", cobertura.CdProduto);
                }
        }

        //protected override void SalvarArquivo()
        //{
        //    //foreach (var linha in arquivo.Linhas)
        //    //    arquivo.AlterarLinhaSeExistirCampo(linha.Index, "CD_CLIENTE", ObterCDClienteCadastrado());
        //    base.SalvarArquivo();
        //}


        public void EnviarParaOds(Arquivo arquivo, bool alterarCdCliente = true, string nomeProc = "")
        {
            if (alterarCdCliente && operadora != OperadoraEnum.SGS)
            {
                //TODO LEMBRAR DE ALTERAR CD_CLIENTE POR UM DA LISTA
                int i = 0;
                foreach (var linha in arquivo.Linhas)
                    arquivo.AlterarLinhaSeExistirCampo(i++, "CD_CLIENTE", ObterCDClienteCadastrado());
            }

            if (!string.IsNullOrEmpty(nomeProc))
                SalvarArquivo();

            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());

            var linhas = ValidarStages(CodigoStage.AprovadoNaFG01);

            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                foreach (var linha in linhas)
                    ODSInsertParcAuto.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);
            else if (arquivo.tipoArquivo == TipoArquivo.Cliente)
                foreach (var linha in linhas)
                    ODSInsertClienteData.Insert(linha.ObterPorColuna("ID_REGISTRO").ValorFormatado, logger);

        }

        public override void ValidarODS()
        {
            throw new NotImplementedException();
            foreach (var arquivo in arquivosOds)
                validadorODS = new ValidadorODSFG05(logger, arquivo);
        }

        //protected override void SalvarArquivo()
        //{
        //    //foreach (var linha in arquivo.Linhas)
        //    //    arquivo.AlterarLinhaSeExistirCampo(linha.Index, "CD_CLIENTE", ObterCDClienteCadastrado());
        //    base.SalvarArquivo();
        //}


        public void IgualarCampos(Arquivo arquivoOrigem, Arquivo arquivoDestino, string[] campos, bool linhaUnicaNaOrigem = false)
        {
            logger.AbrirBloco("IGUALANDO CAMPOS DOS ARQUIVOS:");
            var nomeCampo = string.Empty;
            foreach (var linha in arquivoDestino.Linhas)
                foreach (var campo in campos)
                {
                    nomeCampo = campo;
                    if (campo == "NR_SEQ_EMISSAO")
                        nomeCampo = "NR_SEQUENCIAL_EMISSAO";

                    var index = linhaUnicaNaOrigem ? 0 : linha.Index;
                    AlterarLinha(arquivoDestino, index, nomeCampo, arquivoOrigem.ObterLinha(index).ObterCampoDoArquivo(nomeCampo).ValorFormatado);
                }
        }

        protected void CarregarArquivo(Arquivo arquivo, int qtdLinhas, OperadoraEnum operadora)
        {
            valoresAlteradosBody = new AlteracoesArquivo();
            valoresAlteradosFooter = new AlteracoesArquivo();
            valoresAlteradosHeader = new AlteracoesArquivo();

            logger.AbrirBloco($"INICIANDO CARREGAMENTO DE ARQUIVO DO TIPO: {arquivo.tipoArquivo.ObterTexto()} - OPERACAO: {operadora.ObterTexto()}");
            var arquivoGerado = ArquivoOrigem.ObterArquivoAleatorio(arquivo.tipoArquivo, operadora, Parametros.pastaOrigem);
            arquivo.Carregar(arquivoGerado, 1, 1, qtdLinhas);
            logger.Escrever("ARQUIVO GERADO " + arquivo.NomeArquivo);
            nomeArquivo = arquivo.NomeArquivo;

            logger.FecharBloco();
        }
        protected void CarregarArquivo(Arquivo arquivo, TipoArquivo tipo, int qtdLinhas, OperadoraEnum operadora)
        {
            logger.AbrirBloco($"INICIANDO CARREGAMENTO DE ARQUIVO DO TIPO: {arquivo.tipoArquivo.ObterTexto()} - OPERACAO: {operadora.ObterTexto()}");
            var arquivoGerado = ArquivoOrigem.ObterArquivoAleatorio(tipo, operadora, Parametros.pastaOrigem);
            arquivo.Carregar(arquivoGerado, 1, 1, qtdLinhas);
            nomeArquivo = arquivo.NomeArquivo;
            logger.Escrever("ARQUIVO GERADO " + arquivo.NomeArquivo);
            logger.FecharBloco();
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
            if (qtdErrosNaTabelaDeRetorno > 0)
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
                    //lista.Add("PRC_0097_NEG");
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0022_NEG");
                    //lista.Add("PRC_0027_NEG");
                    //lista.Add("PRC_0038_NEG");
                    //lista.Add("PRC_0044_NEG");
                    //lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0212_NEG");
                    lista.Add("PRC_1012_NEG");
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0022_NEG");
                    //lista.Add("PRC_0027_NEG");
                    //lista.Add("PRC_0034_NEG");
                    //lista.Add("PRC_0038_NEG");
                    //lista.Add("PRC_0044_NEG");
                    //lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0212_NEG");
                    //lista.Add("PRC_0213_NEG");
                    //lista.Add("PRC_0227_NEG");
                    //lista.Add("PRC_0228_NEG");
                    lista.Add("PRC_1012_NEG");
                    lista.Add("PRC_1014_NEG");
                    lista.Add("PRC_1015_NEG");
                    break;

                case TipoArquivo.Comissao:
                    lista.Add("PRC_0022_NEG");
                    //lista.Add("PRC_0034_NEG");
                    //lista.Add("PRC_0038_NEG");
                    //lista.Add("PRC_0054_NEG");
                    //lista.Add("PRC_0097_NEG");
                    lista.Add("PRC_0108_NEG");
                    lista.Add("PRC_0216_NEG");
                    break;

                case TipoArquivo.LanctoComissao:
                    //lista.Add("PRC_0022_NEG");
                    break;
                case TipoArquivo.OCRCobranca:
                    //lista.Add("PRC_0022_NEG");
                    //lista.Add("PRC_0097_NEG");
                    //lista.Add("PRC_0220_NEG");
                    break;

                case TipoArquivo.Sinistro:
                    //lista.Add("PRC_0022_NEG");
                    //lista.Add("PRC_0027_NEG");
                    //lista.Add("PRC_0034_NEG");
                    //lista.Add("PRC_0038_NEG");
                    //lista.Add("PRC_0081_NEG");
                    //lista.Add("PRC_0181_NEG");
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }

        public override void ValidarFGsAnteriores()
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            base.ValidarFGsAnteriores();

            logger.EscreverBloco("Inicio da Validação da FG02.");
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(tipoArquivoTeste.ObterTarefaFG02Enum().ObterTexto());
            ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas());
            ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
            ValidarTabelaDeRetornoFG01();
            logger.EscreverBloco("Fim da Validação da FG02. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();
            logger.EscreverBloco("Fim da FG02.");
        }

        public void AjustaValoresParaFG02()
        {
            if (arquivo.tipoArquivo == TipoArquivo.ParcEmissao)
            {
                arquivo.AlterarLinha(0, "DT_EMISSAO", "20200101");
                arquivo.AlterarLinha(0, "DT_EMISSAO_APOLICE", "20190101");
            }

        }


    }
}
