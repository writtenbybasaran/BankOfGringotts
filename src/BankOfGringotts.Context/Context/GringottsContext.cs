using BankOfGringotts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankOfGringotts.Context.Audit;
using BankOfGringotts.Model.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BankOfGringotts.Context.Context
{
    public class GringottsContext : DbContext
    {

        public GringottsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Customers>()
                .HasIndex(u => u.IdentityNumber)
                .IsUnique();
            builder.Entity<Customers>()
                .HasMany(x => x.Accounts)
                .WithOne();
                

            builder.Entity<Accounts>()
                .HasOne(n => n.Customer)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => x.CustomerId);

            builder.Entity<AccountTransactions>()
                .HasOne(n => n.Account)
                .WithMany(x => x.AccountTransactions)
                .HasForeignKey(x => x.AccountId);
        }

        public override int SaveChanges(bool acceptAllChangesOnSucces)
        {
            OnBeforeSaveChanges();
            SetAuditProperties();
            return base.SaveChanges(acceptAllChangesOnSucces);
        }

        private void SetAuditProperties()
        {
            var entry = ChangeTracker.Entries();
            foreach (var item in entry)
            {
                switch (item.State)
                {
                    case EntityState.Modified:
                        if (item.Entity is IUpdateAudit updatedEntityModifed)
                        {
                            updatedEntityModifed.LastActivityDate = DateTime.Now;
                        }
                        break;
                    case EntityState.Added:
                        if (item.Entity is ICreateAudit createdEntity)
                        {
                            createdEntity.CreatedDate = DateTime.Now;
                        }

                        if (item.Entity is IUpdateAudit updatedEntityAdded)
                        {
                            updatedEntityAdded.LastActivityDate=DateTime.Now;
                        }
                        break;
                    default:
                        break;
                }

                
            }
        }

        private void OnBeforeSaveChanges()
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Model.Audit || entry.State == EntityState.Detached || entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry);
                auditEntry.TableName = entry.Entity.GetType().Name;
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    string propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }
            foreach (var auditEntry in auditEntries)
            {
                Audits.Add(auditEntry.ToAudit());
            }
        }

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<AccountTransactions> AccountTransactions { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Model.Audit> Audits { get; set; }
    }
}
