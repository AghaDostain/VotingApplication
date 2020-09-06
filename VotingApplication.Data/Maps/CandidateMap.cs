using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VotingApplication.Entities;

namespace VotingApplication.Data.Maps
{
    public class CandidateMap : KeyedEntityBaseMap<Candidate, int>
    {
        public override void Configure(EntityTypeBuilder<Candidate> builder)
        {
            base.Configure(builder);
            builder.ToTable("Candidates");
            builder.Property(r => r.CatergoryId).HasColumnName("CatergoryId");
            builder.Property(r => r.Name).HasColumnName("Name").HasMaxLength(255);
            builder.HasOne(s => s.Category)
                .WithMany(s => s.Candidates)
                .HasForeignKey(s => s.CatergoryId)
                .HasConstraintName("FK_Candidates_Categories");
        }
    }
}
