using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_3;
using Acelera.Domain.Layouts._9_4;
using Acelera.Domain.Layouts._9_4_2;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG06
{
    [TestClass]
    public class FG06_Base : TestesFG06
    {
        private bool ClienteTemErro;
        private bool ParcelaTemErro;
        private bool ComissaoTemErro;
        private bool ClienteEnviado;
        private bool ParcelaEnviado;
        private bool ComissaoEnviado;

        [TestInitialize]
        private void IniciaTeste()
        {
            ClienteTemErro = false;
            ParcelaTemErro = false;
            ComissaoTemErro = false;
        }

        protected void AdicionaErro(TipoArquivo tipo)
        {
            logger.AbrirBloco("ADICIONANDO ERRO NO ARQUIVO DE " + tipo.ObterTexto());
            if (tipo == TipoArquivo.Cliente)
            {
                ClienteTemErro = true;
                logger.Escrever("DEFINIDO : DT_NASCIMENTO = 20120416 ESPERANDO ERRO NA FG02");
                triplice.ArquivoCliente.AlterarLinha(0, "DT_NASCIMENTO", "20120416");
            }
            else if (tipo == TipoArquivo.ParcEmissao || tipo == TipoArquivo.ParcEmissaoAuto)
            {
                ParcelaTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                triplice.ArquivoParcEmissao.AlterarLinha(0, "CD_RAMO", "00");
            }
            else if (tipo == TipoArquivo.Comissao)
            {
                ComissaoTemErro = true;
                logger.Escrever("DEFINIDO : CD_RAMO = 00 ESPERANDO ERRO NA FG02");
                triplice.ArquivoComissao.AlterarLinha(0, "CD_RAMO", "00");
            }
            else
                throw new Exception("TIPO ARQUIVO NAO DEFINIDO.");
        }

        protected void SalvarTrinca(bool salvaCliente = true, bool salvaParcela = true, bool salvaComissao = true)
        {
            ClienteEnviado = salvaCliente;
            ParcelaEnviado = salvaParcela;
            ComissaoEnviado = salvaComissao;
            triplice.Salvar(salvaCliente, salvaParcela, salvaComissao);
        }

        public void InicioTesteFG06(string numeroTeste, string descricao, OperadoraEnum operadora)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice);
        }

        public void ValidarFGsAnterioresEErros()
        {
            var listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FG02, FGs.FG05 };

            foreach (var fg in listaFgs)
            {
                if(ClienteEnviado)
                    ExecFgs(!ClienteTemErro, fg, triplice.ArquivoCliente);
                if (ParcelaEnviado)
                    ExecFgs(!ParcelaTemErro, fg, triplice.ArquivoParcEmissao);
                if (ComissaoEnviado)
                    ExecFgs(!ComissaoTemErro, fg, triplice.ArquivoComissao);
            }
        }

        protected void ExecutarEValidarFG06EmissaoComErro()
        {
            ExecutarEValidarFG06(triplice,
                ClienteEnviado ? ClienteTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ParcelaEnviado ? ParcelaTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                ComissaoEnviado ? ComissaoTemErro ? (CodigoStage?)CodigoStage.ReprovadoNegocioSemDependencia : CodigoStage.ReprovadoFG06 : null,
                "267", "25", "25");
        }

        private void ExecFgs(bool sucesso, FGs fg, Arquivo arquivo)
        {
            if (sucesso || fg == FGs.FG00 || fg == FGs.FG01)
            {
                ExecutarEValidar(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(true));
            }
            else if (fg == FGs.FG02)
            {
                ExecutarEValidarEsperandoErro(arquivo, fg, fg.ObterCodigoDeSucessoOuFalha(false));
            }
        }
    }
}
