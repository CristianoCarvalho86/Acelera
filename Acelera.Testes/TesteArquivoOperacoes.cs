using Acelera.Domain.Entidades;
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
        //Adicionar em linhas alteradas a linha completa.
        public void AlterarLinha(Arquivo arquivo, int posicaoLinha, string campo, string valorNovo)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha}");
            logger.Escrever("Valor Antigo :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarLinha(posicaoLinha, campo, valorNovo);
            logger.Escrever("Valor Atualizado :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.FecharBloco();
        }

        public void AdicionarLinha(Arquivo arquivo, int posicaoLinha, LinhaArquivo linhaNova)
        {
            logger.AbrirBloco($"Alterando arquivo - Adicionando linha na posicao {posicaoLinha}");
            arquivo.AdicionarLinha(linhaNova, posicaoLinha);
            logger.Escrever("Linha Adicionada :" + linhaNova.ObterTexto());
            logger.FecharBloco();
        }

        public void ReplicarLinha(Arquivo arquivo, int posicaoLinha, int quantidadeVezes)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.ReplicarLinha(posicaoLinha, quantidadeVezes);
            logger.FecharBloco();
        }

        public void RemoverLinha(Arquivo arquivo, int posicaoLinha)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linha {posicaoLinha}");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.RemoverLinha(posicaoLinha);
            logger.FecharBloco();
        }

        public void RemoverLinha(Arquivo arquivo, int posicaoLinhaInicial, int posicaoLinhaFinal)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linhas - Da linha : {posicaoLinhaInicial} ate linha : {posicaoLinhaFinal}");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinhaInicial).ObterTexto());
            arquivo.RemoverLinhas(posicaoLinhaInicial, posicaoLinhaFinal);
            logger.FecharBloco();
        }
    }
}
