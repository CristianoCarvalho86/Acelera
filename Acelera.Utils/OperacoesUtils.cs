using Acelera.Contratos;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public class OperacoesUtils
    {
        public static string SomarData(string valorAntigo, int diasAdicionados)
        {
            DateTime d = new DateTime();
            if (DateTime.TryParse(valorAntigo, out DateTime data))
                d = data;
            else
                d = new DateTime(int.Parse(valorAntigo.Substring(0, 4)), int.Parse(valorAntigo.Substring(4, 2)), int.Parse(valorAntigo.Substring(6, 2)));
            d = d.AddDays(diasAdicionados);
            return d.ToString("yyyyMMdd");
        }

        public static string SomarData(IArquivo arquivo, int posicaoLinha, string nomeCampo, int diasAdicionados)
        {
            return SomarData(arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).ValorFormatado, diasAdicionados);
        }


        public static string SomarValor(IArquivo arquivo,int posicaoLinha, string nomeCampo, decimal valorAdicionado)
        {
            return (decimal.Parse(arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).ValorFormatadoNumerico) + valorAdicionado).ToString().Replace(",", ".");
        }

        public static decimal SomarDoisCamposDoArquivo(IArquivo arquivo,int posicaoLinha, string campo1, string campo2)
        {
            var linha = arquivo.ObterLinha(posicaoLinha);
            if (!decimal.TryParse(linha.ObterCampoDoArquivo(campo1).ValorFormatadoNumerico, out decimal Valor1) || !decimal.TryParse(linha.ObterCampoDoArquivo(campo2).ValorFormatadoNumerico, out decimal Valor2))
                throw new Exception("VALOR DOS CAMPOS A SEREM SOMADOS PRECISA SER INTEIRO");

            return Valor1 + Valor2;
        }

        public static string SomarValores(decimal valor1, decimal valor2)
        {
            return (valor1 + valor2).ToString("0.00").Replace(",", ".").Replace(".00", "");
        }
        public static string SomarValores(string valor1, string valor2)
        {
            if (!decimal.TryParse(valor1.Replace(".", ","), out decimal Valor1) || !decimal.TryParse(valor2.Replace(".", ","), out decimal Valor2))
                throw new Exception("VALORES A SEREM SOMADOS PRECISAM SER NUMERICOS");
            return SomarValores(Valor1, Valor2);
        }

        public static string MediaEntreValores(string valor1, string valor2)
        {
            if (!decimal.TryParse(valor1.Replace(".", ","), out decimal Valor1) || !decimal.TryParse(valor2.Replace(".", ","), out decimal Valor2))
                throw new Exception("VALORES A SEREM SOMADOS PRECISAM SER NUMERICOS");
            return ((Valor1 + Valor2) / 2M).ValorFormatado();
        }

        public static string MontarCamposConcatenados(IArquivo arquivo, int posicaoLinha, params string[] campos)
        {
            var linha = arquivo.ObterLinha(posicaoLinha);
            var resultado = string.Empty;
            foreach (var campo in campos)
                resultado += linha.ObterCampoDoArquivo(campo).ValorFormatado;
            return resultado;
        }

    }
}
