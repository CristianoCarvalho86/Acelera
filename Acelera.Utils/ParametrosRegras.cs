using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ParametrosRegrasEmissao
    {
        public static string CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.TIM)
                return "18";
            else if (operadora == OperadoraEnum.VIVO || operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX || operadora == OperadoraEnum.POMPEIA)
                return "1";
            throw new Exception("OPERACAO NAO DEFINIDA PARA OBTER TIPO EMISSAO");
        }
        public static string CarregaTipoEmissaoParaSegundaLinhaDaEmissao(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.TIM)
                return "20";
            else if (operadora == OperadoraEnum.VIVO || operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX || operadora == OperadoraEnum.POMPEIA)
                return "1";
            throw new Exception("OPERACAO NAO DEFINIDA PARA OBTER TIPO EMISSAO");
        }
        public static string CarregaPrimeiroNrParcela(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.TIM)
                return "0";
            else
                return "1";
        }
    }
}
