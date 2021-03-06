﻿using Acelera.Contratos;
using Acelera.Domain;
using Acelera.Domain.Entidades;
using Acelera.Domain.Entidades.Interfaces;
using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using Acelera.Logger;
using Acelera.Testes.DataAccessRep;
using Acelera.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Testes.ConjuntoArquivos
{
    [Serializable]
    public abstract class Triplice<T1, T2, T3> : ITrinca where T1 : Arquivo, new() where T2 : Arquivo, new() where T3 : Arquivo, new()
    {
        public IArquivo ArquivoCliente { get; protected set; }
        public IArquivo ArquivoParcEmissao { get; set; }
        public IArquivo ArquivoComissao { get; protected set; }

        public abstract OperadoraEnum Operadora { get; }
        public int QuantidadeInicialCliente { get; protected set; }
        public string PastaOrigem { get; protected set; }
        public string PastaDestino { get; protected set; }

        public abstract bool EhParcAuto { get; }

        private ControleNomeArquivo controleNomeArquivo;

        private IMyLogger logger;

        protected List<string> _arquivosSalvos;

        public Triplice(int quantidadeCliente, IMyLogger logger, ref List<string> arquivosSalvos)
        {
            _arquivosSalvos = arquivosSalvos;
            controleNomeArquivo = ControleNomeArquivo.Instancia;
            ArquivoCliente = new T1();
            ArquivoParcEmissao = new T2();
            ArquivoComissao = new T3();
            QuantidadeInicialCliente = quantidadeCliente;
            PastaOrigem = Parametros.pastaOrigem;
            PastaDestino = Parametros.pastaDestino;
            this.logger = logger;
            Carregar();
            IgualarArquivos();
        }

        public void AlterarTodasAsLinhasQueContenhamOCampo(string nomeCampo, string novoValor)
        {
            for (int i = 0; i < ArquivoParcEmissao.Linhas.Count; i++)
            {
                ArquivoCliente.AlterarLinhaSeExistirCampo(i, nomeCampo, novoValor);
            }

            for (int i = 0; i < ArquivoParcEmissao.Linhas.Count; i++)
            {
                ArquivoParcEmissao.AlterarLinhaSeExistirCampo(i, nomeCampo, novoValor);
            }

            for (int i = 0; i < ArquivoComissao.Linhas.Count; i++)
            {
                ArquivoComissao.AlterarLinhaSeExistirCampo(i, nomeCampo, novoValor);
            }
        }

        public void AlterarParcEComissao(int posicaoLinha, string nomeCampo, string valor)
        {
            logger.AbrirBloco("Alterando arquivos de Parc e Comissao.");
            logger.Escrever($"Alterando campo '{nomeCampo}' na linha '{posicaoLinha}' , Novo Valor: '{valor}'.");
            if (ArquivoParcEmissao.AlterarLinhaSeExistirCampo(posicaoLinha, nomeCampo, valor))
                logger.Escrever("Arquivo de Parc Alterado.");
            else
                logger.Escrever("Arquivo de Parc nao contem esse campo.");
            if (ArquivoComissao.AlterarLinhaSeExistirCampo(posicaoLinha, nomeCampo, valor))
                logger.Escrever("Arquivo de Comissao Alterado.");
            else
                logger.Escrever("Arquivo de Comissao nao contem esse campo.");
            logger.FecharBloco();
        }


        public void AlterarCliente(int posicaoLinha, string campoAlteracao, string valorNovo)
        {
            logger.AbrirBloco("Alterando arquivos de Parc e Cliente.");
            logger.Escrever($"Alterando campo '{campoAlteracao}' na linha '{posicaoLinha}' , Novo Valor: '{valorNovo}'.");
            var valorAntigo = ArquivoCliente.ObterValorFormatadoSeExistirCampo(posicaoLinha, campoAlteracao);
            ArquivoCliente.AlterarLinhaSeExistirCampo(posicaoLinha, campoAlteracao, valorNovo);

            if(ArquivoParcEmissao.ExisteCampo(campoAlteracao))
                ArquivoParcEmissao.AlterarLinhaComCampoIgualAValor(campoAlteracao, valorAntigo, campoAlteracao, valorNovo);
            logger.FecharBloco();
        }


        public void ReplicarLinhaNoParcEComissao(int posicaoLinha, int quantidadeDeVezes)
        {
            logger.AbrirBloco($"Replicando {quantidadeDeVezes} vezes a Linha:{posicaoLinha} de Parc e Comissao.");
            ArquivoParcEmissao.ReplicarLinhaComAjusteFooter(posicaoLinha, quantidadeDeVezes);
            ArquivoComissao.ReplicarLinhaComAjusteFooter(posicaoLinha, quantidadeDeVezes);
            logger.FecharBloco();
        }

        public void Salvar(bool salvaCliente = true, bool salvaParcela = true, bool salvaComissao = true)
        {
            if(salvaCliente)
                SalvarArquivo(ArquivoCliente, TipoArquivo.Cliente, ArquivoCliente.NomeArquivo);
            if (salvaParcela)
            {
                if (Operadora == OperadoraEnum.VIVO)
                    SalvarArquivo(ArquivoParcEmissao, TipoArquivo.ParcEmissaoAuto, ArquivoParcEmissao.NomeArquivo);
                else
                    SalvarArquivo(ArquivoParcEmissao, TipoArquivo.ParcEmissao, ArquivoParcEmissao.NomeArquivo);
            }
            if(salvaComissao)
                SalvarArquivo(ArquivoComissao, TipoArquivo.Comissao, ArquivoComissao.NomeArquivo);
        }

        private void Carregar()
        {
            CarregarArquivos();
            Parametrizacoes(ArquivoCliente);
            Parametrizacoes(ArquivoParcEmissao);
            Parametrizacoes(ArquivoComissao);
        }

        protected virtual void CarregarArquivos()
        {
            ArquivoCliente.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Cliente, Operadora, PastaOrigem), 1, 1, QuantidadeInicialCliente);

            if (Operadora == OperadoraEnum.VIVO)
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissaoAuto, Operadora, PastaOrigem), 1, 1, 1);
            else
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissao, Operadora, PastaOrigem), 1, 1, 1);

            ArquivoComissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Comissao, Operadora, PastaOrigem), 1, 1, 1);
        }

        private void CarregarCancelamento()
        {
            ArquivoCliente.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Cliente, Operadora, PastaOrigem), 1, 1, QuantidadeInicialCliente);
            ArquivoCliente.AjustarQtdLinhasNoFooter();

            if (Operadora == OperadoraEnum.VIVO)
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissaoAuto, Operadora, PastaOrigem), 1, 1, 1);
            else
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissao, Operadora, PastaOrigem), 1, 1, 1);

            ArquivoComissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Comissao, Operadora, PastaOrigem), 1, 1, 1);

            Parametrizacoes(ArquivoCliente);
            Parametrizacoes(ArquivoParcEmissao);
            Parametrizacoes(ArquivoComissao);

        }

        public void IgualarArquivos()
        {
            logger.AbrirBloco("IGUALANDO ARQUIVOS DA TRINCA.");
            int index = 0;
            logger.Escrever("IGUALANDO ARQUIVO DE PARC COM BASE NO CLIENTE.");
            foreach (var linha in ArquivoCliente.Linhas)
            {
                if (index >= ArquivoParcEmissao.Linhas.Count)
                    continue;
                foreach (var campo in linha.Campos)
                {
                    if(ArquivoParcEmissao.AlterarLinhaSeExistirCampo(index, campo.ColunaArquivo, campo.ValorFormatado))
                        logger.Escrever($"Campo alterado no arquivo de Parc, linha:{index}, coluna:'{campo.ColunaArquivo}', Novo Valor:'{campo.ValorFormatado}'");
                }
                index++;
            }

            logger.Escrever("IGUALANDO ARQUIVO DE COMISSAO COM BASE NO DE PARC.");
            index = 0;
            foreach (var linha in ArquivoParcEmissao.Linhas)
            {
                foreach (var campo in linha.Campos)
                    if(ArquivoComissao.AlterarLinhaSeExistirCampo(index, campo.ColunaArquivo, campo.ValorFormatado))
                        logger.Escrever($"Campo alterado no arquivo de Comissao, linha:{index}, coluna:'{campo.ColunaArquivo}', Novo Valor:'{campo.ValorFormatado}'");
                index++;
            }
            logger.Escrever("ARQUIVOS IGUALADOS.");
            logger.FecharBloco();
        }

        protected void SalvarArquivo(IArquivo arquivo, TipoArquivo tipoArquivo, string nomeArquivo)
        {
            var nomeOriginalArquivo = arquivo.NomeArquivo;
            logger.AbrirBloco($"SALVANDO ARQUIVO {tipoArquivo.ObterTexto()}");
            if (tipoArquivo == TipoArquivo.ParcEmissao || tipoArquivo == TipoArquivo.ParcEmissaoAuto)
                for (int i = 0; i < arquivo.Linhas.Count; i++)
                {
                    var idTransacaoOld = arquivo.Linhas[i]["ID_TRANSACAO"];
                    var novoIdTransacao = CarregarIdtransacao(arquivo.Linhas[i]);
                    logger.Escrever($"ALTERANDO LINHA '{i}', Campo : ID_TRANSACAO, Valor Antigo: '{arquivo.ObterLinha(i).ObterCampoDoArquivo("ID_TRANSACAO").ValorFormatado}'" +
                        $", Valor Novo: '{novoIdTransacao}'");
                    arquivo.AlterarLinha(i, "ID_TRANSACAO", novoIdTransacao);

                    arquivo.AlterarLinhaComCampoIgualAValor("ID_TRANSACAO_CANC", idTransacaoOld, "ID_TRANSACAO_CANC", novoIdTransacao);
                }

            FinalizarAlteracao(arquivo);

            var array = nomeArquivo.Split('-');
            array[2] = "/*R*/";
            nomeArquivo = array.ToList().ObterListaConcatenada("-");

            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(tipoArquivo);
            nomeArquivo = nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
            if (arquivo.Header.Count > 0)
                arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);

            var arquivoGerado = PastaDestino + arquivo.tipoArquivo.ObterPastaNoDestino() + "\\" + nomeArquivo;

            logger.Escrever($"SALVANDO ARQUIVO NOME : {arquivoGerado}");
            arquivo.Salvar(arquivoGerado);
            arquivo.AtualizarNomeArquivoFinal(nomeArquivo);
            logger.FecharBloco();
            arquivo.valoresAlteradosBody.FinalizarAlteracaoArquivo(nomeOriginalArquivo, nomeArquivo);
            _arquivosSalvos.Add(arquivoGerado);
        }

        public virtual void FinalizarAlteracao(IArquivo arquivo)
        {

        }

        protected string CarregarIdtransacao(ILinhaArquivo linha)
        {
            return linha.ObterCampoDoArquivo("NR_APOLICE").ValorFormatado + linha.ObterCampoDoArquivo("NR_ENDOSSO").ValorFormatado + linha.ObterCampoDoArquivo("CD_RAMO").ValorFormatado + linha.ObterCampoDoArquivo("NR_PARCELA").ValorFormatado;
        }

        private void Parametrizacoes(IArquivo arquivo)
        {
            //var dados = new Acelera.RegrasNegocio.DadosParametrosData(logger);
            for (int i = 0; i < arquivo.Linhas.Count; i++)
            {
                //var cobertura = new TabelaParametrosData(logger).ObterCoberturaSimples(arquivo.ObterLinhaHeader()["CD_TPA"]);
                //arquivo.AlterarLinhaSeExistirCampo(i, "CD_COBERTURA", cobertura.CdCobertura);
                //arquivo.AlterarLinhaSeExistirCampo(i, "CD_RAMO", cobertura.CdRamo);
                //arquivo.AlterarLinhaSeExistirCampo(i, "CD_PRODUTO", cobertura.CdProduto);
                //var corretor = ParametrosBanco.ObterCdCorretorETipoComissao(Operadora);
                //arquivo.AlterarLinhaSeExistirCampo(i, "CD_CORRETOR", corretor.Key);
                //arquivo.AlterarLinhaSeExistirCampo(i, "CD_TIPO_COMISSAO", corretor.Value);

            }
        }

        public void AlterarLayoutDaTrinca<TCliente,TParc,TComissao>() where TCliente : IArquivo, new() where TParc : IArquivo, new() where TComissao : IArquivo, new()
        {
            var arquivo = ArquivoCliente;
            AlterarLayout<TCliente>(ref arquivo);
            ArquivoCliente = arquivo.Clone();

            arquivo = ArquivoParcEmissao;
            AlterarLayout<TParc>(ref arquivo);
            ArquivoParcEmissao = arquivo.Clone();

            arquivo = ArquivoComissao;
            AlterarLayout<TComissao>(ref arquivo);
            ArquivoComissao = arquivo.Clone();
        }

        private void AlterarLayout<T>(ref IArquivo _arquivo) where T : IArquivo, new()
        {
            logger.AbrirBloco($"ALTERANDO LAYOUT DE {_arquivo.GetType().Name} para {typeof(T)}");
            var novoArquivo = new T();
            novoArquivo.Linhas = new List<ILinhaArquivo>();
            novoArquivo.Header = new List<ILinhaArquivo>();
            novoArquivo.Footer = new List<ILinhaArquivo>();
            novoArquivo.AtualizarNomeArquivoFinal(_arquivo.NomeArquivo);

            novoArquivo.Header.Add(_arquivo.Header[0].Clone());
            novoArquivo.Footer.Add(_arquivo.Footer[0].Clone());
            for (int i = 0; i < _arquivo.Linhas.Count; i++)
                novoArquivo.AdicionarLinha(novoArquivo.CriarLinhaVazia(i));

            novoArquivo.AjustarQtdLinhasNoFooter();
            ArquivoUtils.IgualarCamposQueExistirem(_arquivo, novoArquivo);

            novoArquivo.AlterarHeader("VERSAO", novoArquivo.TextoVersaoHeader);

            logger.FecharBloco();
            _arquivo = novoArquivo;
        }

        public void IgualarCamposQueExistirem(IArquivo arquivoOrigem, IArquivo arquivoDestino)
        {
            ArquivoUtils.IgualarCamposQueExistirem(arquivoOrigem,arquivoDestino);
        }

        public void IgualarCamposQueExistirem(LinhaArquivo linhaOrigem, LinhaArquivo linhaDestino)
        {
            ArquivoUtils.IgualarCamposQueExistirem(linhaOrigem, linhaDestino,logger);
        }

        public ITrinca Clone()
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (ITrinca)binaryFormatter.Deserialize(memoryStream);
            }
        }

    }
}
