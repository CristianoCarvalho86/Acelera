using Acelera.Domain.Entidades;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        public string NomeBanco { get; set; }

        public override string Coluna { get => ObterColuna(); set => base.Coluna = value; }

        public override string ColunaArquivo { get => base.Coluna; }

        public CampoDoArquivo(string nomeCampo,int posicoes): base(nomeCampo)
        {
            Posicoes = posicoes;
        }

        public CampoDoArquivo(string nomeCampo, int posicoes, string nomeNoBanco) : base(nomeCampo)
        {
            Posicoes = posicoes;
            NomeBanco = nomeNoBanco;
        }

        private string ObterColuna()
        {
            if (string.IsNullOrEmpty(NomeBanco))
                return base.Coluna;
            else
                return NomeBanco;
        }

        public void AlterarValor(string novoValor)
        {
            var numEspacosVazios = this.Posicoes - novoValor.Length;
            var espacosBrancos = string.Empty;
            for (int i = 0; i < numEspacosVazios; i++)
                espacosBrancos += " ";

            Valor = espacosBrancos + novoValor;

            Assert.IsTrue(Valor.Length == this.Posicoes,
                $"ERRO AO ALTERAR ARQUIVO - CAMPO '{ColunaArquivo}' ESTOUROU O LIMITE DE POSIÇÕES. MAX: '{this.Posicoes}'");

        }
    }
}
