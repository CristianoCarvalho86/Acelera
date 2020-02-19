using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_LanctoComissao : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new Campo("TIPO REGISTRO", 002));
            linha.Campos.Add(new Campo("CD_RAMO", 002));
            linha.Campos.Add(new Campo("CD_CORRETOR", 007));
            linha.Campos.Add(new Campo("CD_CONTRATO", 020));
            linha.Campos.Add(new Campo("NR_SEQ_EMISSAO", 018));
            linha.Campos.Add(new Campo("CD_TIPO_COMISSAO", 003));
            linha.Campos.Add(new Campo("NR_PARCELA", 004));
            linha.Campos.Add(new Campo("NR_APOLICE", 020));
            linha.Campos.Add(new Campo("NR_ENDOSSO", 020));
            linha.Campos.Add(new Campo("CD_EXTRATO_COMISSAO", 004));
            linha.Campos.Add(new Campo("NR_MES_REFERENCIA", 006));
            linha.Campos.Add(new Campo("CD_LANCAMENTO", 004));
            linha.Campos.Add(new Campo("CD_EVENTO", 006));
            linha.Campos.Add(new Campo("VL_COMISSAO_PAGO", 016));
            linha.Campos.Add(new Campo("DT_PAGAMENTO", 008));
            linha.Campos.Add(new Campo("DT_BAIXA", 008));
            linha.Campos.Add(new Campo("CD_SISTEMA", 003));
            linha.Campos.Add(new Campo("CD_TIPO_LANCAMENTO", 003));
            linha.Campos.Add(new Campo("FILLER", 546));
        }
    }
}
