
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace odec.Framework.Infrastructure.ORM.EF
{
    public static class EFCfgHelper
    {
        public static EFOptions GetEFOptions(IConfiguration cfg, string section = null)
        {
            var efOptions = new EFOptions();
            if (string.IsNullOrEmpty(section))
                section = "EfConfig";

            var efOptionsSection = cfg.GetSection(section);
            efOptionsSection?.Bind(efOptions);

            return efOptions;
        }
        public static void SetContextOptions<TDbContext>(EFOptions efOptions,DbContextOptionsBuilder options)
            where TDbContext : DbContext
        {
            switch (efOptions.ConnectionOption.GetConnectionTypeEnum())
                    {
                        case ConnectionType.MySQL:
                            options.UseMySql(efOptions.ConnectionOption.Value,
                       b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                            break;
                        case ConnectionType.PostgresSQL:
                            options.UseNpgsql(efOptions.ConnectionOption.Value,
                       b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                            break;
                        default:
                            options.UseSqlServer(efOptions.ConnectionOption.Value,
                       b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                            break;
                    }
        }

        public static void SetupEf<TDbContext>(IServiceCollection services, IConfiguration cfg, string section = null)
            where TDbContext : DbContext
        {
            var efOptions = GetEFOptions(cfg, section);

            services.AddDbContext<TDbContext>(options =>
                {
                    SetContextOptions<TDbContext>(efOptions,options);

                });
        }
    }
}
