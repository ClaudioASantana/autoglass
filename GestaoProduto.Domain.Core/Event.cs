using MediatR;
using System;

namespace GestaoProduto.Domain.Core
{
    public abstract class Event : INotification
    {
        public DateTime DataOcorrencia => DateTime.Now;
    }
}
