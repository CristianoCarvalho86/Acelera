using Acelera.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts
{
    public class CampoDoArquivo : Campo
    {
        public int Posicoes { get; set; }

        public CampoDoArquivo(string nomeCampo,int posicoes): base(nomeCampo)
        {
            Posicoes = posicoes;
        }

        public void AlterarValor(string novoValor)
        {
            var numEspacosVazios = this.Posicoes - novoValor.Length;
            var espacosBrancos = string.Empty;
            for (int i = 0; i < numEspacosVazios; i++)
                espacosBrancos += " ";

            Valor = espacosBrancos + novoValor;
        }
    }
}
