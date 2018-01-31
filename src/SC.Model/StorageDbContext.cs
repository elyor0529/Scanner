using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EntityFramework.DynamicFilters;
using SC.Common;
using SC.Model.Entity;

namespace SC.Model
{
    public sealed class StorageDbContext : DbContext
    {
        private void ReConfig()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public StorageDbContext() : this(false)
        {

        }

        public StorageDbContext(bool enableBestPerformance) : base(MainSettings.DatabaseConnectionStringName)
        {
            if (enableBestPerformance)
                ReConfig();
        }

        public DbSet<Scanner> Scanners { get; set; }

        public DbSet<DataTuple> Tuples { get; set; }

        public DbSet<TupleItem> Items { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //prop type
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            modelBuilder.Properties<byte[]>().Configure(c => c.HasColumnType("varbinary"));

            base.OnModelCreating(modelBuilder);

            //prop filter
            modelBuilder.Filter("IsDeleted", (IAuditableEntity f) => f.IsDeleted, false);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return Task.Factory.StartNew(() => SaveChanges(), cancellationToken);
        }

        public override int SaveChanges()
        {
            try
            {
                var modifiedEntries = ChangeTracker.Entries()
                    .Where(a => a.Entity is IAuditableEntity && (a.State == EntityState.Added || a.State == EntityState.Modified));

                foreach (var entry in modifiedEntries)
                {
                    var entity = entry.Entity as IAuditableEntity;

                    if (entity == null)
                        continue;

                    var now = DateTime.Now;

                    if (entry.State == EntityState.Added)
                    {
                        entity.AddedDate = now;
                    }
                    else
                    {
                        Entry(entity).Property(a => a.AddedDate).IsModified = false;
                    }

                    entity.ModifiedDate = now;
                }

                return base.SaveChanges();
            }
            catch (DbEntityValidationException exp)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = exp.EntityValidationErrors
                    .SelectMany(a => a.ValidationErrors)
                    .Select(a => a.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(exp.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, exp.EntityValidationErrors);
            }
        }
    }
}
