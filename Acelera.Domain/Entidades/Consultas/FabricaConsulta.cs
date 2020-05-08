using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Consultas
{
    public static class FabricaConsulta
    {
       public static IList<KeyValuePair<int, Consulta>>  MontarConsultaParaStage(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody, bool existeAlteracaoDeHeaderOuFooter, bool existeLinhaNoArquivo)
       {
            var consultas = new List<KeyValuePair<int, Consulta>>();
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            consultas.Add(new KeyValuePair<int, Consulta>(0, consulta));
            if (existeAlteracaoDeHeaderOuFooter || !existeLinhaNoArquivo)
            {
                return consultas;
            }
            foreach (var alteracao in valoresAlteradosBody.Alteracoes)
            {
                var consultaDaLinha = (Consulta)consulta.Clone();
                if (tabela == TabelasEnum.Cliente)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CLIENTE", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").Valor);
                }
                else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
                }
                else if (tabela == TabelasEnum.Comissao)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
                }
                else if (tabela == TabelasEnum.OCRCobranca)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                }
                else if (tabela == TabelasEnum.LanctoComissao)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
                }
                else if (tabela == TabelasEnum.Sinistro)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    //consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("VL_MOVIMENTO", alteracao.LinhaAlterada.ObterCampoDoBanco("VL_MOVIMENTO").Valor);
                    consultaDaLinha.AdicionarConsulta("NM_BENEFICIARIO", alteracao.LinhaAlterada.ObterCampoDoBanco("NM_BENEFICIARIO").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_SINISTRO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").Valor);

                }
                consultas.Add(new KeyValuePair<int, Consulta>(alteracao.PosicaoDaLinha, consultaDaLinha));
            }
            return consultas;
        }

        public static IList<KeyValuePair<int, Consulta>> MontarConsultaParaTabelaDeRetornoFG02(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        {
            var consultas = new List<KeyValuePair<int, Consulta>>();
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);

            foreach (var alteracao in valoresAlteradosBody.Alteracoes)
            {
                var consultaDaLinha = (Consulta)consulta.Clone();
                CamposDaConsultaTabelaRetorno(consultaDaLinha, tabela, valoresAlteradosBody);
                consultas.Add(new KeyValuePair<int, Consulta>(alteracao.PosicaoDaLinha, consultaDaLinha));
            }
            return consultas;
        }

        public static Consulta MontarConsultaParaTabelaDeRetornoFG01(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);

            CamposDaConsultaTabelaRetorno(consulta, tabela, valoresAlteradosBody);
            return consulta;
        }

        public static Consulta MontarConsultaParaTabelaDeRetornoFG00(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody, bool alteracaoDeHeaderOuFooter, bool existeLinhaNoArquivo)
        {
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
            if (!existeLinhaNoArquivo ||  alteracaoDeHeaderOuFooter || !valoresAlteradosBody.ExisteAlteracaoValida()  )
            {
                return consulta;
            }
            CamposDaConsultaTabelaRetorno(consulta,tabela,valoresAlteradosBody);
            return consulta;
        }

        private static void CamposDaConsultaTabelaRetorno(Consulta consulta, TabelasEnum tabela, AlteracoesArquivo valoresAlteradosBody)
        {
            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").Valor);
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").Valor);
            }
            else
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").Valor);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").Valor);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.Alteracoes.First().LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").Valor);
            }
        }

        public static ConjuntoConsultas MontarConsultaParaODS(TabelasEnum tabela, Arquivo arquivo)
        {
            var consultas = new ConjuntoConsultas();
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", arquivo.NomeArquivo);
            foreach (var linha in arquivo.Linhas)
            {
                var consultaDaLinha = (Consulta)consulta.Clone();
                if (tabela == TabelasEnum.Cliente)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CLIENTE", linha.ObterCampoDoBanco("CD_CLIENTE").Valor);
                }
                else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", linha.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", linha.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", linha.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", linha.ObterCampoDoBanco("CD_COBERTURA").Valor);
                }
                else if (tabela == TabelasEnum.Comissao)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", linha.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", linha.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", linha.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", linha.ObterCampoDoBanco("CD_COBERTURA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", linha.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
                }
                else if (tabela == TabelasEnum.OCRCobranca)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", linha.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", linha.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", linha.ObterCampoDoBanco("NR_PARCELA").Valor);
                }
                else if (tabela == TabelasEnum.LanctoComissao)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", linha.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", linha.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").Valor);
                    consultaDaLinha.AdicionarConsulta("NR_PARCELA", linha.ObterCampoDoBanco("NR_PARCELA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", linha.ObterCampoDoBanco("CD_TIPO_COMISSAO").Valor);
                }
                else if (tabela == TabelasEnum.Sinistro)
                {
                    consultaDaLinha.AdicionarConsulta("CD_CONTRATO", linha.ObterCampoDoBanco("CD_CONTRATO").Valor);
                    consultaDaLinha.AdicionarConsulta("VL_MOVIMENTO", linha.ObterCampoDoBanco("VL_MOVIMENTO").Valor);
                    consultaDaLinha.AdicionarConsulta("NM_BENEFICIARIO", linha.ObterCampoDoBanco("NM_BENEFICIARIO").Valor);// nao tem
                    consultaDaLinha.AdicionarConsulta("CD_COBERTURA", linha.ObterCampoDoBanco("CD_COBERTURA").Valor);
                    consultaDaLinha.AdicionarConsulta("CD_SINISTRO", linha.ObterCampoDoBanco("CD_SINISTRO").Valor);

                }
                consultas.AdicionarConsulta(consultaDaLinha);
            }
            throw new NotImplementedException();
            return consultas;
        }

    }
}
