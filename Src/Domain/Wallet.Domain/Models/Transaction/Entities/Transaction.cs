using Framework.Entities;
using System.Transactions;
using Wallet.Domain.Common.ValueObjects;
using Wallet.Domain.Models.Transaction.Enums;
using Wallet.Domain.Models.Transaction.ValueObjects;
using Wallet.Domain.Models.Wallet.Entities;

namespace Wallet.Domain.Models.Transaction.Entities;

public class Transaction : AggregateRoot
{
    public long WalletId { get; private set; }

    public int Price { get; private set; }

    public TransactionType Type { get; set; }

    public TransactionReason Reason { get; set; }

    public Description Description { get; private set; }

    public long? SourceWalletId { get; set; }

    public long? DestinationWalletId { get; set; }

    public Wallet.Entities.Wallet Wallet { get; set; }




    protected Transaction() { }

    public Transaction(int walletId, int price, string type, string reason, string description, int? sourceWalletId = null, int? destinationWalletId = null)
    {
        WalletId = walletId;
        Price = price;
        Type = type;
        Description = description;
        Reason = reason;
        CreateAt = DateTime.Now;
        SourceWalletId = sourceWalletId ?? null;
        DestinationWalletId = destinationWalletId ?? null;
    }
}
