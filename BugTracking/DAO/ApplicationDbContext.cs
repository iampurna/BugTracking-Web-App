using System;
using BugTracking.Models;
using Microsoft.EntityFrameworkCore;

namespace BugTracking.DAO
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options)
			:base(options)
		{
		}
		public DbSet<UserGroup> UserGroup { get; set;}
        public DbSet<Users> Users { get; set; }
        public DbSet<Complain> Complain { get; set; }
        public DbSet<ComplainStatusTrackInfo> ComplainStatusTrackInfo { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

