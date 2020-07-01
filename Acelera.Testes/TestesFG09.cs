using Acelera.Data;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
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
            return base.ObterProceduresASeremExecutadas().Concat(ObterProcedures(arquivo.tipoArquivo)).ToList();
        }

        protected Arquivo CriarEmissaoODS<T>(OperadoraEnum operadora, bool alterarVersaoHeader = false, string cdTipoEmissao = "20",int qtdParcelas = 1) where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, 1, operadora);
            CriarNovoContrato(0);
            AlterarLinha(0, "CD_TIPO_EMISSAO", cdTipoEmissao);
            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", "1");
            AlterarLinha(0, "NR_ENDOSSO", "0");
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            for (int i = 1; i < qtdParcelas; i++)
            {
                AdicionarLinha(i, ObterLinha(0));
                AlterarLinha(i, "CD_TIPO_EMISSAO", cdTipoEmissao);
                AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO", (i + 1).ToString());
                AlterarLinha(i, "NR_ENDOSSO", "0");
                AlterarLinha(i, "ID_TRANSACAO_CANC", "");
            }


            if(alterarVersaoHeader)
                AlterarHeader("VERSAO", "9.6");
            EnviarParaOds(arquivo);
            return arquivo.Clone();
        }

        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
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

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0042_");
                    lista.Add("PRC_0045_");
                    lista.Add("PRC_0190_");
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
                    lista.Add("PRC_0197_");
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
