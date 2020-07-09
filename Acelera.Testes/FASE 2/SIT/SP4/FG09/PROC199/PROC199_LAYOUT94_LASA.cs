﻿using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG09.PROC199
{
    [TestClass]
    public class PROC199_LAYOUT96_LASA : TestesFG09
    {
        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5525()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5525", "FG09 - PROC199 - ");
            AlterarCobertura(false);

            //Envia parc normal
            var cobertura = dados.ObterCobertura(ObterValorHeader("CD_TPA"));
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 1, "", false, cobertura.CdCobertura);
            AlterarLinha(0, "CD_COBERTURA", cobertura.CdCobertura);
            AlterarLinha(0, "CD_RAMO", cobertura.CdRamoCobertura);
            AlterarLinha(0, "CD_PRODUTO", cobertura.CdProduto);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5526()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5526", "FG09 - PROC199 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Com Critica")]
        public void SAP_5527()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5527", "FG09 - PROC199 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 3);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 1000));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5528()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5528", "FG09 - PROC199 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true, 2);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), 0));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }

        [TestMethod]
        [TestCategory("Sem Critica")]
        public void SAP_5529()
        {
            IniciarTeste(TipoArquivo.ParcEmissao, "5529", "FG09 - PROC199 - ");

            //Envia parc normal
            var arquivoodsParcela = CriarEmissaoODS<Arquivo_Layout_9_4_ParcEmissao>(OperadoraEnum.LASA, true);

            //Sinistro referente a cancelamento
            var arquivoodsComissao = CriarEmissaoComissaoODS<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);

            arquivo = CriarParcelaCancelamento<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoodsParcela, true);
            SalvarArquivo();
            var arquivoParcela = arquivo.Clone();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

            arquivo = CriarComissao<Arquivo_Layout_9_4_EmsComissao>(OperadoraEnum.LASA, arquivoParcela, true);
            AlterarLinha(0, "VL_COMISSAO", SomarValores(arquivoodsComissao.SomarLinhasDoArquivo("VL_COMISSAO"), -1));
            SalvarArquivo();

            ExecutarEValidar(CodigoStage.AprovadoNaFG09);

        }
    }
}
