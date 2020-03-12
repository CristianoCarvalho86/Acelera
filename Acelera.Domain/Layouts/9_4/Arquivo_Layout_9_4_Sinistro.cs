using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_Sinistro : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO REGISTRO", 002, "TIPO_REGISTRO"));
            linha.Campos.Add(new CampoDoArquivo("CD_INTERNO_RESSEGURADOR", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_SEGURADORA", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_MOVIMENTO", 004));
            linha.Campos.Add(new CampoDoArquivo("DT_MOVIMENTO", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_AVISO", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_SINISTRO", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO_RESSEGURO", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 004));
            linha.Campos.Add(new CampoDoArquivo("CD_CLIENTE", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_AVISO", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_OCORRENCIA", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_REGISTRO", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_CAUSA", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQ_EMISSAO", 005, "NR_SEQUENCIAL_EMISSAO"));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_ITEM", 018));
            linha.Campos.Add(new CampoDoArquivo("CD_MOVIMENTO", 008));
            linha.Campos.Add(new CampoDoArquivo("VL_MOVIMENTO", 016));
            linha.Campos.Add(new CampoDoArquivo("TP_SINISTRO", 002));
            linha.Campos.Add(new CampoDoArquivo("VL_TAXA_PAGTO", 015));
            linha.Campos.Add(new CampoDoArquivo("NM_BENEFICIARIO", 060));
            linha.Campos.Add(new CampoDoArquivo("EN_BENEFICIARIO", 050));
            linha.Campos.Add(new CampoDoArquivo("EN_COMPL_BENEFICIARIO", 020));
            linha.Campos.Add(new CampoDoArquivo("EN_BAIRRO_BENEFICIARIO", 030));
            linha.Campos.Add(new CampoDoArquivo("EN_CIDADE_BENEFICIARIO", 030));
            linha.Campos.Add(new CampoDoArquivo("EN_UF_BENEFICIARIO", 002));
            linha.Campos.Add(new CampoDoArquivo("EN_CEP_BENEFICIARIO", 010));
            linha.Campos.Add(new CampoDoArquivo("EN_PAIS_BENEFICIARIO", 020));
            linha.Campos.Add(new CampoDoArquivo("DT_NASC_BENEFICIARIO", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_COBERTURA", 010));
            linha.Campos.Add(new CampoDoArquivo("CD_MOEDA", 001));
            linha.Campos.Add(new CampoDoArquivo("CD_BANCO_SEG", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_SEG", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_DIG_SEG", 001));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_SEG", 009));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_DIG_SEG", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_FORMA_PAGTO", 001));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 003));
            linha.Campos.Add(new CampoDoArquivo("DT_PAGAMENTO", 008));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQ_MOV", 006));
            linha.Campos.Add(new CampoDoArquivo("VL_CEDIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_BENEFICIARIO", 001));
            linha.Campos.Add(new CampoDoArquivo("NR_DOCTO_BENEFICIARIO", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_PRODUTO", 010));
            linha.Campos.Add(new CampoDoArquivo("TP_RAMO_SINISTRO", 002));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_BANCO", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA", 004));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_DIG", 001));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA", 009));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_DIG", 002));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 115));
        }
    }
}
