using GestaoProduto.Application.Produto;
using GestaoProduto.Application.Produto.Commands.AtualizarProduto;
using GestaoProduto.Application.Produto.Commands.ExclusaoProduto;
using GestaoProduto.Application.Produto.Commands.RegistrarProduto;
using GestaoProduto.Application.Produto.Query.ObterProduto;
using GestaoProduto.Application.Produto.Query.ObterTodosProdutos;
using GestaoProduto.Domain.Core;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public ProdutoController(
            IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        //ObterProdutoQuery
        [HttpGet("produto-codigo")]
        public async Task<IActionResult> ObterProdutoPorCodigoAsync([FromQuery] ObterProdutoQuery request)
        {
            var result = await _mediator.Send(request);

            return Ok(new
            {
                List = result
            });
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosProdutosAsync([FromQuery] ObterTodosProdutosQuery request)
        {
            var result = await _mediator.Send(request);

            return Ok(new
            {
                List = result
            });
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarProduto(RegistrarProdutoCommand produto)
        {
            try
            {
                await _mediator.EnviarComando(produto);

                return Ok(new
                {
                    status = "Sucesso",
                    message = "Registro incluído com sucesso!"
                });
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return Ok(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpPut]
        public async Task<IActionResult> AtualizarProduto(AtualizarProdutoCommand produto)
        {
            try
            {
                await _mediator.EnviarComando(produto);

                return Ok(new
                {
                    status = "Sucesso",
                    message = "Registro Atualizado com sucesso!"
                });
            }
            catch (BusinessRuleException ex)
            {
                return Ok(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> ExcluirProduto(ExcluirProdutoCommand produto)
        {
            try
            {
                await _mediator.EnviarComando(produto);

                return Ok(new
                {
                    status = "Sucesso",
                    message = "Registro Excluído com sucesso!"
                });
            }
            catch (BusinessRuleException ex)
            {
                return Ok(new
                {
                    status = "error",
                    message = ex.Message
                });
            }
        }
    }
}