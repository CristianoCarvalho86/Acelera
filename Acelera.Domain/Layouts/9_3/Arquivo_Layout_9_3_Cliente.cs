using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts._9_3
{
    public class Arquivo_Layout_9_3_Cliente : Arquivo
    {
        protected override void CarregaCamposDoLayout(LinhaArquivo linha)
        {
            linha.Campos.Add(new CampoDoArquivo("TIPO REGISTRO", 2));
            linha.Campos.Add(new CampoDoArquivo("CD_CLIENTE", 8));
            linha.Campos.Add(new CampoDoArquivo("NM_CLIENTE", 50));
            linha.Campos.Add(new CampoDoArquivo("NR_CNPJ_CPF", 14));
            linha.Campos.Add(new CampoDoArquivo("NR_RG", 10));
            linha.Campos.Add(new CampoDoArquivo("EN_ENDERECO", 50));
            linha.Campos.Add(new CampoDoArquivo("EN_NUMERO", 20));
            linha.Campos.Add(new CampoDoArquivo("EN_COMPLEMENTO", 50));
            linha.Campos.Add(new CampoDoArquivo("EN_BAIRRO", 50));
            linha.Campos.Add(new CampoDoArquivo("EN_CIDADE", 60));
            linha.Campos.Add(new CampoDoArquivo("EN_UF", 2));
            linha.Campos.Add(new CampoDoArquivo("EN_CEP", 8));
            linha.Campos.Add(new CampoDoArquivo("EM_PAIS", 50));
            linha.Campos.Add(new CampoDoArquivo("TIPO", 1));
            linha.Campos.Add(new CampoDoArquivo("SEXO", 1));
            linha.Campos.Add(new CampoDoArquivo("DT_NASCIMENTO", 8));
            linha.Campos.Add(new CampoDoArquivo("EMAIL", 60));
            linha.Campos.Add(new CampoDoArquivo("DDD_Residencial", 2));
            linha.Campos.Add(new CampoDoArquivo("Telefone_Residencial", 15));
            linha.Campos.Add(new CampoDoArquivo("DDD_Comercial", 2));
            linha.Campos.Add(new CampoDoArquivo("Telefone_Comercial", 15));
            linha.Campos.Add(new CampoDoArquivo("DDD_Celular", 2));
            linha.Campos.Add(new CampoDoArquivo("Telefone_Celular", 15));
            linha.Campos.Add(new CampoDoArquivo("FILLER", 205));
        }
    }
}
