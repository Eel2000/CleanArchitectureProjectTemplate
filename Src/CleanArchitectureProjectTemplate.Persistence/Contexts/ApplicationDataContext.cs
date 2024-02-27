using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureProjectTemplate.Persistence.Contexts;

public class ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : DbContext(options)
{
}
