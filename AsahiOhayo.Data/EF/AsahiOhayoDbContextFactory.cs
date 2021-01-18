using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AsahiOhayo.Data.EF
{
    public class AsahiOhayoDbContextFactory : IDesignTimeDbContextFactory<AsahiOhayoDbContext>
    {
        public AsahiOhayoDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                   //Microsoft.FileExtension
                   .SetBasePath(Directory.GetCurrentDirectory())
                   //Microsoft.Extension.Json
                   .AddJsonFile("appsettings.json")
                   .Build();
            var connectionString = configuration.GetConnectionString("AsahiOhayo");

            var optionBuilder = new DbContextOptionsBuilder<AsahiOhayoDbContext>();
            optionBuilder.UseSqlServer(connectionString);

            return new AsahiOhayoDbContext(optionBuilder.Options);
        }
    }
}
