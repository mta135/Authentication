using Auth.Models.DbSetup.DataBaseMigrations;
using Auth.Models.DbSetup.DbSetupConnection;
using FluentMigrator;
using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Models.DbSetup.MigratorSetup
{
    public static class FluentMigratorSetup
    {
        public static void ConfigureAndRunMigrations(IServiceCollection services)
        {
            // Configure FluentMigrator
            services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                {
                    config.AddSqlServer()
                          .WithGlobalConnectionString(ConnectionString.Connection)
                          .ScanIn(typeof(Migrations).Assembly).For.Migrations();
                });

            // Build the service provider and run migrations
            var serviceProvider = services.BuildServiceProvider();

            RunMigrations(serviceProvider);
        }

        private static void RunMigrations(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();

            // Apply all pending migrations
            runner.MigrateUp();
        }
    }    
}
