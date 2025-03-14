﻿using Microsoft.EntityFrameworkCore;
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

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=Books;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            
        }

      
    }
}
