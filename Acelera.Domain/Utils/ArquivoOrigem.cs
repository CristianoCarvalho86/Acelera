using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Utils
{
    public static class ArquivoOrigem
    {
        public static IList<string> ObterArquivos(TipoArquivo tipoArquivo, OperadoraEnum operadora, string pastaOrigem)
        {
            var arquivosNaPasta = Directory.GetFiles(pastaOrigem);
            return arquivosNaPasta.Where(x => x.Contains(tipoArquivo.ObterPrefixoOperadoraNoArquivo()) && x.Contains(operadora.ObterTexto())).ToList();
        }

        public static string ObterArquivoAleatorio(TipoArquivo tipoArquivo, OperadoraEnum operadora, string pastaOrigem)
        {
            var arquivosNaPasta = Directory.GetFiles(pastaOrigem);
            var lista = arquivosNaPasta.Where(x => x.Contains(tipoArquivo.ObterPrefixoOperadoraNoArquivo()) && x.Contains(operadora.ObterTexto())).ToList();
            return lista[0];
        }
    }
}
