using Microsoft.EntityFrameworkCore;

namespace Presentation.Data.Entities;

public class DataContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<BoilerplateEntity> Boilerplates { get; set; }

}
