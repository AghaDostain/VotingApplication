using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities;

namespace VotingApplication.Data.Maps
{
    public class CategoryMap : KeyedEntityBaseMap<Category, int>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(255);
            base.Configure(builder);
        }
    }
}
