namespace Scrubs.DAL;

using Domain.Entity;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext {
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    
    public DbSet<AppointmentDoctor>? AppointmentDoctors { get; set; }
    
    public DbSet<Doctor>? Doctors { get; set; }
    
    public DbSet<Role>? Roles { get; set; }
    
    public DbSet<Specialization>? Specializations { get; set; }
    
    public DbSet<TimeTable>? TimeTables { get; set; }
    
    public DbSet<User>? Users { get; set; }

}
