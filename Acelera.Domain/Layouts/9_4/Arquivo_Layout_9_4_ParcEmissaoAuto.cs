﻿using Acelera.Contratos;
using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    [Serializable]

    public class Arquivo_Layout_9_4_ParcEmissaoAuto : Arquivo
    {
        public override TipoArquivo tipoArquivo => TipoArquivo.ParcEmissaoAuto;
        public override string TextoVersaoHeader => "9.4";
        protected override string[] CamposChaves => new string[] { "NR_APOLICE", "NR_ENDOSSO" };
        protected override void CarregaCamposDoLayout(ILinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_INTERNO_RESSEGURADOR", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_RAMO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_MOVTO_COBRANCA", 3));
            linha.Campos.Add(new CampoDoArquivo("CD_SEGURADORA", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_SUCURSAL", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_CORRETOR", 7));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_OPERACAO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_TIPO_EMISSAO", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_FORMA_PAGTO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_CATEGORIA", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_FRANQUIA", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_SUSEP_CONTRATO", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_SISTEMA", 3));
            linha.Campos.Add(new CampoDoArquivo("CD_CONTRATO", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_SEQUENCIAL_EMISSAO", 5));
            linha.Campos.Add(new CampoDoArquivo("NR_PARCELA", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_COBERTURA", 10));
            linha.Campos.Add(new CampoDoArquivo("CD_ITEM", 20));
            linha.Campos.Add(new CampoDoArquivo("CD_CLIENTE", 8));
            linha.Campos.Add(new CampoDoArquivo("CD_MOEDA", 3));
            linha.Campos.Add(new CampoDoArquivo("DT_REFERENCIA", 8));
            linha.Campos.Add(new CampoDoArquivo("NR_PROPOSTA", 20));
            linha.Campos.Add(new CampoDoArquivo("DT_PROPOSTA", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_EMISSAO", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_EMISSAO_ORIGINAL", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_INICIO_VIGENCIA", 8));
            linha.Campos.Add(new CampoDoArquivo("DT_FIM_VIGENCIA", 8));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_APOLICE_ORIGINAL", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_ENDOSSO", 20));
            linha.Campos.Add(new CampoDoArquivo("NR_DOCUMENTO", 20));
            linha.Campos.Add(new CampoDoArquivo("VL_JUROS", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_DESCONTO", 16));
            linha.Campos.Add(new CampoDoArquivo("DT_VENCIMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_LIQUIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_IOF", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_ADIC_FRACIONADO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_CUSTO_APOLICE", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_TOTAL", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_TAXA_MOEDA", 15));
            linha.Campos.Add(new CampoDoArquivo("CD_STATUS_EMISSAO", 2));
            linha.Campos.Add(new CampoDoArquivo("VL_LMI", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_IS", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_PERCENTUAL_COSSEGURO", 5));
            linha.Campos.Add(new CampoDoArquivo("VL_PREMIO_CEDIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("VL_COMISSAO_CEDIDO", 16));
            linha.Campos.Add(new CampoDoArquivo("CD_REGIAO", 10));
            linha.Campos.Add(new CampoDoArquivo("VL_FRANQUIA", 16));
            linha.Campos.Add(new CampoDoArquivo("CD_PRODUTO", 10));
            linha.Campos.Add(new CampoDoArquivo("ID_TRANSACAO", 40));
            linha.Campos.Add(new CampoDoArquivo("ID_TRANSACAO_CANC", 40));
            linha.Campos.Add(new CampoDoArquivo("CD_PLANO", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_UF_RISCO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_MODALIDADE", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_MODELO", 8));
            linha.Campos.Add(new CampoDoArquivo("ANO_MODELO", 4));
            linha.Campos.Add(new CampoDoArquivo("VL_PERC_FATOR", 5));
            linha.Campos.Add(new CampoDoArquivo("VL_PERC_BONUS", 5));
            linha.Campos.Add(new CampoDoArquivo("CD_CLASSE_BONUS", 1));
            linha.Campos.Add(new CampoDoArquivo("SEXO_CONDUTOR", 1));
            linha.Campos.Add(new CampoDoArquivo("DT_NASC_CONDUTOR", 8));
            linha.Campos.Add(new CampoDoArquivo("TEMPO_HAB", 3));
            linha.Campos.Add(new CampoDoArquivo("CD_UTILIZACAO", 2));
            linha.Campos.Add(new CampoDoArquivo("CEP_UTILIZACAO", 8));
            linha.Campos.Add(new CampoDoArquivo("CEP_PERNOITE", 8));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 50));
        }
    }
}
