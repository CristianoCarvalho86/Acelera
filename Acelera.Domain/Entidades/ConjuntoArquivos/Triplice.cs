using Acelera.Domain.Enums;
using Acelera.Domain.Extensions;
using Acelera.Domain.Layouts;
using Acelera.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.ConjuntoArquivos
{
    public abstract class Triplice<T1, T2, T3> where T1 : Arquivo, new() where T2 : Arquivo, new() where T3 : Arquivo, new()
    {
        public T1 ArquivoCliente { get; protected set; }
        public T2 ArquivoParcEmissao { get; protected set; }
        public T3 ArquivoComissao { get; protected set; }

        public abstract OperadoraEnum Operadora { get; }
        public int QuantidadeInicialCliente { get; protected set; }
        public string PastaOrigem { get; protected set; }
        public string PastaDestino { get; protected set; }
        private ControleNomeArquivo controleNomeArquivo;

        public Triplice(int quantidadeCliente, string pastaOrigem, string pastaDestino)
        {
            controleNomeArquivo = ControleNomeArquivo.Instancia;
            ArquivoCliente = new T1();
            ArquivoParcEmissao = new T2();
            ArquivoComissao = new T3();
            QuantidadeInicialCliente = quantidadeCliente;
            PastaOrigem = pastaOrigem;
            PastaDestino = pastaDestino;
            Carregar();
            IgualarArquivos();
        }

        public void AlterarParcEComissao(int posicaoLinha, string nomeCampo, string valor)
        {
            ArquivoParcEmissao.AlterarLinhaSeExistirCampo(posicaoLinha, nomeCampo, valor);
            ArquivoComissao.AlterarLinhaSeExistirCampo(posicaoLinha, nomeCampo, valor);
        }

       
        public void AlterarCliente(int posicaoLinha, string campoAlteracao, string valorNovo)
        {
            var valorAntigo = ArquivoCliente.ObterValorFormatadoSeExistirCampo(posicaoLinha, campoAlteracao);
            ArquivoCliente.AlterarLinhaSeExistirCampo(posicaoLinha, campoAlteracao, valorNovo);

            ArquivoParcEmissao.AlterarLinhaComCampoIgualAValor(campoAlteracao,valorAntigo, campoAlteracao, valorNovo);
        }


        public void ReplicarLinhaNoParcEComissao(int posicaoLinha, int quantidadeDeVezes)
        {
            ArquivoParcEmissao.ReplicarLinhaComAjusteFooter(posicaoLinha, quantidadeDeVezes);
            ArquivoComissao.ReplicarLinhaComAjusteFooter(posicaoLinha, quantidadeDeVezes);
        }

        public void Salvar()
        {
            SalvarArquivo(ArquivoCliente, TipoArquivo.Cliente, ArquivoCliente.NomeArquivo);
            if(Operadora == OperadoraEnum.VIVO)
                SalvarArquivo(ArquivoParcEmissao, TipoArquivo.ParcEmissaoAuto, ArquivoParcEmissao.NomeArquivo);
            else
                SalvarArquivo(ArquivoParcEmissao, TipoArquivo.ParcEmissao, ArquivoParcEmissao.NomeArquivo);
            SalvarArquivo(ArquivoComissao, TipoArquivo.Comissao, ArquivoComissao.NomeArquivo);
        }

        private void Carregar()
        {
            ArquivoCliente.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Cliente, Operadora, PastaOrigem),1,1,QuantidadeInicialCliente);
            
            if(Operadora == OperadoraEnum.VIVO)
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissaoAuto, Operadora, PastaOrigem), 1, 1, 1);
            else
                ArquivoParcEmissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.ParcEmissao, Operadora, PastaOrigem), 1, 1, 1);
            
            ArquivoComissao.Carregar(ArquivoOrigem.ObterArquivoAleatorio(TipoArquivo.Comissao, Operadora, PastaOrigem), 1, 1, 1);
        }

        private void IgualarArquivos()
        {
            int index = 0;
            foreach (var linha in ArquivoCliente.Linhas)
            {
                if (index >= ArquivoParcEmissao.Linhas.Count)
                    continue;
                foreach (var campo in linha.Campos)
                    ArquivoParcEmissao.AlterarLinhaSeExistirCampo(index, campo.ColunaArquivo, campo.ValorFormatado);
                index++;
            }
            index = 0;
            foreach (var linha in ArquivoParcEmissao.Linhas)
            {
                foreach (var campo in linha.Campos)
                    ArquivoComissao.AlterarLinhaSeExistirCampo(index, campo.ColunaArquivo, campo.ValorFormatado);
                index++;
            }

        }

        protected void SalvarArquivo(Arquivo arquivo , TipoArquivo tipoArquivo, string nomeArquivo)
        {
            var array = nomeArquivo.Split('-');
            array[2] = "/*R*/";
            nomeArquivo = array.ToList().ObterListaConcatenada("-");

            var numeroArquivoNovo = controleNomeArquivo.ObtemValor(tipoArquivo);
                nomeArquivo = nomeArquivo.Replace("/*R*/", numeroArquivoNovo).Replace(".txt", ".TXT");
                if (arquivo.Header.Count > 0)
                    arquivo.AlterarHeader("NR_ARQ", numeroArquivoNovo);

            arquivo.Salvar(PastaDestino + nomeArquivo);
        }

    }
}
