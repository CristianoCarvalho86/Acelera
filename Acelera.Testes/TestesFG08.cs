using Acelera.Domain;
using Acelera.Domain.DataAccess;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.RegrasNegocio;
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
        private bool _operacaoSucesso = true;
        private bool OperacaoSucesso
        {
            get { return _operacaoSucesso; }
            set
            {
                if (!value && _operacaoSucesso)
                    _operacaoSucesso = false;

            }
        }
        ValidadorODS validadorODS;
        private DeleteStages deleteStages;

        public TestesFG08()
        {

        }

        public void IniciarTesteFG08(string numeroTeste, string descricao, OperadoraEnum operadora, bool geraCliente = true, bool gerarArquivoCapa = false)
        {
            base.IniciarTesteFG07(numeroTeste, descricao, operadora, geraCliente, gerarArquivoCapa);
            validadorODS = new ValidadorODS(new DadosParametrosData(logger),ref logger);
            deleteStages = new DeleteStages(ref logger);
            DeletarRegistrosAntigosDaStage();
        }

        public void ExecutarEValidarFG08(bool esperaSucesso)
        {
            ExecutarFG08();
            //Validar
            ValidarFG08(trinca, esperaSucesso);
        }

        protected void ExecutarFG08()
        {
            ChamarExecucao(FG08_Tarefas.FGR_08.ObterTexto());
        }

        protected void ValidarFG08(ITrinca triplice, bool esperaSucesso)
        {
            var linhasStageParc = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoParcEmissao);
            var linhasStageCliente = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoCliente);
            var linhasStageComissao = ValidarStages(true, (int)FGs.FG08.ObterCodigoDeSucessoOuFalha(esperaSucesso), triplice.ArquivoComissao);

            ValidarTeste();

            IList<ILinhaTabela> linhasDaTabelaDeRetorno;

            var validadorTabelaDeRetorno = new ValidadorTabelaRetorno(triplice.ArquivoParcEmissao.NomeArquivo, logger, triplice.ArquivoParcEmissao);
            linhasDaTabelaDeRetorno = validadorTabelaDeRetorno.RetornarRegistrosDaTabelaDeRetorno();
            if (esperaSucesso && linhasDaTabelaDeRetorno.Count > 0)
                TratarErro($"FORAM ENCONTRADOS ERROS NA TABELA DE RETORNO : {linhasDaTabelaDeRetorno.Select(x => x.ObterPorColuna("CD_MENSAGEM").ValorFormatado).ObterListaConcatenada(" ,")}");

            foreach (var linha in linhasStageParc)
                if (!ValidarStInterface(esperaSucesso, linha.ObterPorColuna("NR_APOLICE").ValorFormatado, linha.ObterPorColuna("NR_ENDOSSO").ValorFormatado))
                    ExplodeFalha();

            //esperaSucesso eh invertido, pois em caso de sucesso nao tem registro na tabela de retorno
            ValidarTabelaDeRetornoVazia(triplice.ArquivoCliente, !esperaSucesso);
            ValidarTabelaDeRetornoVazia(triplice.ArquivoParcEmissao, !esperaSucesso);
            ValidarTabelaDeRetornoVazia(triplice.ArquivoComissao, !esperaSucesso);

            ValidarTeste();//Estoura os erros caso existam.

            //OperacaoSucesso só pode ser negativado uma vez, nao recebe true após isso.
            foreach (var linha in linhasStageParc)
                OperacaoSucesso = validadorODS.RegistroEstaNaOds(linha, esperaSucesso);
            foreach (var linha in linhasStageCliente)
                OperacaoSucesso = validadorODS.RegistroEstaNaOds(linha, esperaSucesso);
            foreach (var linha in linhasStageComissao)
                OperacaoSucesso = validadorODS.RegistroEstaNaOds(linha, esperaSucesso);

            if (!OperacaoSucesso)
                ExplodeFalha();

        }

        protected bool ValidarStInterface(bool esperaSucesso, string nrApolice, string nrEndosso)
        {
            var stInterface = DataAccess.ConsultaUnica($"SELECT \"st_interface\" FROM {Parametros.instanciaDB}.{TabelasOIMEnum.OIM_APL01.ObterTexto()} " +
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

        protected void DeletarRegistrosAntigosDaStage()
        {
            if (!deleteStages.DeletarRegistrosTrinca(CodigoStage.AprovadoNaFG08, trinca.EhParcAuto))
                ExplodeFalha($"ERRO AO DELETAR REGISTROS DA TRINCA COM CODIGO {(int)CodigoStage.AprovadoNaFG08}");
        }

    }
}
