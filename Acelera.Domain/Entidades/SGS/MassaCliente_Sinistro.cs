using Acelera.Domain.Entidades.Tabelas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.SGS
{
    public class MassaCliente_Sinistro : EntidadeDeTabela<MassaCliente_Sinistro>
    {
        public string ID_SEQ { get; set; }
        public string ID_REGISTRO { get; set; }
        public string TP_REGISTRO { get; set; }
        public string CD_CLIENTE { get; set; }
        public string NM_CLIENTE { get; set; }
        public string NR_CNPJ_CPF { get; set; }
        public string NR_RG { get; set; }
        public string EN_ENDERECO { get; set; }
        public string EN_NUMERO { get; set; }
        public string EN_COMPLEMENTO { get; set; }
        public string EN_BAIRRO { get; set; }
        public string EN_CIDADE { get; set; }
        public string EN_UF { get; set; }
        public string EN_CEP { get; set; }
        public string EN_PAIS { get; set; }
        public string TP_PESSOA { get; set; }
        public string CD_SEXO { get; set; }
        public string DT_NASCIMENTO { get; set; }
        public string DS_EMAIL { get; set; }
        public string NR_DDD_RESIDENCIAL { get; set; }
        public string NR_TELEFONE_RESIDENCIAL { get; set; }
        public string NR_DDD_COMERCIAL { get; set; }
        public string NR_TELEFONE_COMERCIAL { get; set; }
        public string NR_DDD_CELULAR { get; set; }
        public string NR_TELEFONE_CELULAR { get; set; }
        public string NM_ARQUIVO_TPA { get; set; }
        public string CD_OPERACAO { get; set; }
        public string NM_TPA { get; set; }
        public string CD_STATUS_PROCESSAMENTO { get; set; }
        public string DT_ARQUIVO { get; set; }
        public string CD_VERSAO_ARQUIVO { get; set; }
        public string QT_LINHA_ARQUIVO { get; set; }

        public override string nomeTabela => "TB_MASS_SGS_SINISTRO_CLIENTE_0031";
    }
}
