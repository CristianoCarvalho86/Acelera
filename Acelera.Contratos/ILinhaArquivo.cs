using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Acelera.Contratos
{
    public interface ILinhaArquivo
    {
        List<ICampoDoArquivo> Campos { get; set; }

        OperadoraEnum OperadoraDoArquivo { get; }

        int Index { get; set; }

        Guid Id { get; set; }

        string this[string nomeCampo] { get; }

        ICampoDoArquivo ObterCampoDoBanco(string nomeCampo);

        ICampoDoArquivo ObterCampoDoArquivo(string nomeCampo);

        string ObterValorFormatado(string nomeCampo);

        int ObterValorInteiro(string nomeCampo);

        ICampoDoArquivo ObterCampoSeExistir(string nomeCampo);

        void CarregaTexto(string texto);

        string ObterTexto();

        ILinhaArquivo Clone();
    }
}
