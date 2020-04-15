using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIFitnessTracker.Models;

namespace WebAPIFitnessTracker.Data
{
    public class WebAPIFitnessTrackerContext : DbContext
    {
        public WebAPIFitnessTrackerContext (DbContextOptions<WebAPIFitnessTrackerContext> options)
            : base(options)
        {
        }

        public WebAPIFitnessTrackerContext()
        {
        }

        public DbSet<WebAPIFitnessTracker.Models.UserData> Users { get; set; }

        public DbSet<WebAPIFitnessTracker.Models.WorkoutData> Workouts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("WebAPIFitnessTrackerContext"));
        }

    }
}
