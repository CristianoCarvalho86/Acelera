using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_6;
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
        public static Arquivo CarregarArquivo(string path)
        {
            var reader = new StreamReader(path);
            var header = reader.ReadLine();
            reader.Close();
            reader.Dispose();

            var fileName = new FileInfo(path).Name;
            var tipoArquivo = ObterTipoArquivo(fileName);
            if (header.Substring(121, 125).Contains("9.4"))
            {
                if (tipoArquivo == TipoArquivo.Cliente)
                    return new Arquivo_Layout_9_4_Cliente().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissao)
                    return new Arquivo_Layout_9_4_ParcEmissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                    return new Arquivo_Layout_9_4_ParcEmissaoAuto().Carregar(path);
                if (tipoArquivo == TipoArquivo.OCRCobranca)
                    return new Arquivo_Layout_9_4_OcrCobranca().Carregar(path);
                if (tipoArquivo == TipoArquivo.LanctoComissao)
                    return new Arquivo_Layout_9_4_LanctoComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Comissao)
                    return new Arquivo_Layout_9_4_EmsComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Sinistro)
                    return new Arquivo_Layout_9_4_Sinistro().Carregar(path);
            }
            if (header.Substring(121, 125).Contains("9.3"))
            {
                if (tipoArquivo == TipoArquivo.Cliente)
                    return new Arquivo_Layout_9_3_Cliente().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissao)
                    return new Arquivo_Layout_9_3_ParcEmissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                    return new Arquivo_Layout_9_3_ParcEmissaoAuto().Carregar(path);
                if (tipoArquivo == TipoArquivo.OCRCobranca)
                    return new Arquivo_Layout_9_3_OcrCobranca().Carregar(path);
                if (tipoArquivo == TipoArquivo.LanctoComissao)
                    return new Arquivo_Layout_9_3_LanctoComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Comissao)
                    return new Arquivo_Layout_9_3_EmsComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Sinistro)
                    return new Arquivo_Layout_9_3_Sinistro().Carregar(path);
            }
            if (header.Substring(121, 125).Contains("9.6"))
            {
                if (tipoArquivo == TipoArquivo.Cliente)
                    return new Arquivo_Layout_9_6_Cliente().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissao)
                    return new Arquivo_Layout_9_6_ParcEmissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                    return new Arquivo_Layout_9_6_ParcEmissaoAuto().Carregar(path);
                if (tipoArquivo == TipoArquivo.OCRCobranca)
                    return new Arquivo_Layout_9_6_OcrCobranca().Carregar(path);
                if (tipoArquivo == TipoArquivo.LanctoComissao)
                    return new Arquivo_Layout_9_6_LanctoComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Comissao)
                    return new Arquivo_Layout_9_6_EmsComissao().Carregar(path);
                if (tipoArquivo == TipoArquivo.Sinistro)
                    return new Arquivo_Layout_9_6_Sinistro().Carregar(path);
            }
            throw new Exception("LAYOUT NAO PARAMETRIZADO");
        }

        public static TipoArquivo ObterTipoArquivo(string nomeArquivo)
        {
            var tipo = nomeArquivo.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries)[2].Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries).First();
            switch (tipo)
            {
                case "CLIENTE":
                    return TipoArquivo.Cliente;
                case "EMSCMS":
                    return TipoArquivo.Comissao;
                case "LCTCMS":
                    return TipoArquivo.LanctoComissao;
                case "COBRANCA":
                    return TipoArquivo.OCRCobranca;
                case "PARCEMS":
                    return TipoArquivo.ParcEmissao;
                case "PARCEMSAUTO":
                    return TipoArquivo.ParcEmissaoAuto;
                case "SINISTRO":
                    return TipoArquivo.Sinistro;
                default:
                    throw new Exception("TIPO_ARQUIVO NAO ENCONTRADO");
            }
        }
    }
}
