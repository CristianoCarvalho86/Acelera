using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_6;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2.SIT.SP4.FG06;
using Acelera.Testes.Validadores;
using Acelera.Utils;
using Castle.Core.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

        }

        protected void ValidarXMLComTabelasOIM(string idArquivo, bool ehParcAuto)
        {
            var xmlDocument = ObterArquivoXML(idArquivo);
            var listaDeTabelas = EnumUtils.ObterListaComTodos<TabelasOIMEnum>();
            if (!ehParcAuto)
                listaDeTabelas.Remove(TabelasOIMEnum.OIM_ITAUTO01);
            foreach (var tabela in listaDeTabelas)
            {
                logger.AbrirBloco("INICIO VALIDACAO DA " + tabela.ObterTexto());
                if (!validadorXML.ValidarXML(xmlDocument, tabela))
                    TesteComErro();
                logger.FecharBloco();
            }
        }

        protected XmlDocument ObterArquivoXML(string idArquivo)
        {
            Thread.Sleep(5000);//ESPERANDO UM TEMPO PARA O ARQUIVO MIGRAR PARA A PASTA FINAL
            //Nome do arquivo - 'OIMX' + DATA DE GERAÇÃO DO ARQUIVO + ID_ARQUIVO SEM O 'EMS' + .xml
            var documento = new XmlDocument();
            //var file =  $"OIMX{DateTime.Now.ToString("yyyyMMdd")}{idArquivo.Replace("EMS", "")}.xml";
            var enderecosPossiveisXML = new string[] { Parametros.pastaDestinoXml, Parametros.pastaDestinoXml + "_ImpOk\\", Parametros.pastaDestinoXml + "_ImpErro\\" };
            foreach (var endereco in enderecosPossiveisXML)
            {
                var arquivos = Directory.GetFiles(endereco);
                var arq = arquivos.SingleOrDefault(x => x.Contains($"_{idArquivo.Replace("EMS", "")}"));
                if (!string.IsNullOrEmpty(arq))
                {
                    logger.EscreverBloco("ARQUIVO ENCONTRADO EM: " + arq);
                    documento.Load(arq);
                    break;
                }
            }

            if (documento.IsNullOrEmpty())
                ExplodeFalha("DOCUMENTO NAO ENCONTRADO. CAMINHOS TESTADOS : " + enderecosPossiveisXML.ObterListaConcatenada(Environment.NewLine));

            return documento;
        }

        protected ILinhaTabela ValidarStageSucessoFG07(bool clienteEnviado = true, bool comissaoEnviada = true, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;
            if (clienteEnviado)
                ValidarStages(_triplice.ArquivoCliente, true, (int)CodigoStage.AprovadoFG07);
            if(comissaoEnviada)
                ValidarStages(_triplice.ArquivoComissao, true, (int)CodigoStage.AprovadoFG07);
            
            return ValidarStages(_triplice.ArquivoParcEmissao, true, (int)CodigoStage.AprovadoFG07).First();
        }

        protected IList<ILinhaTabela> ValidarStageSucessoFG07_1(CodigoStage codigoEsperado, bool clienteEnviado, bool comissaoEnviado, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;
            if (clienteEnviado)
                ValidarStages(_triplice.ArquivoCliente, true, (int)codigoEsperado);
            if(comissaoEnviado)
                ValidarStages(_triplice.ArquivoComissao, true, (int)codigoEsperado);
            
            return ValidarStages(_triplice.ArquivoParcEmissao, true, (int)codigoEsperado);
        }



        public virtual void IniciarTesteFG07(string numeroTeste, string descricao, OperadoraEnum operadora, bool geraCliente = true, bool gerarArquivoCapa = false)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice, geraCliente, gerarArquivoCapa);

            validadorXML = new ValidadorXML(logger);
        }

        protected void SalvaExecutaEValidaFG07(bool salvaCliente = true, bool salvaComissao = true, bool esperaSucesso = true, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;

            CriarEmissaoCompletaFG06(salvaCliente, salvaComissao);

            var linhasStageParc = ExecutarValidarFG07(esperaSucesso, salvaCliente, salvaComissao).Where(x => x.ObterPorColuna("CD_TIPO_EMISSAO") != null && !ParametrosRegrasEmissao.CdTipoEmissaoCapa.Contains(x.ObterPorColuna("CD_TIPO_EMISSAO").ValorFormatado)).ToList();

            var ehParcAuto = triplice.ArquivoParcEmissao.tipoArquivo == TipoArquivo.ParcEmissaoAuto;
            ValidaXmlFG07(linhasStageParc, ehParcAuto);
        }

        public void ValidaXmlFG07(IList<ILinhaTabela> linhasStageParc, bool ehParcAuto)
        {
            var idArquivo = string.Empty;
            ILinhaTabela linhaTemp;
            var erro = false;
            var valorPremioLiquido = linhasStageParc.GroupBy(x => x.ObterPorColuna("NR_PARCELA").ValorFormatado)
                .Select(x => new KeyValuePair<string, decimal>(x.Key,
                x.Sum(y => y.ObterPorColuna("VL_PREMIO_LIQUIDO").ValorDecimal)));

            foreach (ILinhaTabela linhaStage in linhasStageParc)
            {
                linhaTemp = (ILinhaTabela)linhaStage.Clone();
                InserirCpfCorretor(ref linhaTemp);
                if (!validadorXML.ValidarInclusaoNasTabelas(linhaTemp, "711", ehParcAuto,
                    valorPremioLiquido.First(x => x.Key == linhaTemp.ObterPorColuna("NR_PARCELA").ValorFormatado).Value,
                    out idArquivo) && !erro)
                    erro = true;
            }

            ValidarXMLComTabelasOIM(idArquivo, ehParcAuto);

            foreach (ILinhaTabela linhaStage in linhasStageParc)
            {
                ValidarBancoStatusOIM(linhaStage, idArquivo);
            }

            if (erro)
            {
                ExplodeFalha("ERRO ENCONTRADO NA VALIDAÇÃO DE INCLUSAO NAS TABELAS.");
            }
        }

        private void InserirCpfCorretor(ref ILinhaTabela linhaDaStage)
        {
            linhaDaStage.Campos.Add(new Campo("CP_CORRETOR", dados.ObterCPFDoCorretor(linhaDaStage.ObterPorColuna("CD_CORRETOR").ValorFormatado)));
        }

        protected IList<ILinhaTabela> ExecutarValidarFG07(bool sucessoNaFG071, bool clienteEnviado = true, bool comissaoEnviado = true, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;

            ExecutarFG07();

            ValidarStageSucessoFG07(clienteEnviado,comissaoEnviado, _triplice);

            ExecutarFG07_1();

            var linhas = ValidarStageSucessoFG07_1(FGs.FG07.ObterCodigoDeSucessoOuFalha(sucessoNaFG071), clienteEnviado, comissaoEnviado);
            ValidarTeste();

            return linhas;
        }

        protected void ExecutarFG07()
        {
            ChamarExecucaoSemErro(FG07_Tarefas.APL01.ObterTexto());
            ChamarExecucaoSemErro(FG07_Tarefas.CMS01.ObterTexto());
            ChamarExecucaoSemErro(FG07_Tarefas.COB01.ObterTexto());
            ChamarExecucaoSemErro(FG07_Tarefas.ITAUTO01.ObterTexto());
            ChamarExecucaoSemErro(FG07_Tarefas.PARC01.ObterTexto());
            ChamarExecucaoSemErro(FG07_Tarefas.ATUALIZA_STATUS.ObterTexto());
        }

        protected void ExecutarFG07_1()
        {
            ChamarExecucaoSemErro(FG07_Tarefas.FGR_07_1.ObterTexto());
        }

        protected void ValidarBancoStatusOIM(ILinhaTabela linhaStageParc, string idArquivo)
        {
            var dataAccessOIM = new DataAccessOIM(logger);
            var resultadoOIM = dataAccessOIM.ValidarRegistrosOIM(linhaStageParc);
            var count = 0;
            while (!resultadoOIM && count < 5)
            {
                if (count >= 5)
                    break;

                if (dataAccessOIM.LogarErrosEncontradosRetornandoSeHouveErro(idArquivo))
                    ExplodeFalha("ERRO NA VALIDAÇÃO DOS REGISTROS DA OIM.");
                else
                {
                    count++;
                    logger.Escrever($"TENTATIVA : {count}");
                    logger.Escrever("ERRO ENCONTRADO POREM NENHUM ERRO LOGADO NA TABELA oim_validacoes_imp: INICIANDO NOVA TENTATIVA.");
                    resultadoOIM = dataAccessOIM.ValidarRegistrosOIM(linhaStageParc);
                    Thread.Sleep(5000);

                }
            }
        }

        protected void SalvaExecutaEValidaTrinca(bool enviarParaOds = true)
        {
            CriarEmissaoCompletaFG06(true, true);
            if (enviarParaOds)
            {
                EnviarParaOds(triplice.ArquivoCliente, false, true, CodigoStage.AprovadoFG06);
                EnviarParaOds(triplice.ArquivoParcEmissao, false, true, CodigoStage.AprovadoFG06);
                EnviarParaOds(triplice.ArquivoComissao, false, true, CodigoStage.AprovadoFG06);
            }
        }
        protected void SalvaExecutaEValidaTrincaFG02(bool enviarParaOds = true)
        {
             CriarEmissaoCompletaFG02(true, true);
            if (enviarParaOds)
            {
                EnviarParaOds(triplice.ArquivoCliente, false, false, CodigoStage.AprovadoNegocioSemDependencia);
                EnviarParaOds(triplice.ArquivoParcEmissao, false, false, CodigoStage.AprovadoNegocioSemDependencia);
                EnviarParaOds(triplice.ArquivoComissao, false, false, CodigoStage.AprovadoNegocioSemDependencia);
            }
        }

        protected void CriarEmissaoCompletaFG06(bool salvaCliente, bool salvaComissao = true, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;
            SalvarTrinca(salvaCliente, true, salvaComissao, _triplice);
            ValidarFGsAnterioresEErros();

            ExecutarEValidarFG06EmissaoSucesso(salvaCliente, salvaComissao);
            ValidarTeste();
        }

        protected void CriarEmissaoCompletaFG02(bool salvaCliente, bool salvaComissao = true, ITriplice _triplice = null)
        {
            _triplice = _triplice == null ? triplice : _triplice;
            SalvarTrinca(salvaCliente, true, salvaComissao, _triplice);
            ValidarFGsAnterioresEErros(FGs.FG02);
            ValidarTeste();
        }
    }
}
