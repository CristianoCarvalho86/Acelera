using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.RegrasNegocio;
using Acelera.Testes.ConjuntoArquivos;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Acelera.Specflow.Steps
{
    [Binding]
    public sealed class ArquivoStepDefinitions : BaseSteps
    {
        public override string nomeFg => "FGR_02";
        TripliceLASA trinca;

        public ArquivoStepDefinitions(ScenarioContext scenarioContext) : base(scenarioContext)
        {
            
        }

        [Given("um arquivo '(.*)' de '(.*)', com '(.*)' linhas")]
        public void DadoUmArquivo(string _operacao, string _tipoArquivo, int linhas)
        {
            var operacao = EnumUtils.ObterEnumPelaDescricao<OperadoraEnum>(_operacao);
            var tipoArquivo = EnumUtils.ObterEnumPelaDescricao<TipoArquivo>(_tipoArquivo);
            CarregaArquivo(tipoArquivo, operacao, linhas);
        }

        [Given("um arquivo '(.*)' de '(.*)'")]
        public void DadoUmArquivo(string _operacao, string _tipoArquivo)
        {
            var operacao = EnumUtils.ObterEnumPelaDescricao<OperadoraEnum>(_operacao);
            var tipoArquivo = EnumUtils.ObterEnumPelaDescricao<TipoArquivo>(_tipoArquivo);
            CarregaArquivo(tipoArquivo, operacao, 1);
        }

        [Given("uma trinca '(.*)' de emissao")]
        public void DadoUmaTrinca(string _operacao)
        {
            List<string> _arquivosSalvos = new List<string>();
            trinca = new TripliceLASA(1, logger, ref _arquivosSalvos);
        }

        [Given(@"com '(.*)' = '(.*)'")]
        public void GivenCom(string p0, string p1)
        {
            trinca.AlterarParcEComissao(0, p0, p1);
        }
        [Given(@"trinca enviada para ODS")]
        public void GivenTrincaEnviadaParaODS()
        {
            EnviarTrincaParaOds(trinca);
            ScenarioContext.Current.Pending();
        }



        [Given(@"uma trinca '(.*)' de cancelamento")]
        public void GivenUmaTrincaDeCancelamento(string p0)
        {
            ScenarioContext.Current.Pending();
        }




        private void CarregaArquivo(TipoArquivo tipoArquivo, OperadoraEnum operacao, int linhas)
        {
            CriarLog(operacao.ObterTexto());
            CarregaRegras();

            var enderecoArquivo = ArquivoOrigem.ObterArquivoAleatorio(tipoArquivo, operacao, Parametros.pastaOrigem);
            var arquivo = LayoutUtils.CarregarLayout(tipoArquivo, operacao);
            arquivo.Carregar(enderecoArquivo, 1, 1, linhas);
            _scenarioContext.Add("arquivo", arquivo);
        }

        [Given("na linha '(.*)' o '(.*)' = '(.*)'")]
        public void AlterarLinha(int linha, string campo, string valor)
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo",out arquivo);
            arquivo.AlterarLinha(linha - 1, campo, valor);
        }

        [Given("na Comissao")]
        public void NaComissao(Table table)
        {

        }
        [Given("no Cliente")]
        public void NoCliente(Table table)
        {

        }

        [Given("na Parcela")]
        public void NaParcela(Table table)
        {

        }

        [Given("contendo '(.*)' parcelas")]
        public void ContendoParcelas(int quantidade)
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);

            contratoRegras.CriarNovoContrato(0, arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            quantidade = quantidade - 1;
            for (int i = 0; i < quantidade; i++)
            {
                emissaoRegras.CriarNovaLinhaParaEmissao(arquivo, arquivo.UltimaLinha.Index);
            }
        }

        [Given("contendo '(.*)' coberturas")]
        public void ContendoCoberturas(int quantidade)
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);

            contratoRegras.CriarNovoContrato(0, arquivo);
            emissaoRegras.AlterarLinhaParaPrimeiraEmissao(arquivo, 0);

            quantidade = quantidade - 1;
            for (int i = 0; i < quantidade; i++)
            {

            }
        }

        [When("dados no arquivo")]
        public void DadosNoArquivo(Table table)
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);
            int index = 0;
            foreach (TableRow row in table.Rows)
            {
                for (int i = 0; i < row.Keys.Count; i++)
                {
                    arquivo.AlterarLinha(index, row.Keys.ElementAt(i),row.Values.ElementAt(i));
                }
                index++;
            }
        }

        [When("executado até a '(.*)'")]
        public void ExecutadoAte(string _fg)
        {
            var fg = EnumUtils.ObterEnumPelaDescricao<FGs>(_fg);
            executarAteFg = fg;
        }

        [When(@"trinca executada até a '(.*)'")]
        public void WhenTrincaExecutadaAteA(string p0)
        {
            var fg = EnumUtils.ObterEnumPelaDescricao<FGs>(p0);
            executarAteFg = fg;
            ScenarioContext.Current.Pending();
        }



        [Then("espera-se status = '(.*)' na Stage")]
        public void ValidacaoStage(CodigoStage codigoStage)
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);
            SalvarArquivo(arquivo);

            codigoStageEsperado = codigoStage;
        }

        [Then("espera-se erro '(.*)' na Tabela de Retorno")]
        public void ValidacaoTabelaDeRetorno(string msg)
        {
            msgTabelaDeRetornoEsperada = msg;

            executarEValidar();
        }

        private void executarEValidar()
        {
            IArquivo arquivo;
            _scenarioContext.TryGetValue<IArquivo>("arquivo", out arquivo);
            sucessoDoTeste = execucaoRegras.ExecutarEValidarAteFg(arquivo, executarAteFg, codigoStageEsperado, msgTabelaDeRetornoEsperada); 
        }


        private void EnviarTrincaParaOds(TripliceLASA trinca)
        {
            throw new NotImplementedException();
        }
    }
}
