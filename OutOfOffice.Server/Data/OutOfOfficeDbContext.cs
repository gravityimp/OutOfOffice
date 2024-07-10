using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using OutOfOffice.Server.Models;

namespace OutOfOffice.Server.Data
{
    public class OutOfOfficeDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<ApprovalRequest> ApprovalRequests { get; set; }

        public OutOfOfficeDbContext(DbContextOptions<OutOfOfficeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasMany(e => e.ManagedProjects)
            .WithOne(p => p.ProjectManagerRef)
            .HasForeignKey(p => p.ProjectManager);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.LeaveRequests)
                .WithOne(lr => lr.EmployeeRef)
                .HasForeignKey(lr => lr.Employee);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ApprovalRequests)
                .WithOne(ar => ar.ApproverRef)
                .HasForeignKey(ar => ar.Approver);

            modelBuilder.Entity<LeaveRequest>()
                .HasMany(lr => lr.ApprovalRequests)
                .WithOne(ar => ar.LeaveRequestRef)
                .HasForeignKey(ar => ar.LeaveRequest);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.PeoplePartnerRef)
                .WithMany()
                .HasForeignKey(e => e.PeoplePartner)
                .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many Relationship <Employee, Project>
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Projects)
                .WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectEmployee",
                    j => j.HasOne<Project>().WithMany().HasForeignKey("ProjectId"),
                    j => j.HasOne<Employee>().WithMany().HasForeignKey("EmployeeId"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
