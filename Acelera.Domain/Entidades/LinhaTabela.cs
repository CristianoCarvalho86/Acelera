using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades
{
    public abstract class LinhaTabela
    {
        public abstract TabelasEnum TabelaReferente { get; }

        public List<Campo> Campos;

        public LinhaTabela()
        {
            Campos = new List<Campo>();
            CarregarCampos();
        }

        public string ObterNomeTabela()
        {
            return TabelaReferente.GetEnumDescription();
        }

        protected abstract void CarregarCampos();

        protected void AddCampo(string campo)
        {
            Campos.Add(new Campo(campo.ToUpper()));
        }

        public void CarregarLinhaPeloCMD(string retornoQuery)
        {
            var valores = retornoQuery.ToUpper().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Where(x => ExisteCampo(x));
            int IndexDoSeparador = 0;
            foreach (var valor in valores)
            {
                IndexDoSeparador = valor.IndexOf(':');
                var campo = Campos.Where(x => valor.Substring(0, IndexDoSeparador).Contains(x.Coluna)).First();
                campo.Valor = SepararResultado(valor, campo.Coluna);
            }
        }

        public void CarregarLinha(DataRow row)
        {
            foreach (var campo in Campos)
            {
                if (row[campo.Coluna] == null)
                    throw new Exception($"Coluna {campo.Coluna} nao encontrada no resultado da query.");
                campo.Valor = row[campo.Coluna].ToString();
            }
        }

        public override string ToString()
        {
            var retorno = "";
            foreach (var campo in Campos)
                retorno += $"[{campo.Coluna} : {campo.Valor}],";
            return retorno.Remove(retorno.Length - 1);
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

        public Campo ObterPorColuna(string coluna)
        {
            return Campos.Where(x => x.Coluna == coluna.ToUpper()).FirstOrDefault();
        }
    }
}
