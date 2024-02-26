using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoProduto.Application.Produto.Commands.ExclusaoProduto
{
    public class ExcluirProdutoCommand : Command
    {
        public int Codigo { get; set; }
    }
}
