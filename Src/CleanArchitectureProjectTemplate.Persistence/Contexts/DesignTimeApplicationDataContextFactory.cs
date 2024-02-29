using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureProjectTemplate.Persistence.Contexts;

internal class DesignTimeApplicationDataContextFactory
{
#if DEBUG
    private static string ConnectionString = "Server=.\\SQLEXPRESS;Database=DATABASE;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True";
#elif RELEASE
private static string ConnectionString = "PRODUCTION-CONNECTION-STRING";
#endif

    public ApplicationDataContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDataContext>();
        optionsBuilder.UseSqlServer(ConnectionString, b => b.MigrationsAssembly(typeof(ApplicationDataContext).Assembly.FullName));

        return new ApplicationDataContext(optionsBuilder.Options);
    }
}
