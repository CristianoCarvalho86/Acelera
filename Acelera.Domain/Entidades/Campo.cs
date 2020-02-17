using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts
{
    public class Campo
    {
        public int Posicoes { get; set; }
        public string Texto { get; private set; }
        public string NomeCampo { get; set; }

        public Campo(string nomeCampo,int posicoes)
        {
            Posicoes = posicoes;
            NomeCampo = nomeCampo;
        }

        public void AlterarValor(string novoValor)
        {
            var numEspacosVazios = this.Posicoes - novoValor.Length;
            var espacosBrancos = string.Empty;
            for (int i = 0; i < numEspacosVazios; i++)
                espacosBrancos += " ";

            Texto = espacosBrancos + novoValor;
        }
    }
}
