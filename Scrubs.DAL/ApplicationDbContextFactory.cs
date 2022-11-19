namespace Scrubs.DAL;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext> {
    
    public ApplicationDbContext CreateDbContext(string[] args) {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql(
        $"Server=localhost;" +
            $"Port=5432;" +
            $"Database=Scrubs;" +
            $"Username=postgres;" +
            $"Password=guitarist097865"
        );

        return new ApplicationDbContext(optionsBuilder.Options);
    }
    
}
