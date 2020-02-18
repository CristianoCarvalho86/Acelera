using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Enums
{
    public enum OperacaoEnum
    {
        [Description("Carregar Arquivo")]
        CarregarArquivo,
        [Description("Salvar Arquivo")]
        SalvarArquivo,
        [Description("Processar Arquivo")]
        Processar,
        [Description("Verificar Resultado")]
        ValidarResultado
    }
}
