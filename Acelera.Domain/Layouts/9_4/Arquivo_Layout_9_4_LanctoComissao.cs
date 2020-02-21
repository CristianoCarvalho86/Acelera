﻿using System;
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
            linha.Campos.Add(new CampoDoArquivo("TIPO REGISTRO", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_CORRETOR", 007));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQ_EMISSAO", 018));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_COMISSAO", 003));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_EXTRATO_COMISSAO", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_MES_REFERENCIA", 006));
            linha.Campos.Add(new CampoDoArquivo("CD_LANCAMENTO", 004));
            linha.Campos.Add(new CampoDoArquivo("CD_EVENTO", 006));
            linha.Campos.Add(new CampoDoArquivo("VL_COMISSAO_PAGO", 016));
            linha.Campos.Add(new CampoDoArquivo("DT_PAGAMENTO", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_BAIXA", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 003));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_LANCAMENTO", 003));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 546));
        }
    }
}
