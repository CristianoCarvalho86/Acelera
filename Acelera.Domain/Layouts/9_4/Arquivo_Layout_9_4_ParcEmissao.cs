using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_ParcEmissao : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
                linha.Campos.Add(new Campo("TIPO REGISTRO", 002));
                linha.Campos.Add(new Campo("CD_INTERNO_RESSEGURADOR", 005));
                linha.Campos.Add(new Campo("CD_RAMO", 002));
                linha.Campos.Add(new Campo("CD_MOVTO_COBRANCA", 003));
                linha.Campos.Add(new Campo("CD_SEGURADORA", 005));
                linha.Campos.Add(new Campo("CD_SUCURSAL", 005));
                linha.Campos.Add(new Campo("CD_CORRETOR", 007));
                linha.Campos.Add(new Campo("CD_TIPO_OPERACAO", 002));
                linha.Campos.Add(new Campo("CD_TIPO_EMISSAO", 005));
                linha.Campos.Add(new Campo("CD_FORMA_PAGTO", 002));
                linha.Campos.Add(new Campo("CD_CATEGORIA", 002));
                linha.Campos.Add(new Campo("CD_FRANQUIA", 002));
                linha.Campos.Add(new Campo("CD_SUSEP_CONTRATO", 005));
                linha.Campos.Add(new Campo("CD_SISTEMA", 003));
                linha.Campos.Add(new Campo("CD_CONTRATO", 020));
                linha.Campos.Add(new Campo("NR_SEQUENCIAL_EMISSAO", 005));
                linha.Campos.Add(new Campo("NR_PARCELA", 002));
                linha.Campos.Add(new Campo("CD_COBERTURA", 010));
                linha.Campos.Add(new Campo("CD_ITEM", 020));
                linha.Campos.Add(new Campo("CD_CLIENTE", 008));
                linha.Campos.Add(new Campo("CD_MOEDA", 003));
                linha.Campos.Add(new Campo("DT_REFERENCIA", 008));
                linha.Campos.Add(new Campo("NR_PROPOSTA", 020));
                linha.Campos.Add(new Campo("DT_PROPOSTA", 008));
                linha.Campos.Add(new Campo("DT_EMISSAO", 008));
                linha.Campos.Add(new Campo("DT_EMISSAO_ORIGINAL", 008));
                linha.Campos.Add(new Campo("DT_INICIO_VIGENCIA", 008));
                linha.Campos.Add(new Campo("DT_FIM_VIGENCIA", 008));
                linha.Campos.Add(new Campo("NR_APOLICE", 020));
                linha.Campos.Add(new Campo("NR_APOLICE_ORIGINAL", 020));
                linha.Campos.Add(new Campo("NR_ENDOSSO", 020));
                linha.Campos.Add(new Campo("NR_DOCUMENTO", 020));
                linha.Campos.Add(new Campo("VL_JUROS", 016));
                linha.Campos.Add(new Campo("VL_DESCONTO", 016));
                linha.Campos.Add(new Campo("DT_VENCIMENTO", 008));
                linha.Campos.Add(new Campo("VL_PREMIO_LIQUIDO", 016));
                linha.Campos.Add(new Campo("VL_IOF", 016));
                linha.Campos.Add(new Campo("VL_ADIC_FRACIONADO", 016));
                linha.Campos.Add(new Campo("VL_CUSTO_APOLICE", 016));
                linha.Campos.Add(new Campo("VL_PREMIO_TOTAL", 016));
                linha.Campos.Add(new Campo("VL_TAXA_MOEDA", 015));
                linha.Campos.Add(new Campo("CD_STATUS_EMISSAO", 002));
                linha.Campos.Add(new Campo("VL_LMI", 016));
                linha.Campos.Add(new Campo("VL_IS", 016));
                linha.Campos.Add(new Campo("VL_PERCENTUAL_COSSEGURO", 005));
                linha.Campos.Add(new Campo("VL_PREMIO_CEDIDO", 016));
                linha.Campos.Add(new Campo("VL_COMISSAO_CEDIDO", 016));
                linha.Campos.Add(new Campo("CD_REGIAO", 010));
                linha.Campos.Add(new Campo("VL_FRANQUIA", 016));
                linha.Campos.Add(new Campo("CD_PRODUTO", 010));
                linha.Campos.Add(new Campo("ID_TRANSACAO", 040));
                linha.Campos.Add(new Campo("ID_TRANSACAO_CANC", 040));
                linha.Campos.Add(new Campo("CD_PLANO", 005));
                linha.Campos.Add(new Campo("CD_UF_RISCO", 002));
                linha.Campos.Add(new Campo("FILLER", 105));
        }
    }
}
