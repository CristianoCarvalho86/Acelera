using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Layouts._9_4;
using Acelera.Testes.DataAccessRep;
using Acelera.Testes.FASE_2.SIT.SP4.FG07;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.FASE_2.SIT.SP7
{
    [TestClass]
    public class Sinistro_LASA_TIM : FG07_Base
    {
        [TestMethod]
        public void SAP_0001()
        {
            InicioTesteFG06("1", "SP7 - PROC 78- LASA - SINISTRO - Importar arquivo com NR_APOLICE inexistente - CD_TIPO_MOVTO = 1", OperadoraEnum.LASA);
            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);
            AlterarLinha(0, "CD_CLIENTE", dados.ObterCdClienteParceiro(true, arquivo.Header[0]["CD_TPA"]));
            AlterarLinha(0, "CD_CONTRATO", GerarNovoContratoAleatorio(arquivo[0]["CD_CONTRATO"], true));
            AlterarLinha(0, "NR_APOLICE", arquivo[0]["CD_CONTRATO"]);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            GerarCdSinistroEAviso(arquivo, 0);

            SalvarArquivo(arquivo);
            ExecutarEValidarAteFg02(arquivo);
        }

        [TestMethod]
        public void SAP_0004()
        {
            InicioTesteFG06("4", "SP7 - PROC 78 - TIM - SINISTRO - Importar arquivo com NR_APOLICE existente - Envio em dias distintos - CD_TP_MOVTO = 1", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "CD_FORMA_PAGTO", "D");
            GerarCdSinistroEAviso(arquivo, 0);

            SalvarArquivo(arquivo);
            ExecutarEValidarAteFg02(arquivo);
        }

        [TestMethod]
        public void SAP_0005()
        {
            InicioTesteFG06("5", "SP7 - PROC 79 - LASA - SINISTRO - Movimentar sinistro inexistente - CD_TP_MOVTO = 2 E TP_SINISTRO=01", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            GerarCdSinistroEAviso(arquivo, 0);

            SalvarArquivo(arquivo);
            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0009()
        {
            InicioTesteFG06("9", "SP7 - PROC 82 - LASA - SINISTRO - Enviar movimentação duplicda para sinistro - CD_TP_MOVTO=2 - ODS", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0010()
        {
            InicioTesteFG06("10", "SP7 - PROC 82 - TIM - SINISTRO - Enviar movimentação duplicda para sinistro - CD_TP_MOVTO=7 - ODS", OperadoraEnum.TIM);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0011()
        {
            InicioTesteFG06("11", "SP7 - PROC 128 - LASA - SINISTRO - Enviar CD_SINISTRO que já existe na ODS - CD_TP_MOVTO=1", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0014()
        {
            InicioTesteFG06("14", "SP7 - PROC 129 - TIM - SINISTRO - Enviar CD_AVISO que já existe na STG - CD_TP_MOVTO=1", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");


            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);

            var cdSinistro = AlterarUltimasPosicoes(arquivo[0]["CD_SINISTRO"], GerarNumeroAleatorio(11));
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));
            AlterarLinha(0, "CD_SINISTRO", cdSinistro);
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0015()
        {
            InicioTesteFG06("15", "SP7 - PROC 181 - LASA - SINISTRO - Abertura de sinistro para apólice cancelada - NR_ENDOSSO E CD_CONTRATO DE UM ENDOSSO NA ODS QUE SEJA CD_TIPO_EMISSAO 10 OU 11", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            CriarCancelamento(false, false, OperadoraEnum.LASA, "10", out Arquivo arquivoParcCancelamento, out Arquivo arquivoComissaoCancelamento);

            EnviarParaOds(arquivoParcCancelamento);
            EnviarParaOds(arquivoComissaoCancelamento);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(arquivoParcCancelamento, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0018()
        {
            InicioTesteFG06("18", "SP7 - PROC 186 - TIM - SINISTRO - Enviar movimento duplicado - CD_TP_MOVTO = 7 - ODS", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "01");
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_INTERNO_RESSEGURADOR", GerarNumeroAleatorio(3));
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0019()
        {
            InicioTesteFG06("19", "SP7 - PROC 194 - LASA - SINISTRO - Pagamento superior a reserva - CD_TIPO_MOVTO = 7", OperadoraEnum.TIM);

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.TIM);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "7");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "VL_MOVIMENTO", SomarValor(0, "VL_MOVIMENTO", 10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0022()
        {
            InicioTesteFG06("22", "SP7 - PROC 254 - LASA - SINISTRO - Enviar movimentação com informação divergente ao da abertura - CD_CLIENTE -  MOVTO=2", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            AlterarLinha(0, "CD_CLIENTE", GerarNumeroAleatorio(8));
            
            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0023()
        {
            InicioTesteFG06("23", "SP7 - PROC 254 - LASA - SINISTRO - Enviar movimentação com informação divergente ao da abertura - DT_AVISO - MOVTO=2", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "DT_AVISO", SomarData(arquivo[0]["DT_AVISO"], 10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0024()
        {
            InicioTesteFG06("24", "SP7 - PROC 254 - LASA - SINISTRO - Enviar movimentação com informação divergente ao da abertura - DT_OCORRENCIA - MOVTO=2", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "DT_OCORRENCIA", SomarData(arquivo[0]["DT_OCORRENCIA"], 10));
            AlterarLinha(0, "DT_AVISO", SomarData(arquivo[0]["DT_OCORRENCIA"], 10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0025()
        {
            InicioTesteFG06("25", "SP7 - PROC 254 - LASA - SINISTRO - Enviar movimentação com informação divergente ao da abertura - DT_REGISTRO - MOVTO=2", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "DT_REGISTRO", SomarData(arquivo[0]["DT_REGISTRO"], 10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0027()
        {
            InicioTesteFG06("27", "SP7 - PROC 254 - LASA - SINISTRO - Enviar movimentação com informação divergente ao da abertura - CD_ITEM - MOVTO=2", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "CD_ITEM", GerarNumeroAleatorio(10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);

        }

        [TestMethod]
        public void SAP_0028()
        {
            InicioTesteFG06("28", "sem crítica - Abertura - mesmo sinistro / sem crítica - Pagamento - mesmo sinistro", OperadoraEnum.LASA);

            AlterarCdCorretorETipoComissaoDaTriplice(triplice, "C", dados);
            triplice.AlterarParcEComissao(0, "DT_VENCIMENTO", "20201011");

            SalvaExecutaEValidaTrincaFG02(true);

            arquivo = new Arquivo_Layout_9_4_Sinistro();
            CarregarArquivo(arquivo, 1, OperadoraEnum.LASA);

            IgualarCamposQueExistirem(triplice.ArquivoParcEmissao, arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "1");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");

            GerarCdSinistroEAviso(arquivo, 0);
            EnviarParaOds(arquivo, true, false);

            LimparValidacao(arquivo);
            AlterarLinha(0, "CD_TIPO_MOVIMENTO", "2");
            AlterarLinha(0, "TP_SINISTRO", "01");
            AlterarLinha(0, "CD_FORMA_PAGTO", "N");
            AlterarLinha(0, "DT_REGISTRO", SomarData(arquivo[0]["DT_REGISTRO"], 10));

            SalvarArquivo(arquivo);

            ExecutarEValidarAteFg02(arquivo);
        }


        private void GerarCdSinistroEAviso(Arquivo _arquivo, int posicaoLinha)
        {
            var cdSinistro = "";
            while (true)
            {
                cdSinistro = AlterarUltimasPosicoes(_arquivo[posicaoLinha]["CD_SINISTRO"], GerarNumeroAleatorio(11));
                if (!DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.Sinistro.ObterTexto()} WHERE CD_SINISTRO = '{cdSinistro}'", logger) &&
                   !DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.OdsSinistro.ObterTexto()} WHERE CD_SINISTRO = '{cdSinistro}'", logger))
                    break;
            }
            _arquivo.AlterarLinha(posicaoLinha, "CD_SINISTRO", cdSinistro );

            var cdAviso = "";
            while (true)
            {
                cdAviso = GerarNumeroAleatorio(8);
                if (!DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.Sinistro.ObterTexto()} WHERE CD_AVISO = '{cdAviso}'", logger) &&
                   !DataAccess.ExisteRegistro($"SELECT '1' FROM {Parametros.instanciaDB}.{TabelasEnum.OdsSinistro.ObterTexto()} WHERE CD_AVISO = '{cdAviso}'", logger))
                    break;
            }
            _arquivo.AlterarLinha(posicaoLinha, "CD_AVISO", cdAviso);
        }

    }
}
