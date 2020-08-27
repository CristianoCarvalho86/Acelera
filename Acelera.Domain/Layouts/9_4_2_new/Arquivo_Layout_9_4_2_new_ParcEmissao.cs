using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    [Serializable]

    public class Arquivo_Layout_9_4_2_new_ParcEmissao : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.ParcEmissao;
        public override string TextoVersaoHeader => "94.2";
        protected override string[] CamposChaves => new string[] { "NR_APOLICE", "NR_ENDOSSO" };
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_INTERNO_RESSEGURADOR", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_MOVTO_COBRANCA", 003));
            linha.Campos.Add(new CampoDoArquivo("CD_SEGURADORA", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_SUCURSAL", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_CORRETOR", 007));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_OPERACAO", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_EMISSAO", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_FORMA_PAGTO", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_CATEGORIA", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_FRANQUIA", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_SUSEP_CONTRATO", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 003));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 010));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 002));
            linha.Campos.Add(new CampoDoArquivo("CD_COBERTURA", 010));
            linha.Campos.Add(new CampoDoArquivo("CD_ITEM", 020));
            linha.Campos.Add(new CampoDoArquivo("CD_CLIENTE", 008));
            linha.Campos.Add(new CampoDoArquivo("CD_MOEDA", 003));
            linha.Campos.Add(new CampoDoArquivo("DT_REFERENCIA", 008));
            linha.Campos.Add(new CampoDoArquivo("NR_PROPOSTA", 020));
            linha.Campos.Add(new CampoDoArquivo("DT_PROPOSTA", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_EMISSAO", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_EMISSAO_ORIGINAL", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_INICIO_VIGENCIA", 008));
            linha.Campos.Add(new CampoDoArquivo("DT_FIM_VIGENCIA", 008));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE_ORIGINAL", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 020));
            linha.Campos.Add(new CampoDoArquivo("NR_DOCUMENTO", 020));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_DESCONTO", 016));
            linha.Campos.Add(new CampoDoArquivo("DT_VENCIMENTO", 008));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_LIQUIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_IOF", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_ADIC_FRACIONADO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_CUSTO_APOLICE", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_TOTAL", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_TAXA_MOEDA", 015));
            linha.Campos.Add(new CampoDoArquivo("CD_STATUS_EMISSAO", 002));
            linha.Campos.Add(new CampoDoArquivo("VL_LMI", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_IS", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_PERCENTUAL_COSSEGURO", 005));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_CEDIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("VL_COMISSAO_CEDIDO", 016));
            linha.Campos.Add(new CampoDoArquivo("CD_REGIAO", 010));
            linha.Campos.Add(new CampoDoArquivo("VL_FRANQUIA", 016));
            linha.Campos.Add(new CampoDoArquivo("CD_PRODUTO", 010));
            linha.Campos.Add(new CampoDoArquivo("ID_TRANSACAO", 040));
            linha.Campos.Add(new CampoDoArquivo("ID_TRANSACAO_CANC", 040));
            linha.Campos.Add(new CampoDoArquivo("CD_PLANO", 005));
            linha.Campos.Add(new CampoDoArquivo("CD_UF_RISCO", 002));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 100));

        }
    }
}
