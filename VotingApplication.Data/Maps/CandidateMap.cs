using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities;

namespace VotingApplication.Data.Maps
{
    public class CandidateMap : KeyedEntityBaseMap<Candidate, int>
    {
        public override void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.ToTable("Candidates");
            builder.Property(r => r.CatergoryId).HasColumnName("CatergoryId").IsRequired();
            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(255);
            base.Configure(builder);
        }
    }
}
