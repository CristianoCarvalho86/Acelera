using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_EmsComissao : Arquivo
    {
        protected override void CarregaCamposDoLayout(Linha linha)
        {
                linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
                linha.Campos.Add(new Campo("CD_INTERNO_RESSEGURADOR", 5));
                linha.Campos.Add(new Campo("CD_SEGURADORA", 5));
                linha.Campos.Add(new Campo("CD_CORRETOR", 7));
                linha.Campos.Add(new Campo("CD_RAMO", 2));
                linha.Campos.Add(new Campo("CD_CONTRATO", 20));
                linha.Campos.Add(new Campo("NR_SEQUENCIAL_EMISSAO", 5));
                linha.Campos.Add(new Campo("NR_PARCELA", 4));
                linha.Campos.Add(new Campo("CD_ITEM", 4));
                linha.Campos.Add(new Campo("CD_TIPO_COMISSAO", 3));
                linha.Campos.Add(new Campo("CD_COBERTURA", 10));
                linha.Campos.Add(new Campo("VL_COMISSAO", 16));
                linha.Campos.Add(new Campo("VL_BASE_CALCULO", 16));
                linha.Campos.Add(new Campo("PC_COMISSAO", 8));
                linha.Campos.Add(new Campo("PC_PARTICIPACAO", 8));
                linha.Campos.Add(new Campo("CD_SISTEMA", 3));
                linha.Campos.Add(new Campo("FILLER", 582));
        }
    }
}
