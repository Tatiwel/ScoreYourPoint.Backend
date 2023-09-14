using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ScoreYourPointApi.Infra.Data
{

    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ScoreYourPointApiDatabase"), b => b.MigrationsAssembly("ScoreYourPoint.Infra"));
        }

        DbSet<ScoreYourPoint.Domain.Class1> Class1 { get; set; }
    }
}