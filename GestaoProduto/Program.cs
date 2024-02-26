using AutoMapper;
using GestaoProduto.Application;
using GestaoProduto.Application.Produto;
using GestaoProduto.Application.Produto.Commands.AtualizarProduto;
using GestaoProduto.Application.Produto.Commands.ExclusaoProduto;
using GestaoProduto.Application.Produto.Commands.RegistrarProduto;
using GestaoProduto.Application.Produto.Query.ObterProduto;
using GestaoProduto.Application.Produto.Query.ObterTodosProdutos;
using GestaoProduto.Configurations;
using GestaoProduto.Domain.ProdutoAggregate;
using GestaoProduto.Infrastructure.Data;
using GestaoProduto.Infrastructure.Data.Produto;
using GestaoProduto.Infrastructure.Data.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<GestaoProdutoContext>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IRequestHandler<RegistrarProdutoCommand>, RegistrarProdutoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<AtualizarProdutoCommand>, AtualizarProdutoCommandHandler>();
builder.Services.AddScoped<IRequestHandler<ExcluirProdutoCommand>, ExcluirProdutoCommandHandler>();

builder.Services.AddScoped<IRequestHandler<ObterTodosProdutosQuery, object>, ObterTodosProdutosQueryHandler>();
builder.Services.AddScoped<IRequestHandler<ObterProdutoQuery, object>, ObterProdutoQueryHandler>();

builder.Services.AddScoped<IMediatorHandler, MediatorHandler>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

// AutoMapper
var config = AutoMapperConfiguration.RegisterMappings();

IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

AutoMapperConfiguration.RegisterMappings();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();