using System;

namespace GestaoProduto.Domain.ProdutoAggregate
{
    public class Produto
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public Situacao Situacao { get; set; } = new Situacao();
        public DateTime? DataFabricacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public int? CodigoFornecedor { get; set; }
        public string? DescricaoFornecedor { get; set; }
        public string? CnpjFornecedor { get; set; }

        public Produto()
        { }

        public Produto(string descricao, DateTime? dataFabricao, DateTime? dataValidade, int codigoFornecedor, string descricaoFornecedor, string cnpjFornecedor)
        {
            Descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            Situacao = Situacao.Ativo;
            DataFabricacao = dataFabricao;
            DataValidade = dataValidade;
            CodigoFornecedor = codigoFornecedor;
            DescricaoFornecedor = descricaoFornecedor;
            CnpjFornecedor = cnpjFornecedor;
        }

        public void Ativar()
        {
            Situacao = Situacao.Ativo;
        }

        public void Inativar()
        {
            Situacao = Situacao.Inativo;
        }
    }
}