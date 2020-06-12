using Acelera.Domain.Enums;
using Acelera.Domain.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acelera.Domain.Entidades.Interfaces
{
    public interface ITriplice
    {
        Arquivo ArquivoCliente { get; }
        Arquivo ArquivoParcEmissao { get; }
        Arquivo ArquivoComissao { get; }

        OperadoraEnum Operadora { get; }
        int QuantidadeInicialCliente { get; }
        string PastaOrigem { get; }

        void AlterarParcEComissao(int posicaoLinha, string nomeCampo, string valor);


        void AlterarCliente(int posicaoLinha, string campoAlteracao, string valorNovo);


        void ReplicarLinhaNoParcEComissao(int posicaoLinha, int quantidadeDeVezes);

        void Salvar();

        void IgualarArquivos();

    }
}
