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
        public static IList<KeyValuePair<int, Consulta>> MontarConsultaParaStage(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody, bool existeAlteracaoDeHeaderOuFooter, bool existeLinhaNoArquivo)
        {
            var consultas = new List<KeyValuePair<int, Consulta>>();
            var consulta = new Consulta();


            if (existeAlteracaoDeHeaderOuFooter || !existeLinhaNoArquivo)
            {
                consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
                consultas.Add(new KeyValuePair<int, Consulta>(0, consulta));
                return consultas;
            }
            var linhas = valoresAlteradosBody.LinhasAlteradas();
            foreach (var linha in linhas)
            {
                var alteracoes = valoresAlteradosBody.AlteracoesPorLinha(linha).ToList().Where(x => x.CamposAlterados.Count > 0);
                foreach (var alteracao in alteracoes)
                {
                    var consultaDaLinha = (Consulta)consulta.Clone();

                    consultaDaLinha.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);

                    if (tabela == TabelasEnum.Cliente)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CLIENTE", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").ValorFormatado);
                    }
                    else if (tabela == TabelasEnum.ParcEmissao || tabela == TabelasEnum.ParcEmissaoAuto)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").ValorFormatado);
                    }
                    else if (tabela == TabelasEnum.Comissao)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").ValorFormatado);
                    }
                    else if (tabela == TabelasEnum.OCRCobranca)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").ValorFormatado);
                    }
                    else if (tabela == TabelasEnum.LanctoComissao)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NR_PARCELA", alteracao.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_TIPO_COMISSAO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_TIPO_COMISSAO").ValorFormatado);
                    }
                    else if (tabela == TabelasEnum.Sinistro)
                    {
                        consultaDaLinha.AdicionarConsulta("CD_CONTRATO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_CONTRATO").ValorFormatado);
                        //consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", alteracao.LinhaAlterada.ObterCampo("NR_SEQUENCIAL_EMISSAO").Valor);
                        consultaDaLinha.AdicionarConsulta("VL_MOVIMENTO", alteracao.LinhaAlterada.ObterCampoDoBanco("VL_MOVIMENTO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("NM_BENEFICIARIO", alteracao.LinhaAlterada.ObterCampoDoBanco("NM_BENEFICIARIO").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_COBERTURA", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_COBERTURA").ValorFormatado);
                        consultaDaLinha.AdicionarConsulta("CD_SINISTRO", alteracao.LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").ValorFormatado);

                    }
                    consultas.Add(new KeyValuePair<int, Consulta>(alteracao.PosicaoDaLinha, consultaDaLinha));
                }
            }
            return consultas;
        }

        public static IList<KeyValuePair<int, Consulta>> MontarConsultaParaTabelaDeRetornoFG02(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        {
            var consultas = new List<KeyValuePair<int, Consulta>>();
            var consulta = new Consulta();
            consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);

            var linhas = valoresAlteradosBody.LinhasAlteradas();
            if (linhas.Count() == 1 && !valoresAlteradosBody.ExisteAlteracaoValida())
                consultas.Add(new KeyValuePair<int, Consulta>(0, consulta));

            foreach (var linha in linhas)
            {
                var alteracoes = valoresAlteradosBody.AlteracoesPorLinha(linha).ToList().Where(x => x.CamposAlterados.Count > 0);
                foreach (var alteracao in alteracoes)
                {
                    var consultaDaLinha = (Consulta)consulta.Clone();
                    CamposDaConsultaTabelaRetorno(consultaDaLinha, tabela, alteracao);
                    consultas.Add(new KeyValuePair<int, Consulta>(alteracao.PosicaoDaLinha, consultaDaLinha));
                }
                
            }
            return consultas;
        }

        //public static Consulta MontarConsultaParaTabelaDeRetornoFG01(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody)
        //{
        //    return MontarConsultaParaTabelaDeRetornoFG02(tabela, nomeArquivo, valoresAlteradosBody);
        //    //var consulta = new Consulta();
        //    //consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);

        //    //CamposDaConsultaTabelaRetorno(consulta, tabela, valoresAlteradosBody);
        //    //return consulta;
        //}

        //public static Consulta MontarConsultaParaTabelaDeRetornoFG00(TabelasEnum tabela, string nomeArquivo, AlteracoesArquivo valoresAlteradosBody, bool alteracaoDeHeaderOuFooter, bool existeLinhaNoArquivo)
        //{
        //    var consulta = new Consulta();
        //    consulta.AdicionarConsulta("NM_ARQUIVO_TPA", nomeArquivo);
        //    if (!existeLinhaNoArquivo || alteracaoDeHeaderOuFooter || !valoresAlteradosBody.ExisteAlteracaoValida())
        //    {
        //        return consulta;
        //    }
        //    CamposDaConsultaTabelaRetorno(consulta, tabela, valoresAlteradosBody);
        //    return consulta;
        //}

        private static void CamposDaConsultaTabelaRetorno(Consulta consulta, TabelasEnum tabela, Alteracao valoresAlteradosBody)
        {
            if (tabela == TabelasEnum.Cliente)
            {
                consulta.AdicionarConsulta("CD_CLIENTE", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("CD_CLIENTE").ValorFormatado);
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").ValorFormatado);
            }
            else if (tabela == TabelasEnum.Sinistro)
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").ValorFormatado);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").ValorFormatado);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                consulta.AdicionarConsulta("CD_SINISTRO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("CD_SINISTRO").ValorFormatado);
            }
            else
            {
                consulta.AdicionarConsulta("TP_REGISTRO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("TIPO_REGISTRO").ValorFormatado);
                consulta.AdicionarConsulta("NR_APOLICE", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("NR_APOLICE").ValorFormatado);
                consulta.AdicionarConsulta("NR_SEQUENCIAL_EMISSAO", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("NR_SEQUENCIAL_EMISSAO").ValorFormatado);
                consulta.AdicionarConsulta("NR_PARCELA", valoresAlteradosBody.LinhaAlterada.ObterCampoDoBanco("NR_PARCELA").ValorFormatado);
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
