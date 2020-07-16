using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
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

        protected void CriarEmissaoCompletaFG07(bool salvaCliente, bool salvaComissao = true)
        {
            SalvarTrinca(salvaCliente, true, salvaComissao);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoSucesso();
        }

        public void InicioTesteFG07(string numeroTeste, string descricao, OperadoraEnum operadora)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice);
        }

        protected void SalvaExecutaEValidaFG07(bool salvaCliente = true, bool salvaComissao = true)
        {
            CriarEmissaoCompletaFG07(salvaCliente, salvaComissao);
            ChamarExecucao(FG07_Tarefas.Trinca.ObterTexto());
            var linhaStageParc = ValidarStageSucessoFG07();
            var ehParcAuto = triplice.ArquivoParcEmissao.tipoArquivo == TipoArquivo.ParcEmissaoAuto;


            validadorXML.ValidarInclusaoNasTabelas(linhaStageParc, "1210", ehParcAuto , out string idArquivo);
            ValidarXMLComTabelasOIM(idArquivo, ehParcAuto);
        }



    }
}
