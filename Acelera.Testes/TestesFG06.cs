using Acelera.Data;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Utils;
using Acelera.Testes.ConjuntoArquivos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG06 : TestesFG04
    {
        protected override string NomeFG => "FG06";

        protected void ExecutarEValidarFG06(ITriplice triplice,
            CodigoStage codigoEsperadoStageCliente,
            CodigoStage codigoEsperadoStageParcela,
            CodigoStage codigoEsperadoStageComissao,
            string msgTabelaDeRetorno)
        {
            //Executar FG06
            ChamarExecucao(FG06_Tarefas.Trinca.ObterTexto());

            ValidarStages(triplice.ArquivoCliente, triplice.ArquivoCliente.tipoArquivo.ObterTabelaStageEnum(),true,(int)codigoEsperadoStageCliente);
            ValidarStages(triplice.ArquivoParcEmissao, triplice.ArquivoParcEmissao.tipoArquivo.ObterTabelaStageEnum(), true, (int)codigoEsperadoStageParcela);
            ValidarStages(triplice.ArquivoComissao, triplice.ArquivoComissao.tipoArquivo.ObterTabelaStageEnum(), true, (int)codigoEsperadoStageComissao);
            //ValidarTabelaDeRetorno(triplice.ArquivoCliente, true, false, new string[] { erroNaoEsperadoNaTabelaDeRetorno });

            ValidarTeste();
        }
    }
}
