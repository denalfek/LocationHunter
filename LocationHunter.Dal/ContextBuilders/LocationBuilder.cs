using LocationHunter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationHunter.Dal.ContextBuilders
{
    internal class LocationBuilder : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => new { l.Id });

            builder.Property(l => l.Ip);
            builder.Property(l => l.Name);
        }
    }
}
