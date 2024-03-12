using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wallet.Domain.Common.ValueObjects;
using Wallet.Domain.Models.Transaction.ValueObjects;

namespace Wallet.Application.Models.Transaction.Queries.Common
{
    public class TransactionResult
    {
        public long Id { get; set; }

        public long WalletId { get; private set; }

        public int Price { get; private set; }

        public string Type { get; set; }

        public string Reason { get; set; }

        public string Description { get; private set; }

        public long? SourceWalletId { get; set; }

        public long? DestinationWalletId { get; set; }

        public TransactionResult(long id, long walletId, int price, string type, string reason, string description, long? sourceWalletId, long? destinationWalletId)
        {
            Id = id;
            WalletId = walletId;
            Price = price;
            Type = type;
            Reason = reason;
            Description = description;
            SourceWalletId = sourceWalletId;
            DestinationWalletId = destinationWalletId;
        }
    }
}
