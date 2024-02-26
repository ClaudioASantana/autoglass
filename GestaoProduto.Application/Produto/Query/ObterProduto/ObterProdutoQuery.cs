using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProduto.Application.Produto.Query.ObterProduto
{
    public class ObterProdutoQuery : IRequest<object>, IBaseRequest
    {
        public int Codigo { get; set; }
    }
}
