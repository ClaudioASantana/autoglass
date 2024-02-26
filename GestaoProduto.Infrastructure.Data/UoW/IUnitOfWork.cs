using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProduto.Infrastructure.Data.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
