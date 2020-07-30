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

        public static string ObterTarefaDaFG(this TipoArquivo tipoArquivo, FGs FGdaTarefa, bool ehEmissao = true)
        {
            switch (FGdaTarefa)
            {
                case FGs.FG00:
                    return tipoArquivo.ObterTarefaFG00Enum().ObterTexto();
                case FGs.FG01:
                    return tipoArquivo.ObterTarefaFG01Enum().ObterTexto();
                case FGs.FG01_2:
                    return tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto();
                case FGs.FG02:
                    return tipoArquivo.ObterTarefaFG02Enum().ObterTexto();
                case FGs.FG03:
                    return tipoArquivo.ObterTarefaFG03Enum().ObterTexto();
                case FGs.FG04:
                    return tipoArquivo.ObterTarefaFG04Enum().ObterTexto();
                case FGs.FG05:
                    return tipoArquivo.ObterTarefaFG05Enum().ObterTexto();
                case FGs.FG06:
                    return tipoArquivo.ObterTarefaFG06Enum().ObterTexto();
                case FGs.FG09:
                    return tipoArquivo.ObterTarefaFG09Enum().ObterTexto();
                case FGs.FG10:
                    return tipoArquivo.ObterTarefaFG10Enum().ObterTexto();
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

        public static FG01_2_Tarefas ObterTarefaFG01_2Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG01_2_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG01_2_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG01_2_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG01_2_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG01_2_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG01_2_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG01_2_Tarefas.Sinistro;
                default:
                    throw new Exception($"Tabela nao definida para o Enum {tipoArquivo.ObterTexto()}.");
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
                case TipoArquivo.Comissao:
                    return FG04_Tarefas.Comissao;
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

        public static FG06_Tarefas ObterTarefaFG06Enum(this TipoArquivo tipoArquivo)
        {

            return FG06_Tarefas.Trinca;

        }

        public static FG10_Tarefas ObterTarefaFG10Enum(this TipoArquivo tipoArquivo)
        {

            return FG10_Tarefas.TrincaCancelamento;
        }

        public static FG09_Tarefas ObterTarefaFG09Enum(this TipoArquivo tipoArquivo)
        {
            switch (tipoArquivo)
            {
                case TipoArquivo.Cliente:
                    return FG09_Tarefas.Cliente;
                case TipoArquivo.Comissao:
                    return FG09_Tarefas.Comissao;
                case TipoArquivo.LanctoComissao:
                    return FG09_Tarefas.LanctoComissao;
                case TipoArquivo.OCRCobranca:
                    return FG09_Tarefas.OCRCobranca;
                case TipoArquivo.ParcEmissao:
                    return FG09_Tarefas.ParcEmissao;
                case TipoArquivo.ParcEmissaoAuto:
                    return FG09_Tarefas.ParcEmissaoAuto;
                case TipoArquivo.Sinistro:
                    return FG09_Tarefas.Sinistro;
                default:
                    throw new Exception("Tabela nao definida para o Enum TipoArquivo.");
            }
        }

        public static CodigoStage ObterCodigoDeSucessoOuFalha(this FGs fgCorrespondente, bool sucesso = true)
        {
            switch (fgCorrespondente)
            {
                case FGs.FG00:
                    return sucesso ? CodigoStage.AprovadoNAFG00 : CodigoStage.RecusadoNaFG01;
                case FGs.FG01:
                    return sucesso ? CodigoStage.AprovadoNaFG01 : CodigoStage.RecusadoNaFG01;
                case FGs.FG01_2:
                    return sucesso ? CodigoStage.AprovadoNaFG01_2 : CodigoStage.RepovadoNaFG01_2;
                case FGs.FG02:
                    return sucesso ? CodigoStage.AprovadoNegocioSemDependencia : CodigoStage.ReprovadoNegocioSemDependencia;
                case FGs.FG05:
                    return sucesso ? CodigoStage.AprovadoNegocioComDependencia : CodigoStage.ReprovadoNegocioComDependencia;
                case FGs.FG06:
                    return sucesso ? CodigoStage.AprovadoFG06 : CodigoStage.ReprovadoFG06;
                case FGs.FG09:
                    return sucesso ? CodigoStage.AprovadoNaFG09 : CodigoStage.ReprovadoNaFG09;
                case FGs.FG10:
                    return sucesso ? CodigoStage.AprovadoFG10 : CodigoStage.AprovadoFG10;
                default:
                    throw new Exception("Codigo nao definido para o Enum da FG." + fgCorrespondente.ObterTexto());
            }
        }

        public static string ObterTagNoXML(this TabelasOIMEnum tabela)
        {
            switch (tabela)
            {
                case TabelasOIMEnum.OIM_APL01:
                    return "apl01";

                case TabelasOIMEnum.OIM_CMS01:
                    return "cms01";
                case TabelasOIMEnum.OIM_COB01:
                    return "cob01";
                case TabelasOIMEnum.OIM_PARC01:
                    return "parc01";
                case TabelasOIMEnum.OIM_ITAUTO01:
                    return "ITAUTO01";
                default:
                    throw new Exception("TAG NAO ENCONTRADA PARA " + tabela.ObterTexto());
            }
        }
        public static string[] ObterCamposChaves(this TabelasOIMEnum tabela)
        {
            switch (tabela)
            {
                case TabelasOIMEnum.OIM_APL01:
                    return new string[] { "nr_apolice", "nr_endosso" };

                case TabelasOIMEnum.OIM_CMS01:
                    return new string[] { "nr_apolice", "nr_parcela", "cd_corretor" };
                case TabelasOIMEnum.OIM_COB01:
                    return new string[] { "nr_apolice", "vl_premio", "cd_cobertura" };
                case TabelasOIMEnum.OIM_PARC01:
                    return new string[] { "nr_apolice", "vl_premio", "nr_parcela" };
                case TabelasOIMEnum.OIM_ITAUTO01:
                    return new string[] { "cd_modelo", "cd_item" };
                default:
                    throw new Exception("TAG NAO ENCONTRADA PARA " + tabela.ObterTexto());
            }
        }
    }
}
