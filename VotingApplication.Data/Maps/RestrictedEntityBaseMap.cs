using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities.Common;

namespace VotingApplication.Data.Maps
{
    public class RestrictedEntityBaseMap<TEntity, TId> : KeyedEntityBaseMap<TEntity, TId>
        where TEntity : RestrictedEntityBase<TId>
        where TId : struct
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime"); ;
        }
    }
}
