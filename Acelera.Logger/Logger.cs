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
            writer.Write(texto);
        }

        public void InicioOperacao(OperacaoEnum operacao)
        {
            Escrever("Inicio da Operacao : " + operacao.GetEnumDescription());
        }

        public void SucessoDaOperacao(OperacaoEnum operacao)
        {
            Escrever($"Operacao : {operacao.GetEnumDescription()} --- Ok");
        }

        public void ErroNaOperacao(OperacaoEnum operacao)
        {
            Escrever($"Operacao : {operacao.GetEnumDescription()} --- Falha");
        }

        public void Erro(string descricao)
        {
            Escrever($"Houve um erro: {descricao}");
        }

        public void Erro(Exception ex)
        {
            Escrever($"Houve um erro: {ex.ToString()}");
        }

        public void LogComando(string comandoEnviado, string retornoComando)
        {
            Escrever($"Comando enviado : {comandoEnviado}");
            Escrever($"Retorno {retornoComando}");
        }

        public void TesteSucesso()
        {
            Escrever($"Teste passado com sucesso");
        }

        public void TesteComFalha()
        {
            Escrever($"Teste com falha");
        }
    }
}
