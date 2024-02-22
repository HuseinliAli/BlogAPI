using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BlogAppDbContext : DbContext
    {
        public BlogAppDbContext(DbContextOptions options):base(options)
        {           
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        private void SetAuditProperties()
        {
            ChangeTracker.SetAddedProperties();
            //ChangeTracker.SetUpdatedroperties();
            ChangeTracker.SetDeletedProperties();
        }
        public override int SaveChanges()
        {
            SetAuditProperties();
            return base.SaveChanges();
        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            SetAuditProperties();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            SetAuditProperties();
            return base.SaveChangesAsync(cancellationToken);
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperation> UserOperations { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
