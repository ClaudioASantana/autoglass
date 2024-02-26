using GestaoProduto.Domain.Core;
using System;

namespace GestaoProduto.Domain.ProdutoAggregate.Events
{
    public class PrecoAtualizadoEvent : Event
    {
        public Guid Id { get; }
        public decimal Preco { get; }

        public PrecoAtualizadoEvent(Guid id, decimal preco)
        {
            Id = id;
            Preco = preco;
        }
    }
}
