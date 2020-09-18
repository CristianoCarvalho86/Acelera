using Acelera.Contratos;
using Acelera.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Interfaces
{
    public interface ITrinca
    {
        IArquivo ArquivoCliente { get; }
        IArquivo ArquivoParcEmissao { get; set; }
        IArquivo ArquivoComissao { get; }

        OperadoraEnum Operadora { get; }
        bool EhParcAuto { get; }
        int QuantidadeInicialCliente { get; }
        string PastaOrigem { get; }

        void AlterarParcEComissao(int posicaoLinha, string nomeCampo, string valor);
        void AlterarTodasAsLinhasQueContenhamOCampo(string nomeCampo, string novoValor);


        void AlterarCliente(int posicaoLinha, string campoAlteracao, string valorNovo);


        void ReplicarLinhaNoParcEComissao(int posicaoLinha, int quantidadeDeVezes);

        void Salvar(bool salvaCliente = true, bool salvaParcela = true, bool salvaComissao = true);

        void AlterarLayoutDaTrinca<TCliente, TParc, TComissao>() where TCliente : IArquivo, new() where TParc : IArquivo, new() where TComissao : IArquivo, new();

        void IgualarArquivos();

        ITrinca Clone();

    }
}
