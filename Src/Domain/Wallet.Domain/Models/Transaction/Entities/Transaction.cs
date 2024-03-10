using Framework.Entities;
using System.Transactions;
using Wallet.Domain.Common.ValueObjects;
using Wallet.Domain.Models.Transaction.Enums;

namespace Wallet.Domain.Models.Transaction.Entities;

public class Transaction : AggregateRoot
{
    public int WalletId { get; private set; }

    public int Price { get; private set; }

    public _TransactionType Type { get; set; }

    public Description Description { get; private set; }

    protected Transaction() { }

    public Transaction(int walletId, int price, int type, string description)
    {
        WalletId = walletId;
        Price = price;
        Type = type == 1 ? _TransactionType.Deposit_Money : _TransactionType.Withdraw_Money;
        Description = description;
    }
}
