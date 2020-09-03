using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities;

namespace VotingApplication.Data.Maps
{
    public class VoterMap : EditableEntityBaseMap<Voter, int>
    {
        public override void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.ToTable("Voters");
            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(255); ;
            builder.Property(r => r.DOB).HasColumnName("DOB");
            base.Configure(builder);
        }
    }
}
