using GestaoProduto.Application.Produto.Commands.AtualizarProduto;
using GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data.UoW;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Application.Produto.Commands.ExclusaoProduto
{
    public class ExcluirProdutoCommandHandler : CommandHandler,
        IRequestHandler<ExcluirProdutoCommand>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ExcluirProdutoCommandHandler(
            IProdutoRepository produtoRepository,
            IUnitOfWork uow,
            IMediator mediator) : base(uow, mediator)
        {
            _produtoRepository = produtoRepository;
        }

        public Task Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = _produtoRepository.ObterPorCodigo(request.Codigo);
                produto.Inativar();

            _produtoRepository.Excluir(produto);

            Commit();

            return Task.FromResult(true);
        }
    }
}
