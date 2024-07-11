using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Genre> Genres { get; set; }
        public DatabaseContext(DbContextOptions opts) : base(opts)
        {
            
        }

        protected DatabaseContext()
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>(entity =>
            {
                entity.ToTable("tb_genre");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("genre_id");
                entity.Property(e => e.Title).HasColumnName("title").HasMaxLength(100).IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
