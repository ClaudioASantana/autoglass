using System.Collections.Generic;

namespace GestaoProduto.Domain.Core.Model
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get; private set; }

        protected Money()
                : this(0m)
        {
        }

        public Money(decimal value)
        {
            Value = value;
        }

        public Money Add(Money money)
        {
            return new Money(Value + money.Value);
        }

        public Money Subtract(Money money)
        {
            return new Money(Value - money.Value);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            return new List<object>() { Value };
        }
    }
}