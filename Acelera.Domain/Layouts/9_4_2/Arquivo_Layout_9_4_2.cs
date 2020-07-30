using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4_2
{
    public class Arquivo_Layout_9_4_2 : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.Sinistro;
        public override string TextoVersaoHeader => "9.4";
        protected override string[] CamposChaves => new string[] { "CD_SINISTRO", "CD_AVISO" };
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_INTERNO_RESSEGURADOR", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_SEGURADORA", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_MOVIMENTO", 4));
            linha.Campos.Add(new CampoDoArquivo("DT_MOVIMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_AVISO", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_SINISTRO", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO_RESSEGURO", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 4));
            linha.Campos.Add(new CampoDoArquivo("CD_CLIENTE", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_AVISO", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_OCORRENCIA", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_REGISTRO", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_CAUSA", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 5));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_ITEM", 18));
            linha.Campos.Add(new CampoDoArquivo("CD_MOVIMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("VL_MOVIMENTO", 16));
            linha.Campos.Add(new CampoDoArquivo("TP_SINISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("VL_TAXA_PAGTO", 15));
            linha.Campos.Add(new CampoDoArquivo("NM_BENEFICIARIO", 60));
            linha.Campos.Add(new CampoDoArquivo("EN_BENEFICIARIO", 50));
            linha.Campos.Add(new CampoDoArquivo("EN_COMPL_BENEFICIARIO", 20));
            linha.Campos.Add(new CampoDoArquivo("EN_BAIRRO_BENEFICIARIO", 30));
            linha.Campos.Add(new CampoDoArquivo("EN_CIDADE_BENEFICIARIO", 30));
            linha.Campos.Add(new CampoDoArquivo("EN_UF_BENEFICIARIO", 2));
            linha.Campos.Add(new CampoDoArquivo("EN_CEP_BENEFICIARIO", 10));
            linha.Campos.Add(new CampoDoArquivo("EN_PAIS_BENEFICIARIO", 20));
            linha.Campos.Add(new CampoDoArquivo("DT_NASC_BENEFICIARIO", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_COBERTURA", 10));
            linha.Campos.Add(new CampoDoArquivo("CD_MOEDA", 1));
            linha.Campos.Add(new CampoDoArquivo("CD_BANCO_SEG", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_SEG", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_DIG_SEG", 1));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_SEG", 9));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_DIG_SEG", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_FORMA_PAGTO", 1));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 3));
            linha.Campos.Add(new CampoDoArquivo("DT_PAGAMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQ_MOV", 6));
            linha.Campos.Add(new CampoDoArquivo("VL_CEDIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_BENEFICIARIO", 1));
            linha.Campos.Add(new CampoDoArquivo("NR_DOCTO_BENEFICIARIO", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_PRODUTO", 10));
            linha.Campos.Add(new CampoDoArquivo("TP_RAMO_SINISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_BANCO", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA", 4));
            linha.Campos.Add(new CampoDoArquivo("NR_AGENCIA_DIG", 1));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA", 9));
            linha.Campos.Add(new CampoDoArquivo("NR_CONTA_DIG", 2));
            linha.Campos.Add(new CampoDoArquivo("NR_DOCUMENTO", 20));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_CORRECAO_MONETARIA", 16));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 63));
        }
    }
}
