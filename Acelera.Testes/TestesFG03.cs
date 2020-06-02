using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG03 : TestesFG02
    {
        protected SGSData SGS_dados;

        protected IList<Massa_Cliente_Sinistro> clienteSGS;
        protected IList<Massa_Sinistro_Parcela> parcelaSGS;
        protected ClienteSGS cliente;
        protected PaisSGS pais;
        protected IList<EnderecoSGS> enderecos;
        protected EmissaoSGS emissao;

        protected override string NomeFG => "FG03";
        public TestesFG03()
        {
            
        }

        protected override void IniciarTeste(TipoArquivo tipo, string numeroDoTeste, string nomeDoTeste)
        {
            base.IniciarTeste(tipo, numeroDoTeste, nomeDoTeste);
            SGS_dados = new SGSData(logger);
        }

        public void CarregarSinistroDoContrato(string cdContrato)
        {
            SGS_dados.CarregarSinistroDoContrato(arquivo, cdContrato);
        }

        public void ObterLinhaComCdContratoDisponivel()
        {
            logger.AbrirBloco("PROCURANDO CONTRATOS DISPONIVEIS NO ARQUIVO.");
            var contratosUtilizados = ControleCDContratoFG03.Instancia.ObterContratosUtilizados();
            var linha = arquivo.Linhas.Where(x => !contratosUtilizados.Contains(x.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado)).FirstOrDefault();
            if(linha == null)
            {
                logger.Erro("NAO FORAM ENCONTRADOS CONTRATOS DISPONIVEIS NO ARQUIVO");
            }
            logger.Escrever($"CONTRATO ENCONTRADO : '{linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado}' , Linha: {linha.Index} " );
            arquivo.RemoverExcetoEstas(linha.Index, 1);
            ControleCDContratoFG03.Instancia.AtualizaArquivo(linha.ObterCampoDoArquivo("CD_CONTRATO").ValorFormatado);
            logger.Escrever($"OUTRAS LINHAS DO ARQUIVO REMOVIDOS." );
            arquivo.ReIndexar();
            arquivo.AjustarQtdLinhasNoFooter();
            logger.FecharBloco();
        }

        public void ValidarCdTpaNaParametroGlobal(string cdTpa, bool deveEncontrar = true)
        {
            var registroEncontrado = SGS_dados.ValidarCdTpaNaParametroGlobal(cdTpa);
            if (!registroEncontrado && deveEncontrar)
            {
                logger.Erro("REGISTRO DO TPA NA PARAMETRO GLOBAL DEVIA TER SIDO ENCONTRADO.");
                ExplodeFalha();
            }
            else if(registroEncontrado && !deveEncontrar)
            {
                logger.Erro("REGISTRO DO TPA NA PARAMETRO GLOBAL NAO DEVIA TER SIDO ENCONTRADO.");
                ExplodeFalha();
            }
        }

        public void ValidarRegistroNaoExisteNaODSParcela(string cdTpa, string cdContrato, string nrSeqEmissao, bool deveEncontrar = false)
        {
            var cdPnOperacao = dados.ObterCdParceiroNegocioParaTPA(cdTpa);
            var registroNaoEncontrado = SGS_dados.ValidarRegistroNaoExisteNaODSParcela(cdPnOperacao, cdContrato, nrSeqEmissao);
            if (registroNaoEncontrado && deveEncontrar)
                ExplodeFalha();
            else if (!registroNaoEncontrado && !deveEncontrar)
                ExplodeFalha();

        }

        public void ValidaTabelasTemporariasSGSVazia(string cdItem, string cdContrato, string nrSeqEmissao, string cdCliente)
        {
            SGS_dados.CarregaEntidadesDasTabelasTemporariasSGS(cdItem, cdContrato, nrSeqEmissao, cdCliente, out clienteSGS, out parcelaSGS);
            if(clienteSGS.Count() > 0 || parcelaSGS.Count() > 0)
            {
                logger.Erro($"FORAM ENCONTRADOS REGISTROS NAS TABELAS TEMPORARIAS, CLIENTES : {clienteSGS.Count}, PARCELAS : {parcelaSGS.Count}");
                ExplodeFalha();
            }
        }

        public void ValidaTabelasTemporariasSGS(string cdItem, string cdContrato, string nrSeqEmissao, string cdCliente, bool deveHaverMultiplosClientes = false, bool deveHaverMultiplasParcelas = true)
        {
            SGS_dados.CarregaEntidadesDasTabelasTemporariasSGS(cdItem, cdContrato, nrSeqEmissao, cdCliente, out clienteSGS, out parcelaSGS);

            if ((deveHaverMultiplosClientes && clienteSGS.Count() <= 1) ||
                (deveHaverMultiplasParcelas && parcelaSGS.Count() <= 1))
            {
                logger.Escrever($"FORAM ENCONTRADOS REGISTROS NAS TABELAS TEMPORARIAS, CLIENTES : {clienteSGS.Count}, PARCELAS : {parcelaSGS.Count}");
                logger.Escrever($"ERAM ESPERADOS MULTIPLOS REGISTROS NA TEMPORARIA DE CLIENTES : {deveHaverMultiplosClientes}");
                logger.Escrever($"ERAM ESPERADOS MULTIPLOS REGISTROS NA TEMPORARIA DE PARCELAS : {deveHaverMultiplasParcelas}");
                ExplodeFalha();
            }

            if (deveHaverMultiplosClientes && clienteSGS.Count() == 1)
            {
                logger.Erro($"ERA ESPERADO APENAS 1 CLIENTE NA TABELA TEMPORARIA, FORAM ENCONTRADOS : {clienteSGS.Count()}.");
                ExplodeFalha();
            }
            if (deveHaverMultiplasParcelas && parcelaSGS.Count() == 1)
            {
                logger.Erro($"ERA ESPERADO APENAS 1 PARCELA NA TABELA TEMPORARIA, FORAM ENCONTRADOS : {parcelaSGS.Count()}.");
                ExplodeFalha();
            }
        }


        public void CarregarClienteSGS(string cdCliente)
        {
            SGS_dados.CarregarClienteSGS(cdCliente);
        }

        public void CarregarEnderecoSGS(string cdCliente)
        {

        }

        public void CarregarPaisSGS()
        {

        }

        public void CarregarContratoComUmaParcela(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterCodigoContratoComUmaParcela();
            dadosContrato.CarregaLinhaArquivo(linha);
        }
        public void CarregarContratoComMultiplasParcelas(LinhaArquivo linha)
        {
            var dadosContrato = SGS_dados.ObterCodigoContratoComMultiplasParcelas();
            dadosContrato.CarregaLinhaArquivo(linha);
        }


        public void ValidarStageCliente(CodigoStage codigoEsperado)
        {
            foreach (var cliente in clienteSGS)
                if (!(SGS_dados.ValidarStageCliente(cliente) == codigoEsperado.ObterTexto()))
                ExplodeFalha();
        }

        public void ValidarStageParcela(CodigoStage codigoEsperado)
        {
            foreach(var parcela in parcelaSGS)
                if (!(SGS_dados.ValidarStageParcela(parcela) == codigoEsperado.ObterTexto()))
                    ExplodeFalha();
        }

        public void ValidarStageParcelaAuto(CodigoStage codigoEsperado)
        {
            foreach (var parcela in parcelaSGS)
                if (!(SGS_dados.ValidarStageParcelaAuto(parcela) == codigoEsperado.ObterTexto()))
                    ExplodeFalha();
        }

        public void Executar()
        {
            SGS_dados.Executar();
        }

        public override void ValidarFGsAnteriores()
        {
            throw new NotImplementedException();
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return base.ObterProceduresASeremExecutadas();
        }

        public void ValidarFGsAnteriores(bool ValidaFG00, bool ValidaFG02, CodigoStage codigoAguardadoNa01_1)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            if (ValidaFG00)
            {
                logger.EscreverBloco("Inicio da Validação da FG00.");
                //PROCESSAR O ARQUIVO CRIADO
                base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG00Enum().ObterTexto());
                base.ValidarControleArquivo();
                base.ValidarLogProcessamento(true, 1, ObterProceduresFG00().ToList());
                base.ValidarStages(CodigoStage.AprovadoNAFG00);
                ValidarTabelaDeRetornoFG00();
                logger.EscreverBloco("Fim da Validação da FG00. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();
            }

            logger.EscreverBloco("Inicio da Validação da FG01.");
            //PROCESSAR O ARQUIVO CRIADO
            base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG01Enum().ObterTexto());
            base.ValidarLogProcessamento(true, 1, ObterProceduresFG00().Concat(ObterProceduresFG01(tipoArquivoTeste)).ToList());
            base.ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetornoFG01();
            logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();

            base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG01_1_Enum().ObterTexto());
            base.ValidarStages(codigoAguardadoNa01_1);
            ValidarTeste();

            if (ValidaFG02)
            {
                logger.EscreverBloco("Inicio da FG02.");
                base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG02Enum().ObterTexto());
                base.ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas() );
                base.ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
                ValidarTabelaDeRetorno();
                logger.EscreverBloco("Fim da Validação da FG02. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();
            }
        }


    }
}
