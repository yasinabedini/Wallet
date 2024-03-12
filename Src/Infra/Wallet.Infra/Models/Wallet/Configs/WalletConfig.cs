using Microsoft.EntityFrameworkCore;
using Wallet.Domain.Common.ValueObjects.Conversion;
using Wallet.Domain.Models.Wallet.Entities;

namespace Wallet.Infra.Models.Wallet.Configs;

public class WalletConfig : IEntityTypeConfiguration<Domain.Models.Wallet.Entities.Wallet>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Models.Wallet.Entities.Wallet> builder)
    {
        builder.Property(t => t.WalletTitle).IsRequired().HasMaxLength(250).HasConversion<TitleConversion>();
        builder.Property(t => t.PhoneNumber).IsRequired().HasMaxLength(13).HasConversion<PhoneNumberConversion>();
        builder.Property(t => t.WalletBalance).IsRequired().HasDefaultValue(0);              
        builder.Property(t=>t.IsActive).HasDefaultValue(true);

    }
}
