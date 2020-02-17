using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    public class Arquivo_Layout_9_3_OcrCobranca : Arquivo
    {
        protected override void CarregaCamposDoLayout(Linha linha)
        {
            linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
            linha.Campos.Add(new Campo("CD_CONTRATO", 20));
            linha.Campos.Add(new Campo("NR_SEQUENCIAL_EMISSAO", 5));
            linha.Campos.Add(new Campo("NR_PARCELA", 4));
            linha.Campos.Add(new Campo("CD_OCORRENCIA", 4));
            linha.Campos.Add(new Campo("DT_OCORRENCIA", 8));
            linha.Campos.Add(new Campo("VL_DESCONTO", 16));
            linha.Campos.Add(new Campo("VL_PREMIO_PAGO", 16));
            linha.Campos.Add(new Campo("VL_MULTA", 16));
            linha.Campos.Add(new Campo("VL_IOF_RETIDO", 16));
            linha.Campos.Add(new Campo("VL_ADC_FRC", 16));
            linha.Campos.Add(new Campo("VL_ADC_FRC_DVI", 16));
            linha.Campos.Add(new Campo("VL_MULTA_DEVIDO", 16));
            linha.Campos.Add(new Campo("VL_JUROS_COBRADO", 16));
            linha.Campos.Add(new Campo("VL_JUROS_DEVIDO", 16));
            linha.Campos.Add(new Campo("VL_DIF_PREMIO", 16));
            linha.Campos.Add(new Campo("CD_SISTEMA", 3));
            linha.Campos.Add(new Campo("FILLER", 494));
        }
    }
}
