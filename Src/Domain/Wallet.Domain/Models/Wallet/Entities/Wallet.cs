using Framework.Entities;
using Wallet.Domain.Common.ValueObjects;

namespace Wallet.Domain.Models.Wallet.Entities;

public class Wallet : AggregateRoot
{
    public Title WalletTitle { get; private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public int WalletBalance { get; private set; }

    protected Wallet() { }
    public Wallet(int id,string walletTitle, string phoneNumber)
    {
        Id = id;
        WalletTitle = walletTitle;
        PhoneNumber = phoneNumber;
        CreateAt = DateTime.Now;
    }
    public Wallet(string walletTitle, string phoneNumber)
    {
        WalletTitle = walletTitle;
        PhoneNumber = phoneNumber;
        CreateAt = DateTime.Now;
    }

    private void Modified()
    {
        ModifiedAt = DateTime.Now;
    }

    public void ChaneTitle(string title)
    {
        WalletTitle = title;
        Modified();
    }

    public int ChangeWalletBalance(int amount)
    {
        WalletBalance = amount;
        Modified();
        return WalletBalance;
    }

    public void IncreaseWalletBalance(int amount)
    {
        WalletBalance += amount;
        Modified();
    }

    public void DecreaseWalletBalance(int amount)
    {
        WalletBalance -= amount;
        Modified();
    }
}

