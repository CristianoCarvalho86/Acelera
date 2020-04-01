using System;
using System.Collections.Generic;
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
        public string Id { get; set; }
        public string CdCobertura { get; set; }
        public string CdRamo { get; set; }
        public string CdProduto { get; set; }
        public string CdPrdCobertura { get; set; }
        public string CdRamoCobertura { get; set; }
    }
}
