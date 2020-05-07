using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Entidades.Stages;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Testes.Validadores.FG01;
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
        protected bool AoMenosUmComCodigoEsperado = false;
        public static IList<string> ObterProcedures(TipoArquivo tipoArquivoTeste)
        {
            var lista = new List<string>();
            switch (tipoArquivoTeste)
            {
                case TipoArquivo.Cliente:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0041");
                    lista.Add("PRC_0126");
                    break;
                case TipoArquivo.ParcEmissao:
                    lista.Add("PRC_0014");
                    lista.Add("PRC_0015");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_200000");
                    break;

                case TipoArquivo.ParcEmissaoAuto:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0014");
                    lista.Add("PRC_0015");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_200000");
                    break;
                case TipoArquivo.Comissao:
                case TipoArquivo.LanctoComissao:
                case TipoArquivo.OCRCobranca:
                    lista.Add("PRC_200000");
                    break;
                case TipoArquivo.Sinistro:
                    lista.Add("PRC_0008");
                    lista.Add("PRC_0062");
                    lista.Add("PRC_0066");
                    lista.Add("PRC_0126");
                    lista.Add("PRC_200000");
                    lista.Add("PRC_0074");
                    break;
                default:
                    throw new Exception("TIPO ARQUIVO NAO ENCONTRADO.");

            }
            lista.Add("PRC_0110");
            lista.Add("PRC_0001");
            lista.Add("PRC_0005");
            lista.Add("PRC_0006");
            lista.Add("PRC_0007");

            return lista;
        }

        protected override IList<string> ObterProceduresASeremExecutadas()
        {
            return TestesFG00.ObterProcedures().Concat(ObterProcedures(tipoArquivoTeste)).ToList();
        }

        public virtual void ValidarFGsAnteriores() 
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            logger.EscreverBloco("Inicio da Validação da FG00.");
            //PROCESSAR O ARQUIVO CRIADO
            ChamarExecucao(tipoArquivoTeste.ObterTarefaFG00Enum().ObterTexto());
            ValidarLogProcessamento(true,1, TestesFG00.ObterProcedures());
            ValidarControleArquivo();
            ValidarTabelaDeRetornoFG00();
            logger.EscreverBloco("Fim da Validação da FG00. Resultado :" + (sucessoDoTeste ? "SUCESSO" : "FALHA"));
            logger.EscreverBloco("Inicio da FG01.");
            ValidarTeste();
        }

        public override void ValidarStages(TabelasEnum tabela, bool deveHaverRegistro, int codigoEsperado = 0)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try { 
            logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"{NomeFG} - Tabela:{tabela.ObterTexto()}");
            var validador = new ValidadorStagesFG01(tipoArquivoTeste.ObterTabelaStageEnum(), nomeArquivo, logger,
                valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

            var linhasEncontradas = new List<ILinhaTabela>();
            if (validador.ValidarTabelaFG01(deveHaverRegistro, codigoEsperado, AoMenosUmComCodigoEsperado))
                logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"{NomeFG} - Tabela:{tabela.ObterTexto()}");
            else
                ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($"{NomeFG}: Validação da Stage : {tabela.ObterTexto()}");
            }
        }
        public void ValidarStages(CodigoStage codigo)
        {
            ValidarStages(tipoArquivoTeste.ObterTabelaStageEnum(),true,(int)codigo);
        }

        public void ValidarStages(CodigoStage codigo, bool aoMenosUmComCodigoEsperado)
        {
            AoMenosUmComCodigoEsperado = aoMenosUmComCodigoEsperado;
            ValidarStages(tipoArquivoTeste.ObterTabelaStageEnum(), true, (int)codigo);
            AoMenosUmComCodigoEsperado = false;
        }
        public override void ValidarTabelaDeRetorno(bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            ValidarTabelaDeRetornoFG01(validaQuantidadeErros, codigosDeErroEsperados);
        }

        public void ValidarTabelaDeRetornoFG01(bool validaQuantidadeErros = false, params string[] codigosDeErroEsperados)
        {
            if (Parametros.ModoExecucao == ModoExecucaoEnum.ApenasCriacao)
                return;

            try
            {
                AjustarEntradaErros(ref codigosDeErroEsperados);
                logger.InicioOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                var validador = new ValidadorTabelaRetornoFG01(tipoArquivoTeste.ObterTabelaStageEnum(), nomeArquivo, logger,
                    valoresAlteradosBody, valoresAlteradosHeader, valoresAlteradosFooter);

                if (validador.ValidarTabela(validaQuantidadeErros, codigosDeErroEsperados))
                    logger.SucessoDaOperacao(OperacaoEnum.ValidarResultado, $"Tabela:{TabelasEnum.TabelaRetorno.ObterTexto()}");
                else
                    ExplodeFalha();
            }
            catch (Exception)
            {
                TratarErro($"{NomeFG}: Validação da Tabela Retorno");
            }
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
