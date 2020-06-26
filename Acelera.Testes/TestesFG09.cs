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
