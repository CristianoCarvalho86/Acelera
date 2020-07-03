using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Utils
{
    public static class LayoutUtils
    {
        //public static Arquivo CarregarArquivo(string path)
        //{
        //    var reader = new StreamReader(path);
        //    var header = reader.ReadLine();
        //    reader.Close();
        //    reader.Dispose();

        //    var fileName = new FileInfo(path).Name;
        //    if (header.Substring(121, 125).Contains("9.4"))
        //    { 
        //        if(EnumUtils.ObterOperadoraDoArquivo(fileName) != Domain.Enums.OperadoraEnum.VIVO && TipoArquivo.Cliente.Obter )

        //    }
        //}

        //public static TipoArquivo ObterTipoArquivo(string nomeArquivo)
        //{
        //    switch (tipoArquivo)
        //    {
        //        case TipoArquivo.Cliente:
        //            return "CLIENTE";
        //        case TipoArquivo.Comissao:
        //            return "EMSCMS";
        //        case TipoArquivo.LanctoComissao:
        //            return "LCTCMS";
        //        case TipoArquivo.OCRCobranca:
        //            return "COBRANCA";
        //        case TipoArquivo.ParcEmissao:
        //            return "PARCEMS";
        //        case TipoArquivo.ParcEmissaoAuto:
        //            return "PARCEMSAUTO";
        //        case TipoArquivo.Sinistro:
        //            return "SINISTRO";
        //        default:
        //            throw new Exception("TIPO_ARQUIVO NAO ENCONTRADO");
        //    }
        //}
    }
}
