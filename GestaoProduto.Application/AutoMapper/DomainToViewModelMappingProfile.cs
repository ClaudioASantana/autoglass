using AutoMapper;
using GestaoProduto.Application.Produto.Query;
using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;

namespace GestaoProduto.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<ProdutoAgg.Produto, ProdutoViewModel>();
                //.ForMember(d => d.Preco, o => o.MapFrom(src => src.Preco.Value));
        }
    }
}
