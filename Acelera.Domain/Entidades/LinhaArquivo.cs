using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acelera.Domain.Layouts
{
    public class LinhaArquivo
    {
        public List<CampoDoArquivo> Campos { get; set; }
        public int Index { get; set; }
        public LinhaArquivo(int index)
        {
            Campos = new List<CampoDoArquivo>();
            Index = index;
        }

        public CampoDoArquivo ObterCampoDoBanco(string nomeCampo)
        {
            var campo = Campos.Where(x => x.Coluna.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            if (campo == null)
                campo = ObterCampoDoArquivo(nomeCampo);
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo;
        }

        public CampoDoArquivo ObterCampoDoArquivo(string nomeCampo)
        {
            var campo = Campos.Where(x => x.ColunaArquivo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo;
        }

        public CampoDoArquivo ObterCampoSeExistir(string nomeCampo)
        {
            var campo = Campos.Where(x => x.Coluna.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            if (campo == null)
                campo = Campos.Where(x => x.ColunaArquivo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
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

        public LinhaArquivo Clone()
        {
            var linha = new LinhaArquivo(Index);
            foreach (var c in Campos)
                linha.Campos.Add(c.Clone());
            return linha;
        }
    }
}