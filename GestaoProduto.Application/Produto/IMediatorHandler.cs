using System.Threading.Tasks;
using MediatR;

namespace GestaoProduto.Application.Produto
{
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;

        Task EnviarComando<T>(T comando) where T : Command;

        Task<TResponse> Send<TResponse>(IRequest<TResponse> request);
    }
}