using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Acelera.Domain.Layouts
{
    public class LinhaArquivo
    {
        public List<CampoDoArquivo> Campos { get; set; }
        public LinhaArquivo()
        {
            Campos = new List<CampoDoArquivo>();
        }

        public CampoDoArquivo ObterCampo(string nomeCampo)
        {
            var campo = Campos.Where(x => x.Coluna.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            Assert.IsNotNull(campo, "CAMPO NAO ENCONTRADO");
            return campo;
        }

        public void CarregaTexto(string texto)
        {
            int posicao = 0;
            foreach (var campo in Campos)
            {
                campo.AlterarValor(texto.Substring(posicao,campo.Posicoes));
                posicao = posicao + campo.Posicoes;
            }
        }

        public string ObterTexto()
        {
            var texto = "";
            foreach (var campo in Campos)
            {
                texto += campo.Valor;
            }
            return texto;
        }
    }
}