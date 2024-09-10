using Dern_Support_System.Models;
using Dern_Support_System.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dern_Support_System.Data
{
    public class DernSupportDbContext : IdentityDbContext<AppUser>
    {
        public DernSupportDbContext(DbContextOptions<DernSupportDbContext> options) : base(options)
        {
        }

        // DbSets for each entity
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SupportRequest> SupportRequests { get; set; }
        public DbSet<RepairJob> RepairJobs { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<SparePart> SpareParts { get; set; }
        public DbSet<KnowledgeBase> KnowledgeBases { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TechnicianTask> TechnicianTasksDb { get; set; }
        public DbSet<TechnicianProjects> TechnicianProjectsDBset { get; set; }

        // DbSet for the join table
        public DbSet<RepairJobSparePart> RepairJobSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships
            modelBuilder.Entity<TechnicianProjects>().HasKey(pk => new { pk.ProjectId, pk.TechnicianId });

            modelBuilder.Entity<TechnicianProjects>()
                .HasOne(ep => ep.Technician)
                .WithMany(e => e.technicianProjects)
                .HasForeignKey(e => e.TechnicianId);

            modelBuilder.Entity<TechnicianTask>()
                .HasOne(ep => ep.technician)
                .WithMany(e => e.technicianTasks)
                .HasForeignKey(e => e.TechnicianId);

            modelBuilder.Entity<TechnicianProjects>()
                .HasOne(ep => ep.Project)
                .WithMany(e => e.technicianProjects)
                .HasForeignKey(e => e.ProjectId);

            // Customer <-> SupportRequest
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.SupportRequests)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer <-> Feedback
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Feedbacks)
                .WithOne(f => f.Customer)
                .HasForeignKey(f => f.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // SupportRequest <-> Quote (One-to-One)
            modelBuilder.Entity<SupportRequest>()
                .HasOne(s => s.Quote)
                .WithOne(q => q.SupportRequest)
                .HasForeignKey<Quote>(q => q.SupportRequestId);

            // SupportRequest <-> RepairJob (One-to-Many)
            modelBuilder.Entity<SupportRequest>()
                .HasMany(s => s.RepairJobs)
                .WithOne(r => r.SupportRequest)
                .HasForeignKey(r => r.SupportRequestId);

            // RepairJob <-> Technician (One-to-Many)
            modelBuilder.Entity<RepairJob>()
                .HasOne(r => r.Technician)
                .WithMany(t => t.RepairJobs)
                .HasForeignKey(r => r.TechnicianId);

            // RepairJob <-> RepairJobSparePart (Many-to-Many)
            modelBuilder.Entity<RepairJob>()
                .HasMany(r => r.RepairJobSpareParts)
                .WithOne(rjs => rjs.RepairJob)
                .HasForeignKey(rjs => rjs.RepairJobId);

            // SparePart <-> RepairJobSparePart (Many-to-Many)
            modelBuilder.Entity<SparePart>()
                .HasMany(s => s.RepairJobSpareParts)
                .WithOne(rjs => rjs.SparePart)
                .HasForeignKey(rjs => rjs.SparePartId);

            // Composite Key for RepairJobSparePart
            modelBuilder.Entity<RepairJobSparePart>()
                .HasKey(rjs => new { rjs.RepairJobId, rjs.SparePartId });

            // KnowledgeBase <-> SupportRequest (One-to-Many)
            modelBuilder.Entity<KnowledgeBase>()
                .HasMany(k => k.SupportRequests)
                .WithOne(s => s.KnowledgeBaseArticle)
                .HasForeignKey(s => s.KnowledgeBaseId);

            // Feedback <-> SupportRequest (One-to-Many)
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.SupportRequest)
                .WithMany(s => s.Feedback)
                .HasForeignKey(f => f.SupportRequestId);

            // Seeding roles with permissions
            SeedRoles(modelBuilder, "Admin", "update", "read", "delete", "create");
            SeedRoles(modelBuilder, "BusinessCustomer", "update", "read", "delete", "create");
            SeedRoles(modelBuilder, "IndividualCustomer", "update", "read", "delete", "create");
        }

        private void SeedRoles(ModelBuilder modelBuilder, string roleName, params string[] permissions)
        {
            var role = new IdentityRole
            {
                Id = roleName.ToLower(),
                Name = roleName,
                NormalizedName = roleName.ToUpper(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };

            // Add claims for the users
            var claims = permissions.Select(permission => new IdentityRoleClaim<string>
            {
                Id = Guid.NewGuid().GetHashCode(),
                RoleId = role.Id,
                ClaimType = "permission",
                ClaimValue = permission
            });

            // Seed the role and its claims
            modelBuilder.Entity<IdentityRole>().HasData(role);
            modelBuilder.Entity<IdentityRoleClaim<string>>().HasData(claims);
        }
    }
}
