using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acelera.Domain.Enums;

namespace Acelera.Domain.Entidades.Stages
{
    public class LinhaClienteStage : LinhaTabela
    {
        public override TabelasEnum TabelaReferente => TabelasEnum.Cliente;

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
            AddCampo("CD_CLIENTE");
            AddCampo("NM_CLIENTE");
            AddCampo("NR_CNPJ_CPF");
            AddCampo("NR_RG");
            AddCampo("EN_ENDERECO");
            AddCampo("EN_NUMERO");
            AddCampo("EN_COMPLEMENTO");
            AddCampo("EN_BAIRRO");
            AddCampo("EN_CIDADE");
            AddCampo("EN_UF");
            AddCampo("EN_CEP");
            AddCampo("EN_PAIS");
            AddCampo("TP_PESSOA");
            AddCampo("CD_SEXO");
            AddCampo("DT_NASCIMENTO");
            AddCampo("DS_EMAIL");
            AddCampo("NR_DDD_RESIDENCIAL");
            AddCampo("NR_TELEFONE_RESIDENCIAL");
            AddCampo("NR_DDD_COMERCIAL");
            AddCampo("NR_TELEFONE_COMERCIAL");
            AddCampo("NR_DDD_CELULAR");
            AddCampo("NR_TELEFONE_CELULAR");
            AddCampo("ID_REGISTRO");
            AddCampo("TP_MUDANCA");
            AddCampo("DT_MUDANCA");

        }
    }
}
