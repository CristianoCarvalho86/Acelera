using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.Repositorio;
using Acelera.Testes.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG01 : TestesFG00
    {
        protected override string NomeFG => "FG01";

        
        public virtual void ValidarFGsAnteriores(IArquivo _arquivo = null) 
        {
            SetarArquivoEmUso(ref _arquivo);

            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            logger.EscreverBloco("Inicio da Validação da FG00.");
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(_arquivo.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            execucaoRegras.ValidarLogProcessamento(_arquivo,true, 1, RepositorioProcedures.ObterProcedures(FGs.FG00, _arquivo.tipoArquivo));
            execucaoRegras.ValidarControleArquivo(_arquivo);
            this.ValidarTabelaDeRetornoFG00(false,false, _arquivo);
            this.ValidarStages(CodigoStage.AprovadoNAFG00);
            logger.EscreverBloco("Fim da Validação da FG00. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            logger.EscreverBloco("Inicio da FG01.");
            ValidarTeste();
        }

        public override void ValidarTabelaDeRetorno(IArquivo _arquivo = null, bool naoDeveEncontrar = false, bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            _arquivo = arquivo == null ? this.arquivo : _arquivo;
            ValidarTabelaDeRetornoFG01(_arquivo, naoDeveEncontrar, validaQuantidadeErros, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetornoFG01(IArquivo _arquivo ,bool naoDeveEncontrar = false,bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetorno(_arquivo.NomeArquivo, logger,_arquivo);

                if (validador.ValidarTabela(TabelasEnum.TabelaRetorno , naoDeveEncontrar, validaQuantidadeErros, false, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($" Validação da Tabela Retorno");
            }
        }

        public void ValidarFG01_2(IArquivo _arquivo, CodigoStage codigoEsperadoStage, string erroEsperadoNaTabelaDeRetorno = null)
        {
            ValidarTabelaDeRetorno(_arquivo,erroEsperadoNaTabelaDeRetorno);
            ValidarStages(codigoEsperadoStage,false, _arquivo);
        }

        protected override IList<string> ObterProceduresASeremExecutadas(IArquivo _arquivo)
        {
            return RepositorioProcedures.ObterProcedures(FGs.FG01, _arquivo.tipoArquivo);
        }

        public string ObterContratoPlanoB()
        {
            List<string> contratos = new List<string>();
            contratos.Add("797100080017");
            contratos.Add("797100057833");
            contratos.Add("797100081000");
            contratos.Add("797100091793");
            contratos.Add("797100076022");
            contratos.Add("797100117528");
            contratos.Add("797100109524");
            contratos.Add("797100115144");
            contratos.Add("797100185781");
            contratos.Add("797100034609");
            contratos.Add("797100051107");
            contratos.Add("797100054693");
            contratos.Add("797100074423");
            contratos.Add("797100074556");
            contratos.Add("797100066644");
            contratos.Add("797100022581");
            contratos.Add("797700335243");
            contratos.Add("797100025590");
            contratos.Add("797700358855");
            contratos.Add("797100037587");
            var r = new Random();
            var contrato = contratos[r.Next(0, contratos.Count - 1)];
            logger.EscreverBloco($"CONTRATO USADO PARA PLANO B : {contrato}");
            return contrato;

        }
    }
}
