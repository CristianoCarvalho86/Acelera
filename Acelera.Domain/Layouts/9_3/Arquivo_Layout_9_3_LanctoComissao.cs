﻿using Acelera.Contratos;
using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    [Serializable]

    public class Arquivo_Layout_9_3_LanctoComissao : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.LanctoComissao;
        protected override string[] CamposChaves => new string[] { "CD_CONTRATO", "NR_SEQUENCIAL_EMISSAO" };
        public override string TextoVersaoHeader => "9.3";
        protected override void CarregaCamposDoLayout(ILinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_CORRETOR", 7));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQ_EMISSAO", 18, "NR_SEQUENCIAL_EMISSAO"));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_COMISSAO", 3));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_EXTRATO_COMISSAO", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_MES_REFERENCIA", 6));
            linha.Campos.Add(new CampoDoArquivo("CD_LANCAMENTO", 4));
            linha.Campos.Add(new CampoDoArquivo("CD_EVENTO", 6));
            linha.Campos.Add(new CampoDoArquivo("VL_COMISSAO_PAGO", 16));
            linha.Campos.Add(new CampoDoArquivo("DT_PAGAMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_BAIXA", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 3));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_LANCAMENTO", 3));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 546));

        }
    }
}
