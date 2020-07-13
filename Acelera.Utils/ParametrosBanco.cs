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
                return "00900809";
            else if (operadora == OperadoraEnum.TIM)
                return "29249585";

            throw new Exception("ERRO AO OBTER CD CLIENTE CADASTRADO");
        }

        public static KeyValuePair<string, string> ObterCdCorretorETipoComissao(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.VIVO)
            {
                return new KeyValuePair<string, string>("7239711","C");
            }
            else if (operadora == OperadoraEnum.LASA || operadora == OperadoraEnum.SOFTBOX)
            {
                return new KeyValuePair<string, string>("7150145", "P");
            }
            else if (operadora == OperadoraEnum.POMPEIA)
            {
                return new KeyValuePair<string, string>("7150166", "P");
            }
            else if (operadora == OperadoraEnum.TIM)
            {
                return new KeyValuePair<string, string>("7950129", "P");
            }
            throw new Exception("OPERACAO NAO DEFINIDA PARA BUSCA DE CORRETOR E TIPO COMISSAO.");
        }


        public static string ObterCdTpa(OperadoraEnum operadora)
        {
            if (operadora == OperadoraEnum.VIVO)
                return "004";
            else if (operadora == OperadoraEnum.LASA)
                return "007";
            else if (operadora == OperadoraEnum.SOFTBOX)
                return "010";
            else if (operadora == OperadoraEnum.POMPEIA)
                return "025";
            else if (operadora == OperadoraEnum.TIM)
                return "002";

            throw new Exception("ERRO AO OBTER TPA CADASTRADO");
        }
    }
}
