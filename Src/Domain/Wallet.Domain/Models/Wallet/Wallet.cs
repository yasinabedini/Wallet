using Framework.Entities;
using Wallet.Domain.Common.ValueObjects;

namespace Wallet.Domain.Models.Wallet;

public class Wallet : AggregateRoot
{
    public Title WalletTitle { get;private set; }
    public PhoneNumber PhoneNumber { get; private set; }
    public int WalletBalance { get; private set; }

    protected Wallet() { }

    public Wallet(string walletTitle, string phoneNumber, int walletBalance)
    {
        WalletTitle = walletTitle;
        PhoneNumber = phoneNumber;
        WalletBalance = walletBalance;
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
}
