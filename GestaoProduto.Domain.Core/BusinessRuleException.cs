using System;
using System.Collections.Generic;
using System.Text;

namespace GestaoProduto.Domain.Core
{
    public class BusinessRuleException : Exception
    {
        public BusinessRuleException(string message) : base(message)
        {
        }
    }
}
