using GestaoProduto.Infrastructure.Data;

namespace GestaoProduto
{
    public static class ContextConfiguration
    {
        public static void AddContextConfiguration(this IServiceCollection services)
        {
            services.AddScoped<GestaoProdutoContext>();
        }
    }
}
