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
        public DbSet<TechnicianTask> TechnicianTasks { get; set; }

        // DbSet for the join table
        public DbSet<RepairJobSparePart> RepairJobSpareParts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite Key for RepairJobSparePart
            modelBuilder.Entity<RepairJobSparePart>()
                .HasKey(rjs => new { rjs.RepairJobId, rjs.SparePartId });

            // Customer <-> SupportRequest (One-to-Many)
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.SupportRequests)
                .WithOne(s => s.Customer)
                .HasForeignKey(s => s.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Customer <-> Feedback (One-to-Many)
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

            // Technician <-> TechnicianTask (One-to-Many)
            modelBuilder.Entity<TechnicianTask>()
                .HasOne(tt => tt.Technician)
                .WithMany(t => t.TechnicianTasks)
                .HasForeignKey(tt => tt.TechnicianId);

            modelBuilder.Entity<TechnicianTask>().HasData(
            new TechnicianTask
            {
                TechnicianTaskId = 1,
                TechnicianId = 1, // Make sure this ID corresponds to an existing Technician
                Title = "Power Outage Repair",
                Description = "Fix the power outage in the main office.",
                Status = "In Progress"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 2,
                TechnicianId = 2, // Make sure this ID corresponds to an existing Technician
                Title = "Broken Circuit",
                Description = "Repair the broken circuit in server room.",
                Status = "Pending"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 3,
                TechnicianId = 1,
                Title = "Check Wiring",
                Description = "Inspect wiring in server room for damage.",
                Status = "Pending"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 4,
                TechnicianId = 3,
                Title = "Repair Light Fixture",
                Description = "Replace faulty light fixture in lobby.",
                Status = "In Progress"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 5,
                TechnicianId = 2,
                Title = "Test Emergency Lighting",
                Description = "Ensure all emergency lighting is operational.",
                Status = "Completed"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 6,
                TechnicianId = 3,
                Title = "Upgrade Electrical Panel",
                Description = "Upgrade the electrical panel to handle increased load.",
                Status = "Pending"
            },
            new TechnicianTask
            {
                TechnicianTaskId = 7,
                TechnicianId = 1,
                Title = "Inspect HVAC System",
                Description = "Check HVAC system for electrical issues.",
                Status = "In Progress"
            }
            // Add more TechnicianTask records as needed
        );

            // Seed data for Technicians if not already seeded
            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId = 1,
                    Name = "John Doe",
                    Specialization = "Electrical",
                    Availability = "Available"
                },
                new Technician
                {
                    TechnicianId = 2,
                    Name = "Jane Smith",
                    Specialization = "HVAC",
                    Availability = "Not Available"
                },
                 new Technician
                 {
                     TechnicianId = 4,
                     Name = "John Doe",
                     Specialization = "Electrical",
                     Availability = "Available"
                 },
            new Technician
            {
                TechnicianId = 5,
                Name = "Jane Smith",
                Specialization = "HVAC",
                Availability = "Busy"
            },
            new Technician
            {
                TechnicianId = 6,
                Name = "Robert Johnson",
                Specialization = "Plumbing",
                Availability = "Available"
            }
            // Add more Technician records as needed
            );

            modelBuilder.Entity<KnowledgeBase>().HasData(
           new KnowledgeBase
           {
               KnowledgeBaseId = 1,
               Title = "Printer Not Working",
               ProblemDescription = "The printer is not responding when trying to print.",
               SolutionSteps = "1. Check if the printer is powered on.\n2. Ensure the printer is connected to the computer.\n3. Restart the printer and try again.",
               HardwareOrSoftware = "Hardware"
           },
           new KnowledgeBase
           {
               KnowledgeBaseId = 2,
               Title = "Software Installation Error",
               ProblemDescription = "Error occurs during the installation of software X.",
               SolutionSteps = "1. Ensure that the installation package is not corrupted.\n2. Check for sufficient disk space.\n3. Run the installer as an administrator.",
               HardwareOrSoftware = "Software"
           },
           new KnowledgeBase
           {
               KnowledgeBaseId = 3,
               Title = "Slow Computer Performance",
               ProblemDescription = "Computer is running slower than usual.",
               SolutionSteps = "1. Check for any background programs consuming too many resources.\n2. Run a disk cleanup and defragmentation.\n3. Consider upgrading the RAM if necessary.",
               HardwareOrSoftware = "Hardware"
           },
           new KnowledgeBase
           {
               KnowledgeBaseId = 4,
               Title = "Internet Connectivity Issue",
               ProblemDescription = "Unable to connect to the internet.",
               SolutionSteps = "1. Restart the modem and router.\n2. Check if the network cables are properly connected.\n3. Verify the network adapter settings.",
               HardwareOrSoftware = "Software"
           },
            new KnowledgeBase
            {
                KnowledgeBaseId = 5,
                Title = "Blue Screen of Death (BSOD)",
                ProblemDescription = "The computer crashes with a blue screen displaying an error message.",
                SolutionSteps = "1. Check if any recent hardware changes or driver installations have been made.\n" +
                        "2. Ensure all drivers are up to date.\n" +
                        "3. Run a memory diagnostic test to check for faulty RAM.\n" +
                        "4. Perform a system restore to a previous stable state.",
                HardwareOrSoftware = "Hardware"
            },
    new KnowledgeBase
    {
        KnowledgeBaseId = 6,
        Title = "Email Not Syncing",
        ProblemDescription = "Emails are not syncing in the mail client (e.g., Outlook, Thunderbird).",
        SolutionSteps = "1. Check if the internet connection is stable.\n" +
                        "2. Verify email account settings (server details, port numbers, and authentication).\n" +
                        "3. Restart the email client or reboot the device.\n" +
                        "4. Reconfigure the email account if necessary.",
        HardwareOrSoftware = "Software"
    },
    new KnowledgeBase
    {
        KnowledgeBaseId = 7,
        Title = "Operating System Won't Boot",
        ProblemDescription = "The computer fails to load the operating system during startup.",
        SolutionSteps = "1. Check for any loose or disconnected cables inside the computer.\n" +
                        "2. Ensure the boot order is correctly configured in the BIOS.\n" +
                        "3. Use the OS recovery tool to repair the bootloader.\n" +
                        "4. If the issue persists, reinstall the operating system.",
        HardwareOrSoftware = "Hardware"
    },
    new KnowledgeBase
    {
        KnowledgeBaseId = 8,
        Title = "Application Crashing",
        ProblemDescription = "The application crashes unexpectedly when trying to perform a specific action.",
        SolutionSteps = "1. Check if the application is up to date with the latest version.\n" +
                        "2. Review the application logs for any error messages or exceptions.\n" +
                        "3. Uninstall and reinstall the application.\n" +
                        "4. If the issue persists, contact the application's support team.",
        HardwareOrSoftware = "Software"
    },
    new KnowledgeBase
    {
        KnowledgeBaseId = 9,
        Title = "Hard Drive Failure",
        ProblemDescription = "The computer is unable to read from or write to the hard drive, and data is inaccessible.",
        SolutionSteps = "1. Check if the hard drive is properly connected to the motherboard.\n" +
                        "2. Use disk repair tools (e.g., chkdsk) to scan for bad sectors.\n" +
                        "3. If the hard drive is beyond repair, replace it and restore data from backups.",
        HardwareOrSoftware = "Hardware"
    },
    new KnowledgeBase
    {
        KnowledgeBaseId = 10,
        Title = "Network Printer Offline",
        ProblemDescription = "The network printer shows as offline and cannot receive print jobs.",
        SolutionSteps = "1. Restart the printer and check if it's properly connected to the network.\n" +
                        "2. Verify the printer's IP address and ensure it's correct in the printer settings.\n" +
                        "3. Remove and re-add the printer on the computer.\n" +
                        "4. Check firewall settings to ensure the printer is not being blocked.",
        HardwareOrSoftware = "Hardware"
    }
       );

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

            // Add claims for the roles
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
