using AssessmentProject.Models;
using AssessmentProject.secrets;
using Microsoft.EntityFrameworkCore;
using System;

namespace AssessmentProject.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<PersonQualification> PersonQualifications { get; set; }
        public DbSet<PersonRole> PersonRoles { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Settings.ConnectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<PersonType>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<PersonRole>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<PersonQualification>()
                .HasKey(i => i.Id);
            modelBuilder.Entity<Department>()
                .HasKey(i => i.Id);

            modelBuilder.Entity<Person>()
                .HasOne(i => i.PersonType)
                .WithMany(i => i.Persons)
                .HasForeignKey(b => b.TypeId);

            modelBuilder.Entity<Person>()
                .HasOne(i => i.PersonRole)
                .WithMany(i => i.Persons)
                .HasForeignKey(b => b.RoleId);
            modelBuilder.Entity<Person>()
                .HasOne(i => i.PersonQualification)
                .WithMany(i => i.Persons)
                .HasForeignKey(b => b.QualificationId);
        }
    }
}
