using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class ParametrosBanco
    {
        public static string ObterCDClienteCadastrado(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.VIVO)
                return "10876063";
            else if (operadora == OperadoraEnum.LASA)
                return "00952570";
            else if (operadora == OperadoraEnum.SOFTBOX)
                return "00952146";
            else if (operadora == OperadoraEnum.POMPEIA)
                return "00952570";
            else if (operadora == OperadoraEnum.TIM)
                return "173878";

            throw new Exception("ERRO AO OBTER CD CLIENTE CADASTRADO");
        }
    }
}
