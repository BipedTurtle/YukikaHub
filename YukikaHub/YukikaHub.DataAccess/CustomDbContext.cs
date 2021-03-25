using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YukikaHub.Model;

namespace YukikaHub.DataAccess
{
    public class CustomDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = YukikaStoreAppData";
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}