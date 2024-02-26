using GestaoProduto.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdutoAgg = GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data.Produto;
using Microsoft.Extensions.Configuration;
using GestaoProduto.Infrastructure.Data.Extensions;

namespace GestaoProduto.Infrastructure.Data
{
    public class GestaoProdutoContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });

        //public GestaoProdutoContext(DbContextOptions options) : base(options) { }
        public DbSet<ProdutoAgg.Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProdutoAgg.Produto>();

            modelBuilder.Ignore<Event>();

            modelBuilder.AddConfiguration(new ProdutoConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // requires  Microsoft.Extensions.Configuration.FileExtensions
                .AddJsonFile("appsettings.json") // requires Microsoft.Extensions.Configuration.Json
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseLoggerFactory(loggerFactory)
            //    .EnableSensitiveDataLogging()
            //    .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=autoglass;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
