using System;

namespace GestaoProduto.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestaoProdutoContext sistemaDeComprasContexto;

        public UnitOfWork(GestaoProdutoContext context)
        {
            sistemaDeComprasContexto = context;
        }

        public bool Commit()
        {
            return sistemaDeComprasContexto.SaveChanges() > 0;
        }

        public void Dispose()
        {
            sistemaDeComprasContexto.Dispose();
        }
    }
}
