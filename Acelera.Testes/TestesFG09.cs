using Acelera.Data;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG09 : TestesFG05
    {
        protected override string NomeFG => "FG09";
        protected override void ExecutarEValidar(CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno = "", int qtdErrosNaTabelaDeRetorno = 0)
        {
            ValidarFGsAnteriores();

            //Executar FG09
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG09Enum().ObterTexto());

            //VALIDAR NA FG09
            Validar(codigoEsperadoStage, erroEsperadoNaTabelaDeRetorno, qtdErrosNaTabelaDeRetorno);
        }

        protected override void ExecutarEValidarDesconsiderandoErro(CodigoStage codigoEsperadoStage, string erroNaoEsperadoNaTabelaDeRetorno)
        {
            ValidarFGsAnteriores();

            //Executar FG09
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG09Enum().ObterTexto());

            ValidarDesconsiderandoErro(codigoEsperadoStage, erroNaoEsperadoNaTabelaDeRetorno);
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return base.ObterProceduresASeremExecutadas().Where(x => !ObterProceduresFG05(arquivo.tipoArquivo).Contains(x)).Concat(ObterProceduresFG09(arquivo.tipoArquivo)).ToList();
        }

        protected Arquivo CriarEmissaoODS<T>(OperadoraEnum operadora, bool alterarVersaoHeader = false,int qtdParcelas = 1, string nrParcela = ""
            ,bool enviarParaOds = true, string cdCoberturaDoCorretor = "") where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, 1, operadora);
            CriarNovoContrato(0);
            AlterarLinha(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(operadora));

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            
            AlterarLinha(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(operadora));
 
            if(!string.IsNullOrEmpty(nrParcela))
                AlterarLinha(0, "NR_PARCELA", nrParcela);

            if (operadora != OperadoraEnum.VIVO)
            {
                AlterarLinha(0, "CD_SEGURADORA", "5908");
                if(string.IsNullOrEmpty(cdCoberturaDoCorretor))
                    AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
                else
                    AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura(ObterValorHeader("CD_TPA"), "P", cdCoberturaDoCorretor));
            }

            for (int i = 1; i < qtdParcelas; i++)
            {
                AdicionarLinha(i, ObterLinha(0));
                AlterarLinha(i, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(operadora));
                AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO", (i + 1).ToString());
                AlterarLinha(i, "NR_PARCELA",  (i + ObterValorFormatado(0, "NR_PARCELA").ObterParteNumericaDoTexto()).ToString());
                AlterarLinha(i, "NR_ENDOSSO", GerarNumeroAleatorio(6));
                AlterarLinha(i, "ID_TRANSACAO_CANC", "");
            }


            if(alterarVersaoHeader)
                AlterarHeader("VERSAO", "9.6");
            if(enviarParaOds)
                EnviarParaOds(arquivo);
            return arquivo.Clone();
        }

        protected Arquivo CriarEmissaoComissaoODS<T>(OperadoraEnum operadora, Arquivo arquivoParcela, bool alterarVersaoHeader = false, bool enviarOds = true) where T : Arquivo, new()
        {
            if (alterarVersaoHeader)
                return CriarEmissaoComissaoODS<T>(operadora, arquivoParcela, "9.6", enviarOds);
            return CriarEmissaoComissaoODS<T>(operadora, arquivoParcela, "", enviarOds);
        }

        protected Arquivo CriarEmissaoComissaoODS<T>(OperadoraEnum operadora, Arquivo arquivoParcela, string alterarVersaoHeader = "", bool enviarOds = true) where T : Arquivo, new()
        {
            arquivo = CriarComissao<T>(operadora, arquivoParcela, alterarVersaoHeader);

            if (enviarOds)
                EnviarParaOds(arquivo);
            return arquivo.Clone();
        }

        
        protected Arquivo CriarParcelaCancelamento<T>(OperadoraEnum operadora, Arquivo arquivoParcela, bool alterarVersaoHeader = false, string cdTipoEmissao = "10", string cdMovtoCobranca = "02", string nrSequencialEmissao = "") where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, 1, operadora);

            RemoverTodasAsLinhas();
            var ultimoNrSeqUsado = int.Parse(arquivoParcela.Linhas.Last()["NR_SEQUENCIAL_EMISSAO"]);
            foreach (var linha in arquivoParcela.Linhas)
            {
                ultimoNrSeqUsado++;
                AdicionarLinha(0, CriarLinhaCancelamento(arquivoParcela.ObterLinha(0), cdTipoEmissao, cdMovtoCobranca, ultimoNrSeqUsado.ToString()));
            }
            return arquivo;
        }

        public static IList<string> ObterProceduresFG09(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    break;
                case TipoArquivo.ParcEmissao:
                    //lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
                    lista.Add("PRC_0196_");
                    lista.Add("PRC_0197_");
                    //lista.Add("PRC_0199_");
                    lista.Add("PRC_0201_");
                    lista.Add("PRC_0206_");
                    lista.Add("PRC_0207_");
                    lista.Add("PRC_0208_");
                    lista.Add("PRC_0211_");
                    lista.Add("PRC_0222_");
                    lista.Add("PRC_0224_");
                    lista.Add("PRC_0229_");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    //lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
                    //lista.Add("PRC_0199_");
                    lista.Add("PRC_0196_");
                    lista.Add("PRC_0197_");
                    lista.Add("PRC_0201_");
                    lista.Add("PRC_0206_");
                    lista.Add("PRC_0207_");
                    lista.Add("PRC_0208_");
                    lista.Add("PRC_0211_");
                    lista.Add("PRC_0222_");
                    lista.Add("PRC_0224_");
                    lista.Add("PRC_0229_");
                    break;

                case TipoArquivo.Comissao:
                    lista.Add("PRC_0199_");
                    lista.Add("PRC_0200_");
                    break;

                case TipoArquivo.LanctoComissao:
                    break;
                case TipoArquivo.OCRCobranca:
                    break;

                case TipoArquivo.Sinistro:
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }

            return lista;
        }
    }
}
