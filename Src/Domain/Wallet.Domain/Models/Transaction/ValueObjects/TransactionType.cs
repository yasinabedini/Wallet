using Framework.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.Rules;

namespace Wallet.Domain.Models.Transaction.ValueObjects
{
    public class TransactionType:BaseValueObject<TransactionType>
    {
        #region Properties
        public string Value { get; private init; }
        #endregion

        #region Constructors

        public static TransactionType FromString(string value) => new TransactionType(value);

        public TransactionType(string value)
        {
            CheckRule(new TheValueMustNotBeEmpty(value));

            Value = value;
        }
        #endregion

        #region Equality Check
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
        #endregion

        #region Operator Overloading
        public static explicit operator string(TransactionType title) => title.Value;
        public static implicit operator TransactionType(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;
        #endregion
    }
}
