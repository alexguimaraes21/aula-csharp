using Livraria.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Web.Context
{
    public class DatabaseContext : DbContext
    {
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleBook> SaleBooks { get; set; }
        public virtual DbSet<Seller> Sellers { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
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

            modelBuilder.Entity<Author>(entity =>
            {
                entity.ToTable("tb_author");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("author_id");
                entity.Property(e => e.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
                entity.Property(e => e.BirthDate).HasColumnName("birth_date").IsRequired();
            });


            modelBuilder.Entity<Seller>(entity => {
                entity.ToTable("tb_seller");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("seller_id");
                entity.Property(e => e.Name).HasColumnName("name").IsRequired();
                entity.Property(e => e.SellerCode).HasColumnName("seller_code").HasMaxLength(10).IsRequired();
            });

            modelBuilder.Entity<Book>(entity => 
            {
                entity.ToTable("tb_book");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("book_id");
                entity.Property(e => e.Isbn).HasColumnName("isbn").IsRequired();
                entity.Property(e => e.Summary).HasColumnName("summary").HasColumnType("LONGTEXT");
                entity.Property(e => e.Publisher).HasColumnName("publisher");
                entity.Property(e => e.TotalPages).HasColumnName("total_pages");
                entity.Property(e => e.ReleaseDate).HasColumnType("DATE").HasColumnName("release_date");
                entity.Property(e => e.Price).HasColumnName("price");
                entity.Property(e => e.AuthorId).HasColumnName("author_id");
                entity.Property(e => e.GenreId).HasColumnName("genre_id");

                // Foreign Key Book -> Author
                entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(a => a.AuthorId)
                    .HasConstraintName("fk_book_author_id")
                    .IsRequired();

                // Foreign Key Book -> Genre
                entity.HasOne(b => b.Genre)
                    .WithMany(g => g.Books)
                    .HasForeignKey(g => g.GenreId)
                    .HasConstraintName("fk_book_genre_id")
                    .IsRequired();
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("tb_stock");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("stock_id");
                entity.Property(e => e.Qty).HasColumnType("DOUBLE").HasColumnName("qty").IsRequired();
                entity.Property(e => e.BookId).HasColumnName("book_id");

                // Foreign Key Stock -> Book
                entity.HasOne(e => e.Book)
                    .WithMany()
                    .HasForeignKey(e => e.BookId)
                    .HasConstraintName("fk_stock_book_id")
                    .IsRequired();
            });

            modelBuilder.Entity<Sale>(entity => {
                entity.ToTable("tb_sale");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("sale_id");
                entity.Property(e => e.SaleTotal).HasColumnName("sale_total").HasColumnType("DOUBLE").IsRequired();

                // Foreign Key Sale -> Seller
                entity.HasOne(e => e.Seller)
                    .WithMany(s => s.Sales)
                    .HasForeignKey(s => s.SellerId)
                    .HasConstraintName("fk_sale_seller_id")
                    .IsRequired();

                // Foreign Key Sale -> SaleBooks
                entity.HasMany(s => s.SaleBooks)
                    .WithOne(ss => ss.Sale)
                    .HasForeignKey(ss => ss.SaleId)
                    .HasConstraintName("fk_sale_book_sales");

            });

            modelBuilder.Entity<SaleBook>(entity => {
                entity.ToTable("tb_sale_book");
                entity.HasKey(ss => new { ss.SaleId, ss.BookId });
                entity.Property(ss => ss.SaleId).HasColumnName("sale_id");
                entity.Property(ss => ss.BookId).HasColumnName("book_id");


                // Foreign Key SaleBook -> Book
                entity.HasOne(ss => ss.Book)
                    .WithMany(b => b.SaleBooks)
                    .HasConstraintName("fk_sablebook_book_id")
                    .HasForeignKey(ss => ss.BookId);

                // Foreign Key SaleBook -> Sale
                entity.HasOne(ss => ss.Sale)
                    .WithMany(s => s.SaleBooks)
                    .HasConstraintName("fk_sablebook_sale_id")
                    .HasForeignKey(ss => ss.SaleId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
