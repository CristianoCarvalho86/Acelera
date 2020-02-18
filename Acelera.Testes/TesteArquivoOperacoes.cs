using Acelera.Domain.Layouts;
using Acelera.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TesteArquivoOperacoes
    {
        public void AlterarLinha(Arquivo arquivo, int posicaoLinha, string campo, string valorNovo, MyLogger logger)
        {
            logger.AbrirBloco($"Alterando arquivo - Editando campo {campo} na linha {posicaoLinha}");
            logger.Escrever("Valor Antigo :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.Escrever(Environment.NewLine);
            arquivo.AlterarLinha(posicaoLinha, campo, valorNovo);
            logger.Escrever("Valor Atualizado :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            logger.FecharBloco();
        }

        public void AdicionarLinha(Arquivo arquivo, int posicaoLinha, Linha linhaNova, MyLogger logger)
        {
            logger.AbrirBloco($"Alterando arquivo - Adicionando linha na posicao {posicaoLinha}");
            arquivo.AdicionarLinha(linhaNova, posicaoLinha);
            logger.Escrever("Linha Adicionada :" + linhaNova.ObterTexto());
            logger.FecharBloco();
        }

        public void ReplicarLinha(Arquivo arquivo, int posicaoLinha, int quantidadeVezes, MyLogger logger)
        {
            logger.AbrirBloco($"Alterando arquivo - Replicando linha {posicaoLinha} , {quantidadeVezes} vezes.");
            logger.Escrever("Linha a ser replicada :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.ReplicarLinha(posicaoLinha, quantidadeVezes);
            logger.FecharBloco();
        }

        public void RemoverLinha(Arquivo arquivo, int posicaoLinha,  MyLogger logger)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linha {posicaoLinha}");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinha).ObterTexto());
            arquivo.RemoverLinha(posicaoLinha);
            logger.FecharBloco();
        }

        public void RemoverLinha(Arquivo arquivo, int posicaoLinhaInicial, int posicaoLinhaFinal, MyLogger logger)
        {
            logger.AbrirBloco($"Alterando arquivo - removendo linhas - Da linha : {posicaoLinhaInicial} ate linha : {posicaoLinhaFinal}");
            logger.Escrever("Linha Removida :" + arquivo.ObterLinha(posicaoLinhaInicial).ObterTexto());
            arquivo.RemoverLinhas(posicaoLinhaInicial, posicaoLinhaFinal);
            logger.FecharBloco();
        }
    }
}
