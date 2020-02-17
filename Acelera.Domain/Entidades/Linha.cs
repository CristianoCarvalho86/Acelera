using System.Collections.Generic;
using System.Linq;

namespace Acelera.Domain.Layouts
{
    public class Linha
    {
        public List<Campo> Campos { get; set; }
        public Linha()
        {
            Campos = new List<Campo>();
        }

        public Campo ObterCampo(string nomeCampo)
        {
            return Campos.Where(x => x.NomeCampo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
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
                texto += campo.Texto;
            }
            return texto;
        }
    }
}