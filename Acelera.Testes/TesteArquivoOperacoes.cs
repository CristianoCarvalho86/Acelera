using Acelera.Contratos;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Logger;
using Acelera.RegrasNegocio;
using Acelera.Testes.Adapters;
using Acelera.Testes.DataAccessRep;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TesteArquivoOperacoes
    {
        protected IArquivo arquivo;
        protected IMyLogger logger;
        protected EmissaoRegras emissaoRegras { get; set; }
        protected CancelamentoRegras cancelamentoRegras { get; set; }
        protected ComissaoRegras comissaoRegras { get; set; }

        protected ArquivoRegras arquivoRegras { get; set; }
        protected ContratoRegras contratoRegras { get; set; }
        protected DadosParametrosData dados { get; set; }

        protected ExecucaoFgsRegras execucaoRegras { get; set; }
        public TesteArquivoOperacoes()
        {

        }

        public void SelecionarLinhaParaValidacao(int posicaoLinha, bool semHeaderOuFooter = false, IArquivo _arquivo = null)
        {
            _arquivo = _arquivo == null ? arquivo : _arquivo;
            var linhaParaValidacao = _arquivo.ObterLinha(posicaoLinha);
            logger.AbrirBloco($"Linha Selecionada para validacao : linha {posicaoLinha}");
            logger.LinhaEmBranco();
            logger.Escrever("Valores da Linha :" + linhaParaValidacao.ObterTexto());
            logger.Escrever(Environment.NewLine);
            logger.FecharBloco();

            AdicionaAlteracao(_arquivo.NomeArquivo,_arquivo.valoresAlteradosBody, linhaParaValidacao, posicaoLinha,"","",0,semHeaderOuFooter);
        }

        public void AlterarNomeArquivo()
        {
            var linhaParaValidacao = arquivo.ObterLinha(0);
            logger.AbrirBloco($"Linha Selecionada para validacao : linha {0}");
            logger.Escrever("Valores da Linha :" + linhaParaValidacao.ObterTexto());
            logger.Escrever(Environment.NewLine);
            logger.FecharBloco();

            AdicionaAlteracao(arquivo.NomeArquivo,arquivo.valoresAlteradosBody, linhaParaValidacao, 0, "", "", 0, false, true);
        }

        public ILinhaArquivo ObterLinha(int posicaoLinha)
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

            AdicionaAlteracao(arquivo.NomeArquivo, arquivo.valoresAlteradosBody, linhaAlterada, posicaoLinha, campoAlterado, valorNovo);
        }
        public void AlterarLinhaSeHouver(int posicaoLinha, string campo, string valorNovo)
        {
            if(arquivo.ExisteCampo(campo))
                AlterarLinha(posicaoLinha,campo,valorNovo);
        }


        public void AlterarLinha(IArquivo arquivo1 ,int posicaoLinha, string campo, string valorNovo, bool validaAlteracao = false)
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
                AdicionaAlteracao(arquivo1.NomeArquivo, arquivo1.valoresAlteradosBody, linhaAlterada, posicaoLinha, campoAlterado, valorNovo);
            }
        }

        public void AlterarLinhaSeExistirCampo(IArquivo arquivo1, int posicaoLinha, string campo, string valorNovo, bool validaAlteracao = false)
        {
            if (arquivo1.ExisteCampo(campo))
                AlterarLinha(arquivo1, posicaoLinha, campo, valorNovo, validaAlteracao);
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

            AdicionaAlteracao(arquivo.NomeArquivo,arquivo.valoresAlteradosHeader, linhaAlterada, posicaoLinha, campo, valorNovo);
            //SelecionarLinhaParaValidacao(0);
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

            AdicionaAlteracao(arquivo.NomeArquivo, arquivo.valoresAlteradosFooter, linhaAlterada, posicaoLinha, campo, valorNovo);
            SelecionarLinhaParaValidacao(0);
        }

        public void AdicionarLinha(int posicaoLinha, ILinhaArquivo linhaNova)
        {
            logger.AbrirBloco($"Alterando arquivo - Adicionando linha na posicao {posicaoLinha}");
            arquivo.AdicionarLinha(linhaNova.Clone(), posicaoLinha);
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
            SelecionarLinhaParaValidacao(posicaoLinha);
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

            AdicionaAlteracao(arquivo.NomeArquivo,arquivo.valoresAlteradosHeader, arquivo.ObterLinhaHeader(), 0, "", "", quantidadeVezes, false);
            logger.FecharBloco();
            
            SelecionarLinhaParaValidacao(0);
        }

        public void ReplicarFooter(int quantidadeVezes, int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando FOOTER linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinhaFooter(posicaoLinha).ObterTexto());
            arquivo.ReplicarFooter(quantidadeVezes, posicaoLinha);

            AdicionaAlteracao(arquivo.NomeArquivo, arquivo.valoresAlteradosFooter, arquivo.ObterLinhaHeader(), 0, "", "", quantidadeVezes, false);
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

        public void RemoverLinhaComAjusteDeFooter(int posicaoLinha)
        {
            RemoverLinha(posicaoLinha);
            AjustarQtdLinFooter();
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
            SelecionarLinhaParaValidacao(0,true);
        }

        public void RemoverFooter()
        {
            logger.AbrirBloco($"Alterando arquivo - removendo FOOTER");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinhaFooter().ObterTexto());
            arquivo.RemoverFooter();
            logger.FecharBloco();
            SelecionarLinhaParaValidacao(0, true);
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

        private void AdicionaAlteracao(string nomeArquivo,IAlteracoesArquivo alteracoes, ILinhaArquivo linhaAlterada, int posicaoLinha,
            string campo = "", string valor = "", int repeticoes = 0, bool semHeaderOuFooter = false , bool nomeArquivoAlterado = false)
        {
            var alteracao = new Alteracao(linhaAlterada, posicaoLinha);
            alteracao.AdicionarAlteracao(campo, valor, nomeArquivo);
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
            return OperacoesUtils.SomarData(valorAntigo, diasAdicionados);
        }

        public string SomarData(int posicaoLinha, string nomeCampo, int diasAdicionados)
        {
            return OperacoesUtils.SomarData(arquivo, posicaoLinha, nomeCampo, diasAdicionados);
        }


        public string SomarValor(int posicaoLinha, string nomeCampo, decimal valorAdicionado)
        {
            return OperacoesUtils.SomarValor(arquivo, posicaoLinha, nomeCampo, valorAdicionado);
        }
        
        public decimal SomarDoisCamposDoArquivo(int posicaoLinha, string campo1, string campo2)
        {
            return OperacoesUtils.SomarDoisCamposDoArquivo(arquivo, posicaoLinha, campo1, campo2);
        }

        public string SomarValores(decimal valor1 , decimal valor2)
        {
            return OperacoesUtils.SomarValores(valor1, valor2);
        }
        public string SomarValores(string valor1, string valor2)
        {
            return OperacoesUtils.SomarValores(valor1, valor2);
        }

        public string MediaEntreValores(string valor1, string valor2)
        {
            return OperacoesUtils.MediaEntreValores(valor1, valor2);
        }

        public string MontarCamposConcatenados(int posicaoLinha, params string[] campos)
        {
            return OperacoesUtils.MontarCamposConcatenados(arquivo, posicaoLinha, campos);
        }

        public ILinhaArquivo CopiarLinha(int posicaoLinha)
        {
            logger.AbrirBloco("Copiando linha do arquivo.");
            var linha = arquivo.ObterLinha(posicaoLinha);
            logger.Escrever($"Linha copiada : {linha.ObterTexto()}");
            logger.FecharBloco();
            return linha;
        }

        public void InserirLinha(ILinhaArquivo linha, int posicaoLinha)
        {
            logger.AbrirBloco("Inserindo linha no arquivo.");
            logger.Escrever("Linha a ser inserida : " + linha.ObterTexto());
            arquivo.AdicionarLinha(linha, posicaoLinha);
            logger.FecharBloco();
        }

        public virtual void FinalizarAlteracaoArquivo(IArquivo _arquivo)
        {
            if (_arquivo.Operadora == OperadoraEnum.PAPCARD)
            {
                arquivoRegras.AlteracoesPapCardEmissao(_arquivo);
            }
        }

        public string GerarNumeroAleatorio(int posicoes)
        {
            var retorno = string.Empty;
            for (int i = 0; i < posicoes; i++)
            {
                retorno += RandomNumber.Between(0, 9);
            }
            return retorno;
        }

    }
}
