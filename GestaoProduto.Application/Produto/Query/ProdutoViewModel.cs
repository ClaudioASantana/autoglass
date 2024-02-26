using GestaoProduto.Domain.ProdutoAggregate;
using System;

namespace GestaoProduto.Application.Produto.Query
{
    public class ProdutoViewModel
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Situacao Situacao { get; set; }
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }
        public string? CnpjFornecedor { get; set; }
    }
}