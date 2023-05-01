using Microsoft.EntityFrameworkCore;
using TestingWebAPI.Models;

namespace TestingWebAPI.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {
        }

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get; set; }


        public DbSet<Producer> Producers { get; set; }


        public DbSet<ProducerAddress> ProducersAddress { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BANINS\SQLEXPRESS;Database=MovieProducerDB;Trusted_Connection=True;Encrypt=false;TrustServerCertificate=True;");
        }
    }
}
