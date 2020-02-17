using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_4
{
    public class Arquivo_Layout_9_4_Cliente : Arquivo
    {
        protected override void CarregaCamposDoLayout(Linha linha)
        {
                linha.Campos.Add(new Campo("TIPO REGISTRO", 2));
                linha.Campos.Add(new Campo("CD_CLIENTE", 8));
                linha.Campos.Add(new Campo("NM_CLIENTE", 50));
                linha.Campos.Add(new Campo("NR_CNPJ_CPF", 14));
                linha.Campos.Add(new Campo("NR_RG", 10));
                linha.Campos.Add(new Campo("EN_ENDERECO", 50));
                linha.Campos.Add(new Campo("EN_NUMERO", 20));
                linha.Campos.Add(new Campo("EN_COMPLEMENTO", 50));
                linha.Campos.Add(new Campo("EN_BAIRRO", 50));
                linha.Campos.Add(new Campo("EN_CIDADE", 60));
                linha.Campos.Add(new Campo("EN_UF", 2));
                linha.Campos.Add(new Campo("EN_CEP", 8));
                linha.Campos.Add(new Campo("EN_PAIS", 50));
                linha.Campos.Add(new Campo("TIPO", 1));
                linha.Campos.Add(new Campo("SEXO", 1));
                linha.Campos.Add(new Campo("DT_NASCIMENTO", 8));
                linha.Campos.Add(new Campo("EMAIL", 60));
                linha.Campos.Add(new Campo("DDD_RESIDENCIAL", 2));
                linha.Campos.Add(new Campo("TELEFONE_RESIDENCIAL", 15));
                linha.Campos.Add(new Campo("DDD_COMERCIAL", 2));
                linha.Campos.Add(new Campo("TELEFONE_COMERCIAL", 15));
                linha.Campos.Add(new Campo("DDD_CELULAR", 2));
                linha.Campos.Add(new Campo("TELEFONE_CELULAR", 15));
                linha.Campos.Add(new Campo("FILLER,", 205));
        }
    }
}
