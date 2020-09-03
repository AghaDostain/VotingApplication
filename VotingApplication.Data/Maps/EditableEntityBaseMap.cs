using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities.Common;

namespace VotingApplication.Data.Maps
{
    public class EditableEntityBaseMap<TEntity, TId> : KeyedEntityBaseMap<TEntity, TId>
        where TEntity : EditableEntityBase<TId>
        where TId : struct
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            base.Configure(builder);
            builder.Property(t => t.CreatedOn).HasColumnName("CreatedOn").HasColumnType("datetime"); ;
            builder.Property(t => t.UpdatedOn).HasColumnName("UpdatedOn").HasColumnType("datetime");
        }
    }
}
