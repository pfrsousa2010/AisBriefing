using Core.Helpers;
using Core.Models;
using Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Core.Databases
{

    /// <summary>
    /// Add-Migration Initial -P Core -S CoreDatabaseConfiguration
    /// Remove-Migration -P Core -S CoreDatabaseConfiguration
    /// update-database -P Core -S CoreDatabaseConfiguration
    /// </summary>

    public class Database : DbContext
    {
        #region Fields
        string path;
        static Database instance;
        #endregion
        public static Database Instance
        {
            get 
            {
                if (instance == null)
                {
                    instance = new Database(Constants.DatabasePath);
                    instance.Initialize();
                }

                return instance;
            }
            
         }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Notam> Notams { get; set; } // criar supaip aqui tbm igual

        public DbSet<Settings> Settings { get; set; }

        public Database(DbContextOptions<Database> options) : base(options)
        { }

        // contrutor used to build migration on project time
        public Database(string path) : base()
        {
            this.path = path;
           
        }

        public void Initialize()
        {

            Database.Migrate();
            

            if (Settings.Count() == 0)
            {
                Settings.Add(new Settings());
            }


            SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(path))
            {
                optionsBuilder.UseSqlite($"Filename={path}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Comportamento em cascata
        {
            modelBuilder.Entity<Location>().HasMany(location => location.Notams).WithOne(notam => notam.Location).HasForeignKey(notam => notam.LocationId).OnDelete(DeleteBehavior.Cascade);
            // criar supaip aqui tbm igual
        }
    }
}
