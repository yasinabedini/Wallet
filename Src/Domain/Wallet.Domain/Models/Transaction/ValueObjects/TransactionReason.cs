using Framework.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.Rules;
using Wallet.Domain.Common.ValueObjects;

namespace Wallet.Domain.Models.Transaction.ValueObjects
{
    /// <summary>
    /// ProductPurchase | PayingBill || RechargeWallet || BuyMobileRecharge || MoneyTransfer || CashWithdrawal
    /// </summary>
    public class TransactionReason : BaseValueObject<TransactionReason>
    {
        #region Properties
        public string Value { get; private init; }
        #endregion

        #region Constructors

        public static TransactionReason FromString(string value) => new TransactionReason(value);

        public TransactionReason(string value)
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
        public static explicit operator string(TransactionReason title) => title.Value;
        public static implicit operator TransactionReason(string value) => new(value);
        #endregion

        #region Methods
        public override string ToString() => Value;
        #endregion
    }
}
