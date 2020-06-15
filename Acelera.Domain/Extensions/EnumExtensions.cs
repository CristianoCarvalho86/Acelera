using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string ObterTexto(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }

        public static string ObterPrefixoOperadoraNoArquivo(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return "CLIENTE";
                case TipoArquivo.Comissao:
                    return "EMSCMS";
                case TipoArquivo.LanctoComissao:
                    return "LCTCMS";
                case TipoArquivo.OCRCobranca:
                    return "COBRANCA";
                case TipoArquivo.ParcEmissao:
                    return "PARCEMS";
                case TipoArquivo.ParcEmissaoAuto:
                    return "PARCEMSAUTO";
                case TipoArquivo.Sinistro:
                    return "SINISTRO";
                default:
                    throw new Exception("TIPO_ARQUIVO NAO ENCONTRADO");
            }
        }

        public static TabelasEnum ObterTabelaStageEnum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return TabelasEnum.Cliente;
                case TipoArquivo.Comissao:
                    return TabelasEnum.Comissao;
                case TipoArquivo.LanctoComissao:
                    return TabelasEnum.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return TabelasEnum.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return TabelasEnum.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return TabelasEnum.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return TabelasEnum.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static TabelasEnum ObterTabelaODSEnum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return TabelasEnum.OdsParceiroNegocio;
                case TipoArquivo.Comissao:
                    return TabelasEnum.OdsComissao;
                case TipoArquivo.ParcEmissao:
                    return TabelasEnum.OdsParcela;
                case TipoArquivo.ParcEmissaoAuto:
                    return TabelasEnum.OdsParcela;
                case TipoArquivo.Sinistro:
                    return TabelasEnum.OdsSinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static string ObterTarefaDaFG(this TipoArquivo tipoArquivo, FGs FGdaTarefa)
        {
            switch(FGdaTarefa)
            {
                case FGs.FG00:
                    return tipoArquivo.ObterTarefaFG00Enum().ObterTexto();
                case FGs.FG01:
                    return tipoArquivo.ObterTarefaFG01Enum().ObterTexto();
                case FGs.FG02:
                    return tipoArquivo.ObterTarefaFG02Enum().ObterTexto();
                case FGs.FG03:
                    return tipoArquivo.ObterTarefaFG03Enum().ObterTexto();
                case FGs.FG04:
                    return tipoArquivo.ObterTarefaFG04Enum().ObterTexto();
                case FGs.FG05:
                    return tipoArquivo.ObterTarefaFG05Enum().ObterTexto();
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG01_Tarefas ObterTarefaFG01Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG01_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG01_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG01_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG01_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG01_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG01_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG01_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG01_1_Tarefas ObterTarefaFG01_1_Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Sinistro:
                    return FG01_1_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG00_Tarefas ObterTarefaFG00Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG00_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG00_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG00_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG00_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG00_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG00_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG00_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG02_Tarefas ObterTarefaFG02Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG02_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG02_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG02_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG02_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG02_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG02_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG02_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG03_Tarefas ObterTarefaFG03Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Sinistro:
                    return FG03_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static FG04_Tarefas ObterTarefaFG04Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG04_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG04_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG04_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG04_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG04_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG04_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG04_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }


        public static FG05_Tarefas ObterTarefaFG05Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG05_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG05_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG05_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG05_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG05_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG05_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG05_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }
    }
}
