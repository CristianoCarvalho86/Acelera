﻿using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public abstract class LinhaTabela
    {
        public abstract TabelasEnum TabelaReferente { get; }

        public List<CampoTabela> Campos;

        public LinhaTabela()
        {
            Campos = new List<CampoTabela>();
            CarregarCampos();
        }

        public string ObterNomeTabela()
        {
            return TabelaReferente.GetEnumDescription();
        }

        protected abstract void CarregarCampos();

        protected void AddCampo(string campo)
        {
            Campos.Add(new CampoTabela(campo.ToUpper()));
        }

        public void CarregarLinha(string retornoQuery)
        {
            var valores = retornoQuery.ToUpper().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(x => ExisteCampo(x));
            int IndexDoSeparador = 0;
            foreach(var valor in valores)
            {
                IndexDoSeparador = valor.IndexOf(':');
                var campo = Campos.Where(x => valor.Substring(0, IndexDoSeparador).Contains(x.Coluna)).First();
                campo.Valor = SepararResultado(valor, campo.Coluna);
            }
        }

        public bool Validar(string campo, string valorEsperado)
        {
            if (ObterPorColuna(campo).Valor == valorEsperado.ToUpper())
                return true;
            else
                return false;
        }

        private string SepararResultado(string valorBruto, string campo)
        {
            int startIndex = valorBruto.IndexOf(campo + ":") + campo.Length + 1;
            return valorBruto.Substring(startIndex);
        }

        private bool ExisteCampo(string campoValor)
        {
            return Campos.Any(x => x.Coluna.Contains(campoValor));
        }

        public CampoTabela ObterPorColuna(string coluna)
        {
            return Campos.Where(x => x.Coluna == coluna.ToUpper()).FirstOrDefault();
        }
    }
}
