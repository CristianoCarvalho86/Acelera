using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class LanctoComissaoStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.LanctoComissao;

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
            AddCampo("CD_RAMO");
            AddCampo("CD_CORRETOR");
            AddCampo("CD_CONTRATO");
            AddCampo("NR_SEQUENCIAL_EMISSAO");
            AddCampo("CD_TIPO_COMISSAO");
            AddCampo("NR_PARCELA");
            AddCampo("NR_APOLICE");
            AddCampo("NR_ENDOSSO");
            AddCampo("CD_EXTRATO_COMISSAO");
            AddCampo("NR_MES_REFERENCIA");
            AddCampo("CD_LANCAMENTO");
            AddCampo("CD_EVENTO");
            AddCampo("VL_COMISSAO_PAGO");
            AddCampo("DT_PAGAMENTO");
            AddCampo("DT_BAIXA");
            AddCampo("CD_SISTEMA");
            AddCampo("CD_TIPO_LANCAMENTO");
            AddCampo("ID_REGISTRO");
        

        }
    }
}
