using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class Assertions
    {
        public static bool ValidarRegistroUnicoNaLista<T>(IList<T> lista, IMyLogger logger, string nomeDaLista, bool geraExcecao = false) 
        {
            if (lista.Count == 0)
            {
                logger.Erro($"ERRO : NENHUM REGISTRO ENCONTRADO EM '{nomeDaLista}'");
                if (geraExcecao)
                    throw new Exception($"MAIS DE UM REGISTRO ENCONTRADO AO PREENCHER '{nomeDaLista}'");
                return false;
            }
            if (lista.Count > 1)
            {
                logger.Erro($"ERRO : EM '{nomeDaLista}' ERAM ESPERADOS 1 REGISTRO, FORAM ENCONTRADOS : {lista.Count}");
                if(geraExcecao)
                    throw new Exception($"ERRO AO PREENCHER : '{nomeDaLista}'");
                return false;
            }
            logger.Escrever($"APENAS 1 REGISTRO ENCONTRADO PARA '{nomeDaLista}' - OK.");
            return true;
        }
    }
}
