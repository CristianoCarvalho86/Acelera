﻿using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Consultas;
using Acelera.Domain.Entidades.Tabelas;
using Acelera.Domain.Enums;
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
    public class TesteArquivoOperacoes : TesteItens
    {

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

        public void AlterarLinha(int posicaoLinha, string campo, string valorNovo)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha}");
            logger.Escrever("Valor Antigo :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarLinha(posicaoLinha, campo, valorNovo);

            var linhaAlterada = arquivo.ObterLinha(posicaoLinha);
            logger.Escrever("Valor Atualizado :" + linhaAlterada.ObterTexto());
            logger.FecharBloco();

            var campoAlterado = linhaAlterada.ObterCampoDoBanco(campo).Coluna;

            AdicionaAlteracao(valoresAlteradosBody, linhaAlterada, posicaoLinha, campoAlterado, valorNovo);
        }

        public void AlterarHeader(string campo, string valorNovo, int posicaoLinha = 0)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha} do HEADER");
            logger.Escrever("Valor Antigo :" + arquivo.ObterLinhaHeader(posicaoLinha).ObterTexto());
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarHeader(campo, valorNovo , posicaoLinha);

            var linhaAlterada = arquivo.ObterLinhaHeader(posicaoLinha);
            logger.Escrever("Valor Atualizado :" + linhaAlterada.ObterTexto());
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
            logger.FecharBloco();
        }

        public void ReplicarLinha(int posicaoLinha, int quantidadeVezes)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando linha {posicaoLinha} , {quantidadeVezes} vezes.");
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
            logger.AbrirBloco($"FOOTER alterado Valor antigo :{valor} , Valor Novo : {valor + quantidadeASomar}.");
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
            alteracao.AdicionarAlteracao(campo, valor);
            alteracao.DefinirQtdRepeticoes(repeticoes);
            alteracao.DefinirSemHeaderOuFooter(semHeaderOuFooter);
            alteracao.DefinirAlteracaoNomeArquivo(nomeArquivoAlterado);
            alteracoes.AdicionaAlteracao(alteracao);
        }
    }
}
