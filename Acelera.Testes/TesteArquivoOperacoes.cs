using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.Testes.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TesteArquivoOperacoes
    {
        protected AlteracoesArquivo valoresAlteradosBody;
        protected AlteracoesArquivo valoresAlteradosHeader;
        protected AlteracoesArquivo valoresAlteradosFooter;
        protected Arquivo arquivo;
        protected IMyLogger logger;
        public TesteArquivoOperacoes()
        {
            valoresAlteradosBody = new AlteracoesArquivo();
            valoresAlteradosHeader = new AlteracoesArquivo();
            valoresAlteradosFooter = new AlteracoesArquivo();
        }

        public void AjustarNomeArquivo(string nomeArquivoAntigo, string novoNomeArquivo)
        {
            foreach(var alteracao in valoresAlteradosBody.Alteracoes.Where(x => x.NomeArquivo == nomeArquivoAntigo))
            {
                alteracao.NomeArquivo = novoNomeArquivo;
            }
        }

        public void SelecionarLinhaParaValidacao(int posicaoLinha, int qtdRepeticoes = 0, bool semHeaderOuFooter = false)
        {
            var linhaParaValidacao = arquivo.ObterLinha(posicaoLinha);
            logger.AbrirBloco($"Linha Selecionada para validacao : linha {posicaoLinha}");
            logger.LinhaEmBranco();
            logger.Escrever("Valores da Linha :" + linhaParaValidacao.ObterTexto());
            logger.Escrever(Environment.NewLine);
            logger.FecharBloco();

            AdicionaAlteracao(valoresAlteradosBody, linhaParaValidacao, posicaoLinha,"","",0,semHeaderOuFooter);
        }

        public void AlterarNomeArquivo()
        {
            var linhaParaValidacao = arquivo.ObterLinha(0);
            logger.AbrirBloco($"Linha Selecionada para validacao : linha {0}");
            logger.Escrever("Valores da Linha :" + linhaParaValidacao.ObterTexto());
            logger.Escrever(Environment.NewLine);
            logger.FecharBloco();

            AdicionaAlteracao(valoresAlteradosBody, linhaParaValidacao, 0, "", "", 0, false, true);
        }

        public LinhaArquivo ObterLinha(int posicaoLinha)
        {
            return arquivo.ObterLinha(posicaoLinha);
        }

        public void AlterarLinha(int posicaoLinha, string campo, string valorNovo)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha}");
            logger.Escrever("Chave da Linha : " + arquivo.MontarCamposChaveParaLog(posicaoLinha));
            logger.Escrever("Linha Antiga :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.Escrever($"Valor Antigo : {arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(campo).Valor}");
            logger.Escrever($"Valor Novo : {valorNovo}");
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarLinha(posicaoLinha, campo, valorNovo);

            var linhaAlterada = arquivo.ObterLinha(posicaoLinha);
            logger.Escrever("Linha Atualizada :" + linhaAlterada.ObterTexto());
            logger.FecharBloco();

            var campoAlterado = linhaAlterada.ObterCampoDoBanco(campo).Coluna;

            AdicionaAlteracao(valoresAlteradosBody, linhaAlterada, posicaoLinha, campoAlterado, valorNovo);
        }
        public void AlterarLinhaSeHouver(int posicaoLinha, string campo, string valorNovo)
        {
            if(arquivo.ExisteCampo(campo))
                AlterarLinha(posicaoLinha,campo,valorNovo);
        }


        public void AlterarLinha(Arquivo arquivo1 ,int posicaoLinha, string campo, string valorNovo, bool validaAlteracao = false)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha}");
            logger.Escrever("Chave da Linha : " + arquivo1.MontarCamposChaveParaLog(posicaoLinha));
            logger.Escrever("Linha Antiga :" + arquivo1.ObterLinha(posicaoLinha).ObterTexto());
            logger.Escrever($"Valor Antigo : {arquivo1.ObterLinha(posicaoLinha).ObterCampoDoArquivo(campo).Valor}");
            logger.Escrever($"Valor Novo : {valorNovo}");
            logger.Escrever(Environment.NewLine);
            arquivo1.AlterarLinha(posicaoLinha, campo, valorNovo);

            var linhaAlterada = arquivo1.ObterLinha(posicaoLinha);
            logger.Escrever("Linha Atualizada :" + linhaAlterada.ObterTexto());
            logger.FecharBloco();

            if (validaAlteracao)
            {
                var campoAlterado = linhaAlterada.ObterCampoDoBanco(campo).Coluna;
                AdicionaAlteracao(valoresAlteradosBody, linhaAlterada, posicaoLinha, campoAlterado, valorNovo);
            }
        }

        public void AlterarTodasAsLinhas(string campo, string valorNovo)
        {
            logger.AbrirBloco($"Alterando arquivo [TODAS AS LINHAS] - Editando campo {campo} de todas as linhas");
            logger.Escrever($"Valor Novo : {valorNovo}");
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarTodasAsLinhas(campo, valorNovo);

            var linhaAlterada = arquivo.ObterLinha(0);
            logger.Escrever("Primeira Linha Atualizada : " + linhaAlterada.ObterTexto());
            logger.FecharBloco();
        }

        public void AlterarHeader(string campo, string valorNovo, int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha} do HEADER");
            logger.Escrever("Linha de Header Antiga :" + arquivo.ObterLinhaHeader(posicaoLinha).ObterTexto());
            logger.Escrever($"Valor Antigo : {arquivo.ObterLinhaHeader(posicaoLinha).ObterCampoDoArquivo(campo).Valor}");
            logger.Escrever($"Valor Novo : {valorNovo}");
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarHeader(campo, valorNovo , posicaoLinha);

            var linhaAlterada = arquivo.ObterLinhaHeader(posicaoLinha);
            logger.Escrever("Linha de Header Atualizada :" + linhaAlterada.ObterTexto());
            logger.FecharBloco();

            AdicionaAlteracao(valoresAlteradosHeader, linhaAlterada, posicaoLinha, campo, valorNovo);
            SelecionarLinhaParaValidacao(0);
        }

        public void AlterarFooter(string campo, string valorNovo, int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha} do Footer");
            logger.Escrever("Valor Antigo :" + arquivo.ObterLinhaFooter(posicaoLinha).ObterTexto());
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarFooter(campo, valorNovo, posicaoLinha);

            var linhaAlterada = arquivo.ObterLinhaFooter(posicaoLinha);
            logger.Escrever("Valor Atualizado :" + linhaAlterada.ObterTexto());
            logger.FecharBloco();

            AdicionaAlteracao(valoresAlteradosFooter, linhaAlterada, posicaoLinha, campo, valorNovo);
            SelecionarLinhaParaValidacao(0);
        }

        public void AdicionarLinha(int posicaoLinha, LinhaArquivo linhaNova)
        {
            logger.AbrirBloco($"Alterando arquivo - Adicionando linha na posicao {posicaoLinha}");
            arquivo.AdicionarLinha(linhaNova, posicaoLinha);
            logger.Escrever("Linha Adicionada :" + linhaNova.ObterTexto());
            arquivo.AjustarQtdLinhasNoFooter();
            logger.FecharBloco();
        }

        public void ReplicarLinhaComCorrecao(int posicaoLinha, int quantidadeVezes)
        {
            ReplicarLinha(posicaoLinha, quantidadeVezes);
            AumentarLinhasNoFooter(quantidadeVezes);
        }

        public void ReplicarLinha(int posicaoLinha, int quantidadeVezes)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Chave da Linha a ser replicada : " + arquivo.MontarCamposChaveParaLog(posicaoLinha));
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.ReplicarLinha(posicaoLinha, quantidadeVezes);
            logger.FecharBloco();
            SelecionarLinhaParaValidacao(posicaoLinha, quantidadeVezes);
        }

        public void AumentarLinhasNoFooter(int quantidadeASomar, int indexFooter = 0)
        {
            logger.AbrirBloco($"Alterando QT_LIN no FOOTER.");
            var valor = int.Parse(arquivo.ObterLinhaFooter(indexFooter).ObterCampoDoArquivo("QT_LIN").Valor);
            arquivo.AlterarFooter("QT_LIN", (valor + quantidadeASomar).ToString(), indexFooter);
            logger.Escrever($"FOOTER alterado Valor antigo :{valor} , Valor Novo : {valor + quantidadeASomar}.");
            logger.FecharBloco();
        }

        public void ReplicarHeader(int quantidadeVezes , int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando HEADER linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinhaHeader(posicaoLinha).ObterTexto());
            arquivo.ReplicarHeader(quantidadeVezes, posicaoLinha);

            AdicionaAlteracao(valoresAlteradosHeader, arquivo.ObterLinhaHeader(), 0, "", "", quantidadeVezes, false);
            logger.FecharBloco();
            
            SelecionarLinhaParaValidacao(0);
        }

        public void ReplicarFooter(int quantidadeVezes, int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando FOOTER linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinhaFooter(posicaoLinha).ObterTexto());
            arquivo.ReplicarFooter(quantidadeVezes, posicaoLinha);

            AdicionaAlteracao(valoresAlteradosFooter, arquivo.ObterLinhaHeader(), 0, "", "", quantidadeVezes, false);
            logger.FecharBloco();
            SelecionarLinhaParaValidacao(0);
        }

        public void RemoverLinha(int posicaoLinha)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linha {posicaoLinha}");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.RemoverLinha(posicaoLinha);
            logger.FecharBloco();
        }

        public void AjustarQtdLinFooter()
        {
            arquivo.AjustarQtdLinhasNoFooter();
        }

        public void RemoverHeader()
        {
            logger.AbrirBloco($"Alterando arquivo - removendo HEADER");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinhaHeader().ObterTexto());
            arquivo.RemoverHeader();
            logger.FecharBloco();
            SelecionarLinhaParaValidacao(0,0,true);
        }

        public void RemoverFooter()
        {
            logger.AbrirBloco($"Alterando arquivo - removendo FOOTER");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinhaFooter().ObterTexto());
            arquivo.RemoverFooter();
            logger.FecharBloco();
            SelecionarLinhaParaValidacao(0, 0, true);
        }


        public void RemoverLinhas(int posicaoLinhaInicial, int posicaoLinhaFinal)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linhas - Da linha : {posicaoLinhaInicial} ate linha : {posicaoLinhaFinal}");
            logger.LinhaEmBranco();
            for (int i = posicaoLinhaInicial; i < posicaoLinhaFinal; i++)
            {
                logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinhaInicial).ObterTexto());
            }
            arquivo.RemoverLinhas(posicaoLinhaInicial, posicaoLinhaFinal);
            logger.FecharBloco();
        }

        public void RemoverTodasAsLinhasMenosUma(int posicaoAManter)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo TODAS as linhas com excecao da {posicaoAManter}");
            arquivo.RemoverLinhasMenosUma(posicaoAManter);
            logger.Escrever("Linhas do Body Removidas");
            logger.FecharBloco();
        }

        public void RemoverLinhasExcetoAsPrimeiras(int quantidadeAManter)
        {
            logger.AbrirBloco($"Alterando arquivo - diminuindo o arquivo para {quantidadeAManter} linhas");
            arquivo.RemoverExcetoEstas(0, quantidadeAManter);
            logger.Escrever("Linhas do Body Removidas");
            logger.Escrever("Ajustar Footer - QT_LIN");
            arquivo.AlterarFooter("QT_LIN", arquivo.Linhas.Count().ToString());
            logger.Escrever("QT_LIN ajustado.");
            logger.FecharBloco();
        }

        public void RemoverTodasAsLinhas()
        {
            logger.AbrirBloco($"Alterando arquivo - removendo TODAS as linhas - Da linha : {0} ate linha : {arquivo.Linhas.Count - 1}");
            arquivo.RemoverLinhas(0, arquivo.Linhas.Count);
            logger.Escrever("Todas as linhas do Body Removidas");
            logger.FecharBloco();
        }

        private void AdicionaAlteracao(AlteracoesArquivo alteracoes, LinhaArquivo linhaAlterada, int posicaoLinha,
            string campo = "", string valor = "", int repeticoes = 0, bool semHeaderOuFooter = false , bool nomeArquivoAlterado = false)
        {
            var alteracao = new Alteracao(linhaAlterada, posicaoLinha);
            alteracao.AdicionarAlteracao(campo, valor, arquivo.NomeArquivo);
            alteracao.DefinirQtdRepeticoes(repeticoes);
            alteracao.DefinirSemHeaderOuFooter(semHeaderOuFooter);
            alteracao.DefinirAlteracaoNomeArquivo(nomeArquivoAlterado);
            alteracoes.AdicionaAlteracao(alteracao);
        }

        public string ObterValor(int posicaoLinha, string nomeCampo)
        {
            return arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).Valor;
        }

        public string ObterValorFormatado(int posicaoLinha, string nomeCampo)
        {
            return arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).ValorFormatado;
        }

        public string ObterValorHeader(string nomeCampo)
        {
            return arquivo.ObterLinhaHeader().ObterCampoDoArquivo(nomeCampo).ValorFormatado;
        }

        public string SomarData(string valorAntigo, int diasAdicionados)
        {
            DateTime d = new DateTime();
            if (DateTime.TryParse(valorAntigo, out DateTime data))
                d = data;
            else
                d = new DateTime(int.Parse(valorAntigo.Substring(0,4)), int.Parse(valorAntigo.Substring(4, 2)), int.Parse(valorAntigo.Substring(6, 2)));
            d = d.AddDays(diasAdicionados);
            return d.ToString("yyyyMMdd");
        }

        public string SomarData(int posicaoLinha, string nomeCampo, int diasAdicionados)
        {
            return SomarData(arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).ValorFormatado, diasAdicionados);
        }


        public string SomarValor(int posicaoLinha, string nomeCampo, decimal valorAdicionado)
        {
            return (decimal.Parse(arquivo.ObterLinha(posicaoLinha).ObterCampoDoArquivo(nomeCampo).ValorFormatadoNumerico) + valorAdicionado).ToString().Replace(",",".");
        }
        
        public decimal SomarDoisCamposDoArquivo(int posicaoLinha, string campo1, string campo2)
        {
            var linha = arquivo.ObterLinha(posicaoLinha);
            if (!decimal.TryParse(linha.ObterCampoDoArquivo(campo1).ValorFormatadoNumerico, out decimal Valor1) || !decimal.TryParse(linha.ObterCampoDoArquivo(campo2).ValorFormatadoNumerico, out decimal Valor2))
                throw new Exception("VALOR DOS CAMPOS A SEREM SOMADOS PRECISA SER INTEIRO");

            return Valor1 + Valor2;
        }

        public string SomarValores(decimal valor1 , decimal valor2)
        {
            return (valor1 + valor2).ToString("0.00").Replace(",",".").Replace(".00","");
        }
        public string SomarValores(string valor1, string valor2)
        {
            if (!decimal.TryParse(valor1.Replace(".", ","), out decimal Valor1) || !decimal.TryParse(valor2.Replace(".", ","), out decimal Valor2))
                throw new Exception("VALORES A SEREM SOMADOS PRECISAM SER NUMERICOS");
            return SomarValores(Valor1,Valor2);
        }

        public string MediaEntreValores(string valor1, string valor2)
        {
            if (!decimal.TryParse(valor1.Replace(".", ","), out decimal Valor1) || !decimal.TryParse(valor2.Replace(".", ","), out decimal Valor2))
                throw new Exception("VALORES A SEREM SOMADOS PRECISAM SER NUMERICOS");
            return ((Valor1 + Valor2)/2M).ValorFormatado();
        }

        public string MontarCamposConcatenados(int posicaoLinha, params string[] campos)
        {
            var linha = arquivo.ObterLinha(posicaoLinha);
            var resultado = string.Empty;
            foreach (var campo in campos)
                resultado += linha.ObterCampoDoArquivo(campo).ValorFormatado;
            return resultado;
        }

        public LinhaArquivo CopiarLinha(int posicaoLinha)
        {
            logger.AbrirBloco("Copiando linha do arquivo.");
            var linha = arquivo.ObterLinha(posicaoLinha);
            logger.Escrever($"Linha copiada : {linha.ObterTexto()}");
            logger.FecharBloco();
            return linha;
        }

        public void InserirLinha(LinhaArquivo linha, int posicaoLinha)
        {
            logger.AbrirBloco("Inserindo linha no arquivo.");
            logger.Escrever("Linha a ser inserida : " + linha.ObterTexto());
            arquivo.AdicionarLinha(linha, posicaoLinha);
            logger.FecharBloco();
        }

        public virtual void FinalizarAlteracaoArquivo()
        {

        }

        public string GerarNumeroAleatorio(int posicoes)
        {
            var retorno = string.Empty;
            int seed = DateTime.Now.Millisecond;
            for (int i = 0; i < posicoes; i++)
                retorno += new Random(seed * i).Next(0, 9).ToString();
            return retorno;
        }

    }
}
