using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Logger
{
    public interface IMyLogger
    {
        void Escrever(string texto);

        void LinhaEmBranco();

        void EscreverBloco(string texto);

        void AbrirBloco(string texto);

        void FecharBloco();

        void InicioOperacao(OperacaoEnum operacao, string complemento);

        void SucessoDaOperacao(OperacaoEnum operacao, string complemento);

        void ErroNaOperacao(OperacaoEnum operacao, string complemento);

        void Erro(string descricao);

        void Erro(Exception ex);

        void LogRetornoCMD(string retorno);

        void LogRetornoQuery(DataTable retorno, string consulta);


        void TesteSucesso();

        void TesteComFalha();

        void ResultadoDaConsulta(string resultado);

        void EscreveValidacao(string resultadoObtido, string resultadoEsperado);

        void EscreveValidacao(string resultadoObtido, string resultadoEsperado, string tituloValidacao);

        void EscreverNoFimDoArquivo(string texto);

        void DefinirSucesso(bool sucesso);

        void FimDoArquivo(string numeroDoLote, string operacao, string pastaCopia);

        void RenomearLog(string numeroDoLote, string operacao);
        void CriarCopia(string pastaCopia);

    }
}
