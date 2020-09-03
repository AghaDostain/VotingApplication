using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities;

namespace VotingApplication.Data.Maps
{
    public class VoteMap : RestrictedEntityBaseMap<Vote, int>
    {
        public override void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("Votes");
            builder.Property(r => r.VoterId).HasColumnName("VoterId").IsRequired(); ;
            builder.Property(r => r.CandidateId).HasColumnName("CandidateId").IsRequired();
            builder.Property(r => r.CategoryId).HasColumnName("CategoryId").IsRequired();
            base.Configure(builder);
        }
    }
}
