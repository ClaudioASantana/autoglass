using AutoMapper;
using GestaoProduto.Application.Produto.Commands.AtualizarProduto;
using GestaoProduto.Application.Produto.Query;
using GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Configurations
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<AtualizarProdutoCommand, Produto>().ReverseMap();
        }
    }
}
