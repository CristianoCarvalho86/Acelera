using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4_2
{
    public class Arquivo_Layout_9_4_2 : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
                linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
                linha.Campos.Add(new Campo("CD_INTERNO_RESSEGURADOR", 5));
                linha.Campos.Add(new Campo("CD_SEGURADORA", 5));
                linha.Campos.Add(new Campo("CD_TIPO_MOVIMENTO", 4));
                linha.Campos.Add(new Campo("DT_MOVIMENTO", 8));
                linha.Campos.Add(new Campo("CD_AVISO", 8));
                linha.Campos.Add(new Campo("CD_SINISTRO", 20));
                linha.Campos.Add(new Campo("CD_CONTRATO_RESSEGURO", 5));
                linha.Campos.Add(new Campo("CD_RAMO", 4));
                linha.Campos.Add(new Campo("CD_CLIENTE", 8));
                linha.Campos.Add(new Campo("DT_AVISO", 8));
                linha.Campos.Add(new Campo("DT_OCORRENCIA", 8));
                linha.Campos.Add(new Campo("DT_REGISTRO", 8));
                linha.Campos.Add(new Campo("CD_CAUSA", 20));
                linha.Campos.Add(new Campo("CD_CONTRATO", 20));
                linha.Campos.Add(new Campo("NR_SEQ_EMISSAO", 5));
                linha.Campos.Add(new Campo("NR_APOLICE", 20));
                linha.Campos.Add(new Campo("CD_ITEM", 18));
                linha.Campos.Add(new Campo("CD_MOVIMENTO", 8));
                linha.Campos.Add(new Campo("VL_MOVIMENTO", 16));
                linha.Campos.Add(new Campo("TP_SINISTRO", 2));
                linha.Campos.Add(new Campo("VL_TAXA_PAGTO", 15));
                linha.Campos.Add(new Campo("NM_BENEFICIARIO", 60));
                linha.Campos.Add(new Campo("EN_BENEFICIARIO", 50));
                linha.Campos.Add(new Campo("EN_COMPL_BENEFICIARIO", 20));
                linha.Campos.Add(new Campo("EN_BAIRRO_BENEFICIARIO", 30));
                linha.Campos.Add(new Campo("EN_CIDADE_BENEFICIARIO", 30));
                linha.Campos.Add(new Campo("EN_UF_BENEFICIARIO", 2));
                linha.Campos.Add(new Campo("EN_CEP_BENEFICIARIO", 10));
                linha.Campos.Add(new Campo("EN_PAIS_BENEFICIARIO", 20));
                linha.Campos.Add(new Campo("DT_NASC_BENEFICIARIO", 8));
                linha.Campos.Add(new Campo("CD_COBERTURA", 10));
                linha.Campos.Add(new Campo("CD_MOEDA", 1));
                linha.Campos.Add(new Campo("CD_BANCO_SEG", 4));
                linha.Campos.Add(new Campo("NR_AGENCIA_SEG", 4));
                linha.Campos.Add(new Campo("NR_AGENCIA_DIG_SEG", 1));
                linha.Campos.Add(new Campo("NR_CONTA_SEG", 9));
                linha.Campos.Add(new Campo("NR_CONTA_DIG_SEG", 2));
                linha.Campos.Add(new Campo("CD_FORMA_PAGTO", 1));
                linha.Campos.Add(new Campo("CD_SISTEMA", 3));
                linha.Campos.Add(new Campo("DT_PAGAMENTO", 8));
                linha.Campos.Add(new Campo("NR_SEQ_MOV", 6));
                linha.Campos.Add(new Campo("VL_CEDIDO", 16));
                linha.Campos.Add(new Campo("CD_TIPO_BENEFICIARIO", 1));
                linha.Campos.Add(new Campo("NR_DOCTO_BENEFICIARIO", 20));
                linha.Campos.Add(new Campo("CD_PRODUTO", 10));
                linha.Campos.Add(new Campo("TP_RAMO_SINISTRO", 2));
                linha.Campos.Add(new Campo("NR_ENDOSSO", 20));
                linha.Campos.Add(new Campo("CD_BANCO", 4));
                linha.Campos.Add(new Campo("NR_AGENCIA", 4));
                linha.Campos.Add(new Campo("NR_AGENCIA_DIG", 1));
                linha.Campos.Add(new Campo("NR_CONTA", 9));
                linha.Campos.Add(new Campo("NR_CONTA_DIG", 2));
                linha.Campos.Add(new Campo("NR_DOCUMENTO", 20));
                linha.Campos.Add(new Campo("VL_JUROS", 16));
                linha.Campos.Add(new Campo("VL_CORRECAO_MONETARIA ", 16));
                linha.Campos.Add(new Campo("FILLER ", 63));
        }
    }
}
