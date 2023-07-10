using gRPC_Server.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace gRPC_Server.Data;

public class ServerDbContext : DbContext
{
    public DbSet<DbPerson> Person { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Filename = data.db");
    }
}
