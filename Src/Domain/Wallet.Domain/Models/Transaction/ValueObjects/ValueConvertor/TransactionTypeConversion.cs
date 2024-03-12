using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet.Domain.Models.Transaction.ValueObjects.ValueConvertor
{
    public class TransactionTypeConversion : ValueConverter<TransactionType, string>
    {
        public TransactionTypeConversion() : base(c => c.Value, c => TransactionType.FromString(c))
        {

        }
    }
}
