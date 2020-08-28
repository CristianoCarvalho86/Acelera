using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts._9_4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Acelera.Testes.FASE_2.SIT.SP4.FG07
{
    [TestClass]
    public class FG07_CruzamentoXML : FG07_Base
    {
        [TestMethod]
        public void SAP_9527()
        {
            IniciarTeste(TipoArquivo.Cliente, "ABC", "SAP-9527:Submeter todos os arquivos à esteira e gerar XML unica vez");
            ExecutarFG07();
            ExecutarFG07_1();




            var arquivoCliente1 = new Arquivo_Layout_9_4_Cliente();
            arquivoCliente1.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.CLIENTE-EV-3781-20200423.TXT");
            var arquivoCliente2 = new Arquivo_Layout_9_4_Cliente();
            arquivoCliente2.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.CLIENTE-EV-4628-20200612.TXT");
            SelecionarLinhaParaValidacao(0, false, arquivoCliente1);
            SelecionarLinhaParaValidacao(0, false, arquivoCliente2);

            var arquivoParcEms1 = new Arquivo_Layout_9_4_ParcEmissao();
            arquivoParcEms1.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.PARCEMS-EV-3780-20200423.TXT");
            var arquivoParcEms2 = new Arquivo_Layout_9_4_ParcEmissao();
            arquivoParcEms2.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.PARCEMS-EV-4627-20200612.TXT");
            SelecionarLinhaParaValidacao(0, false, arquivoParcEms1);
            SelecionarLinhaParaValidacao(0, false, arquivoParcEms2);

            var arquivoEmsCms1 = new Arquivo_Layout_9_4_EmsComissao();
            arquivoEmsCms1.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.EMSCMS-EV-3782-20200423.TXT");
            var arquivoEmsCms2 = new Arquivo_Layout_9_4_EmsComissao();
            arquivoEmsCms2.Carregar(@"C:\Cristiano\Origem2\Envio OIM\C01.LASA.EMSCMS-EV-4628-20200612.TXT");
            SelecionarLinhaParaValidacao(0, false, arquivoEmsCms1);
            SelecionarLinhaParaValidacao(0, false, arquivoEmsCms2);


            ChamarExecucao(arquivoCliente1.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(arquivoParcEms1.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());
            ChamarExecucao(arquivoEmsCms1.tipoArquivo.ObterTarefaFG00Enum().ObterTexto());

            ChamarExecucao(arquivoCliente1.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(arquivoParcEms1.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());
            ChamarExecucao(arquivoEmsCms1.tipoArquivo.ObterTarefaFG01Enum().ObterTexto());

            ChamarExecucao(FGR_DT_EMISSAO_MES_CONTABIL_PARCELA_TAREFA.PARCELA.ObterTexto());

            ChamarExecucao(arquivoCliente1.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ChamarExecucao(arquivoParcEms1.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());
            ChamarExecucao(arquivoEmsCms1.tipoArquivo.ObterTarefaFG01_2Enum().ObterTexto());

            ChamarExecucao(arquivoCliente1.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());
            ChamarExecucao(arquivoParcEms1.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());
            ChamarExecucao(arquivoEmsCms1.tipoArquivo.ObterTarefaFG02Enum().ObterTexto());

            ChamarExecucao(arquivoCliente1.tipoArquivo.ObterTarefaFG05Enum().ObterTexto());
            ChamarExecucao(arquivoParcEms1.tipoArquivo.ObterTarefaFG05Enum().ObterTexto());
            ChamarExecucao(arquivoEmsCms1.tipoArquivo.ObterTarefaFG05Enum().ObterTexto());

            ChamarExecucao(FG06_Tarefas.Trinca.ObterTexto());


            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoCliente1);
            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoCliente2);

            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoParcEms1);
            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoParcEms2);

            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoEmsCms1);
            ValidarStages(true, (int)CodigoStage.AprovadoFG06, arquivoEmsCms2);


        }

        [TestMethod]
        public void SAP_9527_1()
        {
            IniciarTeste(TipoArquivo.Cliente, "95271", "SAP_9527_1");
            XmlDocument xmlDocCTA = new XmlDocument();
            xmlDocCTA.Load(@"C:\Cristiano\Origem2\Envio OIM\CMS01-737100700218442-CTA.xml");

            XmlDocument xmlDocEsteira = new XmlDocument();
            xmlDocEsteira.Load(@"C:\Cristiano\Origem2\Envio OIM\CMS01-737100700218442-esteira.xml");

            string[] camposADesconsiderar = new string[] { "nm_arquivo", "id_arquivo", "nr_linha", "ref_origem", "sis_origem", "dt_emissao", "lider_nome" };

            StringBuilder erros = new StringBuilder();

            for (int i = 0; i < xmlDocCTA.ChildNodes.Count; i++)
            {
                for (int j = 0; j < xmlDocCTA.ChildNodes[i].ChildNodes.Count; j++)
                {
                    for (int h = 0; h < xmlDocCTA.ChildNodes[i].ChildNodes[j].ChildNodes.Count; h++)
                    {
                        var nohXMLCTA = xmlDocCTA.ChildNodes[i].ChildNodes[j].ChildNodes[h];
                        var nohXMLEsteira = xmlDocEsteira.ChildNodes[i].ChildNodes[j].SelectSingleNode($"//{nohXMLCTA.Name}");

                        if (camposADesconsiderar.Contains(nohXMLCTA.Name))
                            continue;

                        if (nohXMLEsteira == null)
                        {
                            erros.AppendLine($"CAMPO NAO ENCONTRADO NO XML DA ESTEIRA: {nohXMLCTA.Name}");
                            continue;
                        }

                        if (nohXMLCTA.InnerText != nohXMLEsteira.InnerText)
                        {
                            erros.AppendLine($"[TAG:{xmlDocCTA.ChildNodes[i].ChildNodes[j].Name}] ERRO EM :{nohXMLCTA.Name}");
                            erros.AppendLine($"VALOR CTA :{nohXMLCTA.InnerText}, VALOR ESTEIRA: {nohXMLEsteira.InnerText}.");
                        }
                    }
                }
            }

            logger.Escrever("ERROS ENCONTRADOS: " + erros.ToString());
        }
    }
}
