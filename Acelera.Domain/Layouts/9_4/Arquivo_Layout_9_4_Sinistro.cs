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
            linha.Campos.Add(new Campo("TIPO REGISTRO", 002));
            linha.Campos.Add(new Campo("CD_INTERNO_RESSEGURADOR", 005));
            linha.Campos.Add(new Campo("CD_SEGURADORA", 005));
            linha.Campos.Add(new Campo("CD_TIPO_MOVIMENTO", 004));
            linha.Campos.Add(new Campo("DT_MOVIMENTO", 008));
            linha.Campos.Add(new Campo("CD_AVISO", 008));
            linha.Campos.Add(new Campo("CD_SINISTRO", 020));
            linha.Campos.Add(new Campo("CD_CONTRATO_RESSEGURO", 005));
            linha.Campos.Add(new Campo("CD_RAMO", 004));
            linha.Campos.Add(new Campo("CD_CLIENTE", 008));
            linha.Campos.Add(new Campo("DT_AVISO", 008));
            linha.Campos.Add(new Campo("DT_OCORRENCIA", 008));
            linha.Campos.Add(new Campo("DT_REGISTRO", 008));
            linha.Campos.Add(new Campo("CD_CAUSA", 020));
            linha.Campos.Add(new Campo("CD_CONTRATO", 020));
            linha.Campos.Add(new Campo("NR_SEQ_EMISSAO", 005));
            linha.Campos.Add(new Campo("NR_APOLICE", 020));
            linha.Campos.Add(new Campo("CD_ITEM", 018));
            linha.Campos.Add(new Campo("CD_MOVIMENTO", 008));
            linha.Campos.Add(new Campo("VL_MOVIMENTO", 016));
            linha.Campos.Add(new Campo("TP_SINISTRO", 002));
            linha.Campos.Add(new Campo("VL_TAXA_PAGTO", 015));
            linha.Campos.Add(new Campo("NM_BENEFICIARIO", 060));
            linha.Campos.Add(new Campo("EN_BENEFICIARIO", 050));
            linha.Campos.Add(new Campo("EN_COMPL_BENEFICIARIO", 020));
            linha.Campos.Add(new Campo("EN_BAIRRO_BENEFICIARIO", 030));
            linha.Campos.Add(new Campo("EN_CIDADE_BENEFICIARIO", 030));
            linha.Campos.Add(new Campo("EN_UF_BENEFICIARIO", 002));
            linha.Campos.Add(new Campo("EN_CEP_BENEFICIARIO", 010));
            linha.Campos.Add(new Campo("EN_PAIS_BENEFICIARIO", 020));
            linha.Campos.Add(new Campo("DT_NASC_BENEFICIARIO", 008));
            linha.Campos.Add(new Campo("CD_COBERTURA", 010));
            linha.Campos.Add(new Campo("CD_MOEDA", 001));
            linha.Campos.Add(new Campo("CD_BANCO_SEG", 004));
            linha.Campos.Add(new Campo("NR_AGENCIA_SEG", 004));
            linha.Campos.Add(new Campo("NR_AGENCIA_DIG_SEG", 001));
            linha.Campos.Add(new Campo("NR_CONTA_SEG", 009));
            linha.Campos.Add(new Campo("NR_CONTA_DIG_SEG", 002));
            linha.Campos.Add(new Campo("CD_FORMA_PAGTO", 001));
            linha.Campos.Add(new Campo("CD_SISTEMA", 003));
            linha.Campos.Add(new Campo("DT_PAGAMENTO", 008));
            linha.Campos.Add(new Campo("NR_SEQ_MOV", 006));
            linha.Campos.Add(new Campo("VL_CEDIDO", 016));
            linha.Campos.Add(new Campo("CD_TIPO_BENEFICIARIO", 001));
            linha.Campos.Add(new Campo("NR_DOCTO_BENEFICIARIO", 020));
            linha.Campos.Add(new Campo("CD_PRODUTO", 010));
            linha.Campos.Add(new Campo("TP_RAMO_SINISTRO", 002));
            linha.Campos.Add(new Campo("NR_ENDOSSO", 020));
            linha.Campos.Add(new Campo("CD_BANCO", 004));
            linha.Campos.Add(new Campo("NR_AGENCIA", 004));
            linha.Campos.Add(new Campo("NR_AGENCIA_DIG", 001));
            linha.Campos.Add(new Campo("NR_CONTA", 009));
            linha.Campos.Add(new Campo("NR_CONTA_DIG", 002));
            linha.Campos.Add(new Campo("FILLER", 115));
        }
    }
}
