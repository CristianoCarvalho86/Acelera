﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
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
    public class FG06 : TestesFG06
    {
        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5921()
        {
            //5921:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5921", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, CodigoStage.AprovadoFG06, "", "", "");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5922()
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5922", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarCliente(0, "NR_CNPJ_CPF", "00000-00000");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);


            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, CodigoStage.ReprovadoFG06, "41", "103", "105");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5923()
        {
            //FG06 - VIVO - CLI sucesso, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5923", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");
            

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.ReprovadoFG06, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "403", "07", "105");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5924()
        {
            //5924:FG06 - VIVO - CLI sucesso, PARC sucesso e CMS rejeitado
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5924", "");

            CarregarTriplice(OperadoraEnum.VIVO);

            AlteracoesPadraoDaTrinca(triplice);

            triplice.AlterarParcEComissao(0, "VL_COMISSAO", "a");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.ReprovadoFG06, CodigoStage.ReprovadoFG06, CodigoStage.RecusadoNaFG01, "403", "103", "07");

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5925()
        {
            //POMPEIA - CLI rejeitado, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5925", "");

            CarregarTriplice(OperadoraEnum.POMPEIA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");
            triplice.AlterarCliente(0, "NR_CNPJ_CPF", "00000-00000");

            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "41", "07", "105");
        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5926()
        {
            //POMPEIA - CLI rejeitado, PARC rejeitado e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, "5925", "");

            CarregarTriplice(OperadoraEnum.POMPEIA);

            AlteracoesPadraoDaTrinca(triplice);
            triplice.AlterarParcEComissao(0, "VL_PREMIO_LIQUIDO", "abc");
            triplice.AlterarParcEComissao(0, "VL_COMISSAO", "a");


            triplice.Salvar();

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG00, CodigoStage.AprovadoNAFG00);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG00, CodigoStage.AprovadoNAFG00);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.RecusadoNaFG01);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, "403", "07", "07");
        }


        public void InicioTesteFG06(string numeroTeste, string descricao, OperadoraEnum operadora)
        {
            //5922:FG06 - VIVO - CLI rejeitado, PARC sucesso e CMS sucesso
            IniciarTeste(Domain.Enums.TipoArquivo.Comissao, numeroTeste, descricao);

            CarregarTriplice(operadora);

            AlteracoesPadraoDaTrinca(triplice);
        }

        public void FimTesteFG06(KeyValuePair<bool,string> sucessoCliente, KeyValuePair<bool, string> sucessoParcela, KeyValuePair<bool, string> sucessoComissao)
        {
            triplice.Salvar();

            var listaFgs = new FGs[] { FGs.FG00, FGs.FG01, FGs.FG02, FGs.FG05 };

            foreach (var fg in listaFgs)
            {
                if (sucessoCliente.Key == true)
                {
                    ExecutarEValidar(triplice.ArquivoCliente, fg, CodigoStage.AprovadoNAFG00);
                    ExecutarEValidar(triplice.ArquivoParcEmissao, fg, CodigoStage.AprovadoNAFG00);
                    ExecutarEValidar(triplice.ArquivoComissao, fg, CodigoStage.AprovadoNAFG00);
                }
            }

            ExecutarEValidar(triplice.ArquivoCliente, FGs.FG01, CodigoStage.RecusadoNaFG01);
            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG01, CodigoStage.AprovadoNaFG01);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG01, CodigoStage.AprovadoNaFG01);


            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG02, CodigoStage.AprovadoNegocioSemDependencia);

            ExecutarEValidar(triplice.ArquivoParcEmissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);
            ExecutarEValidar(triplice.ArquivoComissao, FGs.FG05, CodigoStage.AprovadoNegocioComDependencia);

            ExecutarEValidarFG06(triplice, CodigoStage.RecusadoNaFG01, CodigoStage.ReprovadoFG06, CodigoStage.ReprovadoFG06, "41", "103", "105");
        }
    }
}
