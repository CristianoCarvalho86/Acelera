using Acelera.Contratos;
using Acelera.Data;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Utils;
using Acelera.Testes.Repositorio;
using Acelera.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    [TestClass]
    public class TestesFG09 : TestesFG05
    {
        protected override string NomeFG => "FG09";
        protected override void ExecutarEValidar(CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno = "", int qtdErrosNaTabelaDeRetorno = 0)
        {
            ValidarFGsAnteriores();

            //Executar FG09
            ChamarExecucao(arquivo.tipoArquivo.ObterTarefaFG09Enum().ObterTexto());

            //VALIDAR NA FG09
            Validar(codigoEsperadoStage, erroEsperadoNaTabelaDeRetorno, qtdErrosNaTabelaDeRetorno);
        }
       
        protected void ExecutarEValidarApenasFg09(IArquivo _arquivo, string falhaEsperada = "")
        {
            SetarArquivoEmUso(ref _arquivo);
            ExecutarEValidar(_arquivo, FGs.FG09, FGs.FG09.ObterCodigoDeSucessoOuFalha(string.IsNullOrEmpty(falhaEsperada)), falhaEsperada);
            if (!execucaoRegras.ValidarLogProcessamento(_arquivo, true, 1, RepositorioProcedures.ObterProcedures(FGs.FG09, _arquivo.tipoArquivo)))
                ExplodeFalha();

        }

        protected override void ExecutarEValidarDesconsiderandoErro(CodigoStage codigoEsperadoStage, string erroNaoEsperadoNaTabelaDeRetorno, IArquivo _arquivo = null)
        {
            SetarArquivoEmUso(ref _arquivo);
            ValidarFGsAnteriores(_arquivo);

            //Executar FG09
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG09Enum().ObterTexto());

            ValidarDesconsiderandoErro(_arquivo,codigoEsperadoStage, erroNaoEsperadoNaTabelaDeRetorno);
        }

        protected IArquivo CriarEmissaoODS<T>(OperadoraEnum operadora, bool alterarVersaoHeader = false,int qtdParcelas = 1, string nrParcela = ""
            ,bool enviarParaOds = true, string cdCoberturaDoCorretor = "") where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, 1, operadora);
            contratoRegras.CriarNovoContrato(0,arquivo);
            AlterarLinha(0, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaPrimeiraLinhaDaEmissao(operadora));

            AlterarLinha(0, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, ObterValorHeader("CD_TPA")));

            AlterarLinha(0, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroSequencialEmissao(operadora));
            AlterarLinha(0, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaPrimeiroNumeroEndosso(arquivo[0], operadora));
            AlterarLinha(0, "ID_TRANSACAO_CANC", "");
            
            AlterarLinha(0, "NR_PARCELA", ParametrosRegrasEmissao.CarregaPrimeiroNrParcela(operadora));
 
            if(!string.IsNullOrEmpty(nrParcela))
                AlterarLinha(0, "NR_PARCELA", nrParcela);

            if (operadora != OperadoraEnum.VIVO)
            {
                AlterarLinha(0, "CD_SEGURADORA", "5908");
                if(string.IsNullOrEmpty(cdCoberturaDoCorretor))
                    AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracao(ObterValorHeader("CD_TPA"), "P", true));
                else
                    AlterarLinha(0, "CD_CORRETOR", dados.ObterCdCorretorParaTipoRemuneracaoECobertura(ObterValorHeader("CD_TPA"), "P", cdCoberturaDoCorretor));
            }

            for (int i = 1; i < qtdParcelas; i++)
            {
                AdicionarLinha(i, ObterLinha(0));

                AlterarLinha(i, "CD_TIPO_EMISSAO", ParametrosRegrasEmissao.CarregaTipoEmissaoParaSegundaLinhaDaEmissao(operadora));
                AlterarLinha(i, "NR_SEQUENCIAL_EMISSAO", ParametrosRegrasEmissao.CarregaProximoNumeroSequencialEmissao(arquivo.UltimaLinha, operadora));
                AlterarLinha(i, "NR_PARCELA",  (i + ObterValorFormatado(0, "NR_PARCELA").ObterParteNumericaDoTexto()).ToString());
                AlterarLinha(i, "NR_ENDOSSO", ParametrosRegrasEmissao.CarregaProximoNumeroEndosso(arquivo.UltimaLinha));
                AlterarLinha(i, "ID_TRANSACAO_CANC", "");
            }


            if(alterarVersaoHeader)
                AlterarHeader("VERSAO", "9.6");
            if(enviarParaOds)
                EnviarParaOdsAlterandoCliente(arquivo, false);
            return arquivo.Clone();
        }

        protected IArquivo CriarEmissaoComissaoODS<T>(OperadoraEnum operadora, IArquivo arquivoParcela, bool alterarVersaoHeader = false, bool enviarOds = true) where T : Arquivo, new()
        {
            if (alterarVersaoHeader)
                return CriarEmissaoComissaoODS<T>(operadora, arquivoParcela, "9.6", enviarOds);
            return CriarEmissaoComissaoODS<T>(operadora, arquivoParcela, "", enviarOds);
        }

        protected IArquivo CriarEmissaoComissaoODS<T>(OperadoraEnum operadora, IArquivo arquivoParcela, string alterarVersaoHeader = "", bool enviarOds = true) where T : Arquivo, new()
        {
            arquivo = comissaoRegras.CriarComissao<T>(operadora, arquivoParcela, alterarVersaoHeader);

            if (enviarOds)
                EnviarParaOdsAlterandoCliente(arquivo);
            return arquivo.Clone();
        }

        
        protected IArquivo CriarParcelaCancelamento<T>(OperadoraEnum operadora, IArquivo arquivoParcela, bool alterarVersaoHeader = false, string cdTipoEmissao = "10", string cdMovtoCobranca = "02", string nrSequencialEmissao = "") where T : Arquivo, new()
        {
            arquivo = new T();
            CarregarArquivo(arquivo, 1, operadora);

            RemoverTodasAsLinhas();
            var ultimoNrSeqUsado = int.Parse(arquivoParcela.Linhas.Last()["NR_SEQUENCIAL_EMISSAO"]);
            foreach (var linha in arquivoParcela.Linhas)
            {
                ultimoNrSeqUsado++;
                AdicionarLinha(0, cancelamentoRegras.CriarLinhaCancelamento(arquivoParcela.ObterLinha(0), cdTipoEmissao, cdMovtoCobranca, ultimoNrSeqUsado.ToString()));
            }
            return arquivo;
        }

        protected override IList<string> ObterProceduresASeremExecutadas(IArquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG09, _arquivo.tipoArquivo);
        }
    }
}
