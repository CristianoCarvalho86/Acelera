using Acelera.Domain.Entidades;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Layouts
{
    [Serializable]
    public abstract class Arquivo
    {
        protected string textoArquivo;
        public IList<LinhaArquivo> Header { get; set; }
        public IList<LinhaArquivo> Linhas { get; set; }
        public IList<LinhaArquivo> Footer { get; set; }

        public abstract TipoArquivo tipoArquivo { get; }

        public abstract string TextoVersaoHeader { get; }

        public string EnderecoCompleto { get; private set; }

        public string EnderecoCompletoArquivoSalvo { get; private set; }

        public IList<string> CamposDoBody => Linhas.FirstOrDefault()?.Campos?.Select(x => x.ColunaArquivo).ToList();

        public string NomeArquivo { get; private set; }
        
        public string NomeArquivoOriginal { get; private set; }

        private int LimiteDeLinhas;

        protected abstract string[] CamposChaves { get; }

        public LinhaArquivo UltimaLinha => Linhas[Linhas.Count - 1];

        public AlteracoesArquivo valoresAlteradosBody { get; set; }
        public AlteracoesArquivo valoresAlteradosHeader { get; set; }
        public AlteracoesArquivo valoresAlteradosFooter { get; set; }

        private OperadoraEnum? _operadora;
        public OperadoraEnum Operadora { 
            get 
            {
                if(!_operadora.HasValue)
                    _operadora = ObterOperadoraDoArquivo(NomeArquivo);
                return _operadora.Value;
            } 
        }
  
        public void AtualizarNomeArquivoFinal(string nomeArquivo)
        {
            NomeArquivoOriginal = NomeArquivo;
            NomeArquivo = nomeArquivo;
        }

        private OperadoraEnum ObterOperadoraDoArquivo(string nomeArquivo)
        {
            var lista = Enum.GetValues(typeof(OperadoraEnum)).Cast<OperadoraEnum>().ToList(); 
            foreach (var operadora in lista)
            {
                if (nomeArquivo.Contains(operadora.ObterTexto()))
                    return operadora;
            }
            throw new Exception("OPERACAO NAO ENCONTRADA NO NOME DO ARQUIVO : " + nomeArquivo);
        }

        public Arquivo()
        {
            valoresAlteradosBody = new AlteracoesArquivo();
            valoresAlteradosFooter = new AlteracoesArquivo();
            valoresAlteradosHeader = new AlteracoesArquivo();
        }

        public Arquivo Clone()
        {
            //var inst = this.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //var a = (Arquivo)inst?.Invoke(this, null);

            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                var arq = (Arquivo)binaryFormatter.Deserialize(memoryStream);
                arq.valoresAlteradosBody = new AlteracoesArquivo();
                arq.valoresAlteradosFooter = new AlteracoesArquivo();
                arq.valoresAlteradosHeader = new AlteracoesArquivo();
                return arq;
            }

            

            //Arquivo newObject = (Arquivo)Activator.CreateInstance(this.GetType());

            //foreach (var originalProp in this.GetType().GetProperties())
            //{
            //    originalProp.SetValue(newObject, originalProp.GetValue(this));
            //}

            //return newObject;
        }

        public Arquivo Carregar(string enderecoArquivo, int? qtdHeader = 1, int? qtdFooter = 1, int limiteDeLinhas = 0)
        {
            EnderecoCompleto = enderecoArquivo;
            LimiteDeLinhas = limiteDeLinhas;
            NomeArquivo = enderecoArquivo.Split('\\').LastOrDefault();
            textoArquivo = File.ReadAllText(enderecoArquivo);
            CarregarEstrutura(qtdHeader.HasValue ? qtdHeader.Value : 1, qtdFooter.HasValue ? qtdFooter.Value : 1);

            AjustarQtdLinhasNoFooter();

            return this;
        }

        protected void CarregarEstrutura(int qtdHeader, int qtdFooter)
        {
            var linhas = textoArquivo.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(x => x != string.Empty);
            Header = CarregaHeader(linhas.Take(qtdHeader));
            Footer = CarregaFooter(linhas.Reverse().Take(qtdFooter).Reverse());
            var linhasBody = linhas.Skip(1).ToList();
            linhasBody.RemoveAt(linhasBody.Count - 1);
            if (LimiteDeLinhas > 0)
                linhasBody = linhasBody.Take(LimiteDeLinhas).ToList();

            Linhas = CarregaLinhas(linhasBody);

        }

        public void CarregarNovasLinhasNoBody(string enderecoArquivo)
        {
            var _textoArquivo = File.ReadAllText(enderecoArquivo);
            var linhas = _textoArquivo.Split(new[] { Environment.NewLine }, StringSplitOptions.None).Where(x => x != string.Empty);
            var linhasBody = linhas.Skip(1).ToList();
            linhasBody.RemoveAt(linhasBody.Count - 1);

            var _linhas = CarregaLinhas(linhasBody);
            foreach (var linha in _linhas)
                Linhas.Add(linha);
            AjustarQtdLinhasNoFooter();

        }

        public void Salvar(string endereco)
        {
            NomeArquivo = endereco.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries).Last();

            var file = File.CreateText(endereco);

            EnderecoCompletoArquivoSalvo = endereco;

            foreach (var header in Header)
                file.WriteLine(header.ObterTexto());
            foreach (var item in Linhas)
                file.WriteLine(item.ObterTexto());
            foreach (var footer in Footer)
                file.WriteLine(footer.ObterTexto());

            file.Close();
        }

        public void RemoverLinhasRepetidas()
        {
            Linhas = Linhas.Distinct().ToList();
        }

        public virtual void AdicionaLinhaNoBody(LinhaArquivo linha)
        {
            Linhas.Add(linha.Clone());
            ReIndexar();
            AjustarQtdLinhasNoFooter();
        }
        public virtual void AdicionaLinhaNoBody(IList<LinhaArquivo> linhas)
        {
            foreach (var linha in linhas)
                Linhas.Add(linha.Clone());
            ReIndexar();
            AjustarQtdLinhasNoFooter();
        }

        public void AjustarQtdLinhasNoFooter()
        {
            AlterarFooter("QT_LIN", (Linhas.Count).ToString());
        }

        public string ObterValorFormatadoSeExistirCampo(int posicaoLinha, string campo)
        {
            if (!CamposDoBody.Contains(campo))
                return null;

            return Linhas.ToList()[posicaoLinha].ObterCampoDoArquivo(campo).ValorFormatado;
        }

        public string ObterValorFormatado(int posicaoLinha, string campo)
        {
            return Linhas.ToList()[posicaoLinha].ObterCampoDoArquivo(campo).ValorFormatado;
        }

        public int ObterValorInteiro(int posicaoLinha, string campo)
        {
            return int.Parse(Linhas.ToList()[posicaoLinha].ObterCampoDoArquivo(campo).ValorFormatado);
        }

        public decimal ObterValorDecimal(int posicaoLinha, string campo)
        {
            return decimal.Parse(Linhas.ToList()[posicaoLinha].ObterCampoDoArquivo(campo).ValorFormatado);
        }

        public LinhaArquivo ObterLinha(int posicaoLinha)
        {
            return Linhas.ToList()[posicaoLinha];
        }

        public LinhaArquivo ObterLinha(Guid idLinha)
        {
            return Linhas.ToList().Where(x => x.Id == idLinha).First();
        }

        public bool ExisteCampo(string nomeCampo)
        {
            if (!CamposDoBody.Contains(nomeCampo))
                return false;
            return true;
        }

        public IList<LinhaArquivo> ObterLinhasOndeCampoIgualAValor(string campo, string valor)
        {
            return Linhas.ToList().Where(x => x.ObterCampoDoArquivo(campo).ValorFormatado == valor).ToList();
        }

        public IList<LinhaArquivo> ObterLinhasComValores(string[] nomeCampo, string[] valor)
        {
            Assert.AreEqual(nomeCampo.Length, valor.Length, "ERRO DE NUMERO DE PARAMETROS");
            Assert.AreEqual(nomeCampo.Length, 6, "ERRO DE NUMERO DE PARAMETROS");

            return Linhas.ToList().Where(x => x.ObterCampoDoArquivo(nomeCampo[0]).ValorFormatado == valor[0]
            && x.ObterCampoDoArquivo(nomeCampo[1]).ValorFormatado == valor[1]
            && x.ObterCampoDoArquivo(nomeCampo[2]).ValorFormatado == valor[2]
            && x.ObterCampoDoArquivo(nomeCampo[3]).ValorFormatado == valor[3]
            && x.ObterCampoDoArquivo(nomeCampo[4]).ValorFormatado == valor[4]
            && x.ObterCampoDoArquivo(nomeCampo[5]).ValorFormatado == valor[5]).ToList();
        }

        public IList<LinhaArquivo> ObterLinhasComValores(string nomeCampo, string valorFormatado)
        {
            return Linhas.ToList().Where(x => x.ObterCampoDoArquivo(nomeCampo).ValorFormatado == valorFormatado).ToList();
        }

        public LinhaArquivo ObterLinhaHeader(int posicaoLinha = 0)
        {
            return Header[posicaoLinha];
        }

        public LinhaArquivo ObterLinhaFooter(int posicaoLinha = 0)
        {
            return Footer[posicaoLinha];
        }

        public void AlterarLinha(int posicaoLinha, string campo, string textoNovo)
        {
            Assert.IsTrue(posicaoLinha < Linhas.Count, $"Linha Informada nao pertece ao BODY, Body contem : {Linhas.Count} , valor informado{posicaoLinha}");
            ObterLinha(posicaoLinha).ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }
        public void AlterarLinhaComCampoIgualAValor(string campoBusca, string valorBusca, string campoAlteracao, string valorAlteracao)
        {
            var linhas = ObterLinhasComValores(campoBusca, valorBusca);
            foreach (var linha in linhas)
                linha.ObterCampoDoArquivo(campoAlteracao).AlterarValor(valorAlteracao);
        }

        public bool AlterarLinhaSeExistirCampo(int posicaoLinha, string campo, string textoNovo)
        {
            if (!ExisteCampo(campo))
                return false;

            Assert.IsTrue(posicaoLinha < Linhas.Count, $"Linha Informada nao pertece ao BODY, Body contem : {Linhas.Count} , valor informado{posicaoLinha}");
            ObterLinha(posicaoLinha).ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
            return true;
        }

        public void AlterarTodasAsLinhas(string campo, string textoNovo)
        {
            foreach (var linha in Linhas)
                linha.ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }

        public void AlterarHeader(string campo, string textoNovo, int posicaoLinhaHeader = 0)
        {
            Header[posicaoLinhaHeader].ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }

        public void ReplicarHeader(int quantidadeVezes, int posicaoLinhaHeader = 0)
        {
            for (int i = 0; i < quantidadeVezes; i++)
                Header.Add(Header[posicaoLinhaHeader]);
        }

        public void ReplicarFooter(int quantidadeVezes, int posicaoLinhaFooter = 0)
        {
            for (int i = 0; i < quantidadeVezes; i++)
                Footer.Add(Footer[posicaoLinhaFooter]);
        }

        public void AlterarFooter(string campo, string textoNovo, int posicaoLinhaFooter = 0)
        {
            Footer[posicaoLinhaFooter].ObterCampoDoArquivo(campo).AlterarValor(textoNovo);
        }

        public bool ValidarCampo(int posicaoLinha, string campo, string valor)
        {
            if (ObterValorFormatado(posicaoLinha, campo) == valor)
                return true;
            return false;
        }

        public void AdicionarLinha(LinhaArquivo linha, int? posicaoLinha = null)
        {
            if (posicaoLinha.HasValue)
                Linhas.Insert(posicaoLinha.Value, linha);
            else
                Linhas.Add(linha);

            AjustarQtdLinhasNoFooter();
            ReIndexar();
        }

        public void ReplicarLinha(int posicaoLinha, int quantidadeVezes)
        {
            for (int i = 0; i < quantidadeVezes; i++)
            {
                AdicionarLinha(ObterLinha(posicaoLinha).Clone(), posicaoLinha + 1);
            }

        }
        public void ReplicarLinhaComAjusteFooter(int posicaoLinha, int quantidadeVezes)
        {
            ReplicarLinha(posicaoLinha, quantidadeVezes);
            AjustarQtdLinhasNoFooter();
        }

        public void RemoverLinha(int posicaoLinha)
        {
            Linhas.RemoveAt(posicaoLinha);
            ReIndexar();
        }

        public void RemoverLinhaComAjuste(Guid idLinha)
        {
            Linhas.Remove(ObterLinha(idLinha));
            ReIndexar();
            AjustarQtdLinhasNoFooter();
        }

        public void RemoverLinhaComAjuste(int posicaoLinha)
        {
            RemoverLinha(posicaoLinha);
            AjustarQtdLinhasNoFooter();
        }

        public void RemoverHeader()
        {
            Header.RemoveAt(0);
        }

        public void RemoverFooter()
        {
            Footer.RemoveAt(0);
        }

        public void RemoverLinhas(int posicaoLinhaInicial, int quantidadeLinhas)
        {
            Linhas = Linhas.Where(x => x.Index < posicaoLinhaInicial || x.Index > (posicaoLinhaInicial + quantidadeLinhas)).ToList();
        }
        public void RemoverTodasLinhasDoBody()
        {
            Linhas = new List<LinhaArquivo>();
            AjustarQtdLinhasNoFooter();
        }

        public void RemoverExcetoEstas(int posicaoLinhaInicial, int quantidadeLinhas)
        {
            Linhas = Linhas.Where(x => x.Index >= posicaoLinhaInicial && x.Index < (posicaoLinhaInicial + quantidadeLinhas)).ToList();
            ReIndexar();
            AjustarQtdLinhasNoFooter();
        }

        public void RemoverLinhasMenosUma(int posicaoLinhaAManter)
        {
            Linhas = Linhas.Where(x => x.Index == posicaoLinhaAManter).ToList();
        }

        public void ReIndexar()
        {
            for (int i = 0; i < Linhas.Count; i++)
            {
                Linhas[i].Index = i;
            }
        }

        protected abstract void CarregaCamposDoLayout(LinhaArquivo linha);

        protected IList<LinhaArquivo> CarregaLinhas(IEnumerable<string> linhas)
        {
            var linhasPreenchidas = new List<LinhaArquivo>();
            LinhaArquivo linha;
            var count = 0;
            foreach (var l in linhas)
            {
                linha = new LinhaArquivo(count,Operadora);
                CarregaCamposDoLayout(linha);
                linha.CarregaTexto(l);
                linhasPreenchidas.Add(linha);
                count++;
            }
            return linhasPreenchidas;
        }

        protected virtual IList<LinhaArquivo> CarregaHeader(IEnumerable<string> linhas)
        {
            var listaHeader = new List<LinhaArquivo>();
            var count = 0;
            foreach (var linha in linhas)
            {
                var header = new LinhaArquivo(count, Operadora);
                header.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
                header.Campos.Add(new CampoDoArquivo("NM_ARQ", 30));
                header.Campos.Add(new CampoDoArquivo("DT_ARQ", 10));
                header.Campos.Add(new CampoDoArquivo("NR_ARQ", 6));
                header.Campos.Add(new CampoDoArquivo("NM_BRIDGE", 30));
                header.Campos.Add(new CampoDoArquivo("CD_TPA", 3, "CD_OPERACAO"));
                header.Campos.Add(new CampoDoArquivo("NOMEARQ", 40));
                header.Campos.Add(new CampoDoArquivo("VERSAO", 4));
                header.Campos.Add(new CampoDoArquivo("FILLER", 575));
                header.CarregaTexto(linha);
                ValidaHeader(header);
                listaHeader.Add(header);
                count++;
            }
            return listaHeader;
        }

        private void ValidaHeader(LinhaArquivo header)
        {
            //Assert.IsTrue(new string[] { "9.3", "9.4","9.6" }.Contains(header.ObterCampoDoArquivo("VERSAO").Valor.Trim()), "FORMATAÇÃO DO HEADER DO ARQUIVO ORIGEM NÃO ESTÁ CORRETA");
            var cdTpa = header.ObterCampoDoArquivo("CD_TPA").Valor.Trim();
            Assert.IsTrue(cdTpa.Length == 3 && int.TryParse(cdTpa, out int r), "CD_TPA DO HEADER DO ARQUIVO ORIGEM NÃO ESTÁ CORRETA");
        }

        protected virtual IList<LinhaArquivo> CarregaFooter(IEnumerable<string> linhas)
        {
            var listaFooter = new List<LinhaArquivo>();
            var count = 0;
            foreach (var linha in linhas)
            {
                var footer = new LinhaArquivo(count, Operadora);
                footer.Campos.Add(new CampoDoArquivo("TIPO_REGISTRO", 2));
                footer.Campos.Add(new CampoDoArquivo("NM_ARQ", 30));
                footer.Campos.Add(new CampoDoArquivo("QT_LIN", 6));
                footer.Campos.Add(new CampoDoArquivo("Filler", 662));
                footer.CarregaTexto(linha);
                listaFooter.Add(footer);
                count++;
            }
            return listaFooter;
        }

        public LinhaArquivo this[int posicao]
        {
            get => ObterLinha(posicao);
        }

        /// <summary>
        /// Busca a primeira linha para cada valor no campo especificado, removendo as outras.
        /// </summary>
        /// <param name="nomeCampo"></param>
        public void RemoverValoresRepetidosNoCampo(string nomeCampo)
        {
            var valoresUnicos = Linhas.Select(x => x.ObterValorFormatado(nomeCampo)).Distinct();
            var novaLista = new List<LinhaArquivo>();
            Parallel.ForEach(valoresUnicos, valor => {
                novaLista.Add(Linhas.Where(x => x.ObterValorFormatado(nomeCampo) == valor).First());
            });
            Linhas = novaLista;
        }

        public string MontarCamposChaveParaLog(int posicaoLinha)
        {
            if (CamposChaves.Count() == 0)
                throw new Exception("CAMPOS CHAVES NAO DEFINIDOS");

            var linha = ObterLinha(posicaoLinha);
            var texto = "";
            foreach (var campo in CamposChaves)
                texto +=  " " + campo + ": '" + linha.ObterCampoDoArquivo(campo).ValorFormatado + "' ;";
            return texto.Substring(0, texto.Length - 1);
        }

        public decimal SomarLinhasDoArquivo(string nomeCampo)
        {
            decimal retorno = 0M;
            foreach(var linha in Linhas)
            {
                retorno += linha.ObterCampoDoArquivo(nomeCampo).ValorDecimal;
            }
            return retorno;
        }

        public void SelecionarLinhas(string nomeCampo, string valorFormatado)
        {
            Linhas = Linhas.Where(x => x.ObterCampoDoArquivo(nomeCampo).ValorFormatado == valorFormatado).ToList() ;

            ReIndexar();
        }

        public LinhaArquivo SelecionarPrimeiraLinhaEncontrada(IList<KeyValuePair<string, string>> valoresDosCampos)
        {
            LinhaArquivo linhaEncontrada = null;
            Parallel.ForEach(Linhas, (linha, loopState) => {
                var linhaValida = true;
                foreach (var valorPorCampo in valoresDosCampos)
                {
                    if (linha.ObterValorFormatado(valorPorCampo.Key) != valorPorCampo.Value)
                        linhaValida = false;
                }
                if (linhaValida)
                {
                    linhaEncontrada = linha;
                    loopState.Break();
                }
            });
            return linhaEncontrada;
        }


        public IList<KeyValuePair<string, string>> ObterValoresDosCamposChaves(LinhaArquivo linha)
        {
            var lista = new List<KeyValuePair<string, string>>();
            foreach (var campoChave in CamposChaves)
            {
                lista.Add(new KeyValuePair<string, string>(campoChave, linha.ObterValorFormatado(campoChave)));
            }
            return lista;
        }

        public LinhaArquivo CriarLinhaVazia(int index)
        {
            var novaLinha = new LinhaArquivo(index, Operadora);
            CarregaCamposDoLayout(novaLinha);
            novaLinha.CarregaTexto("".PadRight(700, ' '));
            return novaLinha;
        }

    }
}
