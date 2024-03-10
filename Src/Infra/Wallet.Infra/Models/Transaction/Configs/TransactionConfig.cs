using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Common.ValueObjects.Conversion;
using Wallet.Domain.Models.Transaction.Entities;

namespace Wallet.Infra.Models.Transaction.Configs;

public class TransactionConfig : IEntityTypeConfiguration<Domain.Models.Transaction.Entities.Transaction>
{
    public void Configure(EntityTypeBuilder<Domain.Models.Transaction.Entities.Transaction> builder)
    {
        builder.Property(t => t.Description).IsRequired().HasMaxLength(500).HasConversion<DescriptionConversion>();
        builder.Property(t => t.Price).IsRequired();
        builder.Property(t => t.Type).IsRequired();
        builder.Property(t => t.WalletId).IsRequired();

        builder.HasOne(t => t.Wallet).WithMany().HasForeignKey(t => t.WalletId);
    }
}
