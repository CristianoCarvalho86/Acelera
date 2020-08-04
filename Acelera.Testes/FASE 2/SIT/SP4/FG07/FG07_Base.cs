using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2.SIT.SP4.FG06;
using Acelera.Testes.Validadores;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_Base : FG06_Base
    {
        protected ValidadorXML validadorXML;

        public FG07_Base()
        {
            validadorXML = new ValidadorXML(logger);
        }

        protected void ValidarXMLComTabelasOIM(string idArquivo, bool ehParcAuto)
        {
            var xmlDocument = ObterArquivoXML(idArquivo);
            var listaDeTabelas = EnumUtils.ObterListaComTodos<TabelasOIMEnum>();
            foreach (var tabela in listaDeTabelas)
                validadorXML.ValidarXML(xmlDocument, tabela);
        }

        protected XmlDocument ObterArquivoXML(string idArquivo)
        {
            //Nome do arquivo - 'OIMX' + DATA DE GERAÇÃO DO ARQUIVO + ID_ARQUIVO SEM O 'EMS' + .xml
            var documento = new XmlDocument();
            documento.Load(Parametros.pastaDestinoXml + $"OIMX{DateTime.Now.ToString("yyyyMMdd")}{idArquivo.Replace("EMS","")}");
            return documento;
        }

        protected ILinhaTabela ValidarStageSucessoFG07()
        {
            ValidarStages(triplice.ArquivoCliente, true, (int)CodigoStage.AprovadoFG07);
            ValidarStages(triplice.ArquivoComissao, true, (int)CodigoStage.AprovadoFG07);
            return ValidarStages(triplice.ArquivoParcEmissao, true, (int)CodigoStage.AprovadoFG07).First();
        }

        protected IList<ILinhaTabela> ValidarStageSucessoFG07_1(CodigoStage codigoEsperado)
        {
            ValidarStages(triplice.ArquivoCliente, true, (int)codigoEsperado);
            ValidarStages(triplice.ArquivoComissao, true, (int)codigoEsperado);
            return ValidarStages(triplice.ArquivoParcEmissao, true, (int)codigoEsperado);
        }

        protected void CriarEmissaoCompletaFG07(bool salvaCliente, bool salvaComissao = true)
        {
            SalvarTrinca(salvaCliente, true, salvaComissao);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoSucesso();
        }

        public void InicioTesteFG07(string numeroTeste, string descricao, OperadoraEnum operadora, bool geraCliente = true)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice, geraCliente);
        }

        protected void SalvaExecutaEValidaFG07(bool salvaCliente = true, bool salvaComissao = true, bool esperaSucesso = true)
        {
            CriarEmissaoCompletaFG07(salvaCliente, salvaComissao);
            var linhasStageParc = ExecutarFG07(esperaSucesso);
            var ehParcAuto = triplice.ArquivoParcEmissao.tipoArquivo == TipoArquivo.ParcEmissaoAuto;
            var idArquivo = string.Empty;
            foreach (var linhaStage in linhasStageParc)
            {
                validadorXML.ValidarInclusaoNasTabelas(linhaStage, "1210", ehParcAuto, out idArquivo);
            }
            ValidarXMLComTabelasOIM(idArquivo, ehParcAuto);
        }

        protected IList<ILinhaTabela> ExecutarFG07(bool sucessoNaFG071)
        {
            ChamarExecucao(FG07_Tarefas.APL01.ObterTexto());
            ChamarExecucao(FG07_Tarefas.CMS01.ObterTexto());
            ChamarExecucao(FG07_Tarefas.COB01.ObterTexto());
            ChamarExecucao(FG07_Tarefas.ITAUTO01.ObterTexto());
            ChamarExecucao(FG07_Tarefas.PARC01.ObterTexto());
            ChamarExecucao(FG07_Tarefas.ATUALIZA_STATUS.ObterTexto());
            ValidarStageSucessoFG07();

            ChamarExecucao(FG07_Tarefas.FGR_07_1.ObterTexto());
            return ValidarStageSucessoFG07_1(FGs.FG07.ObterCodigoDeSucessoOuFalha(sucessoNaFG071));
        }

        protected void ValidarBancoStatusOIM(ILinhaTabela linhaStageParc)
        {
            var dataAccessOIM = new DataAccessOIM(logger);
            if (dataAccessOIM.ValidarRegistrosOIM(linhaStageParc))
                ExplodeFalha("ERRO NA VALIDAÇÃO DOS REGISTROS DA OIM.");
        }



    }
}
