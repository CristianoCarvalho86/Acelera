using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using Acelera.Testes.Validadores;
using Acelera.Testes.Validadores.ODS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes
{
    public class TestesFG08 : FG07_Base
    {
        ValidadorODS validadorODS;
        public TestesFG08()
        {
            validadorODS = new ValidadorODS(ref logger);
        }

        public void ExecutarEValidarFG08(bool sucesso)
        {

            //Validar
        }

        protected void ExecutarFG08()
        {
            ChamarExecucaoSemErro(FG08_Tarefas.FGR_08.ObterTexto());
        }

        protected void ValidarFG08(ITriplice triplice, bool esperaSucesso)
        {
            var linhasStageParc = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoParcEmissao);
            var linhasStageCliente = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoCliente);
            var linhasStageComissao = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoComissao);

            ValidarTeste();

            var validadorTabelaDeRetorno = new ValidadorTabelaRetorno(triplice.ArquivoParcEmissao.NomeArquivo, logger, triplice.ArquivoParcEmissao);
            IList<ILinhaTabela> linhasDaTabelaDeRetorno;
            linhasDaTabelaDeRetorno = validadorTabelaDeRetorno.RetornarRegistrosDaTabelaDeRetorno();
            foreach (var linha in linhasStageParc)
            {
                ValidarStInterface(esperaSucesso, linha.ObterPorColuna("NR_APOLICE").ValorFormatado, linha.ObterPorColuna("NR_ENDOSSO").ValorFormatado);
                if(esperaSucesso && linhasDaTabelaDeRetorno.Count > 0)
                {
                    logger.Erro("FORAM ENCONTRADOS ERROS NA TABELA DE RETORNO : ");
                }
            }
        }

        protected bool ValidarStInterface(bool esperaSucesso, string nrApolice, string nrEndosso)
        {
            var stInterface = DataAccess.ConsultaUnica($"SELECT \"st_interface\" FROM {TabelasOIMEnum.OIM_APL01.ObterTexto()} " +
                $"where \"nr_apolice\" = '{nrApolice}' and \"nr_endosso\" = '{nrEndosso}'");
            var valorEsperado = esperaSucesso ? "A" : "R";
            if (string.IsNullOrEmpty(stInterface))
            {
                TratarErro($"ST_INTERFACE DA TABELA {TabelasOIMEnum.OIM_APL01.ObterTexto()} NAO PREENCHIDO.");
                return false;
            }
            if (stInterface != valorEsperado)
            {
                TratarErro($"ST_INTERFACE DA TABELA '{TabelasOIMEnum.OIM_APL01.ObterTexto()}': '{stInterface}', VALOR ESPERADO: '{valorEsperado}'.");
                return false;
            }
            return true;
        }

    }
}
