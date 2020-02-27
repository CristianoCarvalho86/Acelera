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
            writer.Flush();
        }

        public void EscreverBloco(string texto)
        {
            writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy - mm:ss") + " - " + texto);
            writer.WriteLine("");
            writer.WriteLine("----------------------------------");
            writer.Flush();
        }

        public void AbrirBloco(string texto)
        {
            writer.WriteLine(DateTime.Now.ToString("dd/MM/yyyy - mm:ss") + " - " + texto);
            writer.Flush();
        }

        public void FecharBloco()
        {
            writer.WriteLine("");
            writer.WriteLine("----------------------------------");
            writer.Flush();
        }

        public void InicioOperacao(OperacaoEnum operacao, string complemento = "")
        {
            EscreverBloco("Inicio da Operacao : " + operacao.GetEnumDescription() + " " + complemento);
        }

        public void SucessoDaOperacao(OperacaoEnum operacao, string complemento = "")
        {
            EscreverBloco($"Operacao : {operacao.GetEnumDescription()} {complemento} --- Ok");
        }

        public void ErroNaOperacao(OperacaoEnum operacao, string complemento = "")
        {
            EscreverBloco($"Operacao : {operacao.GetEnumDescription()} {complemento} --- Falha");
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

        public void LogRetornoQuery(DataTable retorno)
        {
            AbrirBloco($"Retorno do Banco :");
            if (retorno.Rows.Count == 0)
                Escrever("Nenhuma linha encontrada.");

            foreach(DataRow row in retorno.Rows)
                foreach(DataColumn column in row.Table.Columns)
                    Escrever($"{column.ColumnName} : {row[column.ColumnName]}");
            FecharBloco();
        }

        public void TesteSucesso()
        {
            EscreverBloco($"Teste passado com sucesso");
        }

        public void TesteComFalha()
        {
            EscreverBloco($"Teste com falha");
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
    }
}
