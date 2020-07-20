using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public class JsonLayout
    {
        public string TIPO { get; set; }
        public string VERSAO { get; set; }
        public List<DadosCampo> FOOTER { get;set;}
        public List<DadosCampo> HEADER { get; set; }
        public List<DadosCampo> BODY { get; set; }
    }

    public class DadosCampo
    {
        public string NOME { get; set; }
        public string TAMANHO { get; set; }
    }

}
