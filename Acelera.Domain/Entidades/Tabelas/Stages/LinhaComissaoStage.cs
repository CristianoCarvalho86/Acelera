using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class LinhaComissaoStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.Comissao;

        protected override void CarregarCampos()
        {
            AddCampo("NM_ARQUIVO_TPA");
            AddCampo("CD_STATUS_PROCESSAMENTO");
            AddCampo("DT_INCLUSAO");
            AddCampo("DT_ARQUIVO");
            AddCampo("DT_PROCESSAMENTO");
            AddCampo("NM_TPA");
            AddCampo("CD_OPERACAO");
            AddCampo("CD_VERSAO_ARQUIVO");
            AddCampo("QT_LINHA_ARQUIVO");
            AddCampo("TIPO_REGISTRO");
            AddCampo("CD_INTERNO_RESSEGURADOR");
            AddCampo("CD_SEGURADORA");
            AddCampo("CD_CORRETOR");
            AddCampo("CD_RAMO");
            AddCampo("CD_CONTRATO");
            AddCampo("NR_SEQUENCIAL_EMISSAO");
            AddCampo("NR_PARCELA");
            AddCampo("CD_ITEM");
            AddCampo("CD_TIPO_COMISSAO");
            AddCampo("CD_COBERTURA");
            AddCampo("VL_COMISSAO");
            AddCampo("VL_BASE_CALCULO");
            AddCampo("PC_COMISSAO");
            AddCampo("PC_PARTICIPACAO");
            AddCampo("CD_SISTEMA");
            AddCampo("ID_REGISTRO");
            AddCampo("TP_MUDANCA");
            AddCampo("DT_MUDANCA");
            AddCampo("NR_ENDOSSO");

        }
    }
}
