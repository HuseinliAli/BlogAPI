using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    internal class BlogAppDbContext : DbContext
    {
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VoteBlogPost> VoteBlogPosts { get; set; }
        public DbSet<UserOperation> UserOperations { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
    }
}
