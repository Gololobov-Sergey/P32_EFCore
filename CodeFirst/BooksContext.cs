using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    public partial class BooksContext : DbContext
    {
        public BooksContext()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public BooksContext(DbContextOptions<BooksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            //modelBuilder.Entity<Author>();
            modelBuilder.Entity<Author>().ToTable("Authors");

            //modelBuilder.Entity<Author>().Ignore(a=> a.Address);

            //modelBuilder.Entity<Author>().Property("Id").HasField("id");

            //modelBuilder.Ignore<Author>();

            //modelBuilder.Entity<Author>().Property(a=>a.Id).HasColumnName("id");

            modelBuilder.Entity<Book>()
                .Property(b=>b.Name)
                .IsRequired()
                //.HasColumnName("name")
                .HasMaxLength(50)
                .HasDefaultValue("");

            //modelBuilder.Entity<Book>().Property(b => b.Publishing).HasDefaultValue(DateOnly.MinValue);
            //modelBuilder.Entity<Book>().Property(b => b.Publishing).HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Book>().ToTable(b => b.HasCheckConstraint("ValidPublishing", "Publishing < GETDATE()"));


            //modelBuilder.Entity<Book>().Property(b => b.Publishing).HasColumnType("date");

            //modelBuilder.Entity<Book>().HasKey(b => b.Idixa);

            //modelBuilder.Entity<Book>().HasKey(b => new { b.Id, b.Name});

            //modelBuilder.Entity<Book>().HasAlternateKey(b=>b.Name).HasName("UK_Books_Name");

            //modelBuilder.Entity<Book>().Property(b=>b.Id).ValueGeneratedNever();


            //modelBuilder.Entity<Book>()
            //    .HasOne(b => b.Author)
            //    .WithMany(a => a.Books)
            //    .HasForeignKey(b => b.AuhtorId)
            //    .HasConstraintName("FK_Books_Authors_999")
            //    .OnDelete(DeleteBehavior.Cascade);


            //modelBuilder.Entity<Book>().HasData(
            //    new Book { Id = 1, Name = "C++", Publishing = new DateOnly(2000, 10, 10), Pages=100},
            //    new Book { Id = 2, Name = "C#", Publishing = new DateOnly(2001, 10, 10), Pages=100},
            //    new Book { Id = 3, Name = "SQL", Publishing = new DateOnly(2012, 10, 10), Pages=100},
            //    new Book { Id = 4, Name = "EF Core", Publishing = new DateOnly(202, 10, 10), Pages=100}
            //    );

        }

      
    }
}
