using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Company.Storage;

public class CompanyDbContext : DbContext
{
    private IConfiguration _configuration { get; }

    public DbSet<Company.Storage.Entities.Company> Companies { get; set; } = null!;

    public CompanyDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer(@"server = 10.200.2.28; Database = company-dev-w66049; User Id = stud; Password =wsiz;",
            x => x.MigrationsHistoryTable("__EFMigrationsHistory", "Company"));

        options.LogTo(x => System.Diagnostics.Debug.WriteLine(x));
    }
}