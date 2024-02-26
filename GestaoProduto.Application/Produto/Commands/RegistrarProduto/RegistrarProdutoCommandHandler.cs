using GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using System.Xml.Linq;
using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Application.Produto.Commands.RegistrarProduto
{
    public class RegistrarProdutoCommandHandler : CommandHandler, 
        IRequestHandler<RegistrarProdutoCommand>
    {
        private readonly IProdutoRepository produtoRepository;

        public RegistrarProdutoCommandHandler(IProdutoRepository produtoRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.produtoRepository = produtoRepository;
        }

        public Task Handle(RegistrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new ProdutoAgg.Produto(
                request.Descricao,
                request.DataFabricacao,
                request.DataValidade,
                request.CodigoFornecedor,
                request.DescricaoFornecedor,
                request.CNPJFornecedor);

            if (request.DataFabricacao != null && request.DataFabricacao >= request.DataValidade) 
            {
                throw new ArgumentOutOfRangeException("Data de fabricação inválida!", new Exception(null));
            }

            produtoRepository.Registrar(produto);

            Commit();

            return Task.CompletedTask;
        }
    }
}