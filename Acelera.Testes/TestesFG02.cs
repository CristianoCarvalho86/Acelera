using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.Validadores.FG02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2
{
    public class TestesFG02 : TestesFG01
    {
        public TabelaParametrosData dados { get; private set; }

        protected override string NomeFG => "FG02";
        public TestesFG02():base()
        {
            
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            dados = new TabelaParametrosData(logger);
        }

        public override void ValidarFGsAnteriores()
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            base.ValidarFGsAnteriores();

            logger.EscreverBloco("Inicio da Validação da FG01.");
            //PROCESSAR O ARQUIVO CRIADO
            base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG01Enum().ObterTexto());
            base.ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas());
            base.ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetornoFG01();
            logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();
            logger.EscreverBloco("Inicio da FG02.");
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return base.ObterProceduresASeremExecutadas().Concat(ObterProcedures(tipoArquivoTeste)).ToList();
        }

        public override void ValidarTabelaDeRetorno(bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG01(validaQuantidadeErros, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetorno(int quantidadeErro, string codigoDeErroEsperado)
        {
            if (string.IsNullOrEmpty(codigoDeErroEsperado) || quantidadeErro == 0)
                throw new Exception("DEVE EXISTIR UM CODIGO DE ERRO A SER PASSADO E QUANTIDADE");

            var erros = new string[quantidadeErro];
            for (int i = 0; i < quantidadeErro; i++)
            {
                erros[i] = codigoDeErroEsperado;
            }

            ValidarTabelaDeRetornoFG01(true, erros);
        }

        public override void ValidarStages(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"FG02 - Tabela:{tabela.ObterTexto()}");
                var validador = new ValidadorStagesFG02(tipoArquivoTeste.ObterTabelaEnum(), nomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

                var linhasEncontradas = new List<ILinhaTabela>();
                if (validador.ValidarTabelaFG02(deveHaverRegistro, codigoEsperado, AoMenosUmComCodigoEsperado))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"FG02 - Tabela:{tabela.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($"FG02: Validação da Stage : {tabela.ObterTexto()}");
            }
        }

        protected string CarregarIdtransacao(LinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }

        #region Procedures
        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_1039_NEG");
                    lista.Add("PRC_1040_NEG");
                    lista.Add("PRC_1041_NEG");

                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0011_NEG");
                    lista.Add("PRC_0013_NEG");
                    lista.Add("PRC_0016_NEG");
                    lista.Add("PRC_0018_NEG");
                    lista.Add("PRC_0019_NEG");
                    lista.Add("PRC_0020_NEG");
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_0023_NEG");
                    lista.Add("PRC_0024_NEG");
                    lista.Add("PRC_0025_NEG");
                    lista.Add("PRC_0026_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0028_NEG");
                    lista.Add("PRC_0032_NEG");
                    lista.Add("PRC_0107_NEG");
                    lista.Add("PRC_0120_NEG");
                    lista.Add("PRC_0122_NEG");
                    lista.Add("PRC_0123_NEG");
                    lista.Add("PRC_0127_NEG");
                    lista.Add("PRC_0155_NEG");
                    lista.Add("PRC_0162_NEG");
                    lista.Add("PRC_0191_NEG");
                    lista.Add("PRC_0215_NEG");
                    lista.Add("PRC_0228_NEG");
                    lista.Add("PRC_1002_NEG");
                    lista.Add("PRC_1003_NEG");
                    lista.Add("PRC_1024_NEG");
                    lista.Add("PRC_1046_NEG");
                    lista.Add("PRC_1048_NEG");
                    lista.Add("PRC_1056_NEG");
                    lista.Add("PRC_1065_NEG");
                    lista.Add("PRC_1067_NEG");
                    lista.Add("PRC_1083_NEG");
                    lista.Add("PRC_1091_NEG");
                    lista.Add("PRC_1092_NEG");
                    lista.Add("PRC_1182_NEG");
                    lista.Add("PRC_1183_NEG");
                    lista.Add("PRC_1184_NEG");

                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0011_NEG");
                    lista.Add("PRC_0013_NEG");
                    lista.Add("PRC_0016_NEG");
                    lista.Add("PRC_0018_NEG");
                    lista.Add("PRC_0019_NEG");
                    lista.Add("PRC_0020_NEG");
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_0023_NEG");
                    lista.Add("PRC_0024_NEG");
                    lista.Add("PRC_0025_NEG");
                    lista.Add("PRC_0026_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0028_NEG");
                    lista.Add("PRC_0032_NEG");
                    lista.Add("PRC_0107_NEG");
                    lista.Add("PRC_0120_NEG");
                    lista.Add("PRC_0122_NEG");
                    lista.Add("PRC_0123_NEG");
                    lista.Add("PRC_0127_NEG");
                    lista.Add("PRC_0155_NEG");
                    lista.Add("PRC_0162_NEG");
                    lista.Add("PRC_0191_NEG");
                    lista.Add("PRC_0215_NEG");
                    lista.Add("PRC_0223_NEG");
                    lista.Add("PRC_0228_NEG");
                    lista.Add("PRC_1002_NEG");
                    lista.Add("PRC_1003_NEG");
                    lista.Add("PRC_1024_NEG");
                    lista.Add("PRC_1046_NEG");
                    lista.Add("PRC_1048_NEG");
                    lista.Add("PRC_1056_NEG");
                    lista.Add("PRC_1065_NEG");
                    lista.Add("PRC_1067_NEG");
                    lista.Add("PRC_1083_NEG");
                    lista.Add("PRC_1091_NEG");
                    lista.Add("PRC_1092_NEG");
                    lista.Add("PRC_1182_NEG");
                    lista.Add("PRC_1183_NEG");
                    lista.Add("PRC_1184_NEG");
                    break;
                case TipoArquivo.Comissao:
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_0024_NEG");
                    lista.Add("PRC_0025_NEG");
                    lista.Add("PRC_0052_NEG");
                    lista.Add("PRC_0218_NEG");
                    lista.Add("PRC_1048_NEG");
                    lista.Add("PRC_1049_NEG");
                    lista.Add("PRC_1111_NEG");
                    break;

                case TipoArquivo.LanctoComissao:
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_0026_NEG");
                    lista.Add("PRC_0124_NEG");
                    lista.Add("PRC_1190_NEG");
                    lista.Add("PRC_1191_NEG");
                    lista.Add("PRC_1193_NEG");
                    break;
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_1167_NEG");
                    lista.Add("PRC_0124_NEG");

                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0033_NEG");
                    lista.Add("PRC_0035_NEG");
                    lista.Add("PRC_0023_NEG");
                    lista.Add("PRC_0024_NEG");
                    lista.Add("PRC_0025_NEG");
                    lista.Add("PRC_0026_NEG");
                    lista.Add("PRC_0027_NEG");
                    lista.Add("PRC_0070_NEG");
                    lista.Add("PRC_0080_NEG");
                    lista.Add("PRC_0081_NEG");
                    lista.Add("PRC_0082_NEG");
                    lista.Add("PRC_0085_NEG");
                    lista.Add("PRC_0086_NEG");
                    lista.Add("PRC_0087_NEG");
                    lista.Add("PRC_0088_NEG");
                    lista.Add("PRC_0107_NEG");
                    lista.Add("PRC_0111_NEG");
                    lista.Add("PRC_0119_NEG");
                    lista.Add("PRC_0120_NEG");
                    lista.Add("PRC_0128_NEG");
                    lista.Add("PRC_0130_NEG");
                    lista.Add("PRC_0131_NEG");
                    lista.Add("PRC_0132_NEG");
                    lista.Add("PRC_0164_NEG");
                    lista.Add("PRC_0176_NEG");
                    lista.Add("PRC_0177_NEG");
                    lista.Add("PRC_0178_NEG");
                    lista.Add("PRC_0181_NEG");
                    lista.Add("PRC_0182_NEG");
                    lista.Add("PRC_0184_NEG");
                    lista.Add("PRC_0185_NEG");

                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }
        #endregion

    }
}
