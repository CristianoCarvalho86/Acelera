using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Logger
{
    public class MyLogger
    {
        private string path;
        private StreamWriter writer;
        public MyLogger(string _path)
        {
            path = _path;
            writer = File.CreateText(path);
        }

        public void Escrever(string texto)
        {
            writer.WriteLine(texto);
        }

        public void EscreverBloco(string texto)
        {
            writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy - mm:ss") + " - " + texto);
            writer.WriteLine("");
            writer.WriteLine("----------------------------------");
        }

        public void InicioOperacao(OperacaoEnum operacao)
        {
            EscreverBloco("Inicio da Operacao : " + operacao.GetEnumDescription());
        }

        public void SucessoDaOperacao(OperacaoEnum operacao)
        {
            EscreverBloco($"Operacao : {operacao.GetEnumDescription()} --- Ok");
        }

        public void ErroNaOperacao(OperacaoEnum operacao)
        {
            EscreverBloco($"Operacao : {operacao.GetEnumDescription()} --- Falha");
        }

        public void Erro(string descricao)
        {
            Escrever($"Houve um erro: {descricao}");
        }

        public void Erro(Exception ex)
        {
            Escrever($"Houve um erro: {ex.ToString()}");
        }

        public void LogRetornoCMD(string retorno)
        {
            Escrever($"Tela de execução :");
            EscreverBloco(retorno);
        }

        public void TesteSucesso()
        {
            EscreverBloco($"Teste passado com sucesso");
        }

        public void TesteComFalha()
        {
            EscreverBloco($"Teste com falha");
        }
    }
}
