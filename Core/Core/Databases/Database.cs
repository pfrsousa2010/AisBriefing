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

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactGroup> ContactGroups{ get; set; }

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

            if (ContactGroups.Count() == 0)
            {
                ContactGroups.AddRange(new[]
                {
                    new ContactGroup{Name = "family".Translate()},
                    new ContactGroup{Name = "work".Translate()},
                    new ContactGroup{Name = "social-media".Translate()},
                    new ContactGroup{Name = "clients".Translate()},
                    new ContactGroup{Name = "contacts".Translate()},
                    new ContactGroup{Name = "providers".Translate()},
                });
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactGroup>().HasMany(group => group.Contacts).WithOne(contact => contact.Group).HasForeignKey(contact => contact.GroupId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
