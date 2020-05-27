using Acelera.Domain.Entidades.SGS;
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


        public void ValidarStageCliente(Massa_Cliente_Sinistro massaCliente)
        {

        }

        public void ValidarStageParcela(IList<Massa_Sinistro_Parcela> massaParcelas)
        {

        }

        public void ValidarStageParcelaAuto(IList<Massa_Sinistro_Parcela> massaSinistro)
        {

        }

        public void Executar()
        {

        }


    }
}
