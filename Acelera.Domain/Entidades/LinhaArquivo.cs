﻿using Acelera.Contratos;
using Acelera.Domain.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Acelera.Domain.Layouts
{
    [Serializable]
    public class LinhaArquivo : ILinhaArquivo
    {
        public List<ICampoDoArquivo> Campos { get; set; }

        public OperadoraEnum OperadoraDoArquivo { get;private set; }

        public int Index { get; set; }

        public Guid Id { get; set; }
        public string this[string nomeCampo]
        {
            get => ObterCampoDoArquivo(nomeCampo).ValorFormatado;
        }

        public LinhaArquivo(int index, OperadoraEnum operadora)
        {
            Campos = new List<ICampoDoArquivo>();
            Index = index;
            Id = Guid.NewGuid();
            OperadoraDoArquivo = operadora;
        }


        public ICampoDoArquivo ObterCampoDoBanco(string nomeCampo)
        {
            var campo = Campos.Where(x => x.Coluna.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            if (campo == null)
                campo = ObterCampoDoArquivo(nomeCampo);
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo;
        }

        public ICampoDoArquivo ObterCampoDoArquivo(string nomeCampo)
        {
            var campo = Campos.Where(x => x.ColunaArquivo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo;
        }

        public string ObterValorFormatado(string nomeCampo)
        {
            var campo = Campos.Where(x => x.ColunaArquivo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo.ValorFormatado;
        }

        public int ObterValorInteiro(string nomeCampo)
        {
            var campo = Campos.Where(x => x.ColunaArquivo.ToUpper() == nomeCampo.ToUpper()).FirstOrDefault();
            Assert.IsNotNull(campo, $"CAMPO NAO ENCONTRADO : '{nomeCampo}'");
            return campo.ValorInteiro;
        }

        public ICampoDoArquivo ObterCampoSeExistir(string nomeCampo)
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

        public ILinhaArquivo Clone()
        {
            var linha = new LinhaArquivo(Index,OperadoraDoArquivo);
            foreach (var c in Campos)
                linha.Campos.Add(c.Clone());
            linha.Id = Guid.NewGuid();
            return linha;
        }
    }
}