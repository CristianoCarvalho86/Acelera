using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ParametrosRegrasEmissao
    {
        public static OperadoraEnum[] OperadorasComCapa => new OperadoraEnum[] { OperadoraEnum.TIM, OperadoraEnum.PITZI, OperadoraEnum.AGREGUE };

        public static OperadoraEnum[] OperadorasParcAuto => new OperadoraEnum[] { OperadoraEnum.VIVO };

        public static string CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.PAPCARD)
                return "20";
            else if (OperadorasComCapa.Contains(operadora))
                return "18";
            else //if (operadora == OperadoraEnum.VIVO || operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX || operadora == OperadoraEnum.POMPEIA)
                return "1";
            throw new Exception("OPERACAO NAO DEFINIDA PARA OBTER TIPO EMISSAO");
        }
        public static string CarregaTipoEmissaoParaSegundaLinhaDaEmissao(OperadoraEnum operadora)
        {
            if (OperadorasComCapa.Contains(operadora) || operadora == OperadoraEnum.PAPCARD)
                return "20";
            else
                return "1";
            throw new Exception("OPERACAO NAO DEFINIDA PARA OBTER TIPO EMISSAO");
        }
        public static string CarregaPrimeiroNrParcela(OperadoraEnum operadora)
        {
            if (OperadorasComCapa.Contains(operadora))
                return "0";
            else
                return "1";
        }

        public static string CarregaPrimeiroNumeroSequencialEmissao(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.PAPCARD)
                return ControleNomeArquivo.Instancia.ObtemValor("SequencialPapcard");
            else
                return "1";
        }

        public static string CarregaProximoNumeroSequencialEmissao(LinhaArquivo linhaDeReferencia, OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.PAPCARD)
                return ControleNomeArquivo.Instancia.ObtemValor("SequencialPapcard");
            else
                return (int.Parse(linhaDeReferencia["NR_SEQUENCIAL_EMISSAO"]) + 1).ToString();
        }
        public static string CarregaPrimeiroNumeroEndosso(LinhaArquivo linhaDeReferencia, OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.PAPCARD)
                return linhaDeReferencia["CD_SUCURSAL"] + linhaDeReferencia["CD_RAMO"] + RandomNumber.GerarNumeroAleatorio(7);
            else
                return "0";
        }

        public static string CarregaProximoNumeroEndosso(LinhaArquivo linhaDeReferencia)
        {
            return linhaDeReferencia["CD_SUCURSAL"] + linhaDeReferencia["CD_RAMO"] + RandomNumber.GerarNumeroAleatorio(7);
        }

        public static string GerarNrApolicePapCard()
        {
            return RandomNumber.GerarNumeroAleatorio(10);
        }

    }
}
