using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.ValueObjects;

namespace Wallet.Domain.Models.Transaction.ValueObjects.ValueConvertor
{
    public class TransactionReasonConversion : ValueConverter<TransactionReason, string>
    {
        public TransactionReasonConversion():base(c=>c.Value,c => TransactionReason.FromString(c))
        {
            
        }
    }
}
