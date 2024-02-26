using GestaoProduto.Domain.ProdutoAggregate;
using MediatR;
using System;

namespace GestaoProduto.Application.Produto.Commands.AtualizarProduto
{
    public class AtualizarProdutoCommand : Command
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Situacao Situacao { get; set; } = new Situacao();
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }

    }
}
