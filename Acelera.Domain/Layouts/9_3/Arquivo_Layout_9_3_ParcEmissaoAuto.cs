using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    public class Arquivo_Layout_9_3_ParcEmissaoAuto : Arquivo
    {
        protected override void CarregaCamposDoLayout(Linha linha)
        {
            linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
            linha.Campos.Add(new Campo("CD_INTERNO_RESSEGURADOR", 5));
            linha.Campos.Add(new Campo("CD_RAMO", 2));
            linha.Campos.Add(new Campo("CD_MOVTO_COBRANCA", 3));
            linha.Campos.Add(new Campo("CD_SEGURADORA", 5));
            linha.Campos.Add(new Campo("CD_SUCURSAL", 5));
            linha.Campos.Add(new Campo("CD_CORRETOR", 7));
            linha.Campos.Add(new Campo("CD_TIPO_OPERACAO", 2));
            linha.Campos.Add(new Campo("CD_TIPO_EMISSAO", 5));
            linha.Campos.Add(new Campo("CD_FORMA_PAGTO", 2));
            linha.Campos.Add(new Campo("CD_CATEGORIA", 2));
            linha.Campos.Add(new Campo("CD_FRANQUIA", 2));
            linha.Campos.Add(new Campo("CD_SUSEP_CONTRATO", 5));
            linha.Campos.Add(new Campo("CD_SISTEMA", 3));
            linha.Campos.Add(new Campo("CD_CONTRATO", 20));
            linha.Campos.Add(new Campo("NR_SEQUENCIAL_EMISSAO", 5));
            linha.Campos.Add(new Campo("NR_PARCELA", 2));
            linha.Campos.Add(new Campo("CD_COBERTURA", 10));
            linha.Campos.Add(new Campo("CD_ITEM", 20));
            linha.Campos.Add(new Campo("CD_CLIENTE", 8));
            linha.Campos.Add(new Campo("CD_MOEDA", 3));
            linha.Campos.Add(new Campo("DT_REFERENCIA", 8));
            linha.Campos.Add(new Campo("NR_PROPOSTA", 20));
            linha.Campos.Add(new Campo("DT_PROPOSTA", 8));
            linha.Campos.Add(new Campo("DT_EMISSAO", 8));
            linha.Campos.Add(new Campo("DT_EMISSAO_ORIGINAL", 8));
            linha.Campos.Add(new Campo("DT_INICIO_VIGENCIA", 8));
            linha.Campos.Add(new Campo("DT_FIM_VIGENCIA", 8));
            linha.Campos.Add(new Campo("NR_APOLICE", 20));
            linha.Campos.Add(new Campo("NR_APOLICE_ORIGINAL", 20));
            linha.Campos.Add(new Campo("NR_ENDOSSO", 20));
            linha.Campos.Add(new Campo("NR_DOCUMENTO", 20));
            linha.Campos.Add(new Campo("VL_JUROS", 16));
            linha.Campos.Add(new Campo("VL_DESCONTO", 16));
            linha.Campos.Add(new Campo("DT_VENCIMENTO", 8));
            linha.Campos.Add(new Campo("VL_PREMIO_LIQUIDO", 16));
            linha.Campos.Add(new Campo("VL_IOF", 16));
            linha.Campos.Add(new Campo("VL_ADIC_FRACIONADO", 16));
            linha.Campos.Add(new Campo("VL_CUSTO_APOLICE", 16));
            linha.Campos.Add(new Campo("VL_PREMIO_TOTAL", 16));
            linha.Campos.Add(new Campo("VL_TAXA_MOEDA", 15));
            linha.Campos.Add(new Campo("CD_STATUS_EMISSAO", 2));
            linha.Campos.Add(new Campo("VL_LMI", 16));
            linha.Campos.Add(new Campo("VL_IS", 16));
            linha.Campos.Add(new Campo("VL_PERCENTUAL_COSSEGURO", 5));
            linha.Campos.Add(new Campo("VL_PREMIO_CEDIDO", 16));
            linha.Campos.Add(new Campo("VL_COMISSAO_CEDIDO", 16));
            linha.Campos.Add(new Campo("CD_REGIAO", 10));
            linha.Campos.Add(new Campo("VL_FRANQUIA", 16));
            linha.Campos.Add(new Campo("CD_PRODUTO", 10));
            linha.Campos.Add(new Campo("ID_TRANSACAO", 40));
            linha.Campos.Add(new Campo("ID_TRANSACAO_CANC", 40));
            linha.Campos.Add(new Campo("CD_PLANO", 5));
            linha.Campos.Add(new Campo("CD_UF_RISCO", 2));
            linha.Campos.Add(new Campo("CD_MODALIDADE", 2));
            linha.Campos.Add(new Campo("CD_MODELO", 8));
            linha.Campos.Add(new Campo("ANO_MODELO", 4));
            linha.Campos.Add(new Campo("VL_PERC_FATOR", 5));
            linha.Campos.Add(new Campo("VL_PERC_BONUS", 5));
            linha.Campos.Add(new Campo("CD_CLASSE_BONUS", 1));
            linha.Campos.Add(new Campo("SEXO_CONDUTOR", 1));
            linha.Campos.Add(new Campo("DT_NASC_CONDUTOR", 8));
            linha.Campos.Add(new Campo("TEMPO_HAB", 3));
            linha.Campos.Add(new Campo("CD_UTILIZACAO", 2));
            linha.Campos.Add(new Campo("CEP_UTILIZACAO", 8));
            linha.Campos.Add(new Campo("CEP_PERNOITE", 8));
            linha.Campos.Add(new Campo("FILLER", 50));
        }
    }
}
