using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Logger
{
    public class MyLogger : IMyLogger
    {
        private string path;
        private string nomeArquivoLog;
        private StreamWriter writer;
        private string TextoFimArquivo;
        private bool sucessoExecucao;
        public MyLogger(string _path, string nomeArquivo)
        {
            path = _path;
            nomeArquivoLog = nomeArquivo;
            writer = File.CreateText(path + nomeArquivoLog);

        }

        public void Escrever(string texto)
        {
            writer.WriteLine(texto);
            writer.Flush();
        }

        public void LinhaEmBranco()
        {
            writer.WriteLine("");
            writer.Flush();
        }

        public void EscreverBloco(string texto)
        {
            writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss") + " - " + texto);
            writer.WriteLine("");
            writer.WriteLine("----------------------------------");
            writer.Flush();
        }

        public void AbrirBloco(string texto)
        {
            writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss") + " - " + texto);
            writer.Flush();
        }

        public void FecharBloco()
        {
            writer.WriteLine("");
            writer.WriteLine("----------------------------------");
            writer.Flush();
        }

        public void InicioOperacao(OperacaoEnum operacao, string complemento)
        {
            EscreverBloco("Inicio da Operacao : " + operacao.ObterTexto() + " " + complemento);
        }

        public void SucessoDaOperacao(OperacaoEnum operacao, string complemento)
        {
            EscreverBloco($"Operacao : {operacao.ObterTexto()} {complemento} --- Ok");
        }

        public void ErroNaOperacao(OperacaoEnum operacao, string complemento)
        {
            EscreverBloco($"Operacao : {operacao.ObterTexto()} - {complemento} --- Falha");
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

        public void LogRetornoQuery(DataTable retorno, string consulta)
        {
            EscreverNoFimDoArquivo($"Consulta Realizada : " + consulta);
            EscreverNoFimDoArquivo($"Retorno do Banco :");
            if (retorno.Rows.Count == 0)
                EscreverNoFimDoArquivo("Nenhuma linha encontrada.");

            var count = 1;
            foreach (DataRow row in retorno.Rows)
            {
                EscreverNoFimDoArquivo($"Linha {count++}:");
                foreach (DataColumn column in row.Table.Columns)
                    EscreverNoFimDoArquivo($"{column.ColumnName} : {row[column.ColumnName]}");
                EscreverNoFimDoArquivo(Environment.NewLine);
            }
            EscreverNoFimDoArquivo("-----------------------------------------");
        }


        public void TesteSucesso()
        {
            EscreverBloco($"Resultado do Teste : Teste passado com sucesso");
        }

        public void TesteComFalha()
        {
            EscreverBloco($"Resultado do Teste : Teste com falha");
        }

        public void ResultadoDaConsulta(string resultado)
        {
            EscreverBloco($"Resultado obtido: {resultado}");
        }
        public void EscreveValidacao(string resultadoObtido, string resultadoEsperado)
        {
            EscreverBloco($"Resultado obtido: {resultadoObtido} {Environment.NewLine} Resultado esperado : {resultadoEsperado}");
        }
        public void EscreveValidacao(string resultadoObtido, string resultadoEsperado, string tituloValidacao)
        {

            EscreverBloco($"{tituloValidacao} {Environment.NewLine} Resultado obtido: {resultadoObtido} {Environment.NewLine} Resultado esperado : {resultadoEsperado}");
        }

        public void EscreverNoFimDoArquivo(string texto)
        {
            TextoFimArquivo += Environment.NewLine + texto;
        }

        public void DefinirSucesso(bool sucesso)
        {
            sucessoExecucao = sucesso;
        }

        public void FimDoArquivo(string numeroDoLote, string operacao, string pastaCopia, ModoExecucaoEnum modoExecucao)
        {
            writer.WriteLine(TextoFimArquivo);
            writer.Flush();
            TextoFimArquivo = "";
            writer.Close();
            writer.Dispose();


            RenomearLog(numeroDoLote, operacao);
            CriarCopia(pastaCopia);

        }

        public void RenomearLog(string numeroDoLote, string operacao)
        {
            var nomeAntigo = nomeArquivoLog;
            nomeArquivoLog = (nomeArquivoLog.Remove(nomeArquivoLog.Length - 4, 4) + "-" +
                (sucessoExecucao ? "SUCESSO" : "FALHA")).Replace("NLOTE", numeroDoLote).Replace("OPERACAO", operacao) + $"-{DateTime.Now.Hour}-{DateTime.Now.Minute}-{DateTime.Now.Second}-" + ".txt";
            if (!File.Exists(path + nomeArquivoLog))
                File.Move(path + nomeAntigo, path + nomeArquivoLog);
        }

        public void CriarCopia(string pastaCopia)
        {
            if (!string.IsNullOrEmpty(pastaCopia))
                File.Copy(path + nomeArquivoLog, pastaCopia + nomeArquivoLog);
        }
    }
}
