﻿using Acelera.Contratos;
using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    [Serializable]

    public class Arquivo_Layout_9_4_OcrCobranca : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.OCRCobranca;
        protected override string[] CamposChaves => new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO" };
        public override string TextoVersaoHeader => "9.4";
        protected override void CarregaCamposDoLayout(ILinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 020, "NR_APOLICE"));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 005));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 004));
            linha.Campos.Add(new CampoDoArquivo("CD_OCORRENCIA", 004));
            linha.Campos.Add(new CampoDoArquivo("DT_OCORRENCIA", 008));
            linha.Campos.Add(new CampoDoArquivo("VL_DESCONTO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_PAGO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_MULTA", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_IOF_RETIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_ADC_FRC", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_ADC_FRC_DVI", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_MULTA_DEVIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS_COBRADO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS_DEVIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_DIF_PREMIO", 016));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 003));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 494));
        }
    }
}
