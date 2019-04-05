
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace odec.Framework.Infrastructure.ORM.EF
{
    /// <summary>
    /// Helps to build the configuration for the Entity Framework from config.
    /// </summary>
    public static class EFCfgHelper
    {
        /// <summary>
        /// Gets Entity framework options from configuration.
        /// </summary>
        /// <param name="cfg">Configuration abstraction <see cref="IConfiguration"/> to map from</param>
        /// <param name="section">section to search for the options. "EfConfig" by default</param>
        /// <returns>returns the bound object of options <see cref="EFOptions"/></returns>
        public static EFOptions GetEFOptions(IConfiguration cfg, string section = null)
        {
            var efOptions = new EFOptions();
            if (string.IsNullOrEmpty(section))
                section = "EfConfig";

            var efOptionsSection = cfg.GetSection(section);
            efOptionsSection?.Bind(efOptions);

            return efOptions;
        }

        /// <summary>
        /// Sets the Migration assembly and the provider to use for the EF.
        /// </summary>
        /// <param name="efOptions">options to be set <see cref="EFOptions"/></param>
        /// <param name="optionsBuilder"> the builder object for options</param>
        public static void SetContextOptions(EFOptions efOptions, DbContextOptionsBuilder optionsBuilder)
        {
            switch (efOptions.ConnectionOption.GetConnectionTypeEnum())
            {
                case ConnectionType.MySQL:
                    optionsBuilder.UseMySql(efOptions.ConnectionOption.Value,
               b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                    break;
                case ConnectionType.PostgresSQL:
                    optionsBuilder.UseNpgsql(efOptions.ConnectionOption.Value,
               b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                    break;
                default:
                    optionsBuilder.UseSqlServer(efOptions.ConnectionOption.Value,
               b => b.MigrationsAssembly(efOptions.MigrationAssembly));
                    break;
            }
        }

        /// <summary>
        /// Sets Entity framework context for the service collection <paramref name="services"/> inside the app with configuration <paramref name="cfg"/> using particular section <paramref name="section"/> which is "EfConfig" by default
        /// </summary>
        /// <typeparam name="TDbContext"> Type for the database context <see cref="DbContext"/> to be configured.</typeparam>
        /// <param name="services"><see cref="IServiceCollection"/> for the application</param>
        /// <param name="cfg">Application <see cref="IConfiguration"/> from where to read the Entity Framework related configuration.</param>
        /// <param name="section">section to search for the options. "EfConfig" by default</param>
        public static void SetupEf<TDbContext>(IServiceCollection services, IConfiguration cfg, string section = null)
            where TDbContext : DbContext
        {
            var efOptions = GetEFOptions(cfg, section);

            services.AddDbContext<TDbContext>(options =>
                {
                    SetContextOptions(efOptions, options);

                });
        }
    }
}
