using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_OcrCobranca : Arquivo
    {
        protected override void CarregaCamposDoLayout(Linha linha)
        {
            linha.Campos.Add(new Campo("TIPO REGISTRO", 002));
            linha.Campos.Add(new Campo("CD_CONTRATO", 020));
            linha.Campos.Add(new Campo("NR_SEQUENCIAL_EMISSAO", 005));
            linha.Campos.Add(new Campo("NR_PARCELA", 004));
            linha.Campos.Add(new Campo("CD_OCORRENCIA", 004));
            linha.Campos.Add(new Campo("DT_OCORRENCIA", 008));
            linha.Campos.Add(new Campo("VL_DESCONTO", 016));
            linha.Campos.Add(new Campo("VL_PREMIO_PAGO", 016));
            linha.Campos.Add(new Campo("VL_MULTA", 016));
            linha.Campos.Add(new Campo("VL_IOF_RETIDO", 016));
            linha.Campos.Add(new Campo("VL_ADC_FRC", 016));
            linha.Campos.Add(new Campo("VL_ADC_FRC_DVI", 016));
            linha.Campos.Add(new Campo("VL_MULTA_DEVIDO", 016));
            linha.Campos.Add(new Campo("VL_JUROS_COBRADO", 016));
            linha.Campos.Add(new Campo("VL_JUROS_DEVIDO", 016));
            linha.Campos.Add(new Campo("VL_DIF_PREMIO", 016));
            linha.Campos.Add(new Campo("CD_SISTEMA", 003));
            linha.Campos.Add(new Campo("FILLER", 494));
        }
    }
}
