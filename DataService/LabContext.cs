﻿using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using static Lab2.Models.Book;

namespace Lab2.DataService
{
    public class LabContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public LabContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("SqlServerConnection"));
                //optionsBuilder.UseSqlServer(connectionString);
            }
        }



        public DbSet<Rolet> roles { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<SubjectType> subject_type { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<PackageSizes> Packagesizes { get; set; }
        public DbSet<Subjects> subjects { get; set; }
        public DbSet<OrderStatus> orderstatus { get; set; }
        public DbSet<Routes> routes { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<UserSubjects> user_subjects { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<InvoiceOrders> invoiceorders { get; set; }
        public DbSet<Payments> payments { get; set; }
        public DbSet<PaymentMethods> paymentmethods { get; set; }
        //per lidhjen njo me shum
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Book> Books { get; set; }

        //shum me shum
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Book> Books { get; set; }
        //public DbSet<BookAuthor> BookAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            //shum me shum 
            //modelBuilder.Entity<BookAuthor>()
            //HasKey(ba => new { ba.BookId, ba.AuthorId });

            //modelBuilder.Entity<BookAuthor>()
            //.HasOne(ba => ba.Book)
            //.WithMany(b => b.BookAuthors)
            //.HasForeignKey(ba => ba.BookId);

            //modelBuilder.Entity<BookAuthor>()
            //.HasOne(ba => ba.Author)
            //.WithMany(a => a.BookAuthors)
            //.HasForeignKey(ba => ba.AuthorId);

            //njo me njo

            //modelBuilder.Entity<Book>()
            //.HasOne(b => b.Author)
            //.WithOne(a => a.Book)
            //.HasForeignKey<Book>(b => b.AuthorId);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.roles)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoletID);

            modelBuilder.Entity<Subjects>()
                .HasMany(s => s.orders)
                .WithOne(o => o.Subject)
                .HasForeignKey(o => o.SubjectID);

            modelBuilder.Entity<Subjects>()
                .HasOne(s => s.subjectType)
                .WithMany(st => st.subjects)
                .HasForeignKey(s => s.Subject_TypeID);


            modelBuilder.Entity<UserSubjects>()
                .HasKey(us => new { us.UserID, us.SubjectID });

            modelBuilder.Entity<UserSubjects>()
                .HasOne(us => us.user)
                .WithMany(u => u.userSubjects)
                .HasForeignKey(us => us.UserID);

            modelBuilder.Entity<UserSubjects>()
                .HasOne(us => us.subjects)
                .WithMany(s => s.userSubjects)
                .HasForeignKey(us => us.SubjectID);

            modelBuilder.Entity<Routes>()
                .HasOne(r => r.Order)
                .WithMany(o => o.Routes)
                .HasForeignKey(r => r.OrderID);

            modelBuilder.Entity<Routes>()
                .HasOne(r => r.Vehicle)
                .WithMany(v => v.Routes)
                .HasForeignKey(r => r.VehicleID);

            modelBuilder.Entity<Invoice>()
            .HasOne(inv => inv.subjects)
            .WithMany(sub => sub.invoices)
            .HasForeignKey(inv => inv.SubjectID);

            modelBuilder.Entity<InvoiceOrders>()
            .HasOne(io => io.Invoice)
            .WithMany(inv => inv.invoiceOrders)
            .HasForeignKey(io => io.InvoiceId);

            modelBuilder.Entity<InvoiceOrders>()
                .HasOne(io => io.Orders)
                .WithMany(ord => ord.InvoiceOrders)
                .HasForeignKey(io => io.OrderId);

            modelBuilder.Entity<Payments>()
            .HasOne(p => p.Invoice)
            .WithMany(inv => inv.payments)
            .HasForeignKey(p => p.InvoiceID);

            modelBuilder.Entity<Payments>()
                .HasOne(p => p.PaymentMethods)
                .WithMany(pm => pm.payments)
                .HasForeignKey(p => p.PaymentMethodsID);

        }
    }

    internal class _configuration
    {
        internal static Action<SqlServerDbContextOptionsBuilder>? GetConnectionString(string v)
        {
            throw new NotImplementedException();
        }
    }
}
