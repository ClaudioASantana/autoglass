using GestaoProduto.Domain.ProdutoAggregate;
using MediatR;
using System;

namespace GestaoProduto.Application.Produto.Commands.RegistrarProduto
{
    public class RegistrarProdutoCommand : Command
    {
        public string Descricao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int CodigoFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CNPJFornecedor { get; set; }
    }
}