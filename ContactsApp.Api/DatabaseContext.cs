using ContactsApp.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsApp.Api
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Contact> Contacts { get; set; }

		public string DbPath { get; }

		public DatabaseContext(){
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "ContactsAppDatabase.db");
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(x => x.Id);

        }
    }
}