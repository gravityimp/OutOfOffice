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
            base.OnModelCreating(modelBuilder);
        }
    }
}
