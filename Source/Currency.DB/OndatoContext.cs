using Microsoft.EntityFrameworkCore;
using Ondato.DB.Models;
using Ondato.DB.Configs;

namespace Ondato.DB
{
    public class OndatoContext : DbContext
    {
        public OndatoContext(DbContextOptions options)
        : base(options)
        { }

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //    => options.UseSqlServer("Data Source=.;Initial Catalog=Products;Integrated Security=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DictionaryValue>().Configs();
            modelBuilder.Entity<DictionaryKey>().Configs();
        }

        public DbSet<DictionaryKey> DictionaryKeys { get; set; }
        public DbSet<DictionaryValue> DictionaryValues { get; set; }
    }
}
