using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Wallet.Domain.Common.ValueObjects.Conversion;

public class DescriptionConversion : ValueConverter<Description, string>
{
    public DescriptionConversion() : base(c => c.Value, c => Description.FromString(c))
    {

    }
}
