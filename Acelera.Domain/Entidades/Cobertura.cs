using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class Cobertura
    {
        public string ValorJurosMaior { get; set; }
        public string ValorJurosMenor { get; set; }
        public string ValorDescontoMaior { get; set; }
        public string ValorDescontoMenor { get; set; }
        public string ValorAdicionalMaior { get; set; }
        public string ValorAdicionalMenor { get; set; }
        public string Id { get; set; }
        public string CdCobertura { get; set; }
        public string CdRamo { get; set; }
        public string CdProduto { get; set; }
        public string CdRamoCobertura { get; set; }

        public string ValorPremioBrutoMaior { get; set; }
        public string ValorPremioBrutoMenor { get; set; }
        public string ValorPremioLiquidoMaior { get; set; }
        public string ValorPremioLiquidoMenor { get; set; }
        public string ValorPercentualAlicotaIof { get; set; }
        public decimal ValorPercentualAlicotaIofDecimal => decimal.Parse(ValorPercentualAlicotaIof);
        public decimal ValorPremioBrutoMaiorDecimal => decimal.Parse(ValorPremioBrutoMaior);
        public decimal ValorPremioBrutoMenorDecimal => decimal.Parse(ValorPremioBrutoMenor);
        public decimal ValorPremioLiquidoMaiorDecimal => decimal.Parse(ValorPremioLiquidoMaior);
        public decimal ValorPremioLiquidoMenorDecimal => decimal.Parse(ValorPremioLiquidoMenor);


        public static Cobertura CarregarCobertura(DataRow linha)
        {
            var cobertura = new Cobertura();
            cobertura.CdCobertura = linha["CD_COBERTURA"].ToString();
            cobertura.Id = linha["ID_COBERTURA"].ToString();
            cobertura.ValorDescontoMaior = !linha.Table.Columns.Contains("VL_DESCONTO_MAIOR") ? "" : linha["VL_DESCONTO_MAIOR"].ToString();
            cobertura.ValorDescontoMenor = !linha.Table.Columns.Contains("VL_DESCONTO_MENOR") ? "" : linha["VL_DESCONTO_MENOR"].ToString();
            cobertura.ValorJurosMaior = !linha.Table.Columns.Contains("VL_JUROS_MAIOR") ? "" : linha["VL_JUROS_MAIOR"].ToString();
            cobertura.ValorJurosMenor = !linha.Table.Columns.Contains("VL_JUROS_MENOR") ? "" : linha["VL_JUROS_MENOR"].ToString();
            cobertura.CdProduto = linha["CD_PRODUTO"].ToString();
            cobertura.CdRamo = linha["CD_RAMO"].ToString();
            cobertura.CdRamoCobertura = !linha.Table.Columns.Contains("CD_RAMO_COBERTURA") ? "" : linha["CD_RAMO_COBERTURA"].ToString();
            cobertura.ValorAdicionalMaior = !linha.Table.Columns.Contains("VL_ADIC_FRAC_MAIOR") ? "" : linha["VL_ADIC_FRAC_MAIOR"].ToString();
            cobertura.ValorAdicionalMenor = !linha.Table.Columns.Contains("VL_ADIC_FRAC_MENOR") ? "" : linha["VL_ADIC_FRAC_MENOR"].ToString();
            cobertura.ValorPremioLiquidoMenor = !linha.Table.Columns.Contains("VL_PREMIO_LQ_MENOR") ? "" : linha["VL_PREMIO_LQ_MENOR"].ToString();
            cobertura.ValorPremioLiquidoMaior = !linha.Table.Columns.Contains("VL_PREMIO_LQ_MAIOR") ? "" : linha["VL_PREMIO_LQ_MAIOR"].ToString();
            cobertura.ValorPremioBrutoMenor = !linha.Table.Columns.Contains("VL_PREMIO_BR_MAIOR") ? "" : linha["VL_PREMIO_BR_MAIOR"].ToString();
            cobertura.ValorPremioBrutoMaior = !linha.Table.Columns.Contains("VL_PREMIO_BR_MENOR") ? "" : linha["VL_PREMIO_BR_MENOR"].ToString();
            cobertura.ValorPercentualAlicotaIof = !linha.Table.Columns.Contains("VL_PERC_ALIQUOTA_IOF") ? "" : linha["VL_PERC_ALIQUOTA_IOF"].ToString();
            return cobertura;
        }

    }
}
