using Microsoft.EntityFrameworkCore;
using Lab2.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Buffers.Text;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(u => u.roles)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoletID);


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

            //modelBuilder.Entity<Orders>()
            //  .HasOne(o => o.PackageSize)     // An Order has one PackageSize
            //.WithMany()                     // A PackageSize can be used in many Orders
            //.HasForeignKey(o => o.SizeID); // Foreign key from Orders to PackageSizes

            // modelBuilder.Entity<Orders>()
            //   .HasOne(o => o.OrderStatus)     // An Order has one OrderStatus
            // .WithMany()                     // An OrderStatus can be used in many Orders
            //.HasForeignKey(o => o.StatusId); ntu daaqin ma von mos tu daqshin i fshin edhe gg

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
