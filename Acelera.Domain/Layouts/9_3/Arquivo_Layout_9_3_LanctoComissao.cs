using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    public class Arquivo_Layout_9_3_LanctoComissao : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
            linha.Campos.Add(new Campo("CD_RAMO", 2));
            linha.Campos.Add(new Campo("CD_CORRETOR", 7));
            linha.Campos.Add(new Campo("CD_CONTRATO", 20));
            linha.Campos.Add(new Campo("NR_SEQ_EMISSAO", 18));
            linha.Campos.Add(new Campo("CD_TIPO_COMISSAO", 3));
            linha.Campos.Add(new Campo("NR_PARCELA", 4));
            linha.Campos.Add(new Campo("NR_APOLICE", 20));
            linha.Campos.Add(new Campo("NR_ENDOSSO", 20));
            linha.Campos.Add(new Campo("CD_EXTRATO_COMISSAO", 4));
            linha.Campos.Add(new Campo("NR_MES_REFERENCIA", 6));
            linha.Campos.Add(new Campo("CD_LANCAMENTO", 4));
            linha.Campos.Add(new Campo("CD_EVENTO", 6));
            linha.Campos.Add(new Campo("VL_COMISSAO_PAGO", 16));
            linha.Campos.Add(new Campo("DT_PAGAMENTO", 8));
            linha.Campos.Add(new Campo("DT_BAIXA", 8));
            linha.Campos.Add(new Campo("CD_SISTEMA", 3));
            linha.Campos.Add(new Campo("CD_TIPO_LANCAMENTO", 3));
            linha.Campos.Add(new Campo("FILLER", 546));

        }
    }
}
