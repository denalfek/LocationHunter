using LocationHunter.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocationHunter.Dal.ContextBuilders
{
    internal class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => new { u.Id });

            builder.Property(u => u.Ip);
        }
    }
}
