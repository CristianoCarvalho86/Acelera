using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_EmsComissao : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
                linha.Campos.Add(new CampoDoArquivo("TIPO REGISTRO", 2, "TIPO_REGISTRO"));
                linha.Campos.Add(new CampoDoArquivo("CD_INTERNO_RESSEGURADOR", 5));
                linha.Campos.Add(new CampoDoArquivo("CD_SEGURADORA", 5));
                linha.Campos.Add(new CampoDoArquivo("CD_CORRETOR", 7));
                linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 2));
                linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 20, "NR_APOLICE"));
                linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 5));
                linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 4));
                linha.Campos.Add(new CampoDoArquivo("CD_ITEM", 4));
                linha.Campos.Add(new CampoDoArquivo("CD_TIPO_COMISSAO", 3));
                linha.Campos.Add(new CampoDoArquivo("CD_COBERTURA", 10));
                linha.Campos.Add(new CampoDoArquivo("VL_COMISSAO", 16));
                linha.Campos.Add(new CampoDoArquivo("VL_BASE_CALCULO", 16));
                linha.Campos.Add(new CampoDoArquivo("PC_COMISSAO", 8));
                linha.Campos.Add(new CampoDoArquivo("PC_PARTICIPACAO", 8));
                linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 3));
                linha.Campos.Add(new CampoDoArquivo("FILLER", 582));
        }
    }
}
