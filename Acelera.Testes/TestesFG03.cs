using Acelera.Domain.Entidades.SGS;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2;
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

        protected Massa_Cliente_Sinistro clienteSGS;
        protected IList<Massa_Sinistro_Parcela> parcelaSGS;

        public TestesFG03()
        {
            SGS_dados = new SGSData(logger);
        }

        public void ValidarCdContratoDisponivel(string cdContrato)
        {

        }

        public void ValidarCdTpaNaParametroGlobal(string cdTpa)
        {

        }

        public void ValidarRegistroNaoExisteNaODSParcela(string cdTpa, string cdContrato, string nrSeqEmissao)
        {
            var cdPnOperacao = dados.ObterCdParceiroNegocioParaTPA(cdTpa);

        }

        public void ValidaTabelasTemporariasSGS(string cdItem, string cdContrato, string nrSeqEmissao, string cdClienteo)
        {

        }

        public void CarregarClienteSGS(string cdCliente)
        {

        }

        public void CarregarEnderecoSGS(string cdCliente)
        {

        }

        public void CarregarPaisSGS()
        {

        }


        public void ValidarStageCliente()
        {

        }

        public void ValidarStageParcela()
        {

        }

        public void ValidarStageParcelaAuto()
        {

        }

        public void Executar()
        {

        }

        public override void ValidarFGsAnteriores()
        {
            throw new NotImplementedException();
        }

        public void ValidarFGsAnteriores(bool ValidaFG00, bool ValidaFG02)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            if(ValidaFG00)
                base.ValidarFGsAnteriores();

            logger.EscreverBloco("Inicio da Validação da FG01.");
            //PROCESSAR O ARQUIVO CRIADO
            base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG01Enum().ObterTexto());
            base.ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas());
            base.ValidarStages(CodigoStage.AprovadoNaFG01);
            ValidarTabelaDeRetornoFG01();
            logger.EscreverBloco("Fim da Validação da FG01. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            ValidarTeste();

            if (ValidaFG02)
            {
                logger.EscreverBloco("Inicio da FG02.");
                base.ChamarExecucao(tipoArquivoTeste.ObterTarefaFG02Enum().ObterTexto());
                base.ValidarLogProcessamento(true, 1, base.ObterProceduresASeremExecutadas());
                base.ValidarStages(CodigoStage.AprovadoNegocioSemDependencia);
                ValidarTabelaDeRetorno();
                logger.EscreverBloco("Fim da Validação da FG02. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
                ValidarTeste();
            }
        }


    }
}
