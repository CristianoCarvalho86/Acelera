using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    [Serializable]

    public class Arquivo_Layout_9_3_OcrCobranca : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.OCRCobranca;
        protected override string[] CamposChaves => new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO" };
        public override string TextoVersaoHeader => "9.3";
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 20, "NR_APOLICE"));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 5));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 4));
            linha.Campos.Add(new CampoDoArquivo("CD_OCORRENCIA", 4));
            linha.Campos.Add(new CampoDoArquivo("DT_OCORRENCIA", 8));
            linha.Campos.Add(new CampoDoArquivo("VL_DESCONTO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_PAGO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_MULTA", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_IOF_RETIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_ADC_FRC", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_ADC_FRC_DVI", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_MULTA_DEVIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS_COBRADO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS_DEVIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_DIF_PREMIO", 16));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 3));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 494));
        }
    }
}
