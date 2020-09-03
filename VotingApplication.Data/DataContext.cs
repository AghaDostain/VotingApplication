using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VotingApplication.Entities;
using VotingApplication.Entities.Common;

namespace VotingApplication.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public virtual DbSet<Candidate> Candidates { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Voter> Voters { get; set; }
        public virtual DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
                var connection = @"Server=.;Database=Voting;Trusted_Connection=True;ConnectRetryCount=0";
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            ProcessTrackableEntities();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                ProcessTrackableEntities();
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ProcessTrackableEntities()
        {
            var editableEntries = ChangeTracker.Entries<EditableEntityBase<int>>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            var restrictedEntries = ChangeTracker.Entries<RestrictedEntityBase<int>>().Where(x => x.State == EntityState.Added).ToList();

            foreach (var entry in editableEntries)
            {
                var type = entry.Entity.GetType().BaseType;

                if (type.GetGenericTypeDefinition() == typeof(EditableEntityBase<>))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.UpdatedOn = DateTime.UtcNow;
                    }
                }
            }            

            foreach (var entry in restrictedEntries)
            {
                var type = entry.Entity.GetType().BaseType;

                if (type.GetGenericTypeDefinition() == typeof(RestrictedEntityBase<>))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}
