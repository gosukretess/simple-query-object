using Microsoft.EntityFrameworkCore;

namespace QueryObjectPatternExamples.Database.EntityFramework.Infrastructure;

public class EfContext : DbContext
{
    public DbSet<GameDbo> Games { get; set; }

    public EfContext(DbContextOptions<EfContext> options)
        : base(options)
    {
    }
}

public class GameDbo
{
    public int Id { get; set; }
    public string Name { get; set; }
}