using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities.Common;

namespace VotingApplication.Data.Maps
{
    public class KeyedEntityBaseMap<TEntity, TId> : IEntityTypeConfiguration<TEntity>
        where TEntity : KeyedEntityBase<TId> 
        where TId : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Primary Key
            builder.HasKey(t => t.Id);

            // Properties
            builder.Property(t => t.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}
