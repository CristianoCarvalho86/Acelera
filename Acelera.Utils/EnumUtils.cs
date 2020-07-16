using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class EnumUtils
    {
        public static OperadoraEnum ObterOperadoraDoArquivo(string nomeArquivo)
        {
            if(nomeArquivo.Contains(OperadoraEnum.LASA.ObterTexto()))
                return OperadoraEnum.LASA;
            if (nomeArquivo.Contains(OperadoraEnum.POMPEIA.ObterTexto()))
                return OperadoraEnum.POMPEIA;
            if (nomeArquivo.Contains(OperadoraEnum.SGS.ObterTexto()))
                return OperadoraEnum.SGS;
            if (nomeArquivo.Contains(OperadoraEnum.TIM.ObterTexto()))
                return OperadoraEnum.TIM;
            if (nomeArquivo.Contains(OperadoraEnum.VIVO.ObterTexto()))
                return OperadoraEnum.VIVO;
            if (nomeArquivo.Contains(OperadoraEnum.SOFTBOX.ObterTexto()))
                return OperadoraEnum.SOFTBOX;
            throw new Exception("OPERACAO NAO ENCONTRADA NO NOME DO ARQUIVO : " + nomeArquivo);
        }

        public static IList<T> ObterListaComTodos<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
