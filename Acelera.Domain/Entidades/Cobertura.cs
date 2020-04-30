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
            return cobertura;
        }

    }
}
