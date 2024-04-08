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
